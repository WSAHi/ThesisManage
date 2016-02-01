using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisManage.Model
{
    /// <summary>
    /// 用户角色实体类
    /// </summary>
    [Serializable]
    public class UserRole
    {
        private int uID = 0;
        /// <summary>
        /// 用户角色内码ID
        /// </summary>
        public int UID
        {
            get { return uID; }
            set { uID = value; }
        }
        private string roleName = string.Empty;
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }

    }
}
