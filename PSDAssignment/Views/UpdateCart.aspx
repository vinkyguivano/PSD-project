﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateCart.aspx.cs" Inherits="PSDAssignment.Views.UpdateCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="margin-left:10%">
        Product Name &nbsp; &nbsp; &nbsp; <asp:TextBox ID="ProductNameTxt" runat="server" ReadOnly="true"></asp:TextBox>
        <br />
        Product Price  &nbsp; &nbsp; &nbsp;  &nbsp; <asp:TextBox ID="ProductPriceTxt" runat="server" ReadOnly="true"></asp:TextBox>
        <br />
        Product Stock &nbsp; &nbsp; &nbsp;&nbsp;<asp:TextBox ID="ProductStockTxt" runat="server" ReadOnly="true"></asp:TextBox>
        <br />
        Product Type &nbsp; &nbsp; &nbsp; &nbsp; <asp:TextBox ID="ProductTypeTxt" runat="server" ReadOnly="true"></asp:TextBox>
        <br />
        Quantity&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
          <asp:TextBox ID="QuantityTxt" runat="server" TextMode="Number" ></asp:TextBox>
          <asp:Label ID="ValidateQty" runat="server" CssClass="text-danger"></asp:Label>
       <br />
          <asp:Button ID="BtnUpdateCart" runat="server" CssClass="btn-primary" Text="Update Cart Item" OnClick="BtnUpdate_Click" />
    </div>

</asp:Content>
