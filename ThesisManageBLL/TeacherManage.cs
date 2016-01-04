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
        /// <param name="teacherId"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public string IsValide(string teacherId, string pass)
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
        /// <summary>
        /// 根据教师编号获取信息
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public Teacher GetTeacherByTeacherId(string teacherId)
        {
            return teacherService.GetTeacherByTeacherId(teacherId);
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="teacherAddress"></param>
        /// <param name="teacherMail"></param>
        /// <param name="teacherPhone"></param>
        /// <returns></returns>
        public int Modifiy(string teacherAddress, string teacherMail, string teacherPhone)
        {
            return teacherService.Modifiy(teacherAddress, teacherMail, teacherPhone);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="TEID"></param>
        /// <returns></returns>
        public int ModifiyPassWord(string pass, int TEID)
        {
            return teacherService.ModifiyPassWord(pass, TEID);
        }
        /// <summary>
        /// 添加教师
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="teacherName"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int AddTeacher(String teacherID, string teacherName, int roleId)
        {
            return teacherService.AddTeacher(teacherID, teacherName, roleId);
        }
        /// <summary>
        /// 批量添加教师
        /// </summary>
        /// <param name="source"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int AddTeacher(string source, int roleId)
        {
            return teacherService.AddTeacher(source, roleId);
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
        /// 根据TeacherID获取教师信息
        /// </summary>
        /// <param name="tEID"></param>
        /// <returns></returns>
        public Teacher GetTeacherById(int tEID)
        {
            return teacherService.GetTeacherById(tEID);
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
