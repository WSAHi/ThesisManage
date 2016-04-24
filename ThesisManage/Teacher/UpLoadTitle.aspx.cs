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
public partial class Student_UpLoadTitle : System.Web.UI.Page
{
    TitleManage titleManage = new TitleManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Teacher)base.Session["teacher"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (titleManage.TeacherAddTitle(txtTitileName.Text, ((Teacher)base.Session["teacher"]).TEID, txtDescription.Text, Convert.ToInt32(txtCanChooseNum.Text.Trim())) > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('提交成功，等待管理员进行审核！');</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('提交失败！');</script>");
            }
        }
        txtTitileName.Text = "";
        txtDescription.Text = "";
        txtCanChooseNum.Text = "";
    }
    protected void btnEsc_Click(object sender, EventArgs e)
    {
        txtTitileName.Text = "";
        txtDescription.Text = "";
        txtCanChooseNum.Text = "";
    }
}
