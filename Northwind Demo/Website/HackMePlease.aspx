<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HackMePlease.aspx.cs" Inherits="HackMePlease" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
        <h1 class="page-header">Hack Me Please!</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Label id="Label1" runat="server" AssociatedControlID="CustName">Enter a customer name:</asp:Label>
                <asp:TextBox ID="CustName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="well">
                (hint: try the following: <code class="h4">hehe';insert into customers(customerid, companyname) values('hacku','gotcha, from Hack University');--</code>)
            </div>
            <asp:LinkButton ID="HackClick" runat="server" CssClass="btn btn-default" OnClick="HackClick_Click"><span class="text-danger glyphicon glyphicon-warning-sign"></span> Search by hack-click</asp:LinkButton>
            <asp:LinkButton ID="SafeClick" runat="server" CssClass="btn btn-default" OnClick="SafeClick_Click"><span class="text-success glyphicon glyphicon-thumbs-up"></span> Search by safe-click</asp:LinkButton>
            <asp:GridView ID="SearchResultGV" runat="server"></asp:GridView>
        </div>
    </div>
</asp:Content>

