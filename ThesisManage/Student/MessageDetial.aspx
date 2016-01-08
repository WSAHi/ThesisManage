<%@ Page Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="MessageDetial.aspx.cs" Inherits="Student_MessageDetial" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>发送人:<asp:Label ID="Label1" runat="server"></asp:Label>
                [<asp:Label ID="Label2" runat="server"></asp:Label>]
            </td>
        </tr>
        <tr>
            <td>内容:<br />
                <asp:Label ID="Label3" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>回复:</td>
        </tr>
        <tr>
            <td>收件人:<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>内 容:<br />
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp: FieldValidator ID=" FieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*"></asp: FieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="回复" />
                <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" /></td>
        </tr>
    </table>
</asp:Content>

