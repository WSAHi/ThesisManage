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

public partial class Student_ChooseTitle : System.Web.UI.Page
{
    StudentManage studentManage = new StudentManage();
    TitleManage titleManage = new TitleManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Student student = (Student)Session["student"];
            if (student == null)
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button btnChooseTitle = (Button)e.Row.FindControl("btnChooseTitle");
            btnChooseTitle.Attributes.Add("onclick", "return confirm('您确认要选择该论题吗?');");
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String studentID = ((Student)Session["student"]).StudentID;
        int studentState = ((Student)Session["student"]).SudentState;
        if (studentState == 0)
        {
            int TitleID = Convert.ToInt32(e.CommandArgument);
            Title title = titleManage.GetTilteByTitleID(TitleID);
            if (title.HasChooseNum < title.Counts)
            {
                int num = studentManage.ModifiyStuSate(1, TitleID, studentID);
                if (num > 0)
                {
                    int ModifyTitleHasChooseNum = titleManage.ModifiyTitleHasChooseNum(TitleID);
                    if (ModifyTitleHasChooseNum > 0)
                    {
                        Student student = studentManage.GetStudentByStudentID(studentID);
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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该标题人数已满！');</script>");
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('你已选题，请别重选！');</script>");
        }
    }
}
