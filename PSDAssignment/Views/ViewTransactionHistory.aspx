<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="ViewTransactionHistory.aspx.cs" Inherits="PSDAssignment.Views.ViewTransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Table ID="TransactionHistoryTable" CssClass="table table-bordered text-center" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell CssClass="text-center">Transaction Date</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="text-center">Payment Type</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="text-center">Product Name</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="text-center">Quantity</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="text-center">Subtotal</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="text-center">Action</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>
