<%@ Page Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="ModifyMessage.aspx.cs" Inherits="Student_ModifyMessage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>学生个人信息修改
            </td>
        </tr>
        <tr>
            <td>学号:</td>
            <td>
                <asp:Label ID="lbNum" runat="server"></asp:Label></td>
            <td>姓名:</td>
            <td>
                <asp:Label ID="lbName" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>班级:</td>
            <td>
                <asp:Label ID="lbClass" runat="server"></asp:Label></td>
            <td>地址:</td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>邮箱:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            <td>联系电话:</td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>是否选题:</td>
            <td>
                <asp:Label ID="lbIsChooseTitle" runat="server"></asp:Label></td>
            <td>
                <asp:Label ID="lbTitle" runat="server" Text="标题名称:"></asp:Label></td>
            <td>
                <asp:Label ID="lbTitleName" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="BtnOk" runat="server" OnClick="BtnOk_Click" Text="保存" /></td>
            <td>
                <asp:Button ID="BtnReSet" runat="server" OnClick="BtnReSet_Click" Text="重置" /></td>
        </tr>
    </table>
</asp:Content>

