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

public partial class Teacher_LookupTitle : System.Web.UI.Page
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
                GridView1.DataSourceID = null;
                GridView1.DataSource = titleManage.GetTitleListByTeacherID(teacher.TEID);
                GridView1.DataBind();
            }
        }
    }
    public void Bind()
    {
        Teacher teacher = (Teacher)Session["teacher"];
        GridView1.DataSourceID = null;
        GridView1.DataSource = titleManage.GetTitleListByTeacherID(teacher.TEID);
        GridView1.DataBind();
    }
    public string JudgeState(object s)
    {
        int state = Convert.ToInt32(s);
        string sta = null;
        if (state == 0)
            sta = "未审核";
        else if (state == 1)
            sta = "通过";
        else if (state == 2)
            sta = "审核未通过";
        return sta;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton linkButton = (LinkButton)e.Row.FindControl("LinkButton1");
            linkButton.Attributes.Add("onclick", "return confirm('确定要删除吗？');");
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName;
        int titleID = Convert.ToInt32(e.CommandArgument);
        ThesisManage.Model.Title title = titleManage.GetTilteByTitleID(titleID);
        if (cmd == "de")
        {
            if (title.State == 0 || title.State == 2)
            {
                titleManage.DeleteTitle(titleID);
                Bind();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该标题已通过审核，不能删除！');</script>");
            }
        }
        if (cmd == "ed")
        {
            if (title.State == 1)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该标题已通过审核，不能进行修改！');</script>");
            }
            else
            {
                Page.Server.Transfer("ModifyTitle.aspx?titleId=" + titleID);
            }
        }
    }
}
