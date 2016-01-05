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
        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="studentID">学生学号</param>
        /// <returns></returns>
        public Student GetStudentByStudentID(string studentID)
        {
            return studentService.GetStudentByStudentID(studentID);
        }
        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="studentAddress">地址</param>
        /// <param name="studentPhone">电话</param>
        /// <param name="studentMail">邮箱</param>
        /// <param name="studentID">学生学号</param>
        /// <returns></returns>
        public int ModifiyStuByStudentID(string studentAddress, string studentPhone, string studentMail, string studentID)
        {
            return studentService.ModifiyStuByStudentID(studentAddress, studentPhone, studentMail, studentID);
        }
        /// <summary>
        /// 修改选题状态
        /// </summary>
        /// <param name="sudentState">选题状态</param>
        /// <param name="titleID">题目ID</param>
        /// <param name="studentID">学生学号</param>
        /// <returns></returns>
        public int ModifiyStuSate(int sudentState, int titleID, string studentID)
        {
            return studentService.ModifiyStuSate(sudentState, titleID, studentID);
        }
        /// <summary>
        /// 学生登陆验证
        /// </summary>
        /// <param name="studentID">学生学号</param>
        /// <param name="pass">密码</param>
        /// <returns></returns>
        public string StudentLogin(string studentID, string pass)
        {
            Student student = studentService.GetStudentByStudentID(studentID);
            string mes = null;
            if (!string.IsNullOrEmpty(student.StudentName))
            {
                if (pass == student.StudentPass)
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
        /// <summary>
        /// 修改学生密码
        /// </summary>
        /// <param name="newPass">新密码</param>
        /// <param name="studentID">学生编号</param>
        /// <returns></returns>
        public int ModifiyStuPass(string newPass, string studentID)
        {
            return studentService.ModifiyStuPass(newPass, studentID);
        }
        /// <summary>
        /// 增加学生
        /// </summary>
        /// <param name="studentID">学生学号</param>
        /// <param name="studentName">学生姓名</param>
        /// <param name="studentClass">学生班级</param>
        /// <param name="roleID">用户角色ID</param>
        /// <returns></returns>
        public int AddStudent(string studentID, string studentName, string studentClass, int roleID)
        {
            return studentService.AddStudent(studentID, studentName, studentClass, roleID);
        }
        /// <summary>
        /// 获取所有班级
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllClass()
        {
            return studentService.GetAllClass();
        }
        /// <summary>
        /// 获取指定列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetStudent(string sql)
        {
            return studentService.GetStudent(sql);
        }
        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="sID">学生ID</param>
        /// <returns></returns>
        public Student GetStudentBySID(int sID)
        {
            return studentService.GetStudentBySID(sID);
        }
        /// <summary>
        /// 获取选择同一个老师的所有学生
        /// </summary>
        /// <param name="teID">教师ID</param>
        /// <returns></returns>
        public List<Student> GetStudentWithOenTeacher(int teID)
        {
            return studentService.GetStudentWithOenTeacher(teID);
        }
        /// <summary>
        /// 获取上传标题的学生
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudentByUpLoadTitle()
        {
            return studentService.GetStudentByUpLoadTitle();
        }
        /// <summary>
        /// 批量添加学生
        /// </summary>
        /// <param name="source">文件</param>
        /// <param name="roleID">用户角色ID</param>
        /// <returns></returns>
        public int addStudents(string source, int roleID)
        {
            return studentService.addStudents(source, roleID);
        }
        /// <summary>
        /// 获取学生数量
        /// </summary>
        /// <returns></returns>
        public int GetStudentCount()
        {
            return studentService.GetStudentCount();
        }
        /// <summary>
        /// 获取已经被选的题目数量
        /// </summary>
        /// <returns></returns>
        public int GetHasChooseTitleNum()
        {
            return studentService.GetHasChooseTitleNum();
        }
        /// <summary>
        /// 更新题目状态
        /// </summary>
        /// <param name="sID">学生ID</param>
        /// <returns></returns>
        public int EscTitleByStudentId(int sID)
        {
            return studentService.EscTitleByStudentId(sID);
        }
    }
}
