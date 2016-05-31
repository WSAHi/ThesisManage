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
        lblStudentTotaloty.Text = studentManage.GetStudentCount().ToString();
        lblTitleTotality.Text = titleManage.GetTitleCount().ToString();
        lblTitltCanChooseTotality.Text = titleManage.GetTitleCountsSum().ToString();
        lblHasChooseTitleStudentNum.Text = studentManage.GetHasChooseTitleNum().ToString();
        lblHasUploadThesisNum.Text = thesisManage.GetThesisCount().ToString();
    }
}
