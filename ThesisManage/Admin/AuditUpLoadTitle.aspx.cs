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

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Admin admin = (Admin)Session["admin"];
        if (admin == null)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
    public string panduan(object s)
    {
        int state = Convert.ToInt32(s);
        string sta = null;
        if (state == 0)
            sta = "未审核";
        else if (state == 1)
            sta = "通过";
        else if (state == 2)
            sta = "审核未通过";
        return sta;
    }
    public string Contents(object c)
    {
        string contents = c.ToString();
        string content = null;
        if (contents.Length > 10)
        {
            content = contents.Substring(0, 10);
            content = content + "...";
        }
        else
            content = contents;
        return content;
    }
}
