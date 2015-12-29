using System;
using System.Collections.Generic;
using System.Text;
using ThesisManage.DAL;
using ThesisManage.Model;

namespace ThesisManage.BLL
{
    public class UserRoleManage
    {
        public static List<UserRole> GetUserRole()
        {
           return  UserRoleService.GetUserRole();
        }
    }
}
