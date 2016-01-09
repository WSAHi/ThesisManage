<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ModifyPassWord.aspx.cs" Inherits="Admin_ModifyPassWord" Title="Untitled Page" %>

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
        <h1 class="h1 text-center">修改密码:</h1>
        <div class="input-group">
            <asp:TextBox ID="txtOldPassWord" runat="server" TextMode="Password" CssClass="form-control" placeholder="原密码" Width="250px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassWord" ErrorMessage="*"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtNewPassWord" runat="server" TextMode="Password" CssClass="form-control" placeholder="新密码" Width="250px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassWord" ErrorMessage="*"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtReNewPassWord" runat="server" TextMode="Password" CssClass="form-control" placeholder="确认密码" Width="250px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReNewPassWord" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassWord" ControlToValidate="txtReNewPassWord" ErrorMessage="CompareValidator">两次输入的密码不一样</asp:CompareValidator>
            <br />
            <br />
            <br />
            <br />
            <div class="btn-group">
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="修改" CssClass="btn" />
                <asp:Button ID="btnEsc" runat="server" OnClick="btnEsc_Click" Text="退出" CssClass="btn" />
            </div>
        </div>
    </div>
</asp:Content>

