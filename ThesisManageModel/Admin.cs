using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisManage.Model
{
    /// <summary>
    /// 管理员实体类
    /// </summary>
    [Serializable]
    public class Admin
    {
        private int aID = 0;
        /// <summary>
        /// 管理员ID
        /// </summary>
        public int AID
        {
            get { return aID; }
            set { aID = value; }
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
        private string loginID = string.Empty;
        /// <summary>
        /// 登入账号
        /// </summary>
        public string LoginID
        {
            get { return loginID; }
            set { loginID = value; }
        }
        private string loginPass = string.Empty;
        /// <summary>
        /// 登入密码
        /// </summary>
        public string LoginPass
        {
            get { return loginPass; }
            set { loginPass = value; }
        }
    }
}
