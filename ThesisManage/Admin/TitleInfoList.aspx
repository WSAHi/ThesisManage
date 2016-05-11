<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="TitleInfoList.aspx.cs" Inherits="Admin_TitleInfoList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid">
        <h1 class="h1 text-center">标题信息</h1>
        <asp:DropDownList ID="ddlTitleISCanOrNoChoose" runat="server" CssClass="form-control">
            <asp:ListItem>题目是否选满</asp:ListItem>
            <asp:ListItem>已满</asp:ListItem>
            <asp:ListItem>未满</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control">
            <asp:ListItem>审核状态</asp:ListItem>
            <asp:ListItem>通过</asp:ListItem>
            <asp:ListItem>未通过</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:TextBox ID="txtTeacher" runat="server" CssClass="form-control" placeholder="指导老师，支持模糊查询"></asp:TextBox>
        <br />
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查询" CssClass="form-control" />
        <br />
        <asp:Button ID="btnExcel" runat="server" OnClick="btnExcel_Click" Text="生成Excel" CssClass="form-control" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table"></asp:GridView>
    </div>
</asp:Content>

