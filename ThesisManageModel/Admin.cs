using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisManage.Model
{
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
        /// 角色
        /// </summary>
        public UserRole UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }
        private string loginId = string.Empty;
        /// <summary>
        /// 登入密码
        /// </summary>
        public string LoginId
        {
            get { return loginId; }
            set { loginId = value; }
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
