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
        /// <param name="studentId"></param>
        /// <param name="choose"></param>
        /// <returns></returns>
        public List<Message> GetStudentMesList(int studentId, string choose)
        {
            return messageService.GetStudentMesList(studentId, choose);
        }
        /// <summary>
        /// 获取教师信息
        /// </summary>
        /// <param name="teacherId"></param>
        /// <param name="choose"></param>
        /// <returns></returns>
        public List<Message> GetTeacherMesList(int teacherId, string choose)
        {
            return messageService.GetTeacherMesList(teacherId, choose);
        }
        /// <summary>
        /// 根据MID获取Message
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public Message GetMesByMID(int MID)
        {
            return messageService.GetMesByMID(MID);
        }
        /// <summary>
        /// 根据MID删除消息
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public int DeleteMessage(int MID)
        {
            return messageService.DeleteMessage(MID);
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
        /// <param name="MID"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int ModifyMessage(int MID, int state)
        {
            return messageService.ModifyMessage(MID, state);
        }
    }
}
