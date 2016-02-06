using System;
using System.Collections.Generic;
using System.Text;
using ThesisManage.DAL;
using ThesisManage.Model;

namespace ThesisManage.BLL
{
    public class ThesisManage
    {
        ThesisService thesisService = new ThesisService();
        /// <summary>
        /// 插入论文相关信息
        /// </summary>
        /// <param name="thesis">论文信息</param>
        /// <returns></returns>
        public int InsertThesis(Thesis thesis)
        {
            return thesisService.InsertThesis(thesis);
        }
        /// <summary>
        /// 根据学生登录（学号）ID获取论文内容
        /// </summary>
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <returns></returns>
        public int GetCountsByStuID(int studentID)
        {
            return thesisService.GetCountsByStuID(studentID);
        }
        /// <summary>
        /// 根据学生登录（学号）ID获取论文信息
        /// </summary>
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <returns></returns>
        public Thesis GetThesisByStuID(int studentID)
        {
            return thesisService.GetThesisByStuID(studentID);
        }
        /// <summary>
        /// 记录论文相关信息
        /// </summary>
        /// <param name="thesis">论文信息</param>
        /// <returns></returns>
        public int UpdateThesisByStuID(Thesis thesis)
        {
            return thesisService.UpdateThesisByStuID(thesis);
        }
        /// <summary>
        /// 根据某教师上传的题目ID获取与该题目有关的论文信息
        /// </summary>
        /// <param name="teacherID">教师登录（工号）ID</param>
        /// <returns></returns>
        public List<Thesis> GetThesisWithOenTeacher(int teacherID)
        {
            return thesisService.GetThesisWithTeacher(teacherID);
        }
        /// <summary>
        /// 根据论文ID获取论文相关信息
        /// </summary>
        /// <param name="thesisID">论文ID</param>
        /// <returns></returns>
        public Thesis GetThesisByID(int thesisID)
        {
            return thesisService.GetThesisById(thesisID);
        }
        /// <summary>
        /// 获取论文数量
        /// </summary>
        /// <returns></returns>
        public int GetThesisCount()
        {
            return thesisService.GetThesisCount();
        }
        /// <summary>
        /// 根据学生登录（学号）ID删除论文信息
        /// </summary>
        /// <param name="studentID">学生登录（学号）ID</param>
        /// <returns></returns>
        public int DeleteThesisByStudentID(int studentID)
        {
            return thesisService.DeleteThesisByStudentID(studentID);
        }
    }
}
