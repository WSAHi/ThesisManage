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

public partial class Admin_TitleDetial : System.Web.UI.Page
{
    TitleManage titleManage = new TitleManage();
    TeacherManage teacherManage = new TeacherManage();
    StudentManage studentManage = new StudentManage();
    public int TID
    {
        get { return (int)ViewState["TID"]; }
        set { ViewState["TID"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnPass.Attributes.Add("onclick", "return confirm('您确认该标题审核通过吗！');");
            Admin admin = (Admin)Session["admin"];
            if (admin == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                TID = Convert.ToInt32(Request.QueryString["TID"]);
                ThesisManage.Model.Title title = titleManage.GetTilteByTitleId(TID);
                if (title.Student == null || title.Student.StudentName == "" || title.Student.StudentName == null)
                {
                    lblTeacher.Text = title.Teacher.TeacherName;
                    lblUploader.Text = "教师:[" + title.Teacher.TeacherName + "]";
                }
                else
                {
                    lblUploader.Text = "学生:[" + title.Student.StudentName + "]";
                }
                lblTitleName.Text = title.TitleName;
                lblDescription.Text = title.Description;
                lblCanChooseNum.Text = title.Counts.ToString();

                if (title.State == 0)
                {
                    lblState.Text = "未审核";
                }
            }

        }
    }
    public string GetImageUrl(object ID)
    {
        int teid = Convert.ToInt32(ID);
        string imageUrl = string.Empty;
        if (teid % 2 == 0)
            imageUrl = "~/Images/1.jpg";
        else if (teid % 3 == 0)
            imageUrl = "~/Images/2.jpg";
        else
            imageUrl = "~/Images/3.jpg";
        return imageUrl;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Admin admin = (Admin)Session["admin"];
        if (lblTeacher.Text == "")
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请给该标题指定一个指导老师！');</script>");
        }
        else
        {
            int num = 0;
            int teacherId = Convert.ToInt32(Session["key"]);
            ThesisManage.Model.Title title = titleManage.GetTilteByTitleId(TID);

            if (title.Student == null || title.Student.StudentName == "" || title.Student.StudentName == null)
            {
                num = titleManage.ModifiyTitleState(TID);
            }
            else
            {
                num = titleManage.ModifiyTitleState(TID, teacherId);
                studentManage.ModifiyStuSate(1, TID, title.Student.StudentID);
            }
            if (num > 0)
            {
                Response.Redirect("AuditUpLoadTitle.aspx");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('操作失败！');</script>");
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Panel1.Visible == true)
        {
            Panel1.Visible = false;
        }
        else
            Panel1.Visible = true;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (txtReason.Text.Trim() != "")
        {
            Admin admin = (Admin)Session["admin"];
            int num = titleManage.ModifiyTitleUnState(TID);
            ThesisManage.Model.Title title = titleManage.GetTilteByTitleId(TID);

            if (num > 0)
            {
                Response.Redirect("AuditUpLoadTitle.aspx");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('操作失败！');</script>");
            }
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请注明原因！');</script>");
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }
}
