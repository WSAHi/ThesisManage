<%@ Page Language="C#" MasterPageFile="~/Teacher/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="LookupTitle.aspx.cs" Inherits="Teacher_LookupTitle" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="odstitlelist" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" CssClass="table table-scripted">
            <Columns>
                <asp:BoundField DataField="TitleID" HeaderText="TitleID" SortExpression="TitleID" Visible="False" />
                <asp:BoundField DataField="TitleName" HeaderText="标题名称" SortExpression="TitleName" />
                <asp:TemplateField HeaderText="描述" SortExpression="Description">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#  cutContents(Eval("Description"))%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Counts" HeaderText="可选人数" SortExpression="Counts">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="HasChooseNum" HeaderText="已选人数" SortExpression="HasChooseNum">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="审核状态" SortExpression="State">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("State") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# panduan( Eval("State")) %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("TitleID") %>'
                            CommandName="de">删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="修改">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("TitleID") %>'
                            CommandName="ed">修改</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odstitlelist" runat="server" SelectMethod="GetTitleListByTeacherId"
            TypeName="ThesisManage.BLL.TitleManage">
            <SelectParameters>
                <asp:Parameter Name="TeacherId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>

