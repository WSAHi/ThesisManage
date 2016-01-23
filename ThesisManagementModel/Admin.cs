using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManageModel
{
    /// <summary>
    /// 管理员实体类
    /// </summary>
    public class Admin
    {
        /// <summary>
        /// 管理员内码ID
        /// </summary>
        private int aID = 0;
        public int AID
        {
            get { return aID; }
            set { aID = value; }
        }
        /// <summary>
        /// 管理员登录ID
        /// </summary>
        private string loginID;
        public string LoginID
        {
            get { return loginID; }
            set { loginID = value; }
        }
        /// <summary>
        /// 管理员登陆密码
        /// </summary>
        private string loginPassword;
        public string LoginPassword
        {
            get { return loginPassword; }
            set { loginPassword = value; }
        }
        /// <summary>
        /// 用户类型
        /// </summary>
        private int userRole;
        public int UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }
    }
}
