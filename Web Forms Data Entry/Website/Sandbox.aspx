<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Sandbox.aspx.cs" Inherits="Sandbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="page-header">
        <h1>Sandbox Page</h1>
    </div>
    <div class="row">
        <div class="col-md-6">
            <asp:Label ID="Label1" runat="server">First name:</asp:Label>
            <asp:TextBox ID="FirstName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" AssociatedControlID="LastName">Last name:</asp:Label>
            <asp:TextBox ID="LastName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" AssociatedControlID="Bio">Bio:</asp:Label>
            <asp:TextBox ID="Bio" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>

            <asp:LinkButton ID="Greet" runat="server" CssClass="btn btn-primary" OnClick="Greet_Click">Say Hello</asp:LinkButton>
            <asp:LinkButton ID="WordCount" runat="server" CssClass="btn btn-default" OnClick="WordCount_Click" >Word Count</asp:LinkButton>
        </div>
        <div class="col-md-6">
            <asp:Label ID="Output" runat="server"></asp:Label>
            <asp:Label ID="MessageLabel" CssClass="bg-info" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FooterContent" Runat="Server">
    <h3>Notes:</h3>
    <p>This is where I can takes notes of stuff I want to remember.</p>
</asp:Content>

