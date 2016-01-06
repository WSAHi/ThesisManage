<%@ Page Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="StudentMessage.aspx.cs" Inherits="Student_StudentMessage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>学生基本信息查询
            </td>
        </tr>
        <tr>
            <td>学号:</td>
            <td>
                <asp:Label ID="lbNum" runat="server"></asp:Label>
            </td>
            <td>姓名:</td>
            <td>
                <asp:Label ID="lbName" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>班级:</td>
            <td>
                <asp:Label ID="lbClass" runat="server"></asp:Label></td>
            <td>地址:</td>
            <td>
                <asp:Label ID="lbAddress" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>邮箱:</td>
            <td>
                <asp:Label ID="lbEmail" runat="server"></asp:Label></td>
            <td>联系电话:</td>
            <td>
                <asp:Label ID="lbPhone" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>是否选题:</td>
            <td>
                <asp:Label ID="lbIsChooseTitle" runat="server"></asp:Label></td>
            <td>
                <asp:Label ID="lbTitle" runat="server" Text="标题名称:"></asp:Label></td>
            <td>
                <asp:Label ID="lbTitleName" runat="server"></asp:Label>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="退选" /></td>
        </tr>
    </table>
</asp:Content>

