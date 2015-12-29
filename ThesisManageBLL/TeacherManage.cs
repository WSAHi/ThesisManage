using System;
using System.Collections.Generic;
using System.Text;
using ThesisManage.DAL;
using ThesisManage.Model;

namespace ThesisManage.BLL
{
    public class TeacherManage
    {
        TeacherService teacherService = new TeacherService();
        public string IsValide(string teacherId,string pass)
        {
            Teacher teacher = teacherService.GetTeacherByTeacherId(teacherId);
            string mes = null;
            if (!string.IsNullOrEmpty(teacher.TeacherName))
            {
                if (pass == teacher.TeacherPass)
                {
                    mes = "成功";
                }
                else
                {
                    mes = "密码错误！";
                }
            }
            else
            {
                mes = "该用户名不存在！";
            }
            return mes;
        }
        public Teacher GetTeacherByTeacherId(string teacherId)
        {
            return teacherService.GetTeacherByTeacherId(teacherId);
        }
        public int Modifiy(string teacherAddress, string teacherMail, string teacherPhone)
        {
            return teacherService.Modifiy(teacherAddress, teacherMail, teacherPhone);
        }
        public int ModifiyPassWord(string pass, int TEID)
        {
            return teacherService.ModifiyPassWord(pass,TEID);
        }
        public int AddTeacher(String teacherID, string teacherName, int roleId)
        {
            return teacherService.AddTeacher(teacherID, teacherName, roleId);
        }
        public int AddTeacher(string source, int roleId)
        {
            return teacherService.AddTeacher(source, roleId);
        }
        public List<Teacher> GetTeacherList()
        {
            return teacherService.GetTeacherList();
        }
        public Teacher GetTeacherById(int tEID)
        {
            return teacherService.GetTeacherById(tEID);
        }
        public List<Teacher> GetTeacherHasUpLoadTitle()
        {
            return teacherService.GetTeacherHasUpLoadTitle();
        }
        public System.Data.DataSet GetTeacher(string sql)
        {
            return teacherService.GetTeacher(sql);
        }
    }
}
