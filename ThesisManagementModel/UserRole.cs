using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagementModel
{
    /// <summary>
    /// 用户角色实体类
    /// </summary>
    class UserRole
    {
        /// <summary>
        /// 用户类型内码ID
        /// </summary>
        private int uID = 0;
        public int UID
        {
            get { return uID; }
            set { uID = value; }
        }
        /// <summary>
        /// 用户类型名称
        /// </summary>
        private string userRoleName;
        public string UserRoleName
        {
            get { return userRoleName; }
            set { userRoleName = value; }
        }
    }
}
