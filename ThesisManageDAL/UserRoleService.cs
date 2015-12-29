using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ThesisManage.Model;

namespace ThesisManage.DAL
{
    public static class UserRoleService
    {
        //通UID获取UserRole
        public static UserRole GetUserRoleByUid(int uID)
        {
            UserRole userRole = new UserRole();
            string sql = string.Format("select * from UserRole where UID={0}", uID);
            SqlDataReader reader = DBHelper.GetReader(sql);
            if (reader.Read())
            {
                userRole.UID = Convert.ToInt32(reader["UID"]);
                userRole.RoleName = (string)reader["RoleName"];
            }
            reader.Close();
            return userRole;
        }
        //获取所有的UserRole
        public static List<UserRole> GetUserRole()
        {
            string sql = string.Format("select * from UserRole ");
            List<UserRole> list = new List<UserRole>();
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow rows in table.Rows)
            {
                UserRole userRole = new UserRole();
                userRole.UID = Convert.ToInt32(rows["UID"]);
                userRole.RoleName = (string)rows["RoleName"];
                list.Add(userRole);
            }
            return list;
        }
    }
}
