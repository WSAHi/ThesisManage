<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="TeacherInfoList.aspx.cs" Inherits="Admin_TeacherInfoList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    教师姓名:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Red" Text="(支持模糊查询)"></asp:Label>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查询" />&nbsp;
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="生成Excel" /><br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
    </asp:GridView>
</asp:Content>

