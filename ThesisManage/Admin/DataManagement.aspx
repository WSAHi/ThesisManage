<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="DataManagement.aspx.cs" Inherits="Admin_DataManagement" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">&nbsp;&nbsp;&nbsp;&nbsp; 添加数据</h1>
        <table class="table table-scriped">
            <tr>
                <td>单行添加</td>
                <td>
                    <table class="table table-striped">
                        <tr>
                            <td>角色:<asp:DropDownList ID="ddlUserRole" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource" DataTextField="RoleName" DataValueField="UID" OnSelectedIndexChanged="ddlUserRole_SelectedIndexChanged" CssClass="form-control">
                            </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="GetALLUserRole" TypeName="ThesisManage.BLL.UserRoleManage"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="panel-group">
                                    <asp:Panel ID="Panel1" runat="server" CssClass="panel">
                                        <table class="table table-scriped">
                                            <tr>
                                                <td>添加学生用户
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtStudentID" runat="server" CssClass="form-control" placeholder="学号"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStudentID" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtStudentName" runat="server" CssClass="form-control" placeholder="姓名"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtStudentName" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtClass" runat="server" CssClass="form-control" placeholder="班级"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtClass" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDefaultStudentPassword" runat="server" Text="添加后的默认密码为：333333"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnAddStudent" runat="server" Text="添加" OnClick="btnAddStudent_Click" CssClass="btn" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnResetStudent" runat="server" Text="重置" OnClick="btnResetStudent_Click" CssClass="btn" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel2" runat="server" CssClass="panel">
                                        <table class="table table-scriped">
                                            <tr>
                                                <td>添加教师帐户</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtTeacherID" runat="server" CssClass="form-control" placeholder="教师工号"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTeacherID" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTeacherName" runat="server" CssClass="form-control" placeholder="姓名"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTeacherName" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDefaultTeacherPassword" runat="server" Text="添加后的默认密码为：222222"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnAddTeacher" runat="server" Text="添加" OnClick="btnAddTeacher_Click" CssClass="btn" /></td>
                                                <td>
                                                    <asp:Button ID="btnResetTeacher" runat="server" Text="重置" OnClick="btnResetTeacher_Click" CssClass="btn" /></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel3" runat="server" CssClass="panel">
                                        <table class="table table-scriped">
                                            <tr>
                                                <td>添加管理员帐户</td>
                                            </tr>
                                            <tr>
                                                <td runat="server">
                                                    <asp:TextBox ID="txtAdminID" runat="server" CssClass="form-control" placeholder="账号"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAdminID" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDefaultAdminPassword" runat="server" Text="添加后的默认密码为：111111"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnAddAdmin" runat="server" Text="添加" OnClick="btnAddAdmin_Click" CssClass="btn" /></td>
                                                <td>
                                                    <asp:Button ID="btnResetAdmin" runat="server" Text="重置" OnClick="btnResetAdmin_Click" CssClass="btn" /></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>多行添加
                </td>
                <td>
                    <table class="table table-scriped">
                        <tr>
                            <td>选择Excel文件<asp:FileUpload ID="FileUpload1" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnAddLost" runat="server" OnClick="btnAddLost_Click" Text="添加" CssClass="btn" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

