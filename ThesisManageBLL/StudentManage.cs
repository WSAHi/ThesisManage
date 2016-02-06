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
        /// 学生登陆验证
        /// </summary>
        /// <param name="studentID">学生学号</param>
        /// <param name="pass">密码</param>
        /// <returns></returns>
        public string StudentLogin(string studentID, string pass)
        {
            Student student = studentService.GetStudentByStudentID(studentID);
            string promptingMessage = null;
            if (!string.IsNullOrEmpty(student.StudentName))
            {
                if (pass == student.StudentPass)
                {
                    promptingMessage = "成功";
                }
                else
                {
                    promptingMessage = "密码错误！";
                }
            }
            else
            {
                promptingMessage = "该用户名不存在！";
            }
            return promptingMessage;
        }
        /// <summary>
        /// 修改学生密码
        /// </summary>
        /// <param name="newPass">新密码</param>
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <returns></returns>
        public int ModifiyStuPassword(string newPass, string studentID)
        {
            return studentService.ModifiyStuPassword(newPass, studentID);
        }
        /// <summary>
        /// 根据学生登录（学号）ID获取学生信息
        /// </summary>
        /// <param name="studentID">学生登录（学号）ID</param>
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
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <returns></returns>
        public int ModifiyStuByStudentID(string studentAddress, string studentPhone, string studentMail, string studentID)
        {
            return studentService.ModifiyStuByStudentID(studentAddress, studentPhone, studentMail, studentID);
        }
        /// <summary>
        /// 修改学生选题状态
        /// </summary>
        /// <param name="sudentState">选题状态</param>
        /// <param name="titleID">题目ID</param>
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <returns></returns>
        public int ModifiyStuSate(int sudentState, int titleID, string studentID)
        {
            return studentService.ModifiyStuSate(sudentState, titleID, studentID);
        }
        /// <summary>
        /// 增加学生
        /// </summary>
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <param name="studentName">学生姓名</param>
        /// <param name="studentClass">学生班级</param>
        /// <param name="roleID">用户角色ID</param>
        /// <returns></returns>
        public int AddStudent(string studentID, string studentName, string studentClass, int roleID)
        {
            return studentService.AddStudent(studentID, studentName, studentClass, roleID);
        }
        /// <summary>
        /// 批量添加学生
        /// </summary>
        /// <param name="source">文件</param>
        /// <param name="roleID">用户角色ID</param>
        /// <returns></returns>
        public int AddStudents(string source, int roleID)
        {
            return studentService.AddStudents(source, roleID);
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
        /// 根据学生内码ID获取学生信息
        /// </summary>
        /// <param name="sID">学生内码ID</param>
        /// <returns></returns>
        public Student GetStudentBySID(int sID)
        {
            return studentService.GetStudentBySID(sID);
        }
        /// <summary>
        /// 获取选择同一个老师的所有学生
        /// </summary>
        /// <param name="teacherID">教师登录（工号）ID</param>
        /// <returns></returns>
        public List<Student> GetStudentWithTeacher(int teacherID)
        {
            return studentService.GetStudentWithTeacher(teacherID);
        }
        /// <summary>
        /// 获取上传自定义题目的学生
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudentByUpLoadTitle()
        {
            return studentService.GetStudentByUpLoadTitle();
        }
        /// <summary>
        /// 获取学生总数
        /// </summary>
        /// <returns></returns>
        public int GetStudentCount()
        {
            return studentService.GetStudentCount();
        }
        /// <summary>
        /// 获取已选题目的数量
        /// </summary>
        /// <returns></returns>
        public int GetHasChooseTitleNum()
        {
            return studentService.GetHasChooseTitleNum();
        }
        /// <summary>
        /// 更新题目状态
        /// </summary>
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <returns></returns>
        public int EscTitleByStudentId(int studentID)
        {
            return studentService.EscTitleByStudentID(studentID);
        }
    }
}
