<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="PSDAssignment.Views.ViewCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Table ID="CartTable" CssClass="table table-bordered text-center" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="text-center">ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Price</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">Quantity</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="text-center">SubTotal</asp:TableHeaderCell>
                    <asp:TableHeaderCell ColumnSpan="2" CssClass="text-center">Action</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <div style="text-align:center">
                <asp:Label ID="validate" runat="server"></asp:Label>         
                <asp:Label ID="Select" runat="server" Text="Select Payment Type"></asp:Label>&nbsp;&nbsp; 
                <asp:DropDownList ID="PaymentTypeList" runat="server"  DataSourceID="SqlDataSource1"  DataTextField="Type" DataValueField="ID"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [ID], [Type] FROM [PaymentTypes]"></asp:SqlDataSource>
                <br />
                <asp:Button ID="CheckoutBtn" CssClass="btn-primary" runat="server" Text="Checkout" OnClick="CheckoutBtn_Click" />
            </div>
</asp:Content>
