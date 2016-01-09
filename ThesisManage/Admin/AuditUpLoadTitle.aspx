<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AuditUpLoadTitle.aspx.cs" Inherits="Admin_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- 新 Bootstrap 核心 CSS 文件 -->
    <link rel="stylesheet" href="//cdn.bootcss.com/bootstrap/3.3.5/css/bootstrap.min.css" />

    <!-- 可选的Bootstrap主题文件（一般不用引入） -->
    <link rel="stylesheet" href="//cdn.bootcss.com/bootstrap/3.3.5/css/bootstrap-theme.min.css" />

    <!-- jQuery文件。务必在bootstrap.min.js 之前引入 -->
    <script src="//cdn.bootcss.com/jquery/1.11.3/jquery.min.js"></script>

    <!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
    <script src="//cdn.bootcss.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <div class="container-fluid">
        <div class="text-center">
            <h1 class="h1">待审核的标题:（点击查看对标题进行审核）</h1>
        </div>
        <div class="row">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="odsTitle" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" CssClass="table">
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
                    <asp:HyperLinkField DataNavigateUrlFields="TID" DataNavigateUrlFormatString="TitleDetial.aspx?TID={0}" HeaderText="详细" Text="查看" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsTitle" runat="server" SelectMethod="GetUnTitleList" TypeName="ThesisManage.BLL.TitleManage"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>

