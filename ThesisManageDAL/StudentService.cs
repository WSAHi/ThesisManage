﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ThesisManage.Model;
using System.Data.OleDb;

namespace ThesisManage.DAL
{
    public class StudentService
    {
        TitleService titleServer = new TitleService();
        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="studentID">学生学号</param>
        /// <returns></returns>
        public Student GetStudentByStudentID(string studentID)
        {
            int userRoleId = 0;//角色ID
            int titleId = 0;//题目ID

            Student student = new Student();
            string sql = string.Format("select * from Student where StudentID ='{0}'", studentID);
            SqlDataReader reader = DBHelper.GetReader(sql);
            if (reader.Read())
            {
                student.SID = Convert.ToInt32(reader["SID"]);
                student.StudentAddress = reader["StudentAddress"].ToString();
                student.StudentClass = reader["StudentClass"].ToString();
                student.StudentMail = reader["StudentMail"].ToString();
                student.StudentName = reader["StudentName"].ToString();
                student.SudentState = Convert.ToInt32(reader["SudentState"]);
                student.StudentID = reader["StudentID"].ToString();
                student.StudentPass = reader["StudentPass"].ToString();
                student.StudentPhone = reader["StudentPhone"].ToString();
                userRoleId = Convert.ToInt32(reader["SRID"]);
                try
                {
                    titleId = Convert.ToInt32(reader["STitleID"]);
                }
                catch (Exception)
                { }
                reader.Close();
                student.Role = UserRoleService.GetUserRoleByUid(userRoleId);
                student.Title = titleServer.GetTiByTitleId(titleId);
            }
            reader.Close();
            return student;
        }
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="sID">学生ID</param>
        /// <returns></returns>
        public Student GetStudentBySID(int sID)
        {
            int userRoleId = 0;//角色ID
            int titleId = 0;//题目ID
            TitleService titleServer = new TitleService();
            Student student = new Student();
            string sql = string.Format("select * from Student where SID ={0}", sID);
            SqlDataReader reader = DBHelper.GetReader(sql);
            if (reader.Read())
            {
                student.SID = Convert.ToInt32(reader["SID"]);
                student.StudentAddress = reader["StudentAddress"].ToString();
                student.StudentClass = reader["StudentClass"].ToString();
                student.StudentMail = reader["StudentMail"].ToString();
                student.StudentName = reader["StudentName"].ToString();
                student.SudentState = Convert.ToInt32(reader["SudentState"]);
                student.StudentID = reader["StudentID"].ToString();
                student.StudentPass = reader["StudentPass"].ToString();
                student.StudentPhone = reader["StudentPhone"].ToString();
                userRoleId = Convert.ToInt32(reader["SRID"]);
                try
                {
                    titleId = Convert.ToInt32(reader["STitleID"]);
                }
                catch (Exception)
                {
                }
                reader.Close();
                student.Role = UserRoleService.GetUserRoleByUid(userRoleId);
                student.Title = titleServer.GetTiByTitleId(titleId);
            }
            reader.Close();
            return student;
        }
        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="studentAddress">地址</param>
        /// <param name="studentPhone">电话</param>
        /// <param name="studentMail">邮箱</param>
        /// <param name="studentID">学生ID</param>
        /// <returns></returns>
        public int ModifiyStuByStudentID(string studentAddress, string studentPhone, string studentMail, string studentID)
        {
            string sql = string.Format("update Student set StudentAddress='{0}',StudentPhone='{1}',StudentMail='{2}' where StudentID='{3}'", studentAddress, studentPhone, studentMail, studentID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 修改选题状态
        /// </summary>
        /// <param name="sudentState">学生状态</param>
        /// <param name="titleId">题目ID</param>
        /// <param name="studentID">学生学号</param>
        /// <returns></returns>
        public int ModifiyStuSate(int sudentState, int titleId, string studentID)
        {
            string sql = string.Format("update Student set SudentState={0},STitleID={1} where StudentID='{2}'", sudentState, titleId, studentID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 修改学生密码
        /// </summary>
        /// <param name="newPass">新密码</param>
        /// <param name="studentID">学生学号</param>
        /// <returns></returns>
        public int ModifiyStuPass(string newPass, string studentID)
        {
            string sql = string.Format("update Student set StudentPass='{0}' where StudentID='{1}'"
               , newPass, studentID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 增加学生
        /// </summary>
        /// <param name="studentID">学生学号</param>
        /// <param name="studentName">学生姓名</param>
        /// <param name="studentClass">学生班级</param>
        /// <param name="roleID">用户角色ID</param>
        /// <returns></returns>
        public int AddStudent(string studentID, string studentName, string studentClass, int roleID)
        {
            string sql = string.Format("insert into student (studentID,studentName,studentClass,SRID,StudentPass) values('{0}','{1}','{2}',{3},'333333')", studentID, studentName, studentClass, roleID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 获取所有班级
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllClass()
        {
            string sql = string.Format("select StudentClass from Student group by StudentClass");
            List<Student> list = new List<Student>();
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow rows in table.Rows)
            {
                Student student = new Student();
                string className = rows["StudentClass"].ToString();
                student.StudentClass = className;
                list.Add(student);
            }
            return list;
        }
        /// <summary>
        /// 获取指定列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetStudent(string sql)
        {
            //string sql = string.Format("select 学号=Student.StudentID,姓名=StudentName,班级=StudentClass,指导老师=(select TeacherName from Teacher where TEID=(select TeacherId from title,student where STitleID=TID group by TeacherId)),标题名=(select TitleName from Title where TID=STitleID group by TitleName) from Student where 1=1");

            SqlDataAdapter adapter = new SqlDataAdapter(sql, DBHelper.Connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "student");
            return dataset;
        }
        /// <summary>
        /// 获取选择同一个老师的所有学生
        /// </summary>
        /// <param name="teacherID">教师编号</param>
        /// <returns></returns>
        public List<Student> GetStudentWithOenTeacher(int teacherID)
        {
            List<Student> list = new List<Student>();
            int userRoleId = 0;//角色ID
            int titleId = 0;//题目ID
            string sql = string.Format("select * from student where STitleID in (select TID from Title where TeacherId={0})", teacherID);
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow rows in table.Rows)
            {
                Student student = new Student();
                student.SID = Convert.ToInt32(rows["SID"]);
                student.StudentAddress = rows["StudentAddress"].ToString();
                student.StudentClass = rows["StudentClass"].ToString();
                student.StudentMail = rows["StudentMail"].ToString();
                student.StudentName = rows["StudentName"].ToString();
                student.SudentState = Convert.ToInt32(rows["SudentState"]);
                student.StudentID = rows["StudentID"].ToString();
                student.StudentPass = rows["StudentPass"].ToString();
                student.StudentPhone = rows["StudentPhone"].ToString();
                userRoleId = Convert.ToInt32(rows["SRID"]);
                try
                {
                    titleId = Convert.ToInt32(rows["STitleID"]);
                }
                catch (Exception)
                {
                }
                student.Role = UserRoleService.GetUserRoleByUid(userRoleId);
                student.Title = titleServer.GetTiByTitleId(titleId);
                list.Add(student);
            }
            return list;
        }
        /// <summary>
        /// 上传题目的学生
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudentByUpLoadTitle()
        {
            List<Student> list = new List<Student>();
            int userRoleId = 0;//角色ID
            int titleId = 0;//题目ID
            string sql = string.Format("select * from student where SID in (select StudentId from Title group by StudentId)");
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow rows in table.Rows)
            {
                Student student = new Student();
                student.SID = Convert.ToInt32(rows["SID"]);
                student.StudentAddress = rows["StudentAddress"].ToString();
                student.StudentClass = rows["StudentClass"].ToString();
                student.StudentMail = rows["StudentMail"].ToString();
                student.StudentName = rows["StudentName"].ToString();
                student.SudentState = Convert.ToInt32(rows["SudentState"]);
                student.StudentID = rows["StudentID"].ToString();
                student.StudentPass = rows["StudentPass"].ToString();
                student.StudentPhone = rows["StudentPhone"].ToString();
                userRoleId = Convert.ToInt32(rows["SRID"]);
                try
                {
                    titleId = Convert.ToInt32(rows["STitleID"]);
                }
                catch (Exception)
                {
                }
                student.Role = UserRoleService.GetUserRoleByUid(userRoleId);
                student.Title = titleServer.GetTiByTitleId(titleId);
                list.Add(student);
            }
            return list;
        }
        /// <summary>
        /// 批量添加学生
        /// </summary>
        /// <param name="source">文件</param>
        /// <param name="roleID">用户角色ID</param>
        /// <returns></returns>
        public int addStudents(string source, int roleID)
        {
            int num = 0;
            try
            {
                string strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties= 'Excel 8.0;Imex=2;HDR=Yes;'", source);
                OleDbConnection cnnxls = new OleDbConnection(strConn);
                OleDbDataAdapter myDa = new OleDbDataAdapter("select   *   from   [Sheet1$]", cnnxls);
                DataSet myDs = new DataSet();
                myDa.Fill(myDs);
                if (myDs.Tables[0].Rows.Count > 0)
                {
                    string strSql = "";
                    for (int i = 0; i < myDs.Tables[0].Rows.Count; i++)
                    {
                        strSql += "insert   into   Student(StudentID,StudentName,StudentClass,SRID)   values   ('";
                        strSql += myDs.Tables[0].Rows[i].ItemArray[0].ToString() + "','";
                        strSql += myDs.Tables[0].Rows[i].ItemArray[1].ToString() + "','";
                        strSql += myDs.Tables[0].Rows[i].ItemArray[2].ToString() + "',";
                        strSql += roleID + ")";
                    }
                    num = DBHelper.ExecuteCommand(strSql);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return num;
        }
        /// <summary>
        /// 学生数量
        /// </summary>
        /// <returns></returns>
        public int GetStudentCount()
        {
            string sql = string.Format("select num=count(*) from student");
            SqlDataReader reader = DBHelper.GetReader(sql);
            int num = 0;
            if (reader.Read())
            {
                num = Convert.ToInt32(reader["num"]);
            }
            reader.Close();
            return num;
        }
        /// <summary>
        /// 已经被选的题目数量
        /// </summary>
        /// <returns></returns>
        public int GetHasChooseTitleNum()
        {
            string sql = string.Format("select num=count(*) from student where SudentState=1");
            SqlDataReader reader = DBHelper.GetReader(sql);
            int num = 0;
            if (reader.Read())
            {
                num = Convert.ToInt32(reader["num"]);
            }
            reader.Close();
            return num;
        }
        /// <summary>
        /// 更新题目状态
        /// </summary>
        /// <param name="studentID">学生学号</param>
        /// <returns></returns>
        public int EscTitleByStudentId(int studentID)
        {
            string sql = string.Format("update student set STitleID=null,SudentState=0 where SID={0}", studentID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
    }

}
