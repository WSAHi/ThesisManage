﻿using System;
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

public partial class Admin_TitleInfoList : System.Web.UI.Page
{
    public string Sql
    {
        get { return (string)ViewState["sql"]; }
        set { ViewState["sql"] = value; }
    }
    TitleManage titleManage = new TitleManage();
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
                Sql = "select 标题=TitleName, 指导老师=teacherName,可选人数=Counts,已选人数=HasChooseNum from Title,Teacher where TEID=Title.TeacherId";
                GridView1.DataSourceID = null;
                GridView1.DataSource = titleManage.GetTitle(Sql);
                GridView1.DataBind();
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Sql = "select 标题=TitleName, 指导老师=teacherName,可选人数=Counts,已选人数=HasChooseNum from Title,Teacher where TEID=Title.TeacherId";
        string isFull = ddlTitleISCanOrNoChoose.SelectedItem.Text;
        string state = ddlState.SelectedItem.Text;
        if (isFull != "题目是否选满")
        {
            if (isFull == "已满")
            {
                Sql = Sql + " and HasChooseNum>=Counts ";
            }
            else
            {
                Sql = Sql + " and HasChooseNum< Counts ";
            }
        }
        if (state != "审核状态")
        {
            if (state == "通过")
            {
                Sql = Sql + " and State=1  ";
            }
            else
            {
                Sql = Sql + " and State=2  ";
            }
        }
        if (txtTeacher.Text.Trim() != "")
        {
            Sql = Sql + " and TeacherName like '%" + txtTeacher.Text.Trim() + "%'";
        }
        GridView1.DataSourceID = null;
        GridView1.DataSource = titleManage.GetTitle(Sql);
        GridView1.DataBind();

    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        DataSet dataset = titleManage.GetTitle(Sql);
        DataTable table = dataset.Tables["title"];
        System.IO.StringWriter sw = new System.IO.StringWriter();
        sw.WriteLine("标题\t指导老师\t可选人数\t已选人数");
        foreach (DataRow dr in table.Rows)
        {
            sw.WriteLine(dr["标题"] + "\t " + dr["指导老师"] + "\t" + dr["可选人数"] + "\t" + dr["已选人数"]);
        }
        sw.Close();
        Response.Charset = "GBK";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("标题信息表.xls", System.Text.Encoding.GetEncoding("UTF-8")));
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GBK");
        Response.Write(sw);
        Response.End();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSourceID = null;
        GridView1.DataSource = titleManage.GetTitle(Sql);
        GridView1.DataBind();
    }
}
