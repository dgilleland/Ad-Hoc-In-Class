<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddEditTerritories.aspx.cs" Inherits="Staffing_AddEditTerritories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
        <h1 class="page-header">Add/Edit Territory/Region</h1>
    </div>

    <div class="row">
        <div class="col-md-6">
            <asp:Label ID="Label1" runat="server">Territories</asp:Label>
            <asp:DropDownList ID="TDropDown" runat="server"></asp:DropDownList>
        </div>
    </div>

</asp:Content>

