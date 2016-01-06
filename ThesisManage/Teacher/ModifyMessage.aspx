<%@ Page Language="C#" MasterPageFile="~/Teacher/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="ModifyMessage.aspx.cs" Inherits="Teacher_ModifyMessage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>教员基本信息查询
            </td>
        </tr>
        <tr>
            <td>教师号:</td>
            <td>
                <asp:Label ID="lbNum" runat="server"></asp:Label></td>
            <td>姓名:</td>
            <td>
                <asp:Label ID="lbName" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>地址:</td>
            <td>
                <asp:TextBox ID="textAddress" runat="server"></asp:TextBox></td>
            <td>联系电话:</td>
            <td>
                <asp:TextBox ID="textphone" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>邮箱:</td>
            <td>
                <asp:TextBox ID="textEmail" runat="server"></asp:TextBox></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnsubmint" runat="server" OnClick="btnsubmint_Click" Text="提交" /></td>
            <td>
                <asp:Button ID="btnesc" runat="server" OnClick="btnesc_Click" Text="取消" /></td>
        </tr>
    </table>
</asp:Content>

