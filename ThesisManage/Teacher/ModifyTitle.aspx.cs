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

public partial class Teacher_ModifyTitle : System.Web.UI.Page
{
    TitleManage titleManage = new TitleManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Teacher teacher = (Teacher)Session["teacher"];
            if (teacher == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                int titleID = Convert.ToInt32(Request.Params["titleID"]);
                Title title = titleManage.GetTilteByTitleID(titleID);
                txtTitile.Text = title.TitleName;
                txtDescription.Text = title.Description;
                txtCanChooseNum.Text = title.Counts.ToString();
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Teacher teacher = (Teacher)Session["teacher"];
        if (Page.IsValid)
        {
            string titleName = txtTitile.Text;
            string description = txtDescription.Text;
            int counts = Convert.ToInt32(txtCanChooseNum.Text);
            int num = titleManage.ModifiyTitle(titleName, description, counts, teacher.TEID);
            if (num > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.href='LookupTitle.aspx';</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败！');window.location.href='LookupTitle.aspx';</script>");
            }
        }
    }
    protected void btnEsc_Click(object sender, EventArgs e)
    {
        Response.Redirect("LookupTitle.aspx");
    }
}
