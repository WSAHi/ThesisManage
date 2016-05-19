<%@ Page Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="ChooseTitle.aspx.cs" Inherits="Student_ChooseTitle" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">可选论文题目</h1>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource" kDataKeyNames="TitleID" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="TitleID" HeaderText="TitleID" SortExpression="TitleID" Visible="False" />
                <asp:BoundField DataField="TitleName" HeaderText="课题名称" SortExpression="TitleName" />
                <asp:BoundField DataField="Description" HeaderText="描述" SortExpression="Description" />
                <asp:BoundField DataField="Counts" HeaderText="可选总数" SortExpression="Counts" />
                <asp:BoundField DataField="HasChooseNum" HeaderText="已选数量" SortExpression="HasChooseNum" />
                <asp:HyperLinkField DataNavigateUrlFields="TitleID" DataNavigateUrlFormatString="TitleDetial.aspx?TitleID={0}" HeaderText="详细" Text="查看" />
                <asp:TemplateField HeaderText="选题" ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnChooseTitle" runat="server" Text="选题" CommandArgument='<%# Eval("TitleID") %>' CssClass="btn btn-link" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="GetTitleList" TypeName="ThesisManage.BLL.TitleManage"></asp:ObjectDataSource>
    </div>
</asp:Content>

