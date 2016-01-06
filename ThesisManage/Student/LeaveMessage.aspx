﻿<%@ Page Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="LeaveMessage.aspx.cs" Inherits="Student_LeaveMessage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Label1" runat="server" Text="消息列表"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True">
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
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("MID") %>'
                        CommandName="de">删除</asp:LinkButton>
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
    <table>
        <tr>
            <td>发送消息
            </td>
        </tr>
        <tr>
            <td>角色:<asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="True" GroupName="btn" OnCheckedChanged="RadioButton3_CheckedChanged" Text="管理员" />
                <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" GroupName="btn" OnCheckedChanged="RadioButton1_CheckedChanged" Text="教师" />
                <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" GroupName="btn" OnCheckedChanged="RadioButton2_CheckedChanged" Text="学生" /><br />
                接受人:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>(注：用户名)<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="查看联系人" /><br />
                <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" Visible="False" DataKeyField="TEID" OnItemCommand="DataList1_ItemCommand">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# GetImageUrl(Eval("TEID")) %>' /><br />
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("TeacherName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:DataList>
                <asp:Label ID="Label6" runat="server" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 503px">内 容:<br />
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button2" runat="server" Text="发送" OnClick="Button2_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="重置" OnClick="Button1_Click" /></td>
        </tr>
    </table>
    <br />
    <br />
</asp:Content>

