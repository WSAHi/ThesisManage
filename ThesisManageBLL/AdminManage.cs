using System;
using System.Collections.Generic;
using System.Text;
using ThesisManage.DAL;
using ThesisManage.Model;

namespace ThesisManage.BLL
{
    public class AdminManage
    {
        AdminService adminService = new AdminService();
        public int AddAdmin(string loginId, int roleId)
        {
            return adminService.AddAdmin(loginId, roleId);
        }
        public int AddAdmins(String source, int roleId)
        {
            return adminService.AddAdmins(source, roleId);
        }
        public string GetAdminById(string loginId,string password)
        {
            Admin admin=adminService.GetAdminById(loginId);
            string mes = null;
            if (!string.IsNullOrEmpty(admin.LoginId))
            {
                if (password ==admin.LoginPass)
                {
                    mes = "成功";
                }
                else
                {
                    mes = "密码错误！";
                }
            }
            else
            {
                mes = "该用户名不存在！";
            }
            return mes;
        }
        public int ModifiyPassWord(string newPassWord, string loginId)
        {
            return adminService.ModifiyPassWord(newPassWord, loginId);
        }
        public Admin GetAdminById(string loginId)
        {
            return adminService.GetAdminById(loginId);
        }
    }
}
