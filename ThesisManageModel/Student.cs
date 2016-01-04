using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisManage.Model
{
    [Serializable]
    public class Student
    {
        private int sID = 0;
        /// <summary>
        /// 学生ID
        /// </summary>
        public int SID
        {
            get { return sID; }
            set { sID = value; }
        }
        private UserRole role;
        /// <summary>
        /// 角色
        /// </summary>
        public UserRole Role
        {
            get { return role; }
            set { role = value; }
        }
        private string studentName = string.Empty;
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }
        private string studentPass = string.Empty;
        /// <summary>
        /// 密码
        /// </summary>
        public string StudentPass
        {
            get { return studentPass; }
            set { studentPass = value; }
        }
        private string studentID = string.Empty;
        /// <summary>
        /// 学号
        /// </summary>
        public string StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }
        private string studentClass = string.Empty;
        /// <summary>
        /// 学生班级
        /// </summary>
        public string StudentClass
        {
            get { return studentClass; }
            set { studentClass = value; }
        }
        private string studentAddress = string.Empty;
        /// <summary>
        /// 地址
        /// </summary>
        public string StudentAddress
        {
            get { return studentAddress; }
            set { studentAddress = value; }
        }
        private string studentPhone = string.Empty;
        /// <summary>
        /// 电话
        /// </summary>
        public string StudentPhone
        {
            get { return studentPhone; }
            set { studentPhone = value; }
        }
        private string studentMail = string.Empty;
        /// <summary>
        /// 学生E-MAIL
        /// </summary>
        public string StudentMail
        {
            get { return studentMail; }
            set { studentMail = value; }
        }
        private int sudentState = 0;
        /// <summary>
        /// 是否选题
        /// </summary>
        public int SudentState
        {
            get { return sudentState; }
            set { sudentState = value; }
        }
        private Title title;
        /// <summary>
        /// 学生的选题
        /// </summary>
        public Title Title
        {
            get { return title; }
            set { title = value; }
        }

    }
}
