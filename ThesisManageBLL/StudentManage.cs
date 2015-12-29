using System;
using System.Collections.Generic;
using System.Text;
using ThesisManage.DAL;
using ThesisManage.Model;
using System.Data;

namespace ThesisManage.BLL
{

    public class StudentManage
    {
        StudentService studentService = new StudentService();
        public Student GetStudentByStudentID(string studentID)
        {
            return studentService.GetStudentByStudentID(studentID);
        }
        public int ModifiyStuByStudentID(string studentAddress, string studentPhone, string studentMail, string studentID)
        {
            return studentService.ModifiyStuByStudentID(studentAddress, studentPhone, studentMail, studentID);
        }
        public int ModifiyStuSate(int sudentState, int titleId, string studentID)
        {
            return studentService.ModifiyStuSate(sudentState, titleId, studentID);
        }
        public string StudentLogin(string studentID, string password)
        {
            Student student = studentService.GetStudentByStudentID(studentID);
            string mes = null;
            if (!string.IsNullOrEmpty(student.StudentName))
            {
                if (password == student.StudentPass)
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
        public int ModifiyStuPass(string newPass, string studentID)
        {
            return studentService.ModifiyStuPass(newPass, studentID);
        }
        public int AddStudent(string studentID, string studentName, string studentClass, int roleID)
        {
            return studentService.AddStudent(studentID, studentName, studentClass, roleID);
        }
        public List<Student> GetAllClass()
        {
            return studentService.GetAllClass();
        }
        public DataSet GetStudent(string sql)
        {
            return studentService.GetStudent(sql);
        }
        public Student GetStudentBySID(int sID)
        {
            return studentService.GetStudentBySID(sID);
        }
        public List<Student> GetStudentWithOenTeacher(int teid)
        {
            return studentService.GetStudentWithOenTeacher(teid);
        }
        public List<Student> GetStudentByUpLoadTitle()
        {
            return studentService.GetStudentByUpLoadTitle();
        }
        public int addStudents(string source, int roleId)
        {
            return studentService.addStudents(source, roleId);
        }
        public int GetStudentCount()
        {
            return studentService.GetStudentCount();
        }
        public int GetHasChooseTitleNum()
        {
            return studentService.GetHasChooseTitleNum();
        }
        public int EscTitleByStudentId(int sid)
        {
            return studentService.EscTitleByStudentId(sid);
        }
    }
}
