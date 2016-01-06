<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="DataManagement.aspx.cs" Inherits="Admin_DataManagement" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>添加数据</td>
        </tr>
        <tr>
            <td>单行添加</td>
            <td>
                <table>
                    <tr>
                        <td>角色:<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="odsrole" DataTextField="RoleName" DataValueField="UID" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList><asp:ObjectDataSource ID="odsrole" runat="server" SelectMethod="GetUserRole" TypeName="ThesisManage.BLL.UserRoleManage"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server">
                                <table>
                                    <tr>
                                        <td>添加学生用户
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>学号:</td>
                                        <td>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>姓名:</td>
                                        <td>
                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>班级:</td>
                                        <td>
                                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="添加后的默认密码为：333333"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="BtnOk" runat="server" Text="添加" OnClick="BtnOk_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="BtnReSet" runat="server" Text="重置" OnClick="BtnReSet_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel2" runat="server">
                                <table>
                                    <tr>
                                        <td>添加教员帐户</td>
                                    </tr>
                                    <tr>
                                        <td>教师号:</td>
                                        <td>
                                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>姓名:</td>
                                        <td>
                                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="添加后的默认密码为：111111"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnsubmint" runat="server" Text="添加" OnClick="btnsubmint_Click" /></td>
                                        <td>
                                            <asp:Button ID="btnesc" runat="server" Text="重置" OnClick="btnesc_Click" /></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel3" runat="server">
                                <table>
                                    <tr>
                                        <td>添加管理员帐户</td>
                                    </tr>
                                    <tr>
                                        <td>帐号:</td>
                                        <td runat="server">
                                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="添加后的默认密码为：222222"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" /></td>
                                        <td>
                                            <asp:Button ID="Button2" runat="server" Text="重置" OnClick="Button2_Click" /></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>多行添加

            </td>
            <td>
                <table>
                    <tr>
                        <td>选择Excel文件<asp:FileUpload ID="FileUpload1" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="添加" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

