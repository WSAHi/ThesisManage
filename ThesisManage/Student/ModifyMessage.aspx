<%@ Page Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="ModifyMessage.aspx.cs" Inherits="Student_ModifyMessage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">学生个人信息修改</h1>
        <table class="table table-striped">
            <tr>
                <td>学号:</td>
                <td>
                    <asp:Label ID="lbNum" runat="server"></asp:Label></td>
                <td>姓名:</td>
                <td>
                    <asp:Label ID="lbName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>班级:</td>
                <td>
                    <asp:Label ID="lbClass" runat="server"></asp:Label></td>
                <td>地址:</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox></td>
            </tr>
            <tr>
                <td>邮箱:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox></td>
                <td>联系电话:</td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox></td>
            </tr>
            <tr>
                <td>是否选题:</td>
                <td>
                    <asp:Label ID="lbIsChooseTitle" runat="server"></asp:Label></td>
                <td>
                    <asp:Label ID="lbTitle" runat="server" Text="标题名称:"></asp:Label></td>
                <td>
                    <asp:Label ID="lbTitleName" runat="server"></asp:Label></td>
            </tr>
        </table>
        <div class="btn-group text-center">
            <asp:Button ID="btnSave" runat="server" OnClick="BtnOk_Click" Text="保存" CssClass="btn" />
            <asp:Button ID="btnReset" runat="server" OnClick="BtnReSet_Click" Text="重置" CssClass="btn" />
        </div>
    </div>
</asp:Content>

