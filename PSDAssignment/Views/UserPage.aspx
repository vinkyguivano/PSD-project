<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="PSDAssignment.Views.UserPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="UserTable" CssClass="table table-bordered text-center" runat="server">
<asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Email</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Role</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Status</asp:TableHeaderCell>
                </asp:TableHeaderRow>
</asp:Table>
</asp:Content>
