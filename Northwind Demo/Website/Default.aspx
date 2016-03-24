<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <img src="Images/stick_figure_micromanaged_150_wht_9338.gif" class="img-responsive pull-right col-md-2 img-thumbnail" />
        <h1>Northwind Traders <small>Admin Site</small></h1>
        <p class="lead">This site is for performing direct maintenance/adjustments to the Northwind Traders' database.</p>
    </div>

    <div class="row">
        <div class="col-md-8">
            <h2>ERD</h2>
            <img src="Images/Demo-Staffing.png" class="img img-responsive" />
            <h3>Class Diagrams</h3>
            <img src="Images/Region%20Class%20Diagram.png" class="img img-responsive" />
        </div>
        <div class="col-md-4">
            <h2>Notes</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
