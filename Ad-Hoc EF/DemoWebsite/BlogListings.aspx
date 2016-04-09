<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BlogListings.aspx.cs" Inherits="BlogListings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
        <h1 class="page-header">Blog Listings</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:DropDownList ID="BlogDropDown" runat="server"></asp:DropDownList>
        </div>
    </div>
</asp:Content>

