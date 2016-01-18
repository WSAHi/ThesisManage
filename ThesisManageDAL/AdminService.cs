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
        /// 获取管理员信息
        /// </summary>
        /// <param name="loginID">管理员账号</param>
        /// <returns>管理员信息</returns>
        public Admin GetAdminById(string loginID)
        {
            string sql = string.Format("select * from Admin where LoginID='{0}'", loginID);
            int roleID = 0;
            Admin admin = new Admin();
            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql);
                if (reader.Read())
                {
                    admin.AID = Convert.ToInt32(reader["AID"]);
                    admin.LoginID = reader["LoginID"].ToString();
                    admin.LoginPass = reader["LoginPassword"].ToString();
                    roleID = Convert.ToInt32(reader["ARID"]);
                    reader.Close();
                    admin.UserRole = UserRoleService.GetUserRoleByUid(roleID);
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
        /// 修改密码
        /// </summary>
        /// <param name="newPassword">新密码</param>
        /// <param name="loginID">登陆账号</param>
        /// <returns></returns>
        public int ModifiyPassWord(string newPassword, string loginID)
        {
            string sql = string.Format("update Admin set LoginPassword='{0}' where LoginID='{1}'", newPassword, loginID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="loginID">登陆账号</param>
        /// <param name="roleID">用户角色ID</param>
        /// <returns></returns>
        public int AddAdmin(string loginID, int roleID)
        {
            string sql = string.Format("insert into Admin (LoginID,ARID,LoginPassword) values('{0}','{1}','111111')", loginID, roleID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        /// <summary>
        /// 批量添加管理员
        /// </summary>
        /// <param name="source">文件</param>
        /// <param name="roleID">用户角色ID</param>
        /// <returns></returns>
        public int AddAdmins(String source, int roleID)
        {
            int num = 0;
            try
            {
                string strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties= 'Excel 8.0;Imex=2;HDR=Yes;'", source);
                OleDbConnection cnnxls = new OleDbConnection(strConn);
                OleDbDataAdapter myDa = new OleDbDataAdapter("select * from [Sheet1$]", cnnxls);
                DataSet ds = new DataSet();
                myDa.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string strSql = "";
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        strSql += "insert into Admin(LoginID,ARID) values ('";
                        strSql += ds.Tables[0].Rows[i].ItemArray[0].ToString() + "',";
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
    }
}
