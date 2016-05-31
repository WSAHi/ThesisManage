<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="TitleDetial.aspx.cs" Inherits="Admin_TitleDetial" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">标题信息</h1>
        <table class="table table-scriped">
            <tr>
                <td>标题名:
                </td>
                <td>
                    <asp:Label ID="lblTitleName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>上传者:
                </td>
                <td>
                    <asp:Label ID="lblUploader" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>描述:
                </td>
                <td>
                    <asp:Label ID="lblDescription" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>可选数量:
                </td>
                <td>
                    <asp:Label ID="lblCanChooseNum" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>状态:</td>
                <td>
                    <asp:Label ID="lblState" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>指导老师:</td>
                <td>
                    <asp:Label ID="lblTeacher" runat="server"></asp:Label><br />
                </td>
            </tr>
        </table>
        <asp:Button ID="btnPass" runat="server" Text="通过" OnClick="btnPass_Click" CssClass="form-control" />
        <br />
        <br />
        <asp:Button ID="btnUnPass" runat="server" Text="不通过" OnClick="btnUnPass_Click" CssClass="form-control" />
    </div>
</asp:Content>

