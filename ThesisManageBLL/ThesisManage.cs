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
        public int InsertThesis(Thesis thesis)
        {
            return thesisService.InsertThesis(thesis);
        }
        public int GetCountsByStuId(int stuId)
        {
            return thesisService.GetCountsByStuId(stuId);
        }
        public Thesis GetThesisByStuId(int stuId)
        {
            return thesisService.GetThesisByStuId(stuId);
        }
        public int UpdateThesisByStuId(Thesis thesis)
        {
            return thesisService.UpdateThesisByStuId(thesis);
        }
        public List<Thesis> GetThesisWithOenTeacher(int TEID)
        {
            return thesisService.GetThesisWithOenTeacher(TEID);
        }
        public Thesis GetThesisById(int id)
        {
            return thesisService.GetThesisById(id);
        }
        public int GetThesisCount()
        {
            return thesisService.GetThesisCount();
        }
        public int DeleteThesisByStudentId(int studentId)
        {
            return thesisService.DeleteThesisByStudentId(studentId);
        }
    }
}
