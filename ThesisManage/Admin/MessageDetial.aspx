<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="MessageDetial.aspx.cs" Inherits="Admin_MessageDetial" Title="Untitled Page" %>

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
            发送人:<asp:Label ID="Label1" runat="server" CssClass="control-label"></asp:Label>
            [<asp:Label ID="Label2" runat="server" CssClass="control-label"></asp:Label>]
        </div>
        <div class="row">
            内容:<asp:Label ID="Label3" runat="server" CssClass="control-label"></asp:Label>
        </div>
        <div class="row">
            <asp:Label ID="Label4" runat="server" CssClass="control-label"></asp:Label>
        </div>
        <br />
        <div class="row">
            回复:
            收件人:<asp:Label ID="Label5" runat="server" Text="Label" CssClass="control-label"></asp:Label>
        </div>
        <div class="row col-lg-3">
            内 容:<asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div class="row">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="回复" CssClass="btn" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="取消" CssClass="btn" />
        </div>
    </div>
</asp:Content>

