<%@ Page Language="C#" MasterPageFile="~/Teacher/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="ModifyMessage.aspx.cs" Inherits="Teacher_ModifyMessage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">教师基本信息修改</h1>
        <table class="table table-scripted">
            <tr>
                <td>教师工号:</td>
                <td>
                    <asp:Label ID="lblTeacherID" runat="server"></asp:Label></td>
                <td>姓名:</td>
                <td>
                    <asp:Label ID="lblTeacherName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>地址:</td>
                <td>
                    <asp:TextBox ID="txtTeacherAddress" runat="server" CssClass="form-control"></asp:TextBox></td>
                <td>联系电话:</td>
                <td>
                    <asp:TextBox ID="txtTeacherPhone" runat="server" CssClass="form-control"></asp:TextBox></td>
            </tr>
            <tr>
                <td>邮箱:</td>
                <td>
                    <asp:TextBox ID="txtTeacherEmail" runat="server" CssClass="form-control"></asp:TextBox></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSubmint" runat="server" OnClick="btnsubmint_Click" Text="提交" CssClass="btn" /></td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnesc_Click" Text="取消" CssClass="btn" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

