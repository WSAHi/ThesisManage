<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="MessageManage.aspx.cs" Inherits="Admin_MessageManage" Title="Untitled Page" %>

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
        <div class="row">
            <h1 class="h1">消息列表</h1>
        </div>
        <div class="row">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="MID" HeaderText="MID" SortExpression="MID" Visible="False" />
                    <asp:TemplateField HeaderText="发送人" SortExpression="Sender">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Sender") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# NameBind(Eval("Sender"),Eval("SenderRole")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="发送人角色" SortExpression="SenderRole" Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("SenderRole") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("SenderRole") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="内容" SortExpression="Contents">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Contents") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# cutContents(Eval("Contents")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MPubDate" HeaderText="发送时间" SortExpression="MPubDate" />
                    <asp:TemplateField HeaderText="阅读否" SortExpression="State">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# panduan(Eval("State")) %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# panduan(Eval("State")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField DataNavigateUrlFields="MID" DataNavigateUrlFormatString="MessageDetial.aspx?MId={0}" HeaderText="详细" Text="查看" />
                    <asp:TemplateField HeaderText="删除">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("MID") %>' CommandName="de">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetStudentMesList" TypeName="ThesisManage.BLL.MessageManage">
                <SelectParameters>
                    <asp:Parameter Name="studentId" Type="Int32" />
                    <asp:Parameter Name="choose" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        <h4 class="h4">消息接收者类型:</h4>
        <div class="row">
            <asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="True" GroupName="btn" OnCheckedChanged="RadioButton3_CheckedChanged" Text="系统消息" />
            <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" GroupName="btn" OnCheckedChanged="RadioButton1_CheckedChanged" Text="教师" />
            <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" GroupName="btn" OnCheckedChanged="RadioButton2_CheckedChanged" Text="学生" />
        </div>
    <div class="row">
        <h4 class="h4">发送消息:</h4>
    </div>
    <div class="row">
        接收人:<asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>(注：用户名)
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="查看联系人" CssClass="btn" />
        <asp:DataList ID="DataList1" runat="server" DataKeyField="TEID" OnItemCommand="DataList1_ItemCommand" RepeatDirection="Horizontal" Visible="False" RepeatColumns="10">
            <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" ImageUrl='<%# GetImageUrl(Eval("TEID")) %>' /><br />
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("TeacherName") %>'></asp:Label>
            </ItemTemplate>
        </asp:DataList><asp:Label ID="Label6" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="Label7" runat="server" Text="教员" Visible="False" CssClass="control-label"></asp:Label>
    </div>
    <div class="row">
        内容:<asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" Width="600px"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="发送" CssClass="btn" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="重置" CssClass="btn" />
    </div>
    </div>
</asp:Content>

