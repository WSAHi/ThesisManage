<%@ Page Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="UpLoadThesis.aspx.cs" Inherits="Student_UpLoadThesis" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>论文上传
            </td>
        </tr>
        <tr>
            <td>选择上传文件:
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="请上传.doc文件" ValidationExpression='^([a-zA-Z]\:|\\)\\([^\\]+\\)*[^\/:*?"<>|]+\.doc(l)?$'></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnUpLoad" runat="server" OnClick="btnUpLoad_Click" Text="上传" /></td>
        </tr>
    </table>
</asp:Content>

