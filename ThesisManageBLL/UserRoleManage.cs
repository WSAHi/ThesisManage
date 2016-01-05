using System;
using System.Collections.Generic;
using System.Text;
using ThesisManage.DAL;
using ThesisManage.Model;

namespace ThesisManage.BLL
{
    public class UserRoleManage
    {
        /// <summary>
        /// 获取所有的用户角色
        /// </summary>
        /// <returns></returns>
        public static List<UserRole> GetUserRole()
        {
            return UserRoleService.GetUserRole();
        }
    }
}
