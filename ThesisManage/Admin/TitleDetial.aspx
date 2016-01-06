<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="TitleDetial.aspx.cs" Inherits="Admin_TitleDetial" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                <div align="center">
                    标题信息
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div align="right">
                    标题名:
                </div>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <div align="right">
                    上传者:
                </div>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td valign="top">
                <div align="right">
                    描述:
                </div>
            </td>
            <td>
                <asp:Label ID="Label8" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td valign="top">
                <div align="right">
                    可选数量:
                </div>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" valign="top">状态:</td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" valign="top">&nbsp;<asp:Label ID="Label5" runat="server" Text="指导老师:"></asp:Label></td>
            <td>
                <asp:Label ID="Label6" runat="server"></asp:Label><br />
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="查看老师" />&nbsp;<br />
                <asp:DataList ID="DataList1" runat="server" DataKeyField="TEID" DataSourceID="odsteacher" OnItemCommand="DataList1_ItemCommand" RepeatColumns="7" RepeatDirection="Horizontal" Width="175px" TabIndex="10" Visible="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# GetImageUrl( Eval("TEID")) %>' Height="50px" Width="43px" /><br />
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("TeacherName") %>' Font-Size="XX-Small" Width="44px"></asp:Label>
                    </ItemTemplate>
                </asp:DataList><asp:ObjectDataSource ID="odsteacher" runat="server" SelectMethod="GetTeacherList" TypeName="ThesisManage.BLL.TeacherManage"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">审核:</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="通过" OnClick="Button1_Click" />&nbsp;
                <asp:Button ID="Button2" runat="server" Text="不通过" OnClick="Button2_Click" />&nbsp;
                <asp:Panel ID="Panel1" runat="server" Visible="False">
                    <table>
                        <tr>
                            <td align="center">请写明原因</td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="Label9" runat="server" Text="原因:"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="提交" />&nbsp;<asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="取消" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top"></td>
            <td></td>
        </tr>
    </table>
</asp:Content>

