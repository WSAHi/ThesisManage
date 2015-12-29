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
        public List<Title> GetUnTitleList()
        {
            return titleService.GetUnTitleList();
        }
        public List<Title> GetTitleList()
        {
            return titleService.GetTitleList();
        }
        public int ModifiyTitleHasChooseNum(int tID)
        {
            return titleService.ModifiyTitleHasChooseNum(tID);
        }
        public Title GetTilteByTitleId(int titleId)
        {
            return titleService.GetTilteByTitleId(titleId);
        }
        public int StuAddTitle(string titleName, int studentId, string Description)
        {
            return titleService.StuAddTitle(titleName, studentId, Description);
        }
        public int TeacherAddTitle(string titleName, int TEID, string Description, int chooseNum)
        {
            return titleService.TeacherAddTitle(titleName, TEID, Description, chooseNum);
        }
        public List<Title> GetTitleListByTeacherId(int TeacherId)
        {
            return titleService.GetTitleListByTeacherId(TeacherId);
        }
        public int DeleteTitle(int tID)
        {
            return titleService.DeleteTitle(tID);
        }
        public int ModifiyTitle(string titleName,string description, int counts, int tID)
        {
            return titleService.ModifiyTitle(titleName,description,counts,tID);
        }
        public int ModifiyTitleState(int tID, int teacherId)
        {
            return titleService.ModifiyTitleState(tID, teacherId);
        }
        public int ModifiyTitleState(int tID)
        {
            return titleService.ModifiyTitleState(tID);
        }
        public int ModifiyTitleUnState(int tID)
        {
            return titleService.ModifiyTitleUnState(tID);
        }
        public DataSet GetTitle(string sql)
        {
            return titleService.GetTitle(sql);
        }
        public int GetTitleCount()
        {
            return titleService.GetTitleCount();
        }
        public int GetTitleCountsSum()
        {
            return titleService.GetTitleCountsSum();
        }
        public int ModifiyTitleChooseNum(int tID) {
            return titleService.ModifiyTitleChooseNum(tID);
        }
    }
}
