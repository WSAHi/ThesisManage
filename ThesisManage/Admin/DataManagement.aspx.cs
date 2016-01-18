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

public partial class Admin_DataManagement : System.Web.UI.Page
{
    StudentManage studentManage = new StudentManage();
    TeacherManage teacherManage = new TeacherManage();
    AdminManage adminManage = new AdminManage();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Admin admin = (Admin)Session["admin"];
            if (admin == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                ddlUserRole.DataSourceID = null;
                ddlUserRole.DataSource = UserRoleManage.GetUserRole();
                ddlUserRole.DataBind();
                Panelvisible();
            }

        }
        string UserRole = ddlUserRole.SelectedItem.Text.Trim();
        btnAddLost.Attributes.Add("onclick", "return confirm('您是要添加【" + UserRole + "】表的数据吗？');");

    }
    protected void ddlUserRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panelvisible();
    }
    public void Panelvisible()
    {
        string UserRole = ddlUserRole.SelectedItem.Text.Trim();
        if (UserRole == "学生")
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
        }
        if (UserRole == "教师")
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
        }
        if (UserRole == "管理员")
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
        }
    }
    protected void btnAddAdmin_Click(object sender, EventArgs e)
    {
        string loginID = txtAdminID.Text.Trim();
        int roleID = Convert.ToInt32(ddlUserRole.SelectedItem.Value.Trim());
        Admin admin = adminManage.GetAdminById(loginID);
        if (admin.LoginID == "")
        {
            int num = adminManage.AddAdmin(loginID, roleID);
            if (num > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！');</script>");
            }
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('你添加的管理员帐户号已存在！');</script>");
        }
    }
    protected void btnResetAdmin_Click(object sender, EventArgs e)
    {
        txtAdminID.Text = "";
    }
    protected void btnAddTeacher_Click(object sender, EventArgs e)
    {
        string teacherID = txtTeacherID.Text.Trim();
        string teacherName = txtTeacherName.Text.Trim();
        int roleID = Convert.ToInt32(ddlUserRole.SelectedItem.Value.Trim());
        Teacher teacher = teacherManage.GetTeacherByTeacherId(teacherID);
        if (teacher.TeacherName == "")
        {
            int num = teacherManage.AddTeacher(teacherID, teacherName, roleID);
            if (num > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！');</script>");
            }
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('你添加的教师号已存在！');</script>");
        }
    }
    protected void btnResetTeacher_Click(object sender, EventArgs e)
    {
        txtTeacherID.Text = "";
        txtTeacherName.Text = "";
    }
    protected void btnAddStudent_Click(object sender, EventArgs e)
    {
        string studentID = txtStudentID.Text.Trim();
        string studentName = txtStudentName.Text.Trim();
        string studentClass = txtClass.Text.Trim();
        Student student = studentManage.GetStudentByStudentID(studentID);
        int roleID = Convert.ToInt32(ddlUserRole.SelectedItem.Value.Trim());
        if (student.StudentName == "")
        {
            int num = studentManage.AddStudent(studentID, studentName, studentClass, roleID);
            if (num > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！');</script>");
            }
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('你添加的学号已存在！');</script>");
        }

    }
    protected void btnResetStudent_Click(object sender, EventArgs e)
    {
        txtStudentID.Text = "";
        txtStudentName.Text = "";
        txtClass.Text = "";
    }
    protected void btnAddLost_Click(object sender, EventArgs e)
    {
        int roleID = Convert.ToInt32(ddlUserRole.SelectedItem.Value.Trim());
        string roleName = ddlUserRole.SelectedItem.Text.Trim();
        string source = this.FileUpload1.PostedFile.FileName;
        string getExtension = System.IO.Path.GetExtension(source);
        if (source == String.Empty || getExtension != ".xls")
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择Excel文件！');</script>");
            return;
        }
        else
        {
            if (roleName == "管理员")
            {
                int num = adminManage.AddAdmins(source, roleID);
                if (num > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');</script>");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！原因可能为:您添加的用户已存在');</script>");
                }
            }
            else if (roleName == "学生")
            {
                int num = studentManage.AddStudents(source, roleID);
                if (num > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');</script>");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！原因可能为:您添加的用户已存在');</script>");
                }
            }
            else if (roleName == "教师")
            {
                int num = teacherManage.AddTeachers(source, roleID);
                if (num > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');</script>");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！原因可能为:您添加的用户已存在');</script>");
                }
            }
        }
    }
}
