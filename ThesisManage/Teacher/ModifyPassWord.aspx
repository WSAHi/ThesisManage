<%@ Page Language="C#" MasterPageFile="~/Teacher/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="ModifyPassWord.aspx.cs" Inherits="Teacher_ModifyPassWord" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>教师密码修改 
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="原始密码:"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtOldPassWord" runat="server" TextMode="Password"></asp:TextBox>
                <asp: FieldValidator ID=" FieldValidator1" runat="server" ControlToValidate="txtOldPassWord" ErrorMessage="*"></asp: FieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="新密码 :"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtNewPassWord" runat="server" TextMode="Password"></asp:TextBox>
                <asp: FieldValidator ID=" FieldValidator2" runat="server" ControlToValidate="txtNewPassWord" ErrorMessage="*"></asp: FieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="确认密码: "></asp:Label></td>
            <td>
                <asp:TextBox ID="txtReNewPassWord" runat="server" TextMode="Password"></asp:TextBox>
                <asp: FieldValidator ID=" FieldValidator3" runat="server" ControlToValidate="txtReNewPassWord" ErrorMessage="*"></asp: FieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassWord" ControlToValidate="txtReNewPassWord" ErrorMessage="CompareValidator">两次输入的密码不一样</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="修改" />
                <asp:Button ID="btnEsc" runat="server" OnClick="btnEsc_Click" Text="退出" /></td>
        </tr>
    </table>
</asp:Content>

