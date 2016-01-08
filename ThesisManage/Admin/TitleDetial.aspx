<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="TitleDetial.aspx.cs" Inherits="Admin_TitleDetial" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- 新 Bootstrap 核心 CSS 文件 -->
    <link rel="stylesheet" href="//cdn.bootcss.com/bootstrap/3.3.5/css/bootstrap.min.css" />

    <!-- 可选的Bootstrap主题文件（一般不用引入） -->
    <link rel="stylesheet" href="//cdn.bootcss.com/bootstrap/3.3.5/css/bootstrap-theme.min.css" />

    <!-- jQuery文件。务必在bootstrap.min.js 之前引入 -->
    <script src="//cdn.bootcss.com/jquery/1.11.3/jquery.min.js"></script>

    <!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
    <script src="//cdn.bootcss.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

    <div class="container">
        <h1 class="h1">标题信息</h1>
        <div class="row">
            标题名:<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            上传者:<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            描述:<asp:Label ID="Label8" runat="server"></asp:Label>
            可选数量:<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            状态:<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="row">
            <asp:Label ID="Label5" runat="server" Text="指导老师:"></asp:Label>
            <asp:Label ID="Label6" runat="server"></asp:Label>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="查看老师" />
        </div>
        <div class="row">
            <asp:DataList ID="DataList1" runat="server" DataKeyField="TEID" DataSourceID="odsteacher" OnItemCommand="DataList1_ItemCommand" RepeatColumns="7" RepeatDirection="Horizontal" Width="175px" TabIndex="10" Visible="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# GetImageUrl( Eval("TEID")) %>' /><br />
                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("TeacherName") %>'></asp:Label>
                </ItemTemplate>
            </asp:DataList>
            <asp:ObjectDataSource ID="odsteacher" runat="server" SelectMethod="GetTeacherList" TypeName="ThesisManage.BLL.TeacherManage"></asp:ObjectDataSource>
        </div>
        <h2 class="h2">审核:</h2>
        <div class="row">
            <div class="col-lg-3">
                <asp:Button ID="Button1" runat="server" Text="通过" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="不通过" OnClick="Button2_Click" />
            </div>
            <div class="col-lg-9">
                <asp:Panel ID="Panel1" runat="server" Visible="False" CssClass="panel">
                    <h2 class="h2">请写明原因:</h2>
                    <div class="row">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="提交" CssClass="btn" />
                        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="取消" CssClass="btn" />
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

