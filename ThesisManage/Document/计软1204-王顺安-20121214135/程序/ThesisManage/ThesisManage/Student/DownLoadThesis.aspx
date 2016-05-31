<%@ Page Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="DownLoadThesis.aspx.cs" Inherits="Student_ModifyThesis" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid">
        <h1 class="h1 text-center">论文信息</h1>
        <asp:Panel ID="Panel1" runat="server" CssClass="panel">
            <table class="table table-striped">
                <tr>
                    <td>论文标题
                    </td>
                    <td>指导老师
                    </td>
                    <td>上传时间
                    </td>
                    <td>论文内容
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTeacher" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUploadTime" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton ID="linkbtnDownload" runat="server" OnClick="LinkButton1_Click" CssClass="btn-link"> 下载到本地</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
</asp:Content>

