using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ThesisManage.Model;
using System.Data.OleDb;

namespace ThesisManage.DAL
{
    public class AdminService
    {
        /// <summary>
        /// ��ȡ����Ա��Ϣ
        /// </summary>
        /// <param name="loginID">����Ա��¼�˺ţ�ID��</param>
        /// <returns>����Ա��Ϣ</returns>
        public Admin GetAdminByID(string loginID)
        {
            int roleID = 0;
            Admin admin = new Admin();
            try
            {
                SqlDataReader reader = DBHelper.GetReader(string.Format("SELECT * FROM Admin WHERE LoginID='{0}'", loginID));
                if (reader.Read())
                {
                    admin.AID = Convert.ToInt32(reader["AID"]);
                    admin.LoginID = reader["LoginID"].ToString();
                    admin.LoginPass = reader["LoginPass"].ToString();
                    roleID = Convert.ToInt32(reader["ARID"]);
                    reader.Close();
                    admin.UserRole = UserRoleService.GetUserRoleByUID(roleID);
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return admin;
        }
        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="newPassword">������</param>
        /// <param name="loginID">����Ա��¼�˺ţ�ID��</param>
        /// <returns></returns>
        public int ModifiyPassword(string newPassword, string loginID)
        {
            return DBHelper.ExecuteCommand(string.Format("UPDATE Admin SET LoginPass='{0}' WHERE LoginID='{1}'", newPassword, loginID));
        }
        /// <summary>
        /// ��ӹ���Ա
        /// </summary>
        /// <param name="loginID">����Ա��½�˺ţ�ID��</param>
        /// <param name="roleID">�û���ɫID</param>
        /// <returns></returns>
        public int AddAdmin(string loginID, int roleID)
        {
            return DBHelper.ExecuteCommand(string.Format("INSERT INTO Admin (LoginID,ARID,LoginPass) VALUES ('{0}','{1}','111111')", loginID, roleID));
        }
        /// <summary>
        /// ������ӹ���Ա
        /// </summary>
        /// <param name="source">�ļ�</param>
        /// <param name="roleID">�û���ɫID</param>
        /// <returns></returns>
        public int AddAdmins(String source, int roleID)
        {
            int num = 0;
            try
            {
                new OleDbDataAdapter("select * from [Sheet1$]", new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties= 'Excel 8.0;Imex=2;HDR=Yes;'", source))).Fill(new DataSet());
                if (new DataSet().Tables[0].Rows.Count > 0)
                {
                    string strSql = "";
                    for (int i = 0; i < new DataSet().Tables[0].Rows.Count; i++)
                    {
                        strSql += "INSERT INTO Admin(LoginID,ARID,LoginPass) VALUES ('";
                        strSql += new DataSet().Tables[0].Rows[i].ItemArray[0].ToString() + "','";
                        strSql += roleID + "','";
                        strSql += "111111" + "')";
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
    }
}
