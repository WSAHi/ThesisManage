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
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int AddAdmin(string loginId, int roleId)
        {
            return adminService.AddAdmin(loginId, roleId);
        }
        /// <summary>
        /// 批量添加管理员
        /// </summary>
        /// <param name="source"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int AddAdmins(String source, int roleId)
        {
            return adminService.AddAdmins(source, roleId);
        }
        /// <summary>
        /// 管理员登陆验证
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string GetAdminById(string loginId, string password)
        {
            Admin admin = adminService.GetAdminById(loginId);
            string mes = null;
            if (!string.IsNullOrEmpty(admin.LoginId))
            {
                if (password == admin.LoginPass)
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
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="newPassWord"></param>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public int ModifiyPassWord(string newPassWord, string loginId)
        {
            return adminService.ModifiyPassWord(newPassWord, loginId);
        }
        /// <summary>
        /// 根据管理员ID获取信息
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public Admin GetAdminById(string loginId)
        {
            return adminService.GetAdminById(loginId);
        }
    }
}
