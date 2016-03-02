﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CreateBankAccount.aspx.cs" Inherits="FormSamples_CreateBankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="page-header">
        <h1>Create Bank Account</h1>
    </div>
    <div class="row col-md-12">
        <blockquote>
            <i>This illustrates some basic controls for creating a bank account. Note that the page uses the NuGet <a href="https://www.nuget.org/packages/Bootwrap.FreeCode/" target="_blank">BootWrap</a> package to support Bootstrap's recommended rendering for horizontal form controls while leaving the .aspx file un-cluttered from implementing the extra tags/classes needed for <a href="http://getbootstrap.com/css/#forms-horizontal" target="_blank">horizontal forms in Bootstrap</a>.</i>
        </blockquote>
    </div>
    <div class="row">
        <div class="col-md-6">
            <p>
                Fill in the following form and click Submit.
            </p>
            <fieldset class="form-horizontal">
                <legend>New Bank Account</legend>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="AccountHolder">Account Holder</asp:Label>
                <asp:TextBox ID="AccountHolder" runat="server"></asp:TextBox>

                <asp:Label ID="Label2" runat="server" AssociatedControlID="AccountNumber">Account Number</asp:Label>
                <asp:TextBox ID="AccountNumber" runat="server"></asp:TextBox>

                <asp:Label ID="Label3" runat="server" AssociatedControlID="OpeningBalance">Opening Balance</asp:Label>
                <asp:TextBox ID="OpeningBalance" runat="server"></asp:TextBox>

                <asp:Label ID="Label4" runat="server" AssociatedControlID="OverdraftLimit">Overdraft Limit</asp:Label>
                <asp:TextBox ID="OverdraftLimit" runat="server"></asp:TextBox>

                <asp:Label ID="Label5" runat="server" AssociatedControlID="AccountType">Account Type</asp:Label>
                <asp:DropDownList ID="AccountType" runat="server">
                    <asp:ListItem>Chequing</asp:ListItem>
                    <asp:ListItem>Savings</asp:ListItem>
                    <asp:ListItem>Credit</asp:ListItem>
                </asp:DropDownList>
            </fieldset>
            <p>
                <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
            </p>
        </div>
        <div class="col-md-6">
            <asp:Label ID="MessageLabel" runat="server" />
            <div>
                <%--Validation Controls--%>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-warning alert-dismissible" HeaderText="Please fix the following problems before sumitting this form." />
                <asp:RequiredFieldValidator ID="ValidateAccountHolder" runat="server" Display="None"
                    ControlToValidate="AccountHolder" 
                    ErrorMessage="The name of the holder of the account is required."></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="ValidateAccountNumber" runat="server" Display="None"
                    ControlToValidate="AccountNumber" 
                    ErrorMessage="Account numbers must be 10 digits." 
                    ValidationExpression="[1-9]\d{9}?"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="ValidateOpeningBalance" runat="server" Display="None"
                    ControlToValidate="OpeningBalance" 
                    ErrorMessage="Opening Balance must be greater than zero." 
                    ValueToCompare="0" Operator="GreaterThan" Type="Currency"></asp:CompareValidator>
                <asp:CompareValidator ID="ValidateOverdraftLimit" runat="server" Display="None"
                    ControlToValidate="OverdraftLimit" 
                    ErrorMessage="Overdraft Limit must be greater than or equal to zero." 
                    ValueToCompare="0" Operator="GreaterThanEqual" Type="Currency"></asp:CompareValidator>
            </div>
        </div>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>

