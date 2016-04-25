﻿<%@ Page Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="UpLoadTitle.aspx.cs" Inherits="Student_UpLoadTitle" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">上传定义题目</h1>
        <table class="table table-scriped">
            <tr>
                <td>题目：
                </td>
                <td>
                    <asp:TextBox ID="txtTitleName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitleName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>描述：
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    指导教师:
                </td>
                <td>

                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="obsTeacher" DataTextField="TeacherName" DataValueField="TEID" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="obsTeacher" runat="server" SelectMethod="GetTeacherList" TypeName="ThesisManage.BLL.TeacherManage"></asp:ObjectDataSource>

                </td>
            </tr>
            <tr>
                <td>
                    <div class="btn-group">
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text=" 提交"  CssClass="btn"/>
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnEsc_Click" Text="取消" CssClass="btn" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

