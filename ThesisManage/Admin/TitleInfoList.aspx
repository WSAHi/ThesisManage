<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="TitleInfoList.aspx.cs" Inherits="Admin_TitleInfoList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    选题情况:<asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>选择</asp:ListItem>
        <asp:ListItem>已满</asp:ListItem>
        <asp:ListItem>未满</asp:ListItem>
    </asp:DropDownList>
    审核状态:<asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem>选择</asp:ListItem>
        <asp:ListItem>通过</asp:ListItem>
        <asp:ListItem>未通过</asp:ListItem>
    </asp:DropDownList>
    <br />
    指导老师:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Text="(支持模糊查询)"></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查询" />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="生成Excel" /><br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
    </asp:GridView>
</asp:Content>

