﻿<%@ Page Language="C#" MasterPageFile="~/Teacher/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="UpLoadTitle.aspx.cs" Inherits="Student_UpLoadTitle" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="1" bordercolor="#2e90b0" style="font-family: 楷体_GB2312; width: 555px; height: 204px;">
        <tr>
            <td colspan="2" bgcolor="#33ffcc">
                <div align="center">上传自定义题目</div>
            </td>
        </tr>
        <tr>
            <td style="width: 83px">
                <div align="right">题目：</div>
            </td>
            <td style="width: 23px">
                <asp:TextBox ID="txtTitile" runat="server" Width="424px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitile"
                    ErrorMessage="*" Style="position: absolute"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 83px">
                <div align="right">描述：</div>
            </td>
            <td style="width: 23px">
                <asp:TextBox ID="txtDescription" runat="server" Height="116px" TextMode="MultiLine"
                    Width="423px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription"
                    ErrorMessage="*" Style="position: absolute"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 83px">
                <div align="right">
                    可选人数：
                </div>
            </td>
            <td style="width: 23px">
                <asp:TextBox ID="TextBox1" runat="server" Width="28px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitile"
                    ErrorMessage="*" Style="position: absolute"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                    ErrorMessage="请输入整数" Height="12px" Style="position: absolute" ValidationExpression="\d"
                    Width="98px"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 83px; height: 22px">&nbsp;</td>
            <td style="width: 23px; height: 22px;">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text=" 提交" />&nbsp;
        <asp:Button ID="btnEsc" runat="server" OnClick="btnEsc_Click" Style="position: absolute"
            Text="取消" />
            </td>
        </tr>
    </table>
</asp:Content>
