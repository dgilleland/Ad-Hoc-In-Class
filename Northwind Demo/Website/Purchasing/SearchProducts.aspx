﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SearchProducts.aspx.cs" Inherits="Purchasing_SearchProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    .row>h1.page-header
    <div class="row">
        <h1 class="page-header">Search Products Page</h1>
    </div>
    .row>.col-md-4*3>h3
    <div class="row">
        <div class="col-md-4">
            <h3>Find by Category</h3>
            <asp:DropDownList ID="CategoryDropDown" runat="server"></asp:DropDownList>
            <asp:LinkButton ID="LookupByCategory" runat="server"
                 CssClass="btn btn-default" OnClick="LookupByCategory_Click">Lookup</asp:LinkButton>
        </div>
        <div class="col-md-4">
            <h3>Find by Supplier</h3>
            <asp:DropDownList ID="SupplierDropDown" runat="server"></asp:DropDownList>
            <asp:LinkButton ID="LookupBySupplier" runat="server"
                 CssClass="btn btn-default" OnClick="LookupBySupplier_Click">Lookup</asp:LinkButton>
        </div>
        <div class="col-md-4">
            <h3>Find by Product Name</h3>
        </div>
    </div>
    .row>.col-md-12
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="SearchResultsGridView" runat="server">
                <EmptyDataTemplate>No products for the selected search.</EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

