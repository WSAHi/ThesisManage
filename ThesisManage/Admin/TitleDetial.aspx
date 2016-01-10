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
            <tr>
                <td>审核:</td>
                <td>
                    <asp:Button ID="btnPass" runat="server" Text="通过" OnClick="Button1_Click" CssClass="btn" />
                    <asp:Button ID="btnUnPass" runat="server" Text="不通过" OnClick="Button2_Click" CssClass="btn" />
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <table class="table table-scriped">
                            <tr>
                                <td>请写明原因</td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:TextBox ID="txtReason" runat="server" CssClass="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="btnSubmit" runat="server" OnClick="Button4_Click" Text="提交" CssClass="btn" />
                                    <asp:Button ID="btnCancel" runat="server" OnClick="Button5_Click" Text="取消" CssClass="btn" /></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

