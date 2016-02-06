using System;
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
        Student student = new Student();
        /// <summary>
        /// 根据学生内码ID获取学生信息
        /// </summary>
        /// <param name="sID">学生内码ID</param>
        /// <returns>学生信息</returns>
        public Student GetStudentBySID(int sID)
        {
            int userRoleID = 0;//用户角色ID
            int titleID = 0;//题目ID
            string sql = string.Format("SELECT * FROM Student WHERE SID ={0}", sID);
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
                userRoleID = Convert.ToInt32(reader["SRID"]);
                try
                {
                    titleID = Convert.ToInt32(reader["STitleID"]);
                }
                catch (Exception)
                {
                }
                reader.Close();
                student.Role = UserRoleService.GetUserRoleByUID(userRoleID);
                student.Title = titleServer.GetTiByTitleId(titleID);
            }
            reader.Close();
            return student;
        }
        /// <summary>
        /// 根据学生登录（学号）ID获取学生信息
        /// </summary>
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <returns>学生信息</returns>
        public Student GetStudentByStudentID(string studentID)
        {
            int userRoleID = 0;//用户角色ID
            int titleID = 0;//题目ID
            string sql = string.Format("SELECT * FROM Student WHERE StudentID ='{0}'", studentID);
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
                userRoleID = Convert.ToInt32(reader["SRID"]);
                try
                {
                    titleID = Convert.ToInt32(reader["STitleID"]);
                }
                catch (Exception)
                { }
                reader.Close();
                student.Role = UserRoleService.GetUserRoleByUID(userRoleID);
                student.Title = titleServer.GetTiByTitleId(titleID);
            }
            reader.Close();
            return student;
        }
        /// <summary>
        /// 修改学生密码
        /// </summary>
        /// <param name="newPass">新密码</param>
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <returns></returns>
        public int ModifiyStuPassword(string newPass, string studentID)
        {
            string sql = string.Format("UPDATE Student SET StudentPass='{0}' WHERE StudentID='{1}'", newPass, studentID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="studentAddress">地址</param>
        /// <param name="studentPhone">电话</param>
        /// <param name="studentMail">邮箱</param>
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <returns></returns>
        public int ModifiyStuByStudentID(string studentAddress, string studentPhone, string studentMail, string studentID)
        {
            string sql = string.Format("UPDATE Student SET StudentAddress='{0}',StudentPhone='{1}',StudentMail='{2}' WHERE StudentID='{3}'", studentAddress, studentPhone, studentMail, studentID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 修改学生选题状态
        /// </summary>
        /// <param name="sudentState">学生选题状态</param>
        /// <param name="titleID">题目ID</param>
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <returns></returns>
        public int ModifiyStuSate(int sudentState, int titleID, string studentID)
        {
            string sql = string.Format("UPDATE Student SET SudentState={0},STitleID={1} WHERE StudentID='{2}'", sudentState, titleID, studentID);
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
            string sql = string.Format("INSERT INTO Student (StudentID,StudentName,StudentClass,SRID,StudentPass,SudentState) VALUES ('{0}','{1}','{2}',{3},'333333','0')", studentID, studentName, studentClass, roleID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 批量添加学生
        /// </summary>
        /// <param name="source">文件</param>
        /// <param name="roleID">用户角色ID</param>
        /// <returns></returns>
        public int AddStudents(string source, int roleID)
        {
            int num = 0;
            int studentState = 0;
            string pass = "333333";
            try
            {
                string strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties= 'Excel 8.0;Imex=2;HDR=Yes;'", source);
                OleDbConnection cnnxls = new OleDbConnection(strConn);
                OleDbDataAdapter myDa = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", cnnxls);
                DataSet myDs = new DataSet();
                myDa.Fill(myDs);
                if (myDs.Tables[0].Rows.Count > 0)
                {
                    string strSql = "";
                    for (int i = 0; i < myDs.Tables[0].Rows.Count; i++)
                    {
                        strSql += "INSERT INTO Student(StudentID,StudentName,StudentClass,SRID,StudentPass) VALUES ('";
                        strSql += myDs.Tables[0].Rows[i].ItemArray[0].ToString() + "','";
                        strSql += myDs.Tables[0].Rows[i].ItemArray[1].ToString() + "','";
                        strSql += myDs.Tables[0].Rows[i].ItemArray[2].ToString() + "','";
                        strSql += roleID + "','";
                        strSql += studentState + "','";
                        strSql += pass + "')";
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
        /// 获取所有班级
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllClass()
        {
            string sql = string.Format("SELECT StudentClass FROM Student GROUP BY StudentClass");
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
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DBHelper.Connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "student");
            return dataset;
        }
        /// <summary>
        /// 获取选择同一个老师的所有学生
        /// </summary>
        /// <param name="teacherID">教师登录（工号）ID</param>
        /// <returns>选择同一个老师的学生的信息</returns>
        public List<Student> GetStudentWithTeacher(int teacherID)
        {
            List<Student> list = new List<Student>();
            int userRoleID = 0;//用户角色ID
            int titleID = 0;//题目ID
            string sql = string.Format("SELECT * FROM Student WHERE STitleID IN (SELECT TID FROM Title WHERE TeacherID={0})", teacherID);
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
                userRoleID = Convert.ToInt32(rows["SRID"]);
                try
                {
                    titleID = Convert.ToInt32(rows["STitleID"]);
                }
                catch (Exception)
                {
                }
                student.Role = UserRoleService.GetUserRoleByUID(userRoleID);
                student.Title = titleServer.GetTiByTitleId(titleID);
                list.Add(student);
            }
            return list;
        }
        /// <summary>
        /// 获取上传自定义题目的学生
        /// </summary>
        /// <returns>上传自定义题目的学生信息</returns>
        public List<Student> GetStudentByUpLoadTitle()
        {
            List<Student> list = new List<Student>();
            int userRoleID = 0;//用户角色ID
            int titleID = 0;//题目ID
            string sql = string.Format("SELECT * FROM Student WHERE SID IN (SELECT StudentID FROM Title GROUP BY StudentID)");
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
                userRoleID = Convert.ToInt32(rows["SRID"]);
                try
                {
                    titleID = Convert.ToInt32(rows["STitleID"]);
                }
                catch (Exception)
                {
                }
                student.Role = UserRoleService.GetUserRoleByUID(userRoleID);
                student.Title = titleServer.GetTiByTitleId(titleID);
                list.Add(student);
            }
            return list;
        }
        /// <summary>
        /// 获取学生总数
        /// </summary>
        /// <returns>学生总数</returns>
        public int GetStudentCount()
        {
            string sql = string.Format("SELECT num=COUNT(*) FROM Student");
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
        /// 获取已经选题的学生数量
        /// </summary>
        /// <returns>已经选题的学生数量</returns>
        public int GetHasChooseTitleNum()
        {
            string sql = string.Format("SELECT num=COUNT(*) FROM Student WHERE SudentState=1");
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
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <returns></returns>
        public int EscTitleByStudentID(int studentID)
        {
            string sql = string.Format("UPDATE Student SET STitleID=null,SudentState=0 WHERE SID={0}", studentID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
    }
}
