<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <img src="Images/stick_figure_micromanaged_150_wht_9338.gif" class="img-responsive pull-right col-md-2 img-thumbnail" />
        <h1>Northwind Traders <small>Admin Site</small></h1>
        <p class="lead">This site is for performing direct maintenance/adjustments to the Northwind Traders' database.</p>
    </div>

    <div class="row">
        <div class="col-md-8">
            <h2>Purchasing</h2>
            <img src="Images/Northwind%20Traders%20-%20Purchasing.png" class="img img-responsive" />
        </div>
        <div class="col-md-4">
            <h2>Notes</h2>
            
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            <h2>Staffing</h2>
            <img src="Images/Northwind%20Traders%20-%20Staffing.png" class="img img-responsive" />
        </div>
        <div class="col-md-4">
            <h2>Notes</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            <h2>Sales</h2>
            <img src="Images/Northwind%20Traders%20-%20Sales.png" class="img img-responsive" />
        </div>
        <div class="col-md-4">
            <h2>Notes</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <h3>Complete Northwind Traders ERD</h3>
            <img src="Images/Northwind%20Traders%20-%20ERD.png" class="img img-responsive" />
        </div>
    </div>
</asp:Content>
