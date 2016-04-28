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
    public int TitleID
    {
        get { return (int)ViewState["TitleID"]; }
        set { ViewState["TitleID"] = value; }
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
                TitleID = Convert.ToInt32(Request.QueryString["TitleID"]);
                Title title = titleManage.GetTilteByTitleID(TitleID);
                if (title.Student == null || title.Student.StudentName == "" || title.Student.StudentName == null)
                {
                    lblUploader.Text = "教师:[" + title.Teacher.TeacherName + "]";
                }
                else
                {
                    lblUploader.Text = "学生:[" + title.Student.StudentName + "]";
                }
                lblTeacher.Text = title.Teacher.TeacherName;
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
    protected void btnPass_Click(object sender, EventArgs e)
    {
        Admin admin = (Admin)Session["admin"];
        if (lblTeacher.Text == "")
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请给该标题指定一个指导老师！');</script>");
        }
        else
        {
            int num = 0;
            int teacherID = Convert.ToInt32(Session["key"]);
            Title title = titleManage.GetTilteByTitleID(TitleID);

            if (title.Student == null || title.Student.StudentName == "" || title.Student.StudentName == null)
            {
                num = titleManage.ModifiyTitleState(TitleID);
            }
            else
            {
                num = titleManage.ModifiyTitleState(TitleID, teacherID);
                studentManage.ModifiyStuSate(1, TitleID, title.Student.StudentID);
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
    protected void btnUnPass_Click(object sender, EventArgs e)
    {
        Admin admin = (Admin)Session["admin"];
        int num = titleManage.ModifiyTitleUnState(TitleID);
        Title title = titleManage.GetTilteByTitleID(TitleID);

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
