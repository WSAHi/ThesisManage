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
using System.IO;
using ThesisManage.BLL;
using ThesisManage.Model;

public partial class Student_UpLoadThesis : System.Web.UI.Page
{
    ThesisManage.BLL.ThesisManage thesisManage = new ThesisManage.BLL.ThesisManage();
    TitleManage titlemanage = new TitleManage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Student student = (Student)Session["student"];
            if (student == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                btnUpLoad.Attributes.Add("onclick", "return confirm('你已上传论文，确定要重新上传吗？');");
            }
        }
    }
    protected void btnUpLoad_Click(object sender, EventArgs e)
    {

        Student student = (Student)Session["student"];
        if (student.Title.TitleName != null && student.Title.TitleName != "")
        {
            string wordtype = FileUpload1.PostedFile.ContentType;
            string name = this.FileUpload1.PostedFile.FileName;
            int n = FileUpload1.PostedFile.InputStream.Read(new byte[FileUpload1.PostedFile.ContentLength], 0, FileUpload1.PostedFile.ContentLength);
            Thesis thesis = new Thesis();
            thesis.Student = student;
            thesis.PublishDate = DateTime.Now.ToString();
            thesis.Content = (new byte[FileUpload1.PostedFile.ContentLength]);
            thesis.Title = titlemanage.GetTilteByTitleID(student.Title.TID);
            if (string.IsNullOrEmpty(thesisManage.GetThesisByStuID(student.SID).PublishDate))
            {

                int isUpLoadOk = thesisManage.InsertThesis(thesis);
                if (isUpLoadOk > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('论上传成功！');</script>");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('论文上传失败！');</script>");
                }
            }
            else
            {
                btnUpLoad.Attributes.Add("onclick", "return confirm('你已上传论文，确定要重新上传吗？');");
                thesisManage.DeleteThesisByStudentID(student.SID);
                if (thesisManage.InsertThesis(thesis) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('论文重新上传成功！');</script>");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('论文重新上传失败！');</script>");
                }
            }
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('你还没有选题，请选题！');</script>");
        }
    }
}
