<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="MessageDetial.aspx.cs" Inherits="Admin_MessageDetial" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-2 text-center">
                发送人:<asp:Label ID="lblUserName" runat="server" CssClass="control-label"></asp:Label>[<asp:Label ID="lblUserRole" runat="server" CssClass="control-label"></asp:Label>]
            </div>
            <div class="col-lg-6 text-center">
                内容:<asp:Label ID="lblMessageComtents" runat="server" CssClass="control-label"></asp:Label>
            </div>
            <div class="col-lg-4 text-center">
                <asp:Label ID="lblMessageSendTime" runat="server" CssClass="control-label"></asp:Label>
            </div>
        </div>
        <br />
        回复:<asp:Label ID="lblUser" runat="server" CssClass="control-label"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" placeholder="内容"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMessage" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br />
        <div class="btn-group">
            <asp:Button ID="btnReply" runat="server" OnClick="Button1_Click" Text="回复" CssClass="btn" />
            <asp:Button ID="btnCancel" runat="server" OnClick="Button2_Click" Text="取消" CssClass="btn" />
        </div>
    </div>
</asp:Content>

