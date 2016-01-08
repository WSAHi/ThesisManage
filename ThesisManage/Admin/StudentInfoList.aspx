<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="StudentInfoList.aspx.cs" Inherits="Admin_AdminTest" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- 新 Bootstrap 核心 CSS 文件 -->
    <link rel="stylesheet" href="//cdn.bootcss.com/bootstrap/3.3.5/css/bootstrap.min.css" />

    <!-- 可选的Bootstrap主题文件（一般不用引入） -->
    <link rel="stylesheet" href="//cdn.bootcss.com/bootstrap/3.3.5/css/bootstrap-theme.min.css" />

    <!-- jQuery文件。务必在bootstrap.min.js 之前引入 -->
    <script src="//cdn.bootcss.com/jquery/1.11.3/jquery.min.js"></script>

    <!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
    <script src="//cdn.bootcss.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

    <div class="container-fluid">
        <div class="row">
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource1" DataValueField="StudentClass" DataTextField="StudentClass" CssClass="dropdown"></asp:DropDownList>
            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="btn" Text="已选" />
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="btn" Text="未选" />
        </div>
        <div class="row">
            <asp:Button ID="Button2" runat="server" Text="查询" OnClick="Button2_Click" CssClass="btn" />
            <asp:Button ID="Button3" runat="server" Text="生成Excel" OnClick="Button3_Click" CssClass="btn" />
        </div>
        <div class="row">
            <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource2" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table"></asp:GridView>
        </div>
    </div>
</asp:Content>

