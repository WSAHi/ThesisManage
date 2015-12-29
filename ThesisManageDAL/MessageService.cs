using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ThesisManage.Model;

namespace ThesisManage.DAL
{
    public class MessageService
    {
        StudentService studentService = new StudentService();
        TeacherService teacherService = new TeacherService();
        //获取管理员的信息
        public List<Message> GetAdminMesList(string choose)
        {
            string sql = string.Format("select * from Messages where State=2 or State=3 order by State");
            if (!string.IsNullOrEmpty(choose))
            {
                sql = string.Format("select * from Messages where State=2 order by State");
            }
            List<Message> list = new List<Message>();
            int sId = 0;
            int tId = 0;
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow rows in table.Rows)
            {
                Message message = new Message();
                message.MID =Convert.ToInt32( rows["MID"]);
                message.Contents = rows["Contents"].ToString();
                message.MPubDate = rows["MPubDate"].ToString();
                message.State = Convert.ToInt32(rows["State"]);
                message.Sender = Convert.ToInt32(rows["SenderId"].ToString());
                message.SenderRole = rows["SenderRole"].ToString();
                try
                {
                    tId = Convert.ToInt32(rows["MTeacherId"]);
                }
                catch (Exception)
                {
                }
                try
                {
                    sId = Convert.ToInt32(rows["MStudentId"]);
                }
                catch (Exception)
                {
                }             
                message.Student = studentService.GetStudentBySID(sId);
                message.Teacher = teacherService.GetTeacherById(tId);
                list.Add(message);
            }
            return list;
        }
        //添加信息
        public int AddMessage(Message message)
        {
            string sql = null;
            if(message.Teacher!=null)
            {
                sql = string.Format("insert into Messages values({0},null,'{1}','{2}',{3},{4},'{5}')",
               message.Teacher.TEID,message.Contents,message.MPubDate,message.State,message.Sender,message.SenderRole);
            }
            else if (message.Student != null)
            {
                sql = string.Format("insert into Messages values(null,{0},'{1}','{2}',{3},{4},'{5}')",
              message.Student.SID, message.Contents, message.MPubDate, message.State, message.Sender, message.SenderRole);
            }
            else
            {
                sql = string.Format("insert into Messages values(null,null,'{0}','{1}',{2},{3},'{4}')",
            message.Contents, message.MPubDate, message.State, message.Sender, message.SenderRole);
            }
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        //获取学生的信息
        public List<Message> GetStudentMesList(int studentId, string choose)
        {
            string sql = string.Format("select * from Messages where MStudentId={0} or State=4 order by MPubDate desc", studentId);
            if (!string.IsNullOrEmpty(choose))
            {
                sql = string.Format("select * from Messages where (MStudentId={0} and  State=0) or State=4 order by MPubDate desc", studentId);
            }
            List<Message> list = new List<Message>();
            int sId = 0;
            int tId = 0;
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow rows in table.Rows)
            {
                Message message = new Message();
                message.MID = Convert.ToInt32(rows["MID"]);
                message.Contents = rows["Contents"].ToString();
                message.MPubDate = rows["MPubDate"].ToString();
                message.State = Convert.ToInt32(rows["State"]);
                message.Sender = Convert.ToInt32(rows["SenderId"].ToString());
                message.SenderRole = rows["SenderRole"].ToString();
                try
                {
                    tId = Convert.ToInt32(rows["MTeacherId"]);
                }
                catch (Exception)
                {
                }
                try
                {
                    sId = Convert.ToInt32(rows["MStudentId"]);
                }
                catch (Exception)
                {
                }
                message.Student = studentService.GetStudentBySID(sId);
                message.Teacher = teacherService.GetTeacherById(tId);
                list.Add(message);
            }
            return list;
        }
        //获取老师的信息
        public List<Message> GetTeacherMesList(int teacherId, string choose)
        {
            string sql = string.Format("select * from Messages where MTeacherId={0}  or State=4 order by MPubDate desc", teacherId);
            if (!string.IsNullOrEmpty(choose))
            {
                sql = string.Format("select * from Messages where (MTeacherId={0} and  State=0) or State=4 order by MPubDate desc", teacherId);
            }
            List<Message> list = new List<Message>();
            int sId = 0;
            int tId = 0;
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow rows in table.Rows)
            {
                Message message = new Message();
                message.MID = Convert.ToInt32(rows["MID"]);
                message.Contents = rows["Contents"].ToString();
                message.MPubDate = rows["MPubDate"].ToString();
                message.State = Convert.ToInt32(rows["State"]);
                message.Sender = Convert.ToInt32(rows["SenderId"].ToString());
                message.SenderRole = rows["SenderRole"].ToString();
                try
                {
                    tId = Convert.ToInt32(rows["MTeacherId"]);
                }
                catch (Exception)
                {
                }
                try
                {
                    sId = Convert.ToInt32(rows["MStudentId"]);
                }
                catch (Exception)
                {
                }
                message.Student = studentService.GetStudentBySID(sId);
                message.Teacher = teacherService.GetTeacherById(tId);
                list.Add(message);
            }
            return list;
        }
        //根据MID获取message
        public Message GetMesByMID(int MID)
        {
            string sql = string.Format("select * from Messages where MID={0}", MID);
            Message message = new Message();
            int sId = 0;
            int tId = 0;
            DataTable table = DBHelper.GetDataSet(sql);
            foreach (DataRow rows in table.Rows)
            {
                
                message.MID = Convert.ToInt32(rows["MID"]);
                message.Contents = rows["Contents"].ToString();
                message.MPubDate = rows["MPubDate"].ToString();
                message.State = Convert.ToInt32(rows["State"]);
                message.Sender = Convert.ToInt32(rows["SenderId"].ToString());
                message.SenderRole = rows["SenderRole"].ToString();
                try
                {
                    tId = Convert.ToInt32(rows["MTeacherId"]);
                }
                catch (Exception)
                {
                }
                try
                {
                    sId = Convert.ToInt32(rows["MStudentId"]);
                }
                catch (Exception)
                {
                }
                message.Student = studentService.GetStudentBySID(sId);
                message.Teacher = teacherService.GetTeacherById(tId);
            }
            return message;
        }
        //删除消息
        public int DeleteMessage(int MID)
        {
            string sql = string.Format("delete Messages where MID={0}", MID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
        //修改信息状态
        public int ModifyMessage(int MID,int state)
        {
            string sql = string.Format("update Messages set state={0} where MID={1}", state, MID);
            int num = DBHelper.ExecuteCommand(sql);
            return num;
        }
    }
}
