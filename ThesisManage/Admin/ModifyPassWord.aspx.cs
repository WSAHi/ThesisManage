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

public partial class Admin_ModifyPassWord : System.Web.UI.Page
{
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
        }
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Admin admin = (Admin)Session["admin"];
            if (admin.LoginPass == txtOldPassword.Text.Trim())
            {
                string password = txtNewPassword.Text.Trim();
                int num =adminManage.ModifiyPassword(password, admin.LoginID);
                if (num > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('密码修改成功！');</script>");
                }
                else
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('密码修改失败！');</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('原始密码输入错误！');</script>");
            }
        }
    }
}
