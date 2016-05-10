<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="StudentInfoList.aspx.cs" Inherits="Admin_AdminTest" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">学生信息</h1>
        <table class="table table-scriped">
            <tr>
                <td>
                    <asp:DropDownList ID="ddlTeacher" runat="server" DataSourceID="ObjectDataSource1" DataValueField="StudentClass" DataTextField="StudentClass" CssClass="form-control"></asp:DropDownList>
                    <br />
                    <asp:DropDownList ID="ddlISOrNOChooseTitle" runat="server" CssClass="form-control">
                        <asp:ListItem>是否选题</asp:ListItem>
                        <asp:ListItem Value="1">已选</asp:ListItem>
                        <asp:ListItem Value="0">未选</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <div class="btn-group">
                        <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" CssClass="btn" />
                        <asp:Button ID="btnExcel" runat="server" Text="生成Excel" OnClick="btnExcel_Click" CssClass="btn" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-scripted"></asp:GridView>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

