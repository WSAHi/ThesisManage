﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisManage.Model
{
    /// <summary>
    /// 教师实体类
    /// </summary>
    public class Teacher
    {
        private int tEID = 0;
        /// <summary>
        /// 教师内码ID
        /// </summary>
        public int TEID
        {
            get { return tEID; }
            set { tEID = value; }
        }
        private string teacherID = string.Empty;
        /// <summary>
        /// 教师登录（工号）ID
        /// </summary>
        public string TeacherID
        {
            get { return teacherID; }
            set { teacherID = value; }
        }
        private string teacherPass = string.Empty;
        /// <summary>
        /// 教师登录密码
        /// </summary>
        public string TeacherPass
        {
            get { return teacherPass; }
            set { teacherPass = value; }
        }
        private string teacherName = string.Empty;
        /// <summary>
        /// 教师姓名
        /// </summary>
        public string TeacherName
        {
            get { return teacherName; }
            set { teacherName = value; }
        }
        private string teacherPhone = string.Empty;
        /// <summary>
        /// 教师电话
        /// </summary>
        public string TeacherPhone
        {
            get { return teacherPhone; }
            set { teacherPhone = value; }
        }
        private string teacherMail = string.Empty;
        /// <summary>
        /// 教师邮箱
        /// </summary>
        public string TeacherMail
        {
            get { return teacherMail; }
            set { teacherMail = value; }
        }
        private string teacherAddress = string.Empty;
        /// <summary>
        /// 教师地址
        /// </summary>
        public string TeacherAddress
        {
            get { return teacherAddress; }
            set { teacherAddress = value; }
        }
        private int teacherState = 0;
        /// <summary>
        /// 教师的选题是否为选满状态
        /// </summary>
        public int TeacherState
        {
            get { return teacherState; }
            set { teacherState = value; }
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
