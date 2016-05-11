<%@ Page Language="C#" MasterPageFile="~/Teacher/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="LookupTitle.aspx.cs" Inherits="Teacher_LookupTitle" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" CssClass="table table-scripted">
            <Columns>
                <asp:BoundField DataField="TitleID" HeaderText="TitleID" SortExpression="TitleID" Visible="False" />
                <asp:BoundField DataField="TitleName" HeaderText="课题名称" SortExpression="TitleName" />
                <asp:BoundField DataField="Description" HeaderText="描述" SortExpression="Description"></asp:BoundField>
                <asp:BoundField DataField="Counts" HeaderText="可选总数" SortExpression="Counts"></asp:BoundField>
                <asp:BoundField DataField="HasChooseNum" HeaderText="已选数量" SortExpression="HasChooseNum" />
                <asp:DynamicField DataField="Teacher" HeaderText="教师" />
                <asp:DynamicField DataField="Student" HeaderText="学生" />
                <asp:TemplateField HeaderText="审核状态" SortExpression="State">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("State") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# JudgeState( Eval("State")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("TitleID") %>' CommandName="delete">删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="修改">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("TitleID") %>' CommandName="update">修改</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="GetTitleListByTeacherID" TypeName="ThesisManage.BLL.TitleManage">
            <SelectParameters>
                <asp:Parameter Name="teacherID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>

