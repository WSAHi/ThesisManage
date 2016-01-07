<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LLogin" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>毕业设计选题系统</title>
    <!-- 新 Bootstrap 核心 CSS 文件 -->
    <link rel="stylesheet" href="//cdn.bootcss.com/bootstrap/3.3.5/css/bootstrap.min.css">

    <!-- 可选的Bootstrap主题文件（一般不用引入） -->
    <link rel="stylesheet" href="//cdn.bootcss.com/bootstrap/3.3.5/css/bootstrap-theme.min.css">

    <!-- jQuery文件。务必在bootstrap.min.js 之前引入 -->
    <script src="//cdn.bootcss.com/jquery/1.11.3/jquery.min.js"></script>

    <!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
    <script src="//cdn.bootcss.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
</head>
<body>
    >
    <div class="container">
        <form id="form1" runat="server">
            <h1 class="h1  text-center">毕业设计选题系统</h1>
            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control text-center" placeholder="用户名" required autofocus></asp:TextBox>
            <br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control text-center" placeholder="密码" required></asp:TextBox>
            <br />
            <asp:DropDownList ID="ddlUserRole" runat="server" DataSourceID="ObjectDataSource1" DataTextField="RoleName" DataValueField="UID" CssClass="form-control text-center"></asp:DropDownList>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" CssClass="btn btn-lg btn-primary btn-block" />
            <asp:Button ID="btnEsc" runat="server" Text="退出" OnClick="btnEsc_Click" CssClass="btn btn-lg btn-primary btn-block" />
            <br />
            <asp:Label ID="lbmes" runat="server"></asp:Label>
        </form>
    </div>
</body>
</html>
