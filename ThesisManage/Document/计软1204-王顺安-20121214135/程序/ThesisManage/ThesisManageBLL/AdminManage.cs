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
        /// 管理员登陆验证
        /// </summary>
        /// <param name="loginID">管理员登录（账号）ID</param>
        /// <param name="pass">管理员登录密码</param>
        /// <returns></returns>
        public string AdminSSO(string loginID, string pass)
        {
            Admin admin = adminService.GetAdminByID(loginID);
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
        public int ModifiyPassword(string newPass, string loginID)
        {
            return adminService.ModifiyPassword(newPass, loginID);
        }
        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <param name="loginID">登陆ID</param>
        /// <returns></returns>
        public Admin GetAdminByID(string loginID)
        {
            return adminService.GetAdminByID(loginID);
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="loginID">管理员登录（账号）ID</param>
        /// <param name="roleID">用户角色ID</param>
        /// <returns></returns>
        public int AddAdmin(string loginID, int roleID)
        {
            return adminService.AddAdmin(loginID, roleID);
        }
        /// <summary>
        /// 批量添加管理员
        /// </summary>
        /// <param name="source">文件</param>
        /// <param name="roleID">用户角色ID</param>
        /// <returns></returns>
        public int AddAdmins(String source, int roleID)
        {
            return adminService.AddAdmins(source, roleID);
        }
    }
}
