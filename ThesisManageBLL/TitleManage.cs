using System;
using System.Collections.Generic;
using System.Text;
using ThesisManage.DAL;
using ThesisManage.Model;
using System.Data;

namespace ThesisManage.BLL
{
    public class TitleManage
    {
        TitleService titleService = new TitleService();
        /// <summary>
        /// 获取未审核的题目列表
        /// </summary>
        /// <returns></returns>
        public List<Title> GetUnTitleList()
        {
            return titleService.GetUnTitleList();
        }
        /// <summary>
        /// 获取可选的题目列表
        /// </summary>
        /// <returns></returns>
        public List<Title> GetTitleList()
        {
            return titleService.GetTitleList();
        }
        /// <summary>
        /// 更新题目被选择的数量（+）
        /// </summary>
        /// <param name="tID"></param>
        /// <returns></returns>
        public int ModifiyTitleHasChooseNum(int tID)
        {
            return titleService.ModifiyTitleHasChooseNum(tID);
        }
        /// <summary>
        /// 更新题目被选择的数量（-）
        /// </summary>
        /// <param name="tID"></param>
        /// <returns></returns>
        public int ModifiyTitleChooseNum(int tID)
        {
            return titleService.ModifiyTitleChooseNum(tID);
        }
        /// <summary>
        /// 根据题目ID获取题目
        /// </summary>
        /// <param name="titleID">题目ID</param>
        /// <returns></returns>
        public Title GetTilteByTitleID(int titleID)
        {
            return titleService.GetTilteByTitleID(titleID);
        }
        /// <summary>
        /// 学生上传自定义题目
        /// </summary>
        /// <param name="titleName">题目名称</param>
        /// <param name="studentID">学生登陆（学号）ID</param>
        /// <param name="Description">题目描述</param>
        /// <param name="teacherID">选择的指导老师的ID</param>
        /// <returns></returns>
        public int StuAddTitle(string titleName, int studentID, string Description, int teacherID)
        {
            return titleService.StuAddTitle(titleName, studentID, Description, teacherID);
        }
        /// <summary>
        /// 教师上传自定义题目
        /// </summary>
        /// <param name="titleName">题目名称</param>
        /// <param name="titleID">题目ID</param>
        /// <param name="Description">题目描述</param>
        /// <param name="counts">题目默认可选总人数</param>
        /// <returns></returns>
        public int TeacherAddTitle(string titleName, int titleID, string Description, int counts)
        {
            return titleService.TeacherAddTitle(titleName, titleID, Description, counts);
        }
        /// <summary>
        /// 获取教师上传的题目列表
        /// </summary>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public List<Title> GetTitleListByTeacherID(int teacherID)
        {
            return titleService.GetTitleListByTeacherId(teacherID);
        }
        /// <summary>
        /// 删除题目
        /// </summary>
        /// <param name="tID"></param>
        /// <returns></returns>
        public int DeleteTitle(int tID)
        {
            return titleService.DeleteTitle(tID);
        }
        /// <summary>
        /// 教师修改上报的题目
        /// </summary>
        /// <param name="titleName">题目名称</param>
        /// <param name="Description">题目描述</param>
        /// <param name="counts">题目默认可选总人数</param>
        /// <param name="titleID">题目ID</param>
        /// <returns></returns>
        public int ModifiyTitle(string titleName, string Description, int counts, int titleID)
        {
            return titleService.ModifiyTitle(titleName, Description, counts, titleID);
        }
        /// <summary>
        /// 修改题目的选择状态
        /// </summary>
        /// <param name="titleID">题目ID</param>
        /// <param name="teacherID">教师登录（工号）ID</param>
        /// <returns></returns>
        public int ModifiyTitleState(int titleID, int teacherID)
        {
            return titleService.ModifiyTitleState(titleID, teacherID);
        }
        /// <summary>
        /// 修改审核通过的题目状态
        /// </summary>
        /// <param name="titleID">题目ID</param>
        /// <returns></returns>
        public int ModifiyTitleState(int titleID)
        {
            return titleService.ModifiyTitleState(titleID);
        }
        /// <summary>
        /// 修改未审核通过的题目状态
        /// </summary>
        /// <param name="titleID">题目ID</param>
        /// <returns></returns>
        public int ModifiyTitleUnState(int titleID)
        {
            return titleService.ModifiyTitleUnState(titleID);
        }
        /// <summary>
        /// 获取指定列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetTitle(string sql)
        {
            return titleService.GetTitle(sql);
        }
        /// <summary>
        /// 题目数量
        /// </summary>
        /// <returns></returns>
        public int GetTitleCount()
        {
            return titleService.GetTitleCount();
        }
        /// <summary>
        /// 题目默认可选总人数
        /// </summary>
        /// <returns></returns>
        public int GetTitleCountsSum()
        {
            return titleService.GetTitleCountsSum();
        }
    }
}
