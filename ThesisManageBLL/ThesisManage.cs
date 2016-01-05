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
        /// 添加论文
        /// </summary>
        /// <param name="thesis"></param>
        /// <returns></returns>
        public int InsertThesis(Thesis thesis)
        {
            return thesisService.InsertThesis(thesis);
        }
        public int GetCountsByStuId(int stuId)
        {
            return thesisService.GetCountsByStuId(stuId);
        }
        /// <summary>
        /// 获取论文信息
        /// </summary>
        /// <param name="stuID"></param>
        /// <returns></returns>
        public Thesis GetThesisByStuId(int stuID)
        {
            return thesisService.GetThesisByStuId(stuID);
        }
        /// <summary>
        /// 记录论文相关信息
        /// </summary>
        /// <param name="thesis"></param>
        /// <returns></returns>
        public int UpdateThesisByStuId(Thesis thesis)
        {
            return thesisService.UpdateThesisByStuId(thesis);
        }
        /// <summary>
        /// 获取论文，题目是老师同一上传的
        /// </summary>
        /// <param name="tEID">教师ID</param>
        /// <returns></returns>
        public List<Thesis> GetThesisWithOenTeacher(int tEID)
        {
            return thesisService.GetThesisWithOenTeacher(tEID);
        }
        /// <summary>
        /// 获取论文相关信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Thesis GetThesisById(int id)
        {
            return thesisService.GetThesisById(id);
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
        /// 删除论文
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public int DeleteThesisByStudentId(int studentId)
        {
            return thesisService.DeleteThesisByStudentId(studentId);
        }
    }
}
