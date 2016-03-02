<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ContestEntry.aspx.cs" Inherits="FormSamples_ContestEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="page-header">
        <h1>Contest Entry</h1>
    </div>
    <div class="row col-md-12">
        <blockquote style="font-style: italic">
            This illustrates some simple controls to fill out an entry form for a contest.
        </blockquote>
    </div>
    <div class="row">
        <div class="col-md-6">
            <p>
                Please fill out the following form to enter the contest. This contest is only 
        available to residents in Western Canada.
            </p>
            <fieldset>
                <legend>Entry Form</legend>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="FirstName">First Name</asp:Label>
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>

                <asp:Label ID="Label2" runat="server" AssociatedControlID="LastName">Last Name</asp:Label>
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>

                <asp:Label ID="Label3" runat="server" AssociatedControlID="StreetAddress1">Street Address 1</asp:Label>
                <asp:TextBox ID="StreetAddress1" runat="server"></asp:TextBox>

                <asp:Label ID="Label4" runat="server" AssociatedControlID="StreetAddress2">Street Address 2</asp:Label>
                <asp:TextBox ID="StreetAddress2" runat="server"></asp:TextBox>

                <asp:Label ID="Label5" runat="server" AssociatedControlID="City">City</asp:Label>
                <asp:TextBox ID="City" runat="server"></asp:TextBox>

                <asp:Label ID="Label6" runat="server" AssociatedControlID="Province">Province</asp:Label>
                <asp:DropDownList ID="Province" runat="server">
                    <asp:ListItem>BC</asp:ListItem>
                    <asp:ListItem>AB</asp:ListItem>
                    <asp:ListItem>SK</asp:ListItem>
                    <asp:ListItem>MB</asp:ListItem>
                </asp:DropDownList>

                <asp:Label ID="Label7" runat="server" AssociatedControlID="PostalCode">Postal Code</asp:Label>
                <asp:TextBox ID="PostalCode" runat="server"></asp:TextBox>

                <asp:Label ID="Label8" runat="server" AssociatedControlID="EmailAddress">Email</asp:Label>
                <asp:TextBox ID="EmailAddress" runat="server"></asp:TextBox>

                <asp:Label ID="Label9" runat="server" AssociatedControlID="AgreeToTerms">Terms and Conditions</asp:Label>
                <asp:CheckBox ID="AgreeToTerms" runat="server"
                    Text="I agree to the terms of the contest." />
                <br />
            </fieldset>
            <asp:Button ID="Submit" runat="server" Text="Submit" />
            <p>Note: You must agree to the contest terms in order to be entered.</p>
        </div>
        <div class="col-md-6">
            <asp:Label ID="MessageLabel" runat="server" />
        </div>
    </div>

</asp:Content>

