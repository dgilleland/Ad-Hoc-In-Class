<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddEditOrders.aspx.cs" Inherits="Sales_AddEditOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
        <h1 class="page-header">Add/Edit Order</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-inline">
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="Orders" AssociatedControlID="CurrentOrders"></asp:Label>
                            <asp:DropDownList ID="CurrentOrders" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:LinkButton ID="ShowOrderDetails" runat="server" CssClass="btn btn-primary" CausesValidation="false" OnClick="ShowOrderDetails_Click">Show Order Summary Information</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 text-center">
                    <asp:LinkButton ID="AddOrder" runat="server" CssClass="btn btn-default" OnClick="AddOrder_Click">Add Order</asp:LinkButton>
                    <asp:LinkButton ID="UpdateOrder" runat="server" CssClass="btn btn-default" OnClick="UpdateOrder_Click">Update Order</asp:LinkButton>
                    <asp:LinkButton ID="DeleteOrder" runat="server" CssClass="btn btn-default" OnClick="DeleteOrder_Click">Delete Order</asp:LinkButton>
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
                <legend>Order Summary Information</legend>
                <asp:Label ID="Label3" runat="server" Text="Order ID" AssociatedControlID="OrderID"></asp:Label>
                <asp:TextBox ID="OrderID" runat="server" Enabled="false"></asp:TextBox>

                <asp:Label ID="Label2" runat="server" Text="Customer" AssociatedControlID="CustomerDropDown"></asp:Label>
                <asp:DropDownList ID="CustomerDropDown" runat="server"></asp:DropDownList>

                <asp:Label ID="Label5" runat="server" Text="Employee" AssociatedControlID="EmployeeDropDown"></asp:Label>
                <asp:DropDownList ID="EmployeeDropDown" runat="server"></asp:DropDownList>

                <asp:Label ID="Label4" runat="server" Text="Order Date" AssociatedControlID="OrderDate"></asp:Label>
                <asp:TextBox ID="OrderDate" runat="server"></asp:TextBox>

                <asp:Label ID="Label12" runat="server" Text="Order Date" AssociatedControlID="RequiredDate"></asp:Label>
                <asp:TextBox ID="RequiredDate" runat="server"></asp:TextBox>

                <asp:Label ID="Label13" runat="server" Text="Order Date" AssociatedControlID="ShippedDate"></asp:Label>
                <asp:TextBox ID="ShippedDate" runat="server"></asp:TextBox>

                <asp:Label ID="Label6" runat="server" Text="Last Modified Date" AssociatedControlID="LastModified"></asp:Label>
                <asp:TextBox ID="LastModified" runat="server" Enabled="false"></asp:TextBox>
            </fieldset>

            <fieldset>
                <legend>Order Delivery Information</legend>
                <asp:Label ID="Label14" runat="server" Text="Ship Via" AssociatedControlID="ShippersDropDown"></asp:Label>
                <asp:DropDownList ID="ShippersDropDown" runat="server"></asp:DropDownList>

                <asp:Label ID="Label7" runat="server" Text="Freight Price" AssociatedControlID="FreightPrice"></asp:Label>
                <asp:TextBox ID="FreightPrice" runat="server"></asp:TextBox>

                <asp:Label ID="Label8" runat="server" Text="Ship To" AssociatedControlID="ShipToName"></asp:Label>
                <asp:TextBox ID="ShipToName" runat="server"></asp:TextBox>

                <asp:Label ID="Label9" runat="server" Text="Destination Address" AssociatedControlID="DestinationAddress"></asp:Label>
                <asp:TextBox ID="DestinationAddress" runat="server"></asp:TextBox>

                <asp:Label ID="Label10" runat="server" Text="City" AssociatedControlID="DestinationCity"></asp:Label>
                <asp:TextBox ID="DestinationCity" runat="server"></asp:TextBox>

                <asp:Label ID="Label15" runat="server" Text="Region" AssociatedControlID="DestinationRegion"></asp:Label>
                <asp:TextBox ID="DestinationRegion" runat="server"></asp:TextBox>

                <asp:Label ID="Label16" runat="server" Text="Postal Code" AssociatedControlID="DestinationPostalCode"></asp:Label>
                <asp:TextBox ID="DestinationPostalCode" runat="server"></asp:TextBox>

                <asp:Label ID="Label17" runat="server" Text="Country" AssociatedControlID="DestinationCountry"></asp:Label>
                <asp:TextBox ID="DestinationCountry" runat="server"></asp:TextBox>
            </fieldset>
        </div>
    </div>

    <link href="../Content/bootwrap-freecode.css" rel="stylesheet" />
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>

