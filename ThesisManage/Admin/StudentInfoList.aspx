<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="StudentInfoList.aspx.cs" Inherits="Admin_AdminTest" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="1" bordercolor="#2e90b0" style="font-family: 楷体_GB2312; width: 640px;">
        <tr>
            <td colspan="2" style="height: 23px">班级:<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource1" DataValueField="StudentClass" DataTextField="StudentClass">
            </asp:DropDownList>&nbsp;&nbsp; 是否选题:<asp:RadioButton ID="RadioButton1" runat="server" GroupName="btn" Text="已选" />&nbsp;<asp:RadioButton
                ID="RadioButton2" runat="server" GroupName="btn" Text="未选" />
                <asp:Button ID="Button2" runat="server" BackColor="#C0FFFF" BorderColor="#C0FFFF"
                    BorderStyle="Ridge" Text="查询" OnClick="Button2_Click" />
                <asp:Button ID="Button3" runat="server" BackColor="#C0FFFF" BorderColor="#C0FFFF"
                    BorderStyle="Ridge" Text="生成Excel" OnClick="Button3_Click" /></td>
        </tr>
        <tr>
            <td colspan="2" height="23">
                <asp:GridView ID="GridView1" runat="server" CellPadding="3" DataSourceID="ObjectDataSource2"
                    ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView1_RowDataBound"
                    Width="630px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="132px">
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

