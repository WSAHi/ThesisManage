<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AuditUpLoadTitle.aspx.cs" Inherits="Admin_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid">
        <h1 class="h1 text-center">待审核的标题</h1>
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table" DataSourceID="ObjectDataSource">
            <Columns>
                <asp:BoundField DataField="TitleID" HeaderText="TitleID" SortExpression="TitleID" Visible="False" />
                <asp:BoundField DataField="TitleName" HeaderText="课题名称" SortExpression="TitleName" />
                <asp:BoundField DataField="Description" HeaderText="描述" SortExpression="Description" />
                <asp:BoundField DataField="Counts" HeaderText="可选数量" SortExpression="Counts" />
                <asp:TemplateField HeaderText="审核状态" SortExpression="State">
                    <EditItemTemplate>
                        <asp:Label ID="TextBox1" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# JudgeState(Eval("State")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField DataNavigateUrlFields="TitleID" DataNavigateUrlFormatString="TitleDetial.aspx?TitleID={0}" HeaderText="详细" Text="查看" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="GetUnTitleList" TypeName="ThesisManage.BLL.TitleManage"></asp:ObjectDataSource>
    </div>
</asp:Content>

