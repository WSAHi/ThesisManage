<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LLogin" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>毕业设计选题系统</title>
</head>
<body class="auto-style3">
    <form id="form1" runat="server">
        <img src="Images/i.jpg">用户名:<asp:TextBox ID="txtName" runat="server" Width="149px"></asp:TextBox>
        密码:<asp:TextBox ID="txtPassWord" runat="server" TextMode="Password" Width="151px"></asp:TextBox>
        用户类型:<asp:DropDownList ID="ddlUserRole" runat="server" DataSourceID="ObjectDataSource1" DataTextField="RoleName" DataValueField="UID" Width="157px">
        </asp:DropDownList>
        <asp:Button ID="btnLogin" runat="server" Text="登  录" OnClick="btnLogin_Click" />
        <asp:Button ID="btnEsc" runat="server" Text="退  出" OnClick="btnEsc_Click" />
        <asp:Label ID="lbmes" runat="server" ForeColor="Red" Width="57px"></asp:Label>
        <br />
    </form>
</body>
</html>
