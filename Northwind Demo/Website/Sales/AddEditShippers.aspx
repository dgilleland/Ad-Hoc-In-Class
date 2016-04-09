<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddEditShippers.aspx.cs" Inherits="Sales_AddEditShippers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
        <h1 class="page-header">Add/Edit Shipper</h1>
    </div>
    <div class="row">
        <div class="pull-right col-sm-6">
            <fieldset>
                <legend>Form Actions</legend>
            </fieldset>

            <div class="form-inline">
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" CssClass="control-label" Text="Shippers" AssociatedControlID="ExistingShippers"></asp:Label>
                    <asp:DropDownList ID="ExistingShippers" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:LinkButton ID="FetchShipper" runat="server" CssClass="btn btn-primary" CausesValidation="false" OnClick="FetchShipper_Click">Fetch Shipper DEtails</asp:LinkButton>
                </div>
            </div>
            <br />
            <div>
                <asp:LinkButton ID="AddShipper" runat="server" CssClass="btn btn-default" OnClick="AddShipper_Click">Add Shipper</asp:LinkButton>
                <asp:LinkButton ID="UpdateShipper" runat="server" CssClass="btn btn-default" OnClick="UpdateShipper_Click">Update Shipper</asp:LinkButton>
                <asp:LinkButton ID="DeleteShipper" runat="server" CssClass="btn btn-default" OnClick="DeleteShipper_Click">Delete Shipper</asp:LinkButton>
                <asp:LinkButton ID="ClearForm" runat="server" CssClass="btn btn-default" OnClick="ClearForm_Click">Clear Form</asp:LinkButton>
            </div>
            <br />
            <div>
                <asp:Panel ID="MessagePanel" runat="server" role="alert" Visible="false">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <asp:Label ID="MessageLabel" runat="server"></asp:Label>
                </asp:Panel>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CompanyName" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="none" ControlToValidate="CompanyName" ValidationExpression="^[\s\S]{5,40}$" ErrorMessage="Company name must be between 5 and 40 characters long."></asp:RegularExpressionValidator>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Phone" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="none" ControlToValidate="Phone" ValidationExpression="\(\d{3}\) \d{3}-\d{4}" ErrorMessage="Phone number must match the pattern of (###) ###-####."></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="col-sm-6">
            <fieldset>
                <legend>Shipper Details</legend>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="ShipperID">Shipper ID</asp:Label>
                <asp:TextBox ID="ShipperID" runat="server" Enabled="false"></asp:TextBox>

                <asp:Label ID="Label2" runat="server" AssociatedControlID="CompanyName">Company Name</asp:Label>
                <asp:TextBox ID="CompanyName" runat="server"></asp:TextBox>

                <asp:Label ID="Label3" runat="server" AssociatedControlID="Phone">Phone Number</asp:Label>
                <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
            </fieldset>
        </div>
    </div>

    <link href="../Content/bootwrap-freecode.css" rel="stylesheet" />
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>

