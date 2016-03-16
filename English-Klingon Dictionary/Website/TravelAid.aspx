<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TravelAid.aspx.cs" Inherits="TravelAid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="page-header">
        <h1>English-Klingon Travel Aid</h1>
    </div>
    <div class="row col-md-12">
        <blockquote>More info here....</blockquote>
    </div>
    <div class="row">
        <div class="col-md-6">
            <p>Use this form to add popular translations.</p>
            <fieldset>
                <legend>Popular Phrases</legend>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="English">English Phrase</asp:Label>
                <asp:TextBox ID="English" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" AssociatedControlID="Klingon">In Klingon</asp:Label>
                <asp:TextBox ID="Klingon" runat="server"></asp:TextBox>
            </fieldset>
            <asp:LinkButton ID="AddPhrase" runat="server" CssClass="btn btn-primary" OnClick="AddPhrase_Click">Add Phrase</asp:LinkButton>
        </div>
        <div class="col-md-6">
            <asp:Label ID="MessageLabel" runat="server" />
            <asp:GridView ID="TranslationGridView" runat="server">
                <EmptyDataTemplate>
                    There are no translations to display
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
    <link href="Content/bootwrap-freecode.css" rel="stylesheet" />
    <script src="Scripts/bootwrap-freecode.js"></script>
</asp:Content>

