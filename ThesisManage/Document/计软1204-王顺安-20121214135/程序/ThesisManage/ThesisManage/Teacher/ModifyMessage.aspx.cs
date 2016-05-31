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

public partial class Teacher_ModifyMessage : System.Web.UI.Page
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
                lblTeacherID.Text = teacher.TeacherID;
                lblTeacherName.Text = teacher.TeacherName;
                txtTeacherAddress.Text = teacher.TeacherAddress;
                txtTeacherEmail.Text = teacher.TeacherMail;
                txtTeacherPhone.Text = teacher.TeacherPhone;
            }
        }
    }
    protected void btnsubmint_Click(object sender, EventArgs e)
    {
        string address = txtTeacherAddress.Text;
        string email=txtTeacherEmail.Text;
        string phone=txtTeacherPhone.Text;
        int num = teacherManage.Modifiy(address,email,phone);
        if (num > 0)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.href='TeacherMessage.aspx';</script>");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败！');</script>");
        }
    }
    protected void btnesc_Click(object sender, EventArgs e)
    {
        txtTeacherAddress.Text = "";
        txtTeacherEmail.Text = "";
        txtTeacherPhone.Text = "";
    }
}
