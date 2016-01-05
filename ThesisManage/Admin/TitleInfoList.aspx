<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="TitleInfoList.aspx.cs" Inherits="Admin_TitleInfoList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    选题情况:<asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>--选择--</asp:ListItem>
        <asp:ListItem>已满</asp:ListItem>
        <asp:ListItem>未满</asp:ListItem>
    </asp:DropDownList>
    审核状态:<asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem>--选择--</asp:ListItem>
        <asp:ListItem>通过</asp:ListItem>
        <asp:ListItem>未通过</asp:ListItem>
    </asp:DropDownList>
    指导老师:<asp:TextBox ID="TextBox1" runat="server" Width="111px"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Red" Text="(支持模糊查询)"></asp:Label>
    <asp:Button ID="Button1" runat="server" BackColor="#C0FFFF" BorderColor="#C0FFFF"
        OnClick="Button1_Click" Text="查询" />&nbsp;<asp:Button ID="Button2" runat="server"
            BackColor="#C0FFFF" BorderColor="#C0FFFF" OnClick="Button2_Click" Text="生成Excel" /><br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="3" ForeColor="Black"
        GridLines="Vertical" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" Width="639px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
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
</asp:Content>

