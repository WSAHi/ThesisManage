using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManageModel
{
    /// <summary>
    /// 教师实体类
    /// </summary>
    class Teacher
    {
        /// <summary>
        /// 教师内码ID
        /// </summary>
        private int tID = 0;
        public int TID
        {
            get { return tID; }
            set { tID = value; }
        }
        /// <summary>
        /// 教师登录（编号）ID
        /// </summary>
        private string teacherID;
        public string TeacherID
        {
            get { return teacherID; }
            set { teacherID = value; }
        }
        /// <summary>
        /// 教师登录密码
        /// </summary>
        private string teacherPassword;
        public string TeacherPassword
        {
            get { return teacherPassword; }
            set { teacherPassword = value; }
        }
        /// <summary>
        /// 教师姓名
        /// </summary>
        private string teacherName;
        public string TeacherName
        {
            get { return teacherName; }
            set { teacherName = value; }
        }
        /// <summary>
        /// 教师电话
        /// </summary>
        private string teacherPhone;
        public string TeacherPhone
        {
            get { return teacherPhone; }
            set { teacherPhone = value; }
        }
        /// <summary>
        /// 教师邮箱
        /// </summary>
        private string teacherEMail;
        public string TeacherEMail
        {
            get { return teacherEMail; }
            set { teacherEMail = value; }
        }
        /// <summary>
        /// 教师地址
        /// </summary>
        private string teacherAddress;
        public string TeacherAddress
        {
            get { return teacherAddress; }
            set { teacherAddress = value; }
        }
        /// <summary>
        /// 教师的选题是否为选满状态
        /// </summary>
        private int teacherState;
        public int TeacherState
        {
            get { return teacherState; }
            set { teacherState = value; }
        }
        /// <summary>
        /// 用户角色
        /// </summary>
        private int userRole;
        public int UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }
    }
}
