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

public partial class LLogin : System.Web.UI.Page
{
    StudentManage studentManage = new StudentManage();
    TeacherManage teacherManage = new TeacherManage();
    AdminManage adminManage = new AdminManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlUserRole.DataSourceID = null;
            ddlUserRole.DataSource = UserRoleManage.GetUserRole();
            ddlUserRole.DataBind();
            ddlUserRole.Items.Insert(0, new ListItem("请选择用户类型", "-1"));
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string userRole = ddlUserRole.SelectedItem.Text.Trim();
        string loginName = txtUserName.Text.Trim();
        string password = txtPassword.Text.Trim();
        if (userRole == "管理员")
        {
            string message = adminManage.GetAdminByID(loginName, password);
            if (message.Trim() == "成功")
            {
                Admin admin = new Admin();
                admin.LoginID = loginName;
                admin.LoginPass = password;
                Session["admin"] = admin;
                Response.Redirect("Admin/AuditUpLoadTitle.aspx");
            }
            else
            {
                lblLoginMessage.Text = message;
            }
        }
        else if (userRole == "教师")
        {
            string message = teacherManage.IsValide(loginName, password);
            if (message.Trim() == "成功")
            {
                Teacher teacher = teacherManage.GetTeacherByTeacherID(loginName);
                Session["teacher"] = teacher;
                Session["TEID"] = teacher.TEID;
                Response.Redirect("Teacher/TeacherMessage.aspx");
            }
            else
            {
                lblLoginMessage.Text = message;
            }
        }
        else if (userRole == "学生")
        {
            string message = studentManage.StudentLogin(loginName, password);
            if (message.Trim() == "成功")
            {
                Student student = studentManage.GetStudentByStudentID(loginName);
                Session["student"] = student;
                Response.Redirect("Student/StudentMessage.aspx");
            }
            else
            {
                lblLoginMessage.Text = message;
            }
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择用户角色！');</script>");
        }
    }
}
