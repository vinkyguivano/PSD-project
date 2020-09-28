<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="ProductType.aspx.cs" Inherits="PSDAssignment.Views.ProductType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="ProductTable" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Type</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Description</asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="2" CssClass="text-center">Action</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
</asp:Content>
