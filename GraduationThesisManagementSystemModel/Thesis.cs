using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisManagementModel
{
    /// <summary>
    /// 论文实体类
    /// </summary>
    class Thesis
    {
        /// <summary>
        /// 论文内码ID
        /// </summary>
        private int thesisID;
        public int ThesisID
        {
            get { return thesisID; }
            set { thesisID = value; }
        }
        /// <summary>
        /// 上传时间
        /// </summary>
        private DateTime publishDate;
        public DateTime PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }
        /// <summary>
        /// 论文内容
        /// </summary>
        private byte[] content;
        public byte[] Content
        {
            get { return content; }
            set { content = value; }
        }
        /// <summary>
        /// 选择的论文题目的信息
        /// </summary>
        private Title title;
        public Title Title
        {
            get { return title; }
            set { title = value; }
        }
        /// <summary>
        /// 论文所属学生的信息
        /// </summary>
        private Student student;
        public Student Student
        {
            get { return student; }
            set { student = value; }
        }
    }
}
