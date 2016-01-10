<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="TeacherInfoList.aspx.cs" Inherits="Admin_TeacherInfoList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid">
        <h1 class="h1 text-center">教师信息</h1>
        <asp:TextBox ID="txtTeacherName" runat="server" CssClass="form-control text-center" placeholder="教师姓名,支持模糊查询"></asp:TextBox>
        <br />
        <div class="btn-group">
            <asp:Button ID="btnSearch" runat="server" OnClick="Button1_Click" Text="查询" CssClass="btn" />
            <asp:Button ID="btnExcel" runat="server" OnClick="Button2_Click" Text="生成Excel" CssClass="btn" />
        </div>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" CssClass="table table-scripted"></asp:GridView>
    </div>
</asp:Content>

