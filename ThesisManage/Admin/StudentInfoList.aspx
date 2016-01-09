<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="StudentInfoList.aspx.cs" Inherits="Admin_AdminTest" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">教师信息</h1>
        <table class="table table-scriped">
            <tr>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource1" DataValueField="StudentClass" DataTextField="StudentClass" CssClass="form-control"></asp:DropDownList>
                    是否选题:<asp:RadioButton ID="RadioButton1" runat="server" GroupName="btn" Text="已选" />
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="btn" Text="未选" />
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="查询" OnClick="Button2_Click" CssClass="btn" />
                    <asp:Button ID="Button3" runat="server" Text="生成Excel" OnClick="Button3_Click" CssClass="btn" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource2" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table"></asp:GridView>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

