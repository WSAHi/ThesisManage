using System;
using System.Collections.Generic;
using System.Text;

namespace ThesisManage.Model
{
    [Serializable]
    public class Time
    {
        private int timeID = 0;
        /// <summary>
        /// 时间ID
        /// </summary>
        public int TimeID
        {
            get { return timeID; }
            set { timeID = value; }
        }
        private string pubDate = string.Empty;
        /// <summary>
        /// 活动时间
        /// </summary>
        public string PubDate
        {
            get { return pubDate; }
            set { pubDate = value; }
        }

    }
}
