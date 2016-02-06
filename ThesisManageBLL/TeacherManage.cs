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
        /// <summary>
        /// 教师登陆验证
        /// </summary>
        /// <param name="teacherID">教师登录（工号）ID</param>
        /// <param name="pass">教师登录密码</param>
        /// <returns></returns>
        public string IsValide(string teacherID, string pass)
        {
            Teacher teacher = teacherService.GetTeacherByTeacherId(teacherID);
            string promptingMessage = null;
            if (!string.IsNullOrEmpty(teacher.TeacherName))
            {
                if (pass == teacher.TeacherPass)
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
        /// 根据教师登录（工号）ID获取教师信息
        /// </summary>
        /// <param name="teacherID">教师登录（工号）ID</param>
        /// <returns></returns>
        public Teacher GetTeacherByTeacherID(string teacherID)
        {
            return teacherService.GetTeacherByTeacherId(teacherID);
        }
        /// <summary>
        /// 修改教师信息
        /// </summary>
        /// <param name="teacherAddress">地址</param>
        /// <param name="teacherMail">邮箱</param>
        /// <param name="teacherPhone">电话</param>
        /// <returns></returns>
        public int Modifiy(string teacherAddress, string teacherMail, string teacherPhone)
        {
            return teacherService.Modifiy(teacherAddress, teacherMail, teacherPhone);
        }
        /// <summary>
        /// 修改教师密码
        /// </summary>
        /// <param name="newPass">新密码</param>
        /// <param name="teacherID">教师登录（工号）ID</param>
        /// <returns></returns>
        public int ModifiyPassword(string newPass, int teacherID)
        {
            return teacherService.ModifiyPassword(newPass, teacherID);
        }
        /// <summary>
        /// 添加教师
        /// </summary>
        /// <param name="teacherID">教师登录（工号）ID</param>
        /// <param name="teacherName">教师姓名</param>
        /// <param name="roleID">用户角色ID</param>
        /// <returns></returns>
        public int AddTeacher(String teacherID, string teacherName, int roleID)
        {
            return teacherService.AddTeacher(teacherID, teacherName, roleID);
        }
        /// <summary>
        /// 批量添加教师
        /// </summary>
        /// <param name="source">文件</param>
        /// <param name="roleID">用户角色ID</param>
        /// <returns></returns>
        public int AddTeachers(string source, int roleID)
        {
            return teacherService.AddTeachers(source, roleID);
        }
        /// <summary>
        /// 获取所有教师
        /// </summary>
        /// <returns></returns>
        public List<Teacher> GetTeacherList()
        {
            return teacherService.GetTeacherList();
        }
        /// <summary>
        /// 根据教师内码ID获取教师信息
        /// </summary>
        /// <param name="tEID">教师ID</param>
        /// <returns></returns>
        public Teacher GetTeacherById(int tEID)
        {
            return teacherService.GetTeacherByID(tEID);
        }
        /// <summary>
        /// 查询已上传标题的教师
        /// </summary>
        /// <returns></returns>
        public List<Teacher> GetTeacherHasUpLoadTitle()
        {
            return teacherService.GetTeacherHasUpLoadTitle();
        }
        /// <summary>
        /// 获取指定列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public System.Data.DataSet GetTeacher(string sql)
        {
            return teacherService.GetTeacher(sql);
        }
    }
}
