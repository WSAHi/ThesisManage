<%@ Page Language="C#" MasterPageFile="~/Teacher/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="TeacherMessage.aspx.cs" Inherits="Teacher_TeacherMessage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>教师基本信息查询
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
                <asp:Label ID="lbAddress" runat="server"></asp:Label></td>
            <td>联系电话:</td>
            <td>
                <asp:Label ID="lbPhone" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>邮箱:</td>
            <td>
                <asp:Label ID="lbEmail" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

