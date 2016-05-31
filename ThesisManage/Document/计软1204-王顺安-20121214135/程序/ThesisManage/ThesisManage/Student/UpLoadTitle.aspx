<%@ Page Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="UpLoadTitle.aspx.cs" Inherits="Student_UpLoadTitle" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">上传定义题目</h1>
        <br />
        题目：<asp:TextBox ID="txtTitleName" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitleName" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br />
        描述：<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br />
        指导教师:<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource" DataTextField="TeacherName" DataValueField="TEID" CssClass="form-control"></asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="GetTeacherList" TypeName="ThesisManage.BLL.TeacherManage"></asp:ObjectDataSource>
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text=" 提交" CssClass="form-control" />
        <br />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnEsc_Click" Text="取消" CssClass="form-control" />
    </div>
</asp:Content>

