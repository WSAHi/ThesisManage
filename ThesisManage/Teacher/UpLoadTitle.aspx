<%@ Page Language="C#" MasterPageFile="~/Teacher/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="UpLoadTitle.aspx.cs" Inherits="Student_UpLoadTitle" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">题目上传</h1>
        <table class="table table-scripted">
            <tr>
                <td>题目：
                </td>
                <td>
                    <asp:TextBox ID="txtTitileName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitileName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>描述：
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>可选人数：
                </td>
                <td>
                    <asp:TextBox ID="txtCanChooseNum" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitileName" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCanChooseNum" ErrorMessage="请输入整数" ValidationExpression="\d"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text=" 提交" CssClass="btn" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnEsc_Click" Text="取消" CssClass="btn" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

