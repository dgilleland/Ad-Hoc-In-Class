﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Sales_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="jumbotron">
        <img src="/Images/stick_figure_scuba_150_wht_8770.gif" class="img-responsive pull-right col-md-2 img-thumbnail" />
        <h1>Northwind Traders <small>Admin Site</small></h1>
        <p class="lead">This site is for performing direct maintenance/adjustments to the Northwind Traders' database.</p>
    </div>

    <div class="row">
        <div class="col-md-8">
            <h2>Sales</h2>
            <img src="/Images/Northwind%20Traders%20-%20Sales.png" class="img img-responsive" />
        </div>
        <div class="col-md-4">
            <h2>Notes</h2>
            <p>Create CRUD maintenance forms for the Shippers and Orders tables. The forms are already created for you, but you will need to create the Entity classes and add appropriate code to the BLL class(es). You should ensure that at least one of the drop-down lists on the Orders form is populated via an ObjectDataSource control. All other page functionality must be done as code-behind.</p>
            <p>For the EmployeeID in the Orders table, you can use the data from the NuGet package <a href="https://www.nuget.org/packages/NWDemo.FreeCode/" target="_blank">NWDemo.FreeCode</a>. Here is a sample DropDownList showing this data.</p>
            <asp:DropDownList ID="DemoEmployeeDropDown" runat="server" DataSourceID="EmployeeDataSource" DataTextField="Text" DataValueField="Key"></asp:DropDownList>
            <asp:ObjectDataSource runat="server" ID="EmployeeDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListEmployeeIds" TypeName="NWDemoFreeCode.RelatedTableController"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
