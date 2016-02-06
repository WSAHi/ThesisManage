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
        /// ���ݽ�ʦ����ID��ȡ��ʦ��Ϣ
        /// </summary>
        /// <param name="tEID">��ʦ����ID</param>
        /// <returns>��ʦ��Ϣ</returns>
        public Teacher GetTeacherByID(int tEID)
        {
            string sql = string.Format("SELECT * FROM Teacher WHERE TEID={0}", tEID);
            SqlDataReader reader = DBHelper.GetReader(sql);
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
                teacher.UserRole = UserRoleService.GetUserRoleByUid(roleID);
            }
            reader.Close();
            return teacher;
        }
        /// <summary>
        /// ���ݽ�ʦ��¼�����ţ�ID��ȡ��ʦ��Ϣ
        /// </summary>
        /// <param name="teacherID">��ʦ��¼�����ţ�ID</param>
        /// <returns>��ʦ��Ϣ</returns>
        public Teacher GetTeacherByTeacherId(string teacherID)
        {
            string sql = string.Format("SELECT * FROM Teacher WHERE TeacherID='{0}'", teacherID);
            SqlDataReader reader = DBHelper.GetReader(sql);
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
                teacher.UserRole = UserRoleService.GetUserRoleByUid(roleId);
            }
            reader.Close();
            return teacher;
        }
        /// <summary>
        /// �޸Ľ�ʦ����
        /// </summary>
        /// <param name="newPass">������</param>
        /// <param name="tEID">��ʦID</param>
        /// <returns></returns>
        public int ModifiyPassword(string newPass, int tEID)
        {
            string sql = string.Format("UPDATE Teacher SET TeacherPass='{0}' WHERE TEID={1}", newPass, tEID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// �޸Ľ�ʦ��Ϣ
        /// </summary>
        /// <param name="teacherAddress">��ַ</param>
        /// <param name="teacherMail">����</param>
        /// <param name="teacherPhone">�绰</param>
        /// <returns></returns>
        public int Modifiy(string teacherAddress, string teacherMail, string teacherPhone)
        {
            string sql = string.Format("UPDATE Teacher SET TeacherAddress='{0}',TeacherMail='{1}',TeacherPhone='{2}'", teacherAddress, teacherMail, teacherPhone);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// ��ȡ���н�ʦ
        /// </summary>
        /// <returns></returns>
        public List<Teacher> GetTeacherList()
        {
            List<Teacher> list = new List<Teacher>();
            string sql = string.Format("SELECT * FROM Teacher");
            DataTable table = DBHelper.GetDataSet(sql);
            int roleID = 0;
            foreach (DataRow rows in table.Rows)
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
                teacher.UserRole = UserRoleService.GetUserRoleByUid(roleID);
                list.Add(teacher);
            }
            return list;
        }
        /// <summary>
        /// ��ӽ�ʦ
        /// </summary>
        /// <param name="teacherID">���</param>
        /// <param name="teacherName">����</param>
        /// <param name="roleID">�û���ɫID</param>
        /// <returns></returns>
        public int AddTeacher(String teacherID, string teacherName, int roleID)
        {
            string sql = string.Format("INSERT INTO Teacher (TeacherID,TeacherName,TRID,TeacherPass,TeacherState) VALUES ('{0}','{1}','{2}','222222','0') ", teacherID, teacherName, roleID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// ������ӽ�ʦ
        /// </summary>
        /// <param name="source">�ļ�</param>
        /// <param name="roleID">�û���ɫID</param>
        /// <returns></returns>
        public int AddTeachers(string source, int roleID)
        {
            int num = 0;
            int teacherState = 0;
            string pass = "222222";
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
                        strSql += "INSERT INTO Teacher(TeacherID,TeacherName,TRID,TeacherState,TeacherPass) VALUES ('";
                        strSql += myDs.Tables[0].Rows[i].ItemArray[0].ToString() + "','";
                        strSql += myDs.Tables[0].Rows[i].ItemArray[1].ToString() + "','";
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
        /// ��ѯ���ϴ�����Ľ�ʦ
        /// </summary>
        /// <returns></returns>
        public List<Teacher> GetTeacherHasUpLoadTitle()
        {
            string sql = string.Format("SELECT * FROM Teacher WHERE TEID IN (SELECT TeacherID FROM Title GROUP BY TeacherID)");
            DataTable table = DBHelper.GetDataSet(sql);
            List<Teacher> list = new List<Teacher>();
            int roleId = 0;
            foreach (DataRow row in table.Rows)
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
                teacher.UserRole = UserRoleService.GetUserRoleByUid(roleId);
                list.Add(teacher);
            }
            return list;
        }
        /// <summary>
        /// ��ȡָ����
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetTeacher(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DBHelper.Connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "teacher");
            return dataset;
        }
    }
}
