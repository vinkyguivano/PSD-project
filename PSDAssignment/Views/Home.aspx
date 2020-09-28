<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PSDAssignment.Views.Home1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="ProductTable" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Price</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Stock</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Type</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Actions</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
</asp:Content>
