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
        /// <param name="teacherID">教师编号</param>
        /// <param name="pass">密码</param>
        /// <returns></returns>
        public string IsValide(string teacherID, string pass)
        {
            Teacher teacher = teacherService.GetTeacherByTeacherId(teacherID);
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
        /// <summary>
        /// 获取教师信息
        /// </summary>
        /// <param name="teacherID">教师编号</param>
        /// <returns></returns>
        public Teacher GetTeacherByTeacherId(string teacherID)
        {
            return teacherService.GetTeacherByTeacherId(teacherID);
        }
        /// <summary>
        /// 修改信息
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
        /// 修改密码
        /// </summary>
        /// <param name="newPass">新密码</param>
        /// <param name="teID">教师ID</param>
        /// <returns></returns>
        public int ModifiyPassWord(string newPass, int teID)
        {
            return teacherService.ModifiyPassword(newPass, teID);
        }
        /// <summary>
        /// 添加教师
        /// </summary>
        /// <param name="teacherID">教师编号</param>
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
        /// 获取教师信息
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
        /// 获取教师表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public System.Data.DataSet GetTeacher(string sql)
        {
            return teacherService.GetTeacher(sql);
        }
    }
}
