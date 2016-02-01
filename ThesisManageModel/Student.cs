using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisManage.Model
{
    /// <summary>
    /// 学生实体类
    /// </summary>
    [Serializable]
    public class Student
    {
        private int sID = 0;
        /// <summary>
        /// 学生内码ID
        /// </summary>
        public int SID
        {
            get { return sID; }
            set { sID = value; }
        }
        private string studentID = string.Empty;
        /// <summary>
        /// 学生登陆(学号)ID
        /// </summary>
        public string StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }
        private string studentPass = string.Empty;
        /// <summary>
        /// 学生登录密码
        /// </summary>
        public string StudentPass
        {
            get { return studentPass; }
            set { studentPass = value; }
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
        private string studentClass = string.Empty;
        /// <summary>
        /// 学生班级
        /// </summary>
        public string StudentClass
        {
            get { return studentClass; }
            set { studentClass = value; }
        }
        private string studentPhone = string.Empty;
        /// <summary>
        /// 学生电话
        /// </summary>
        public string StudentPhone
        {
            get { return studentPhone; }
            set { studentPhone = value; }
        }
        private string studentMail = string.Empty;
        /// <summary>
        /// 学生邮箱
        /// </summary>
        public string StudentMail
        {
            get { return studentMail; }
            set { studentMail = value; }
        }
        private string studentAddress = string.Empty;
        /// <summary>
        /// 学生地址
        /// </summary>
        public string StudentAddress
        {
            get { return studentAddress; }
            set { studentAddress = value; }
        }
        private int sudentState = 0;
        /// <summary>
        /// 学生选题状态
        /// </summary>
        public int SudentState
        {
            get { return sudentState; }
            set { sudentState = value; }
        }
        private Title title;
        /// <summary>
        /// 选题信息
        /// </summary>
        public Title Title
        {
            get { return title; }
            set { title = value; }
        }
        private UserRole userRole;
        /// <summary>
        /// 用户角色
        /// </summary>
        public UserRole Role
        {
            get { return userRole; }
            set { userRole = value; }
        }
    }
}
