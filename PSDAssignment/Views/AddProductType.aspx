<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="AddProductType.aspx.cs" Inherits="PSDAssignment.Views.AddProductType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="auto-style1">
        Add Product Type</p>
    <div class="text-center">
        Product Type Name<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TypeNameTxt" runat="server" Width="318px"></asp:TextBox>
&nbsp;<%--        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TypeNameTxt" CssClass="text-danger" ErrorMessage="Name Must Be More Than 5 Characters"></asp:RangeValidator>--%><asp:Label ID="TypeTxt" runat="server" CssClass="text-danger"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <br />
        Product Type Description<br />
        <asp:TextBox ID="TypeDescriptionTxt" runat="server" Width="322px"></asp:TextBox>
        <asp:Label ID="DescLabel" runat="server" CssClass="text-danger"></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnSubmit" runat="server" CssClass="btn-primary" OnClick="BtnSubmit_Click" Text="Submit" />
    </div>
</asp:Content>
