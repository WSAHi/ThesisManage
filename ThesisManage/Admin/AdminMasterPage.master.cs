using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ThesisManage.BLL;
using ThesisManage.Model;

public partial class Admin_AdminMasterPage : System.Web.UI.MasterPage
{
    StudentManage studentManage = new StudentManage();
    TitleManage titleManage = new TitleManage();
    ThesisManage.BLL.ThesisManage thesisManage = new ThesisManage.BLL.ThesisManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        int studentCounts = studentManage.GetStudentCount();
        int titleCounts = titleManage.GetTitleCount();
        int titleCountSum = titleManage.GetTitleCountsSum();
        int hasChooseTitleNum = studentManage.GetHasChooseTitleNum();
        int upLoadThesisNum = thesisManage.GetThesisCount();
        lblStudentTotaloty.Text = studentCounts.ToString();
        lblTitleTotality.Text = titleCounts.ToString();
        lblTitltCanChooseTotality.Text = titleCountSum.ToString();
        lblHasChooseTitleStudentNum.Text = hasChooseTitleNum.ToString();
        lblHasUploadThesisNum.Text = upLoadThesisNum.ToString();
    }
}
