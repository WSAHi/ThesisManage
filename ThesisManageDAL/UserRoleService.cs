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
        /// <summary>
        /// 通UID获取用户角色信息
        /// </summary>
        /// <param name="uID">用户角色ID</param>
        /// <returns></returns>
        public static UserRole GetUserRoleByUID(int uID)
        {
            UserRole userRole = new UserRole();
            SqlDataReader sqlDataReader = DBHelper.GetReader(string.Format("SELECT * FROM UserRole WHERE UID={0}", uID));
            if (sqlDataReader.Read())
            {
                userRole.UID = Convert.ToInt32(sqlDataReader["UID"]);
                userRole.RoleName = (string)sqlDataReader["RoleName"];
            }
            sqlDataReader.Close();
            return userRole;
        }
        /// <summary>
        /// 获取所有的用户角色
        /// </summary>
        /// <returns></returns>
        public static List<UserRole> GetAllUserRole()
        {
            DataTable dataTable = DBHelper.GetDataSet(string.Format("SELECT * FROM UserRole"));
            foreach (DataRow userRoleRows in dataTable.Rows)
            {
                UserRole userRole = new UserRole();
                userRole.UID = Convert.ToInt32(userRoleRows["UID"]);
                userRole.RoleName = (string)userRoleRows["RoleName"];
                new List<UserRole>().Add(userRole);
            }
            return new List<UserRole>();
        }
    }
}
