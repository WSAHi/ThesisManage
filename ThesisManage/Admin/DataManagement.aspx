<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="DataManagement.aspx.cs" Inherits="Admin_DataManagement" Title="Untitled Page" %>

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
        <h1 class="h1 text-center">添加数据</h1>
        <div class="row">
            <div class="col-lg-4">
                <asp:Label runat="server" Text="单行添加" CssClass="control-label text-right"></asp:Label>
            </div>
            <div class="col-lg-8">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="odsrole" DataTextField="RoleName" DataValueField="UID" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                <asp:ObjectDataSource ID="odsrole" runat="server" SelectMethod="GetUserRole" TypeName="ThesisManage.BLL.UserRoleManage"></asp:ObjectDataSource>
            </div>
        </div>
        <br />
        <div class="form-control panel-group">
            <asp:Panel ID="Panel1" runat="server">
                <div class="row ">
                    <div class="col-lg-3">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="学号"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-3">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="姓名"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-3">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="班级"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-3">
                        <asp:Label ID="Label1" runat="server" Text="添加后的默认密码为：333333" CssClass="control-label"></asp:Label>
                    </div>
                </div>
                <div class="btn-group">
                    <asp:Button ID="BtnOk" runat="server" Text="添加" OnClick="BtnOk_Click" CssClass="btn" />
                    <asp:Button ID="BtnReSet" runat="server" Text="重置" OnClick="BtnReSet_Click" CssClass="btn" />
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <div class="row">
                    <div class="col-lg-4">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="工号"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-4">
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" placeholder="姓名"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-4">
                        <asp:Label ID="Label2" runat="server" Text="添加后的默认密码为：111111" CssClass="control-label"></asp:Label>
                    </div>
                </div>
                <div class="btn-group">
                    <asp:Button ID="btnsubmint" runat="server" Text="添加" OnClick="btnsubmint_Click" CssClass="btn" />
                    <asp:Button ID="btnesc" runat="server" Text="重置" OnClick="btnesc_Click" CssClass="btn" />
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server">
                <div class="row">
                    <div class="col-lg-6">
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control " placeholder="账号"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-lg-6">
                        <asp:Label ID="Label3" runat="server" Text="添加后的默认密码为：222222" CssClass="control-label"></asp:Label>
                    </div>
                </div>
                <div class="btn-group">
                    <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" CssClass="btn" />
                    <asp:Button ID="Button2" runat="server" Text="重置" OnClick="Button2_Click" CssClass="btn" />
                </div>
            </asp:Panel>
        </div>
        <br />
        <br />
        <br />
        <br />
        <div class="form-group">
            <asp:Label runat="server" Text="多行添加（选择Excel文件）" CssClass="control-label"></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" Width="300px " />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="添加" CssClass="btn" />
        </div>
    </div>
</asp:Content>
