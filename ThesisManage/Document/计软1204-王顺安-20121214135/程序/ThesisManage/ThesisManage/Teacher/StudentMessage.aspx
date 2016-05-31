<%@ Page Language="C#" MasterPageFile="~/Teacher/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="StudentMessage.aspx.cs" Inherits="Teacher_StudentMessage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">学生详细信息</h1>
        <table class="table table-scripted">
            <tr>
                <td>学号:</td>
                <td>
                    <asp:Label ID="lblStudentID" runat="server"></asp:Label></td>
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
                    <asp:Label ID="lblStudentEmail" runat="server"></asp:Label></td>
                <td>联系电话:</td>
                <td>
                    <asp:Label ID="lblStudentPhone" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>是否选题:</td>
                <td>
                    <asp:Label ID="lbIsOrNoChooseTitle" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>论文信息
                </td>
            </tr>
            <tr>
                <td>论文标题:</td>
                <td>
                    <asp:Label ID="lblTitle" runat="server"></asp:Label></td>
                <td>上传时间:</td>
                <td>
                    <asp:Label ID="lblUploadTime" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>下载论文:</td>
                <td>
                    <asp:LinkButton ID="linkbtnDownload" runat="server" OnClick="LinkButton1_Click" CssClass="btn-link">下载论文</asp:LinkButton></td>
            </tr>
        </table>
    </div>
</asp:Content>

