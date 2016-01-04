using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisManage.Model
{
    [Serializable]
    public class Thesis
    {
        private int thesisID = 0;
        /// <summary>
        /// 论文ID
        /// </summary>
        public int ThesisID
        {
            get { return thesisID; }
            set { thesisID = value; }
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
        private Title title;
        /// <summary>
        /// 标题
        /// </summary>
        public Title Title
        {
            get { return title; }
            set { title = value; }
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
        private byte[] content;
        /// <summary>
        /// 内容
        /// </summary>
        public byte[] Content
        {
            get { return content; }
            set { content = value; }
        }
    }
}
