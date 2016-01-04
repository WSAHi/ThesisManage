using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisManage.Model
{
    [Serializable]
    public class Title
    {
        private int tID = 0;
        /// <summary>
        /// 标题ID
        /// </summary>
        public int TID
        {
            get { return tID; }
            set { tID = value; }
        }
        private Teacher teacher;
        /// <summary>
        /// 标题对应的教员
        /// </summary>
        public Teacher Teacher
        {
            get { return teacher; }
            set { teacher = value; }
        }
        private string titleName = string.Empty;
        /// <summary>
        /// 标题名称
        /// </summary>
        public string TitleName
        {
            get { return titleName; }
            set { titleName = value; }
        }
        private int counts = 0;
        /// <summary>
        /// 可选数量
        /// </summary>
        public int Counts
        {
            get { return counts; }
            set { counts = value; }
        }
        private int state = 0;
        /// <summary>
        /// 是否通过审核
        /// </summary>
        public int State
        {
            get { return state; }
            set { state = value; }
        }
        private string description;
        /// <summary>
        ///描述
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int hasChooseNum;
        /// <summary>
        /// 已选数量
        /// </summary>
        public int HasChooseNum
        {
            get { return hasChooseNum; }
            set { hasChooseNum = value; }
        }
        private Student student;
        /// <summary>
        /// 学生
        /// </summary>
        public Student Student
        {
            get { return student; }
            set { student = value; }
        }


    }
}
