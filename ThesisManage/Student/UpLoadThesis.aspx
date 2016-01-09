<%@ Page Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="UpLoadThesis.aspx.cs" Inherits="Student_UpLoadThesis" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">上传论文</h1>
        <table class="table table-striped">
            <tr>
                <td class="text-right">选择上传文件:
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="请上传.doc文件" ValidationExpression='^([a-zA-Z]\:|\\)\\([^\\]+\\)*[^\/:*?"<>|]+\.doc(l)?$'></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnUpLoad" runat="server" OnClick="btnUpLoad_Click" Text="上传"  CssClass="form-control btn-block"/>
    </div>
</asp:Content>

