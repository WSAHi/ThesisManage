<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="TitleInfoList.aspx.cs" Inherits="Admin_TitleInfoList" Title="Untitled Page" %>

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
        <br />
        <div class="row">
            <div class="col-lg-3">
                <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                    <asp:ListItem>选课情况</asp:ListItem>
                    <asp:ListItem>已满</asp:ListItem>
                    <asp:ListItem>未满</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-3">
                <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                    <asp:ListItem>审核状态</asp:ListItem>
                    <asp:ListItem>通过</asp:ListItem>
                    <asp:ListItem>未通过</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-4">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="指导老师，支持模糊查询" required></asp:TextBox>
            </div>
        </div>
        <span>
            <br />
        </span>
        <div class="row">
            <div class="col-lg-5">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查询" CssClass="form-control btn-info" />
            </div>
            <div class="col-lg-5">
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="生成Excel" CssClass="form-control btn-info" /><br />
            </div>
        </div>
    </div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" CssClass="table-bordered col-lg-10 right">
    </asp:GridView>
</asp:Content>

