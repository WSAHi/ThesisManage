﻿<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ModifyPassword.aspx.cs" Inherits="Admin_ModifyPassWord" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid">
        <h1 class="h1 text-center">修改密码:</h1>
        <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="原密码"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassWord" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="新密码"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassWord" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtReNewPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="确认密码"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReNewPassWord" ErrorMessage="*"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassWord" ControlToValidate="txtReNewPassWord" ErrorMessage="CompareValidator">两次输入的密码不一样</asp:CompareValidator>
        <br />
        <asp:Button ID="btnModify" runat="server" OnClick="btnModify_Click" Text="修改" CssClass="form-control" />
    </div>
</asp:Content>

