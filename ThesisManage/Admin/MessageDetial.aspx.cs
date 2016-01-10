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

public partial class Admin_MessageDetial : System.Web.UI.Page
{
    public Message mes
    {
        get { return (Message)ViewState["mes"]; }
        set { ViewState["mes"] = value; }
    }
    MessageManage messageManage = new MessageManage();
    TeacherManage teacherManage = new TeacherManage();
    StudentManage studentManage = new StudentManage();
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
                int MID = Convert.ToInt32(Request.QueryString["MID"]);
                messageManage.ModifyMessage(MID, 3);
                mes = messageManage.GetMesByMID(MID);
                lblUserRole.Text = mes.SenderRole;
                lblUserName.Text = NameBind(mes.Sender, mes.SenderRole);
                lblMessageComtents.Text = mes.Contents;
                lblMessageSendTime.Text = "发送时间:" + mes.MPubDate;
                lblUser.Text = NameBind(mes.Sender, mes.SenderRole);
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Message message = new Message();
            message.MPubDate = DateTime.Now.ToString();
            Admin admin = (Admin)Session["admin"];
            message.Sender = admin.AID;
            message.SenderRole = "管理员";
            message.Contents = txtMessage.Text;
            message.Teacher = null;
            message.Student = null;
            if (mes.SenderRole == "教师")
            {
                Teacher teacher = teacherManage.GetTeacherById(mes.Sender);
                message.Teacher = teacher;
                message.Student = null;
                message.State = 0;
            }
            else if (mes.SenderRole == "学生")
            {
                Student stu = studentManage.GetStudentBySID(mes.Sender);
                message.Student = stu;
                message.Teacher = null;
                message.State = 0;
            }
            else
            {
                message.State = 2;
            }
            int num = messageManage.AddMessage(message);
            if (num > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('发送成功！');</script>");
                txtMessage.Text = "";
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('发送失败！');</script>");
            }


        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        txtMessage.Text = "";
    }
    public string NameBind(int id, string roleName)
    {
        string mes = null;
        if (roleName.Trim() == "教师")
        {
            Teacher teacher = teacherManage.GetTeacherById(id);
            mes = teacher.TeacherName;
        }
        else if (roleName.Trim() == "管理员")
        {
            mes = "管理员";
        }
        else if (roleName.Trim() == "学生")
        {
            Student student = studentManage.GetStudentBySID(id);
            mes = student.StudentName;
        }
        return mes;
    }
}
