<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="FooterStuff" ContentPlaceHolderID="FooterContent" runat="server">
    &reg; &trade; Dan Gilleland - All Rights Reserved (ha-ha)
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Data Entry with WebForms</h1>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>About This Site</h2>
        </div>
        <div class="col-md-4">
            <h2>Demo Pages</h2>
        </div>
        <div class="col-md-4">
            <h2>Practice</h2>
        </div>
    </div>
</asp:Content>
