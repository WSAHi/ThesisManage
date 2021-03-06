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
public partial class Student_UpLoadTitle : System.Web.UI.Page
{
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Student student = (Student)Session["student"];
            if (string.IsNullOrEmpty(student.Title.TitleName))
            {
                string title = txtTitleName.Text;
                string Description = txtDescription.Text;
                int tEID = Convert.ToInt32(DropDownList1.SelectedItem.Value.Trim());
                int num = titleManage.StuAddTitle(title, student.SID, Description, tEID);
                if (num > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('提交成功，等待管理员进行审核！');</script>");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('提交失败！');</script>");
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('你已选题，不能再上传题目！');</script>");
            }
        }
    }
    protected void btnEsc_Click(object sender, EventArgs e)
    {
        txtTitleName.Text = "";
        txtDescription.Text = "";
    }
}
