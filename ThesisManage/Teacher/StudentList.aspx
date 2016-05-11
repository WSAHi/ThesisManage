<%@ Page Language="C#" MasterPageFile="~/Teacher/TeacherMasterPage.master" AutoEventWireup="true" CodeFile="StudentList.aspx.cs" Inherits="Teacher_StudentList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">学生列表</h1>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" CssClass="table">
            <Columns>
                <asp:DynamicField DataField="Student" HeaderText="姓名" />
                <asp:DynamicField DataField="Title" HeaderText="课题名称" />
                <asp:BoundField DataField="ThesisID" HeaderText="ThesisID" SortExpression="ThesisID" Visible="False" />
                <asp:BoundField DataField="PublishDate" HeaderText="上传时间" SortExpression="PublishDate" />
                <asp:HyperLinkField DataNavigateUrlFormatString="StudentMessage.aspx?ThesisID={0}" DataNavigateUrlFields="ThesisID" HeaderText="详细信息" Text="查看" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ThesisID") %>' Text="下载"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="GetThesisWithTeacher" TypeName="ThesisManage.BLL.ThesisManage">
            <SelectParameters>
                <asp:Parameter Name="titleID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>

