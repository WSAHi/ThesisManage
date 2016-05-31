using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisManage.Model
{
    /// <summary>
    /// 管理员实体类
    /// </summary>
    public class Admin
    {
        private int aID = 0;
        /// <summary>
        /// 管理员内码ID
        /// </summary>
        public int AID
        {
            get { return aID; }
            set { aID = value; }
        }
        private string loginID = string.Empty;
        /// <summary>
        /// 管理员登录账号（ID）
        /// </summary>
        public string LoginID
        {
            get { return loginID; }
            set { loginID = value; }
        }
        private string loginPass = string.Empty;
        /// <summary>
        /// 管理员登录密码
        /// </summary>
        public string LoginPass
        {
            get { return loginPass; }
            set { loginPass = value; }
        }
        private UserRole userRole;
        /// <summary>
        /// 用户角色
        /// </summary>
        public UserRole UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }
    }
}
