<%@ Page Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="DownLoadThesis.aspx.cs" Inherits="Student_ModifyThesis" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" runat="server">
        <table>
            <tr>
                <td>论文信息
                </td>
            </tr>
            <tr>
                <td>论文标题
                </td>
                <td>指导老师
                </td>
                <td>上传时间
                </td>
                <td>论文内容
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"> 下载到本地</asp:LinkButton>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="Label4" runat="server"></asp:Label>
</asp:Content>

