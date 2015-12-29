<%@ Page Language="C#" MasterPageFile="~/Teacher/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="StudentList.aspx.cs" Inherits="Teacher_StudentList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="odsthesis" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" Width="642px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
        <Columns>
            <asp:BoundField DataField="ThesisID" HeaderText="ThesisID" SortExpression="ThesisID"
                Visible="False" />
            <asp:TemplateField HeaderText="姓名" SortExpression="Student">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Student") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Student.StudentName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="论文标题" SortExpression="Title">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title.TitleName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="上传时间" SortExpression="PublishDate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PublishDate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("PublishDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFormatString="StudentMessage.aspx?ThesisID={0}" DataNavigateUrlFields="ThesisID"
                HeaderText="详细信息" Text="查看" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ThesisID") %>'
                        Text="下载"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
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
    <asp:ObjectDataSource ID="odsthesis" runat="server" SelectMethod="GetThesisWithOenTeacher"
        TypeName="ThesisManage.BLL.ThesisManage">
        <SelectParameters>
            <asp:SessionParameter Name="TEID" SessionField="TEID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

