<%@ Page Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="StudentMessage.aspx.cs" Inherits="Student_StudentMessage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <h1 class="h1 text-center">个人基本信息</h1>
        <div class=" table-bordered">
            <div class="row">
                <div class="col-lg-6 text-right">
                    学号:<asp:Label ID="lbNum" runat="server" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-6 text-left">
                    姓名:<asp:Label ID="lbName" runat="server" CssClass="control-label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 text-right">
                    班级:<asp:Label ID="lbClass" runat="server" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-6 text-left">
                    地址:<asp:Label ID="lbAddress" runat="server" CssClass="control-label"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 text-right">
                    邮箱:<asp:Label ID="lbEmail" runat="server" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-lg-6 text-left">
                    联系电话:<asp:Label ID="lbPhone" runat="server" CssClass="control-label"></asp:Label>
                </div>
            </div>
            <div class="row text-center">
                是否选题:<asp:Label ID="lbIsChooseTitle" runat="server" CssClass="control-label label-info"></asp:Label>
            </div>
            <div class="row text-center">
                <asp:Label ID="lbTitle" runat="server" Text="标题名称:" CssClass="control-label"></asp:Label>
                <asp:Label ID="lbTitleName" runat="server" CssClass="label-primary"></asp:Label>
            </div>
            <div class="row text-center">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="退选" CssClass="btn" />
            </div>
        </div>
    </div>
</asp:Content>

