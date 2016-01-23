using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManageModel;

namespace ThesisManagementModel
{
    /// <summary>
    /// 论文题目实体类
    /// </summary>
    class Title
    {
        /// <summary>
        /// 题目内码ID
        /// </summary>
        private int tID;
        public int TID
        {
            get { return tID; }
            set { tID = value; }
        }
        /// <summary>
        /// 题目名称
        /// </summary>
        private string titleName;
        public string TitleName
        {
            get { return titleName; }
            set { titleName = value; }
        }
        /// <summary>
        /// 题目描述
        /// </summary>
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        /// <summary>
        /// 题目可选数量
        /// </summary>
        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        /// <summary>
        /// 题目已被选数量
        /// </summary>
        private int hasChooseNum;
        public int HasChooseNum
        {
            get { return hasChooseNum; }
            set { hasChooseNum = value; }
        }
        /// <summary>
        /// 题目状态（审核通过）
        /// </summary>
        private int titleState;
        public int TitleState
        {
            get { return titleState; }
            set { titleState = value; }
        }
        /// <summary>
        /// 学生信息（学生上传的自定义题目）
        /// </summary>
        private Student student;
        public Student Student
        {
            get { return student; }
            set { student = value; }
        }
        /// <summary>
        /// 教师信息（教师上传题目）
        /// </summary>
        private Teacher teacher;
        public Teacher Teacher
        {
            get { return teacher; }
            set { teacher = value; }
        }
    }
}
