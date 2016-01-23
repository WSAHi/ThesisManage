using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagementModel
{
    /// <summary>
    /// 学生实体类
    /// </summary>
    class Student
    {
        /// <summary>
        /// 学生内码ID
        /// </summary>
        private int sID = 0;
        public int SID
        {
            get { return sID; }
            set { sID = value; }
        }
        /// <summary>
        /// 学生登录（学号）ID
        /// </summary>
        private string studentID;
        public string StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }
        /// <summary>
        /// 学生登录密码
        /// </summary>
        private string studentPassword;
        public string StudentPassword
        {
            get { return studentPassword; }
            set { studentPassword = value; }
        }
        /// <summary>
        /// 学生姓名
        /// </summary>
        private string studentName;
        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }
        /// <summary>
        /// 学生班级
        /// </summary>
        private string studentClass;
        public string StudentClass
        {
            get { return studentClass; }
            set { studentClass = value; }
        }
        /// <summary>
        /// 学生电话
        /// </summary>
        private string studentPhone;
        public string StudentPhone
        {
            get { return studentPhone; }
            set { studentPhone = value; }
        }
        /// <summary>
        /// 学生邮箱
        /// </summary>
        private string studentEMail;
        public string StudentEMail
        {
            get { return studentEMail; }
            set { studentEMail = value; }
        }
        /// <summary>
        /// 学生地址
        /// </summary>
        private string studentAddress;
        public string StudentAddress
        {
            get { return studentAddress; }
            set { studentAddress = value; }
        }
        /// <summary>
        /// 学生选题状态
        /// </summary>
        private int studentState;
        public int StudentState
        {
            get { return studentState; }
            set { studentState = value; }
        }
    }
}
