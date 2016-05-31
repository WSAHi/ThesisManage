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
            string getUserRoleByUIDSQL = string.Format("SELECT * FROM UserRole WHERE UID={0}", uID);
            SqlDataReader userRoleByUIDSQLReader = DBHelper.GetReader(getUserRoleByUIDSQL);
            if (userRoleByUIDSQLReader.Read())
            {
                userRole.UID = Convert.ToInt32(userRoleByUIDSQLReader["UID"]);
                userRole.RoleName = (string)userRoleByUIDSQLReader["RoleName"];
            }
            userRoleByUIDSQLReader.Close();
            return userRole;
        }
        /// <summary>
        /// 获取所有的用户角色
        /// </summary>
        /// <returns></returns>
        public static List<UserRole> GetAllUserRole()
        {
            string getUserRoleSQL = string.Format("SELECT * FROM UserRole");
            List<UserRole> userRoleList = new List<UserRole>();
            DataTable userRoleTable = DBHelper.GetDataSet(getUserRoleSQL);
            foreach (DataRow userRoleRows in userRoleTable.Rows)
            {
                UserRole userRole = new UserRole();
                userRole.UID = Convert.ToInt32(userRoleRows["UID"]);
                userRole.RoleName = (string)userRoleRows["RoleName"];
                userRoleList.Add(userRole);
            }
            return userRoleList;
        }
    }
}
