<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ModifyPassword.aspx.cs" Inherits="Admin_ModifyPassWord" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid">
        <h1 class="h1">修改密码:</h1>
        <div class="input-group">
            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" CssClass="form-control input" placeholder="原密码"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassWord" ErrorMessage="*"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="form-control input" placeholder="新密码"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassWord" ErrorMessage="*"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtReNewPassword" runat="server" TextMode="Password" CssClass="form-control input" placeholder="确认密码"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReNewPassWord" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassWord" ControlToValidate="txtReNewPassWord" ErrorMessage="CompareValidator">两次输入的密码不一样</asp:CompareValidator>
            <br />
            <br />
            <div class="btn-group">
                <asp:Button ID="btnModify" runat="server" OnClick="btnModify_Click" Text="修改" CssClass="btn" />
            </div>
        </div>
    </div>
</asp:Content>

