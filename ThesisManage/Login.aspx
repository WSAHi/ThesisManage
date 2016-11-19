<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>毕业设计选题系统</title>
    <!-- jQuery文件。务必在bootstrap.min.js 之前引入 -->
    <script src="Scripts/jquery-2.2.2.min.js"></script>

    <!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
    <script src="Scripts/bootstrap.min.js"></script>


    <!-- 新 Bootstrap 核心 CSS 文件 -->
    <link rel="stylesheet" href="Content/bootstrap.min.css" />

    <!-- 可选的Bootstrap主题文件（一般不用引入） -->
    <link rel="stylesheet" href="Content/bootstrap-theme.min.css" />
</head>
<body>
    <div class="container-fluid">
        <form id="form1" runat="server">
            <div class="jumbotron">
                <h1 class="h1 text-center">毕业设计选题系统<small>Thesis Manage</small></h1>
            </div>
            <div class="container text-center">
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control text-center" placeholder="用户名"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control text-center" placeholder="密码"></asp:TextBox>
                <br />
                <asp:DropDownList ID="ddlUserRole" runat="server" DataSourceID="ObjectDataSource1" DataTextField="RoleName" DataValueField="UID" CssClass="form-control"></asp:DropDownList>
                <br />
                <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" CssClass="form-control" />
                <br />
                <asp:Label ID="lblLoginMessage" runat="server" CssClass="control-label label-warning"></asp:Label>
            </div>
        </form>
    </div>
</body>
</html>
