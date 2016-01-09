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

    <div class="container-fluid">
        <h1 class="h1 text-center">标题信息</h1>
        <div class="text-center">
            标题名:<asp:Label ID="Label1" runat="server" Text="Label" CssClass="control-label"></asp:Label>
            上传者:<asp:Label ID="Label2" runat="server" Text="Label" CssClass="control-label"></asp:Label>
            描述:<asp:Label ID="Label8" runat="server" CssClass="control-label"></asp:Label>
            可选数量:<asp:Label ID="Label3" runat="server" Text="Label" CssClass="control-label"></asp:Label>
            状态:<asp:Label ID="Label4" runat="server" Text="Label" CssClass="control-label"></asp:Label>
        </div>
        <div class="text-center">
            <asp:Label ID="Label5" runat="server" Text="指导老师:" CssClass="control-label"></asp:Label>
            <asp:Label ID="Label6" runat="server" CssClass="control-label"></asp:Label>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="查看老师" CssClass="btn" />
        </div>
        <div class="text-center">
            <asp:DataList ID="DataList1" runat="server" DataKeyField="TEID" DataSourceID="odsteacher" OnItemCommand="DataList1_ItemCommand" RepeatColumns="7" RepeatDirection="Horizontal" Width="175px" TabIndex="10" Visible="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# GetImageUrl( Eval("TEID")) %>' /><br />
                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("TeacherName") %>'></asp:Label>
                </ItemTemplate>
            </asp:DataList>
            <asp:ObjectDataSource ID="odsteacher" runat="server" SelectMethod="GetTeacherList" TypeName="ThesisManage.BLL.TeacherManage"></asp:ObjectDataSource>
        </div>
        <h4 class="h4">审核:</h4>
        <div class="btn-group">
            <asp:Button ID="Button1" runat="server" Text="通过" OnClick="Button1_Click" CssClass="btn" />
            <asp:Button ID="Button2" runat="server" Text="不通过" OnClick="Button2_Click" CssClass="btn" />
        </div>
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" Visible="False" CssClass="panel">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="请写明原因"></asp:TextBox>
            <br />
            <br />
            <div class="btn-group">
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="提交" CssClass="btn" />
                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="取消" CssClass="btn" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>

