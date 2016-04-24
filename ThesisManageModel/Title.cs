using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisManage.Model
{
    /// <summary>
    /// 题目实体类
    /// </summary>
    public class Title
    {
        private int titleID = 0;
        /// <summary>
        /// 题目内码ID
        /// </summary>
        public int TitleID
        {
            get { return titleID; }
            set { titleID = value; }
        }
        private string titleName = string.Empty;
        /// <summary>
        /// 题目名称
        /// </summary>
        public string TitleName
        {
            get { return titleName; }
            set { titleName = value; }
        }
        private string description;
        /// <summary>
        /// 题目描述
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int counts = 0;
        /// <summary>
        /// 题目可选数量
        /// </summary>
        public int Counts
        {
            get { return counts; }
            set { counts = value; }
        }
        private int hasChooseNum;
        /// <summary>
        /// 题目已选数量
        /// </summary>
        public int HasChooseNum
        {
            get { return hasChooseNum; }
            set { hasChooseNum = value; }
        }
        private int state = 0;
        /// <summary>
        /// 题目审核状态
        /// </summary>
        public int State
        {
            get { return state; }
            set { state = value; }
        }
        private Teacher teacher;
        /// <summary>
        /// 标题对应的教师信息（教师上传的自定义题目）
        /// </summary>
        public Teacher Teacher
        {
            get { return teacher; }
            set { teacher = value; }
        }
        private Student student;
        /// <summary>
        /// 标题对应的学生信息（学生上传的自定义题目）
        /// </summary>
        public Student Student
        {
            get { return student; }
            set { student = value; }
        }
    }
}
