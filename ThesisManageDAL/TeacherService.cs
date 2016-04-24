using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ThesisManage.Model;
using System.Data.OleDb;

namespace ThesisManage.DAL
{
    public class TeacherService
    {
        /// <summary>
        /// 根据教师内码ID获取教师信息
        /// </summary>
        /// <param name="tEID">教师内码ID</param>
        /// <returns>教师信息</returns>
        public Teacher GetTeacherByID(int tEID)
        {
            SqlDataReader reader = DBHelper.GetReader(string.Format("SELECT * FROM Teacher WHERE TEID={0}", tEID));
            Teacher teacher = new Teacher();
            int roleID = 0;
            if (reader.Read())
            {
                teacher.TEID = Convert.ToInt32(reader["TEID"]);
                teacher.TeacherID = reader["TeacherID"].ToString();
                teacher.TeacherName = reader["TeacherName"].ToString();
                teacher.TeacherAddress = reader["TeacherAddress"].ToString();
                teacher.TeacherMail = reader["TeacherMail"].ToString();
                teacher.TeacherPass = reader["TeacherPass"].ToString();
                teacher.TeacherPhone = reader["TeacherPhone"].ToString();
                teacher.TeacherState = Convert.ToInt32(reader["TeacherState"]);
                roleID = Convert.ToInt32(reader["TRID"]);
                reader.Close();
                teacher.UserRole = UserRoleService.GetUserRoleByUID(roleID);
            }
            reader.Close();
            return teacher;
        }
        /// <summary>
        /// 根据教师登录（工号）ID获取教师信息
        /// </summary>
        /// <param name="teacherID">教师登录（工号）ID</param>
        /// <returns>教师信息</returns>
        public Teacher GetTeacherByTeacherID(string teacherID)
        {
            SqlDataReader reader = DBHelper.GetReader(string.Format("SELECT * FROM Teacher WHERE TeacherID='{0}'", teacherID));
            Teacher teacher = new Teacher();
            int roleId = 0;
            if (reader.Read())
            {
                teacher.TEID = Convert.ToInt32(reader["TEID"]);
                teacher.TeacherID = reader["TeacherID"].ToString();
                teacher.TeacherName = reader["TeacherName"].ToString();
                teacher.TeacherAddress = reader["TeacherAddress"].ToString();
                teacher.TeacherMail = reader["TeacherMail"].ToString();
                teacher.TeacherPass = reader["TeacherPass"].ToString();
                teacher.TeacherPhone = reader["TeacherPhone"].ToString();
                teacher.TeacherState = Convert.ToInt32(reader["TeacherState"]);
                roleId = Convert.ToInt32(reader["TRID"]);
                reader.Close();
                teacher.UserRole = UserRoleService.GetUserRoleByUID(roleId);
            }
            reader.Close();
            return teacher;
        }
        /// <summary>
        /// 修改教师密码
        /// </summary>
        /// <param name="newPass">新密码</param>
        /// <param name="tEID">教师ID</param>
        /// <returns></returns>
        public int ModifiyPassword(string newPass, int tEID)
        {
            return DBHelper.ExecuteCommand(string.Format("UPDATE Teacher SET TeacherPass='{0}' WHERE TEID={1}", newPass, tEID));
        }
        /// <summary>
        /// 修改教师信息
        /// </summary>
        /// <param name="teacherAddress">地址</param>
        /// <param name="teacherMail">邮箱</param>
        /// <param name="teacherPhone">电话</param>
        /// <returns></returns>
        public int Modifiy(string teacherAddress, string teacherMail, string teacherPhone)
        {
            return DBHelper.ExecuteCommand(string.Format("UPDATE Teacher SET TeacherAddress='{0}',TeacherMail='{1}',TeacherPhone='{2}'", teacherAddress, teacherMail, teacherPhone));
        }
        /// <summary>
        /// 获取所有教师
        /// </summary>
        /// <returns></returns>
        public List<Teacher> GetTeacherList()
        {
            int roleID = 0;
            var list = new List<Teacher>();
            foreach (DataRow rows in DBHelper.GetDataSet(string.Format("SELECT * FROM Teacher")).Rows)
            {
                Teacher teacher = new Teacher();
                teacher.TEID = Convert.ToInt32(rows["TEID"]);
                teacher.TeacherID = rows["TeacherID"].ToString();
                teacher.TeacherName = rows["TeacherName"].ToString();
                teacher.TeacherAddress = rows["TeacherAddress"].ToString();
                teacher.TeacherMail = rows["TeacherMail"].ToString();
                teacher.TeacherPass = rows["TeacherPass"].ToString();
                teacher.TeacherPhone = rows["TeacherPhone"].ToString();
                teacher.TeacherState = Convert.ToInt32(rows["TeacherState"]);
                roleID = Convert.ToInt32(rows["TRID"]);
                teacher.UserRole = UserRoleService.GetUserRoleByUID(roleID);
                list.Add(teacher);
            }
            return list;
        }
        /// <summary>
        /// 添加教师
        /// </summary>
        /// <param name="teacherID">编号</param>
        /// <param name="teacherName">姓名</param>
        /// <param name="roleID">用户角色ID</param>
        /// <returns></returns>
        public int AddTeacher(String teacherID, string teacherName, int roleID)
        {
            return DBHelper.ExecuteCommand(string.Format("INSERT INTO Teacher (TeacherID,TeacherName,TRID,TeacherPass,TeacherState) VALUES ('{0}','{1}','{2}','222222','0') ", teacherID, teacherName, roleID));
        }
        /// <summary>
        /// 批量添加教师
        /// </summary>
        /// <param name="source">文件</param>
        /// <param name="roleID">用户角色ID</param>
        /// <returns></returns>
        public int AddTeachers(string source, int roleID)
        {
            int num = 0;
            int teacherState = 0;
            string pass = "222222";
            try
            {
                var dataSet = new DataSet();
                new OleDbDataAdapter("SELECT * FROM [Sheet1$]", new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties= 'Excel 8.0;Imex=2;HDR=Yes;'", source))).Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    string strSql = "";
                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        strSql += "INSERT INTO Teacher(TeacherID,TeacherName,TRID,TeacherState,TeacherPass) VALUES ('";
                        strSql += dataSet.Tables[0].Rows[i].ItemArray[0].ToString() + "','";
                        strSql += dataSet.Tables[0].Rows[i].ItemArray[1].ToString() + "','";
                        strSql += roleID + "','";
                        strSql += teacherState + "','";
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
        /// 查询已上传标题的教师
        /// </summary>
        /// <returns></returns>
        public List<Teacher> GetTeacherHasUpLoadTitle()
        {
            int roleId = 0;
            var list = new List<Teacher>();
            foreach (DataRow row in DBHelper.GetDataSet(string.Format("SELECT * FROM Teacher WHERE TEID IN (SELECT TeacherID FROM Title GROUP BY TeacherID)")).Rows)
            {
                Teacher teacher = new Teacher();
                teacher.TEID = Convert.ToInt32(row["TEID"]);
                teacher.TeacherID = row["TeacherID"].ToString();
                teacher.TeacherName = row["TeacherName"].ToString();
                teacher.TeacherAddress = row["TeacherAddress"].ToString();
                teacher.TeacherMail = row["TeacherMail"].ToString();
                teacher.TeacherPass = row["TeacherPass"].ToString();
                teacher.TeacherPhone = row["TeacherPhone"].ToString();
                teacher.TeacherState = Convert.ToInt32(row["TeacherState"]);
                roleId = Convert.ToInt32(row["TRID"]);
                teacher.UserRole = UserRoleService.GetUserRoleByUID(roleId);
                list.Add(teacher);
            }
            return list;
        }
        /// <summary>
        /// 获取指定列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetTeacher(string sql)
        {
            var dataSet = new DataSet();
            new SqlDataAdapter(sql, DBHelper.Connection).Fill(dataSet, "teacher");
            return dataSet;
        }
    }
}
