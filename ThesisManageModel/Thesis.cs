using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisManage.Model
{
    /// <summary>
    /// 论文实体类
    /// </summary>
    [Serializable]
    public class Thesis
    {
        private int thesisID = 0;
        /// <summary>
        /// 论文内码ID
        /// </summary>
        public int ThesisID
        {
            get { return thesisID; }
            set { thesisID = value; }
        }
        private byte[] content;
        /// <summary>
        /// 内容
        /// </summary>
        public byte[] Content
        {
            get { return content; }
            set { content = value; }
        }
        private string publishDate = string.Empty;
        /// <summary>
        /// 上传时间
        /// </summary>
        public string PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }
        private Title title;
        /// <summary>
        /// 论文所属题目信息
        /// </summary>
        public Title Title
        {
            get { return title; }
            set { title = value; }
        }
        private Student student;
        /// <summary>
        /// 论文所属学生的信息
        /// </summary>
        public Student Student
        {
            get { return student; }
            set { student = value; }
        }
    }
}
