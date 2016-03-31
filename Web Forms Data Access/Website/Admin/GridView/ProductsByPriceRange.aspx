<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductsByPriceRange.aspx.cs" Inherits="Admin_GridView_ProductsByPriceRange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
        <h1 class="page-header">Add/Edit Categories</h1>
    </div>
    <div class="row">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="col-md-4">
                <asp:Label ID="MinPriceValue" runat="server" AssociatedControlID="MinPrice" />
                <asp:TextBox ID="MinPrice" runat="server" TextMode="Range" AutoPostBack="true"
                        Text="0" min="0" max="300" step="1" OnTextChanged="MinPrice_TextChanged"></asp:TextBox>
                </div>
                <div class="col-md-4">
                <asp:Label ID="MaxPriceValue" runat="server" AssociatedControlID="MaxPrice" />
                <asp:TextBox ID="MaxPrice" runat="server" TextMode="Range" AutoPostBack="true"
                        Text="300" min="0" max="300" step="1" OnTextChanged="MaxPrice_TextChanged"></asp:TextBox>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="col-md-4">
            <asp:LinkButton ID="LookupProducts" runat="server" CssClass="btn btn-primary" OnClick="LookupProducts_Click">Lookup Products</asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="FoundProducts" runat="server">

            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyEnd" Runat="Server">
</asp:Content>

