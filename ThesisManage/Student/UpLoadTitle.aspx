<%@ Page Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="UpLoadTitle.aspx.cs" Inherits="Student_UpLoadTitle" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>上传自定义题目
            </td>
        </tr>
        <tr>
            <td>题目：
            </td>
            <td>
                <asp:TextBox ID="txtTitile" runat="server"></asp:TextBox>
                <asp: FieldValidator ID=" FieldValidator1" runat="server" ControlToValidate="txtTitile" ErrorMessage="*"></asp: FieldValidator>
            </td>
        </tr>
        <tr>
            <td>描述：
            </td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp: FieldValidator ID=" FieldValidator2" runat="server" ControlToValidate="txtDescription" ErrorMessage="*"></asp: FieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text=" 提交" />
                <asp:Button ID="btnEsc" runat="server" OnClick="btnEsc_Click" Text="取消" />
            </td>
        </tr>
    </table>
</asp:Content>

