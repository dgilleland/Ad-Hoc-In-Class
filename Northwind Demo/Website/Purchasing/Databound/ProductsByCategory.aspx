<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductsByCategory.aspx.cs" Inherits="Purchasing_Databound_ProductsByCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    .row>h1.page-header
    <div class="row">
        <h1 class="page-header">Products by Category</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            Category
            <asp:DropDownList ID="CategoryDropDown" runat="server" DataSourceID="CategoryDataSource" DataTextField="CategoryName" DataValueField="CategoryID" AppendDataBoundItems="true">
                <asp:ListItem Value="0">[select a category]</asp:ListItem>
            </asp:DropDownList>
            <asp:ObjectDataSource runat="server" ID="CategoryDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllCategories" TypeName="NorthwindSystem.BLL.NorthwindController"></asp:ObjectDataSource>
            <asp:LinkButton ID="Fetch" runat="server" CssClass="btn btn-primary">Get Products</asp:LinkButton>

            <asp:GridView ID="ProductsGridView" runat="server" AutoGenerateColumns="False" DataSourceID="ProductsDataSource">
                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID"></asp:BoundField>
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName"></asp:BoundField>
                    <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" SortExpression="SupplierID"></asp:BoundField>
                    <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" SortExpression="CategoryID"></asp:BoundField>
                    <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="QuantityPerUnit"></asp:BoundField>
                    <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice"></asp:BoundField>
                    <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock"></asp:BoundField>
                    <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder"></asp:BoundField>
                    <asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" SortExpression="ReorderLevel"></asp:BoundField>
                    <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued"></asp:CheckBoxField>
                    <asp:BoundField DataField="LastModified" HeaderText="LastModified" SortExpression="LastModified"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource runat="server" ID="ProductsDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductsByCategory" TypeName="NorthwindSystem.BLL.NorthwindController">
                <SelectParameters>
                    <asp:ControlParameter ControlID="CategoryDropDown" PropertyName="SelectedValue" Name="searchId" Type="Int32"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>

