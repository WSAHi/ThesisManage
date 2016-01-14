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
        /// 根据TitleID获取题目
        /// </summary>
        /// <param name="titleID"></param>
        /// <returns></returns>
        public Title GetTilteByTitleId(int titleID)
        {
            return titleService.GetTilteByTitleId(titleID);
        }
        /// <summary>
        /// 学生上传题目
        /// </summary>
        /// <param name="titleName"></param>
        /// <param name="studentID"></param>
        /// <param name="Description"></param>
        /// <param name="tEID"></param>
        /// <returns></returns>
        public int StuAddTitle(string titleName, int studentID, string Description, int tEID)
        {
            return titleService.StuAddTitle(titleName, studentID, Description, tEID);
        }
        /// <summary>
        /// 教师上传题目
        /// </summary>
        /// <param name="titleName"></param>
        /// <param name="TEID"></param>
        /// <param name="Description"></param>
        /// <param name="chooseNum"></param>
        /// <returns></returns>
        public int TeacherAddTitle(string titleName, int TEID, string Description, int chooseNum)
        {
            return titleService.TeacherAddTitle(titleName, TEID, Description, chooseNum);
        }
        /// <summary>
        /// 获取教师上传的题目列表
        /// </summary>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public List<Title> GetTitleListByTeacherId(int teacherID)
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
        /// 修改教师自己上传并未被审核通过的题目信息
        /// </summary>
        /// <param name="titleName"></param>
        /// <param name="Description"></param>
        /// <param name="counts"></param>
        /// <param name="tID"></param>
        /// <returns></returns>
        public int ModifiyTitle(string titleName, string Description, int counts, int tID)
        {
            return titleService.ModifiyTitle(titleName, Description, counts, tID);
        }
        /// <summary>
        /// 修改题目的选择状态
        /// </summary>
        /// <param name="tID"></param>
        /// <param name="teacherID"></param>
        /// <returns></returns>
        public int ModifiyTitleState(int tID, int teacherID)
        {
            return titleService.ModifiyTitleState(tID, teacherID);
        }
        /// <summary>
        /// 修改审核通过的题目状态
        /// </summary>
        /// <param name="tID"></param>
        /// <returns></returns>
        public int ModifiyTitleState(int tID)
        {
            return titleService.ModifiyTitleState(tID);
        }
        /// <summary>
        /// 修改未审核通过的题目状态
        /// </summary>
        /// <param name="tID"></param>
        /// <returns></returns>
        public int ModifiyTitleUnState(int tID)
        {
            return titleService.ModifiyTitleUnState(tID);
        }
        /// <summary>
        /// 获取题目列表
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
        /// 题目数量
        /// </summary>
        /// <returns></returns>
        public int GetTitleCountsSum()
        {
            return titleService.GetTitleCountsSum();
        }
    }
}
