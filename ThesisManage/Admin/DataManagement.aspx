<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="DataManagement.aspx.cs" Inherits="Admin_DataManagement" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">添加数据</h1>
        角色:<asp:DropDownList ID="ddlUserRole" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource" DataTextField="RoleName" DataValueField="UID" OnSelectedIndexChanged="ddlUserRole_SelectedIndexChanged" CssClass="form-control">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="GetALLUserRole" TypeName="ThesisManage.BLL.UserRoleManage"></asp:ObjectDataSource>
        <br />
        <div class="panel-group">
            <asp:Panel ID="Panel1" runat="server" CssClass="panel">
                添加学生用户（默认密码：6个3）
                <asp:TextBox ID="txtStudentID" runat="server" CssClass="form-control" placeholder="学号"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStudentID" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtStudentName" runat="server" CssClass="form-control" placeholder="姓名"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtStudentName" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtClass" runat="server" CssClass="form-control" placeholder="班级"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtClass" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Button ID="btnAddStudent" runat="server" Text="添加" OnClick="btnAddStudent_Click" CssClass="form-control" />
                <br />
                <asp:Button ID="btnResetStudent" runat="server" Text="重置" OnClick="btnResetStudent_Click" CssClass="form-control" />
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" CssClass="panel">
                添加教师帐户（默认密码：6个2）
                <asp:TextBox ID="txtTeacherID" runat="server" CssClass="form-control" placeholder="教师工号"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStudentID" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtTeacherName" runat="server" CssClass="form-control" placeholder="姓名"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTeacherName" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Button ID="btnAddTeacher" runat="server" Text="添加" OnClick="btnAddTeacher_Click" CssClass="form-control" />
                <br />
                <asp:Button ID="btnResetTeacher" runat="server" Text="重置" OnClick="btnResetTeacher_Click" CssClass="form-control" />
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server" CssClass="panel">
                添加管理员帐户(默认密码：6个1)
                <asp:TextBox ID="txtAdminID" runat="server" CssClass="form-control" placeholder="账号"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAdminID" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Button ID="btnAddAdmin" runat="server" Text="添加" OnClick="btnAddAdmin_Click" CssClass="form-control" />
                <br />
                <asp:Button ID="btnResetAdmin" runat="server" Text="重置" OnClick="btnResetAdmin_Click" CssClass="form-control" />
            </asp:Panel>
        </div>
        选择Excel文件（批量添加）
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button ID="btnAddLost" runat="server" OnClick="btnAddLost_Click" Text="添加" CssClass="form-control" />
    </div>
</asp:Content>

