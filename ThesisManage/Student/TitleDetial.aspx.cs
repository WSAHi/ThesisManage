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

public partial class Student_TitleDetial : System.Web.UI.Page
{
    TitleManage titleManage = new TitleManage();
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
            Student student = (Student)Session["student"];
            if (student == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                TitleID = Convert.ToInt32(Request.QueryString["TitleID"]);
                ThesisManage.Model.Title title = titleManage.GetTilteByTitleID(TitleID);
                lblTeacher.Text = title.Teacher.TeacherName;
                lblUploader.Text = "教师:[" + title.Teacher.TeacherName + "]";
                lblTitleName.Text = title.TitleName;
                lblDescription.Text = title.Description;
                lblCanChooseNum.Text = title.Counts.ToString();
                Label4.Text = title.HasChooseNum.ToString();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (((Student)base.Session["student"]).SudentState == 0)
        {
            if (studentManage.ModifiyStuSate(1, TitleID, ((Student)base.Session["student"]).StudentID) > 0)
            {
                if (titleManage.ModifiyTitleHasChooseNum(TitleID) > 0)
                {

                    Student student = studentManage.GetStudentByStudentID(((Student)base.Session["student"]).StudentID);
                    Session.Remove("student");
                    Session["student"] = student;                    
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('选题成功！');window.location.href='StudentMessage.aspx';</script>");
                }
            }
            else
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('选题失败！');</script>");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('你已选题，请别重选！');</script>");
        }
    }
}
