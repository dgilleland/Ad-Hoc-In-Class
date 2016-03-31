<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HackMePlease.aspx.cs" Inherits="HackMePlease" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
        <h1 class="page-header">Hack Me Please!</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            Enter a customer name:
            <asp:TextBox ID="CustName" runat="server"></asp:TextBox>
            (hint: try the following: <b>hehe';insert into customers(customerid, companyname) values('fart1','gotcha');--</b>)
            <asp:LinkButton ID="HackClick" runat="server" OnClick="HackClick_Click">Search by hack-click</asp:LinkButton>
            <asp:LinkButton ID="SafeClick" runat="server" OnClick="SafeClick_Click">Search by safe-click</asp:LinkButton>
            <asp:GridView ID="SearchResultGV" runat="server"></asp:GridView>
        </div>

    </div>
</asp:Content>

