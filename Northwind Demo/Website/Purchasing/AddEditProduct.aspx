﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddEditProduct.aspx.cs" Inherits="Purchasing_AddEditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
        <h1 class="page-header">Add/Edit Products</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-inline">
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="Products" AssociatedControlID="CurrentProducts"></asp:Label>
                            <asp:DropDownList ID="CurrentProducts" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:LinkButton ID="ShowProductDetails" runat="server" CssClass="btn btn-primary" CausesValidation="false" OnClick="ShowProductDetails_Click">Show Product Details</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 text-center">
                    <asp:LinkButton ID="AddProduct" runat="server" CssClass="btn btn-default" OnClick="AddProduct_Click">Add Product</asp:LinkButton>
                    <asp:LinkButton ID="UpdateProduct" runat="server" CssClass="btn btn-default" OnClick="UpdateProduct_Click">Update Product</asp:LinkButton>
                    <asp:LinkButton ID="DeleteProduct" runat="server" CssClass="btn btn-default" OnClick="DeleteProduct_Click">Delete Product</asp:LinkButton>
                    <asp:LinkButton ID="ClearForm" runat="server" CssClass="btn btn-default" OnClick="ClearForm_Click">Clear Form</asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="col-sm-12">
            <br />
            <asp:Panel ID="MessagePanel" runat="server" role="alert" Visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <asp:Label ID="MessageLabel" runat="server"></asp:Label>
            </asp:Panel>
        </div>
        <div class="col-md-offset-2 col-md-8">
            <br />
            <fieldset>
                <legend>
                    <asp:Literal ID="LegendTitle" runat="server" Text="Add Product Form" /></legend>
                <asp:Label ID="Label3" runat="server" Text="Product ID" AssociatedControlID="ProductID"></asp:Label>
                <asp:TextBox ID="ProductID" runat="server" Enabled="false"></asp:TextBox>

                <asp:Label ID="Label4" runat="server" Text="Product Name" AssociatedControlID="ProductName"></asp:Label>
                <asp:TextBox ID="ProductName" runat="server"></asp:TextBox>

                <asp:Label ID="Label2" runat="server" Text="Supplier" AssociatedControlID="Supplier"></asp:Label>
                <asp:DropDownList ID="Supplier" runat="server"></asp:DropDownList>

                <asp:Label ID="Label5" runat="server" Text="Category" AssociatedControlID="Category"></asp:Label>
                <asp:DropDownList ID="Category" runat="server"></asp:DropDownList>

                <asp:Label ID="Label6" runat="server" Text="Qty per Unit" AssociatedControlID="QtyPerUnit"></asp:Label>
                <asp:TextBox ID="QtyPerUnit" runat="server"></asp:TextBox>

                <asp:Label ID="Label7" runat="server" Text="Unit Price" AssociatedControlID="UnitPrice"></asp:Label>
                <asp:TextBox ID="UnitPrice" runat="server"></asp:TextBox>

                <asp:Label ID="Label8" runat="server" Text="In Stock" AssociatedControlID="InStock"></asp:Label>
                <asp:TextBox ID="InStock" runat="server"></asp:TextBox>

                <asp:Label ID="Label9" runat="server" Text="On Order" AssociatedControlID="OnOrder"></asp:Label>
                <asp:TextBox ID="OnOrder" runat="server"></asp:TextBox>

                <asp:Label ID="Label10" runat="server" Text="Reorder Level" AssociatedControlID="ReorderLevel"></asp:Label>
                <asp:TextBox ID="ReorderLevel" runat="server"></asp:TextBox>

                <asp:Label ID="Label11" runat="server" Text="Discontinued" AssociatedControlID="Discontinued"></asp:Label>
                <asp:CheckBox ID="Discontinued" runat="server" Text="Product is discontinued"></asp:CheckBox>
            </fieldset>
        </div>
    </div>

    <link href="../Content/bootwrap-freecode.css" rel="stylesheet" />
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>

