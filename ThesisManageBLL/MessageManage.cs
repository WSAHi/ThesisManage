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
        public List<Message> GetAdminMesList(string choose)
        {
            return messageService.GetAdminMesList(choose);
        }
        public List<Message> GetStudentMesList(int studentId, string choose)
        {
            return messageService.GetStudentMesList(studentId, choose);
        }
        public List<Message> GetTeacherMesList(int teacherId, string choose)
        {
            return messageService.GetTeacherMesList(teacherId, choose);
        }
        public Message GetMesByMID(int MID)
        {
            return messageService.GetMesByMID(MID);
        }
        public int DeleteMessage(int MID)
        {
            return messageService.DeleteMessage(MID);
        }
        public int AddMessage(Message message)
        {
            return messageService.AddMessage(message);
        }
        public int ModifyMessage(int MID, int state)
        {
            return messageService.ModifyMessage(MID, state);
        }
    }
}
