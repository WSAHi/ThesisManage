<%@ Page Language="C#" MasterPageFile="~/Teacher/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="MessageManage.aspx.cs" Inherits="Teacher_Message" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">消息列表</h1>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" CssClass="table table-scripted">
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
        <div class="container-fluid text-center">
            <table class="table table-striped">
                <tr>
                    <td>发送消息
                    </td>
                </tr>
                <tr>
                    <td>消息接收者类型:<asp:RadioButton ID="radiobtnAdmin" runat="server" AutoPostBack="True" GroupName="btn" OnCheckedChanged="RadioButton3_CheckedChanged" Text="管理员" />
                        <asp:RadioButton ID="radiobtnTeacher" runat="server" AutoPostBack="True" GroupName="btn" OnCheckedChanged="RadioButton1_CheckedChanged" Text="教师" />
                        <asp:RadioButton ID="radiobtnStudent" runat="server" AutoPostBack="True" GroupName="btn" OnCheckedChanged="RadioButton2_CheckedChanged" Text="学生" /><br />
                        <asp:TextBox ID="txtMessageReceiver" runat="server" CssClass="form-control" placeholder="接收人（用户名）"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" placeholder="内容"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="btn-group">
                            <asp:Button ID="btnSend" runat="server" Text="发送" OnClick="Button2_Click" CssClass="btn" />
                            <asp:Button ID="btnReset" runat="server" Text="重置" OnClick="Button1_Click" CssClass="btn" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

