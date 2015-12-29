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
        //根据管理员Id获取信息
        public Admin GetAdminById(string loginId)
        {
            string sql = string.Format("select * from Admin where LoginId='{0}'", loginId);
            int roleId = 0;
            Admin admin = new Admin();
            try
            {
                SqlDataReader reader = DBHelper.GetReader(sql);
                if (reader.Read())
                {
                    admin.AID = Convert.ToInt32(reader["AID"]);
                    admin.LoginId = reader["LoginId"].ToString();
                    admin.LoginPass = reader["LoginPass"].ToString();
                    roleId = Convert.ToInt32(reader["ARID"]);
                    reader.Close();
                    admin.UserRole = UserRoleService.GetUserRoleByUid(roleId);
                }
                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }

            return admin;
        }
        //修改密码
        public int ModifiyPassWord(string newPassWord, string loginId)
        {
            string sql = string.Format("update Admin set LoginPass='{0}' where LoginId='{1}'", newPassWord, loginId);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        //添加管理员
        public int AddAdmin(string loginId, int roleId)
        {
            string sql = string.Format("insert into Admin (loginId,arid) values('{0}',{1})", loginId, roleId);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        //添加多行数据
        public int AddAdmins(String source, int roleId)
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
                        strSql += "insert   into   Admin(loginId,arid)   values   ('";
                        strSql += myDs.Tables[0].Rows[i].ItemArray[0].ToString() + "',";
                        strSql += roleId + ")";
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
