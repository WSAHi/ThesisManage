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

public partial class Teacher_TeacherMessage : System.Web.UI.Page
{
    TeacherManage teacherManage = new TeacherManage();
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
                Teacher te = teacherManage.GetTeacherByTeacherId(teacher.TeacherID);
                lblTeacherID.Text = te.TeacherID;
                lblTeacherName.Text = te.TeacherName;
                lblTeacherEmail.Text = te.TeacherMail;
                lblTeacherAddress.Text = te.TeacherAddress;
                lblTeacherPhone.Text = te.TeacherPhone;
            }
        }
    }
}
