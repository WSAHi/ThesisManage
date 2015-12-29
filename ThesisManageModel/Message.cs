using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisManage.Model
{
    [Serializable]
    public class Message
    {
        private int mID = 0;
        /// <summary>
        /// 消息Id
        /// </summary>
        public int MID
        {
            get { return mID; }
            set { mID = value; }
        }
        private Teacher teacher;
        /// <summary>
        /// 老师
        /// </summary>
        public Teacher Teacher
        {
            get { return teacher; }
            set { teacher = value; }
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
        private string contents = string.Empty;
        /// <summary>
        /// 内容
        /// </summary>
        public string Contents
        {
            get { return contents; }
            set { contents = value; }
        }
        private string mPubDate = string.Empty;
        /// <summary>
        /// 时间
        /// </summary>
        public string MPubDate
        {
            get { return mPubDate; }
            set { mPubDate = value; }
        }
        private int state = 0;
        /// <summary>
        /// 是否被阅读
        /// </summary>
        public int State
        {
            get { return state; }
            set { state = value; }
        }
        private int sender;
        /// <summary>
        /// 发送人
        /// </summary>
        public int Sender
        {
            get { return sender; }
            set { sender = value; }
        }
        private string senderRole;
        /// <summary>
        /// 发送者的角色
        /// </summary>
        public string SenderRole
        {
            get { return senderRole; }
            set { senderRole = value; }
        }

    }
}
