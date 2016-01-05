using System;
using System.Collections.Generic;
using System.Text;
using ThesisManage.DAL;
using ThesisManage.Model;

namespace ThesisManage.BLL
{
    public class MessageManage
    {
        MessageService messageService = new MessageService();
        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <param name="choose"></param>
        /// <returns></returns>
        public List<Message> GetAdminMesList(string choose)
        {
            return messageService.GetAdminMesList(choose);
        }
        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="studentID">学生学号</param>
        /// <param name="choose"></param>
        /// <returns></returns>
        public List<Message> GetStudentMesList(int studentID, string choose)
        {
            return messageService.GetStudentMesList(studentID, choose);
        }
        /// <summary>
        /// 获取教师信息
        /// </summary>
        /// <param name="teacherID">教师编号</param>
        /// <param name="choose"></param>
        /// <returns></returns>
        public List<Message> GetTeacherMesList(int teacherID, string choose)
        {
            return messageService.GetTeacherMesList(teacherID, choose);
        }
        /// <summary>
        /// 根据MID获取Message
        /// </summary>
        /// <param name="MID">MID</param>
        /// <returns></returns>
        public Message GetMesByMID(int MID)
        {
            return messageService.GetMesByMID(MID);
        }
        /// <summary>
        /// 根据MID删除消息
        /// </summary>
        /// <param name="mID">MID</param>
        /// <returns></returns>
        public int DeleteMessage(int mID)
        {
            return messageService.DeleteMessage(mID);
        }
        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public int AddMessage(Message message)
        {
            return messageService.AddMessage(message);
        }
        /// <summary>
        /// 修改信息状态
        /// </summary>
        /// <param name="mID">MID</param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int ModifyMessage(int mID, int state)
        {
            return messageService.ModifyMessage(mID, state);
        }
    }
}
