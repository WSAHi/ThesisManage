﻿<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AuditUpLoadTitle.aspx.cs" Inherits="Admin_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    待审核的标题:（点击查看对标题进行审核）<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3"
        DataSourceID="odsTitle" ForeColor="Black" GridLines="Vertical" Width="765px" Height="172px" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
        <FooterStyle BackColor="#CCCCCC" />
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="TID" HeaderText="TID" SortExpression="TID" Visible="False" />
            <asp:BoundField DataField="TitleName" HeaderText="标题" SortExpression="TitleName" />
            <asp:TemplateField HeaderText="描述" SortExpression="Description">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# cutContents(Eval("Description")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="教师" SortExpression="Teacher">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Teacher") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Teacher.TeacherName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Counts" HeaderText="可选人数" SortExpression="Counts">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="HasChooseNum" HeaderText="总人数" SortExpression="HasChooseNum">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="审核状态" SortExpression="State">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("State") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# panduan(Eval("State")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="TID" DataNavigateUrlFormatString="TitleDetial.aspx?TID={0}"
                HeaderText="详细" Text="查看" />
        </Columns>
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <asp:ObjectDataSource ID="odsTitle" runat="server" SelectMethod="GetUnTitleList"
        TypeName="ThesisManage.BLL.TitleManage"></asp:ObjectDataSource>
    <br />
    &nbsp;
</asp:Content>
