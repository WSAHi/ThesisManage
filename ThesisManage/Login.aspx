<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LLogin" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>毕业设计选题系统</title>
</head>
<body>
    <form id="form1" runat="server" style="background-color:aliceblue">
        <div id="head">
            <h1 style="margin: auto; padding: 50px 100px 50px 100px; color:darkcyan; font-family: 等线; font-size: 100px;">毕业设计选题系统</h1>
        </div>
        <div id="main">
            <div id="username" style="font-family: 等线; margin: auto; padding-top: 20px; padding-right: inherit; padding-bottom: 20px; padding-left: 300px;">
                用&nbsp; 户&nbsp; 名:<asp:TextBox ID="txtName" runat="server" Width="149px"></asp:TextBox>
            </div>
            <div id="password" style="font-family: 等线; margin: auto; padding-top: 20px; padding-right: inherit; padding-bottom: 20px; padding-left: 300px;">
                密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 码:<asp:TextBox ID="txtPassWord" runat="server" TextMode="Password" Width="151px"></asp:TextBox>
            </div>
            <div id="usertypt" style="font-family: 等线; margin: auto; padding-top: 20px; padding-right: inherit; padding-bottom: 20px; padding-left: 300px;">
                用户类型:<asp:DropDownList ID="ddlUserRole" runat="server" DataSourceID="ObjectDataSource1" DataTextField="RoleName" DataValueField="UID" Width="157px">
                </asp:DropDownList>
            </div>
            <div id="btn" style="font-family: 等线; margin: auto; padding-top: 10px; padding-right: inherit; padding-bottom: 10px; padding-left: 350px;">
                <asp:Button ID="btnLogin" runat="server" Text="登  录" OnClick="btnLogin_Click" />
                <asp:Button ID="btnEsc" runat="server" Text="退  出" OnClick="btnEsc_Click" />
                <asp:Label ID="lbmes" runat="server" ForeColor="Red" Width="57px"></asp:Label>
            </div>
        </div>
        <br />
    </form>
</body>
</html>
