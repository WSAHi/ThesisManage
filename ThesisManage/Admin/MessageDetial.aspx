<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="MessageDetial.aspx.cs" Inherits="Admin_MessageDetial" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid text-center">
        <div class="row">
            <div class="col-lg-2">
                发送人:<asp:Label ID="Label2" runat="server" CssClass="control-label"></asp:Label>[<asp:Label ID="Label1" runat="server" CssClass="control-label"></asp:Label>]
            </div>
            <div class="col-lg-6 text-center">
                内容:<asp:Label ID="Label3" runat="server" CssClass="control-label"></asp:Label>
            </div>
            <div class="col-lg-4">
                <asp:Label ID="Label4" runat="server" CssClass="control-label"></asp:Label>
            </div>
        </div>
        <br />
        回复:<asp:Label ID="Label5" runat="server" Text="Label" CssClass="control-label"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="内容"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br />
        <div class="btn-group">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="回复" CssClass="btn" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="取消" CssClass="btn" />
        </div>
    </div>
</asp:Content>

