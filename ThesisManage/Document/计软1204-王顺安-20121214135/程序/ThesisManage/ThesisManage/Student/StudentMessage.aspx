<%@ Page Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="StudentMessage.aspx.cs" Inherits="Student_StudentMessage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">学生基本信息查询</h1>
        <table class="table table-striped">
            <tr>
                <td>学号:</td>
                <td>
                    <asp:Label ID="lblNStudentID" runat="server"></asp:Label>
                </td>
                <td>姓名:</td>
                <td>
                    <asp:Label ID="lblStudentName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>班级:</td>
                <td>
                    <asp:Label ID="lblClass" runat="server"></asp:Label></td>
                <td>地址:</td>
                <td>
                    <asp:Label ID="lblStudentAddress" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>邮箱:</td>
                <td>
                    <asp:Label ID="lblStudnetEmail" runat="server"></asp:Label></td>
                <td>联系电话:</td>
                <td>
                    <asp:Label ID="lblStudentPhone" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>是否选题:</td>
                <td>
                    <asp:Label ID="lbIISOrNoChooseTitle" runat="server"></asp:Label></td>
                <td>
                    <asp:Label ID="lblTitle" runat="server" Text="标题名称:"></asp:Label></td>
                <td>
                    <asp:Label ID="lblTitleName" runat="server"></asp:Label>
                    <asp:Button ID="btnCancelChooseTitle" runat="server" OnClick="Button1_Click" Text="退选" CssClass="btn btn-link" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

