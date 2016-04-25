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

public partial class Admin_AdminTest : System.Web.UI.Page
{
    StudentManage studentManage = new StudentManage();
    public string Sql
    {
        get { return (string)ViewState["sql"]; }
        set { ViewState["sql"] = value; }
    }

    public string Sql2
    {
        get { return (string)ViewState["sql2"]; }
        set { ViewState["sql2"] = value; }
    }

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
                Sql = "select 学号=Student.StudentID,姓名=StudentName,班级=StudentClass,指导老师=teacherName,标题名=titleName from Student,teacher,title where 1=1 and STitleID=TitleID and TEID=title.TeacherID";
                Sql2 = "select 学号=Student.StudentID,姓名=StudentName,班级=StudentClass,指导老师='无',标题名='未选题' from Student where SudentState=0";
                ddlTeacher.DataSourceID = null;
                ddlTeacher.DataSource = studentManage.GetAllClass();
                ddlTeacher.DataBind();
                ddlTeacher.Items.Insert(0, new ListItem("请选择班级", "-1"));
                DataSet dataset = studentManage.GetStudent(Sql + " union " + Sql2);
                GridView1.DataSourceID = null;
                GridView1.DataSource = dataset;
                GridView1.DataBind();
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Sql = "select 学号=Student.StudentID,姓名=StudentName,班级=StudentClass,指导老师=teacherName,标题名=titleName from Student,teacher,title where 1=1 and STitleID=TitleID and TEID=title.TeacherId";
        Sql2 = "select 学号=Student.StudentID,姓名=StudentName,班级=StudentClass,指导老师='无',标题名='未选题' from Student where SudentState=0";
        string className = ddlTeacher.SelectedItem.Text;
        if (!(className == "请选择班级"))
        {
            Sql = Sql + " and StudentClass='" + className.Trim() + "'";
            Sql2 = Sql2 + " and StudentClass='" + className.Trim() + "'";
        }
        if (ddlISOrNOChooseTitle.SelectedItem.Value == "1")
        {
            Sql = Sql + " and STitleID is not null";
            Sql2 = Sql2 + " and STitleID is not null";
        }
        else if (ddlISOrNOChooseTitle.SelectedItem.Value == "0")
        {
            Sql = Sql + " and SudentState=0";
        }
        string sql = Sql + " union " + Sql2;
        DataSet dataset = studentManage.GetStudent(sql);
        GridView1.DataSourceID = null;
        GridView1.DataSource = dataset;
        GridView1.DataBind();
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        string sql = Sql + " union " + Sql2;
        DataSet dataset = studentManage.GetStudent(sql);
        DataTable table = dataset.Tables["student"];
        System.IO.StringWriter sw = new System.IO.StringWriter();
        sw.WriteLine("学号\t姓名\t班级\t指导老师\t标题名");
        foreach (DataRow dr in table.Rows)
        {
            sw.WriteLine(dr["学号"] + "\t " + dr["姓名"] + "\t" + dr["班级"] + "\t" + dr["指导老师"] + "\t" + dr["标题名"]);
        }
        sw.Close();
        Response.Charset = "GBK";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("学生信息表.xls", System.Text.Encoding.GetEncoding("UTF-8")));
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GBK");
        Response.Write(sw);
        Response.End();

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        DataSet dataset = studentManage.GetStudent(Sql + " union " + Sql2);
        GridView1.DataSourceID = null;
        GridView1.DataSource = dataset;
        GridView1.DataBind();
    }
}
