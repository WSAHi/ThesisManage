<%@ Page Language="C#" MasterPageFile="~/Teacher/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="StudentMessage.aspx.cs" Inherits="Teacher_StudentMessage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">学生详细信息</h1>
        <table class="table table-scripted">
            <tr>
                <td>学生信息
                </td>
                <td>学号:</td>
                <td>
                    <asp:Label ID="lbNum" runat="server"></asp:Label></td>
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
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>论文信息
                </td>
                <td>论文标题:</td>
                <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label></td>
                <td>上传时间:</td>
                <td>
                    <asp:Label ID="Label2" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>下载论文:</td>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="btn-link">下载论文</asp:LinkButton></td>
            </tr>
        </table>
    </div>
</asp:Content>

