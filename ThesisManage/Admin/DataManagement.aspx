<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="DataManagement.aspx.cs" Inherits="Admin_DataManagement" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">添加数据</h1>
        <table class="table table-scriped">
            <tr>
                <td>单行添加</td>
                <td>
                    <table class="table">
                        <tr>
                            <td>角色:<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="odsrole" DataTextField="RoleName" DataValueField="UID" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="form-control">
                            </asp:DropDownList><asp:ObjectDataSource ID="odsrole" runat="server" SelectMethod="GetUserRole" TypeName="ThesisManage.BLL.UserRoleManage"></asp:ObjectDataSource>
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
                                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="学号"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="姓名"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="班级"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="添加后的默认密码为：333333"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="BtnOk" runat="server" Text="添加" OnClick="BtnOk_Click" CssClass="btn" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnReSet" runat="server" Text="重置" OnClick="BtnReSet_Click" CssClass="btn" />
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
                                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="教师工号"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" placeholder="姓名"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="添加后的默认密码为：111111"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnsubmint" runat="server" Text="添加" OnClick="btnsubmint_Click" CssClass="btn" /></td>
                                                <td>
                                                    <asp:Button ID="btnesc" runat="server" Text="重置" OnClick="btnesc_Click" CssClass="btn" /></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel3" runat="server" CssClass="panel">
                                        <table class="table table-scriped">
                                            <tr>
                                                <td>添加管理员帐户</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"placeholder="账号"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="添加后的默认密码为：222222"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" CssClass="btn" /></td>
                                                <td>
                                                    <asp:Button ID="Button2" runat="server" Text="重置" OnClick="Button2_Click" CssClass="btn" /></td>
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
                                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="添加" CssClass="btn" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

