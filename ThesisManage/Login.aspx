<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LLogin" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>毕业设计选题系统</title>
    <style type="text/css">
        body {
            background-color:aliceblue;
            border:5px double deepskyblue;
        }
        #form1 {
            background-color:aliceblue;
            margin:auto;
            padding:inherit;
        }
        #head {
            font-family:'Microsoft YaHei';
            font-size:100px;
            color:deepskyblue;
            margin:auto;
            padding-top:50px;
            padding-left:300px;
            border:5px double deepskyblue;
        }
        #part {
            border:5px double deepskyblue;
        }
        .login {
            font-family:'Microsoft YaHei';
            margin:auto;
            padding-top:25px;
            padding-left:600px;
        }
        #btn {
            font-family:'Microsoft YaHei';
            margin:auto;
            padding-top:20px;
            padding-left:650px;
        }
    </style>
</head>
<body>
    <div id="main">
        <form id="form1" runat="server">
            <div id="head">
                毕业设计选题系统
            </div>
            <div id="part">
                <div id="username" class="login">
                    用户名:<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </div>
                <div id="password" class="login">
                    密&nbsp;&nbsp; 码:<asp:TextBox ID="txtPassWord" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div id="usertype" class="login">
                    用户类型:<asp:DropDownList ID="ddlUserRole" runat="server" DataSourceID="ObjectDataSource1" DataTextField="RoleName" DataValueField="UID">
                    </asp:DropDownList>
                </div>
                <div id="btn">
                    <asp:Button ID="btnLogin" runat="server" Text="登  录" OnClick="btnLogin_Click" />
                    <asp:Button ID="btnEsc" runat="server" Text="退  出" OnClick="btnEsc_Click" />
                    <asp:Label ID="lbmes" runat="server" ForeColor="Red" Width="57px"></asp:Label>
                </div>
            </div>
            <br />
        </form>
    </div>
</body>
</html>
