<%@ Page Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="TitleDetial.aspx.cs" Inherits="Student_TitleDetial" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">标题信息</h1>
        <table class="table table-striped">
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
                <td>已选数量</td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="lblHasChooseNum"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="指导老师:"></asp:Label></td>
                <td>
                    <asp:Label ID="lblTeacher" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnChoose" runat="server" OnClick="btnChoose_Click" Text="选题" CssClass="btn center-block" />
    </div>
</asp:Content>

