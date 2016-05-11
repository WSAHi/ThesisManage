<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="StudentInfoList.aspx.cs" Inherits="Admin_AdminTest" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">学生信息</h1>
        <asp:DropDownList ID="ddlTeacher" runat="server" DataSourceID="ObjectDataSource" DataValueField="StudentClass" DataTextField="StudentClass" CssClass="form-control"></asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="GetAllClass" TypeName="ThesisManage.BLL.StudentManage"></asp:ObjectDataSource>
        <br />
        <asp:DropDownList ID="ddlISOrNOChooseTitle" runat="server" CssClass="form-control">
            <asp:ListItem>是否选题</asp:ListItem>
            <asp:ListItem Value="1">已选</asp:ListItem>
            <asp:ListItem Value="0">未选</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" CssClass="form-control" />
        <br />
        <asp:Button ID="btnExcel" runat="server" Text="生成Excel" OnClick="btnExcel_Click" CssClass="form-control" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-scripted"></asp:GridView>
    </div>
</asp:Content>

