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
        /// <param name="loginID">登陆ID</param>
        /// <param name="roleID">用户角色ID</param>
        /// <returns></returns>
        public int AddAdmin(string loginID, int roleID)
        {
            return adminService.AddAdmin(loginID, roleID);
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
        /// <param name="loginID"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public string GetAdminById(string loginID, string pass)
        {
            Admin admin = adminService.GetAdminById(loginID);
            string promptingMessage = string.Empty;
            if (!string.IsNullOrEmpty(admin.LoginID))
            {
                if (pass == admin.LoginPass)
                {
                    promptingMessage = "成功";
                }
                else
                {
                    promptingMessage = "密码错误！";
                }
            }
            else
            {
                promptingMessage = "该用户名不存在！";
            }
            return promptingMessage;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="newPass">新密码</param>
        /// <param name="loginID">登陆ID</param>
        /// <returns></returns>
        public int ModifiyPassWord(string newPass, string loginID)
        {
            return adminService.ModifiyPassWord(newPass, loginID);
        }
        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <param name="loginID">登陆ID</param>
        /// <returns></returns>
        public Admin GetAdminById(string loginID)
        {
            return adminService.GetAdminById(loginID);
        }
    }
}
