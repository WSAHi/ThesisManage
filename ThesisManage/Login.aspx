<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LLogin" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>毕业设计选题系统</title>
</head>
<body>
    <form id="form1" runat="server">
        毕业设计选题系统
         
        <br />
        用户名:<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <br />
        密码:<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        用户类型:<asp:DropDownList ID="ddlUserRole" runat="server" DataSourceID="ObjectDataSource1" DataTextField="RoleName" DataValueField="UID"></asp:DropDownList>
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" />
        <asp:Button ID="btnEsc" runat="server" Text="退出" OnClick="btnEsc_Click" />
        <asp:Label ID="lbmes" runat="server" ForeColor="Red" Width="57px"></asp:Label>
    </form>
</body>
</html>
