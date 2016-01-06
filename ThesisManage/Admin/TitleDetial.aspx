<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="TitleDetial.aspx.cs" Inherits="Admin_TitleDetial" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>标题信息
            </td>
        </tr>
        <tr>
            <td>标题名:
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>上传者:
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>描述:
            </td>
            <td>
                <asp:Label ID="Label8" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>可选数量:
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>状态:</td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="指导老师:"></asp:Label></td>
            <td>
                <asp:Label ID="Label6" runat="server"></asp:Label><br />
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="查看老师" /><br />
                <asp:DataList ID="DataList1" runat="server" DataKeyField="TEID" DataSourceID="odsteacher" OnItemCommand="DataList1_ItemCommand" RepeatColumns="7" RepeatDirection="Horizontal" Width="175px" TabIndex="10" Visible="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# GetImageUrl( Eval("TEID")) %>' /><br />
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("TeacherName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:DataList><asp:ObjectDataSource ID="odsteacher" runat="server" SelectMethod="GetTeacherList" TypeName="ThesisManage.BLL.TeacherManage"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>审核:</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="通过" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="不通过" OnClick="Button2_Click" />
                <asp:Panel ID="Panel1" runat="server" Visible="False">
                    <table>
                        <tr>
                            <td>请写明原因</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="原因:"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="提交" />
                                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="取消" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

