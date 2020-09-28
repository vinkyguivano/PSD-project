<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="EditProductType.aspx.cs" Inherits="PSDAssignment.Views.EditProductType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="auto-style1">
        Add Product Type</p>
    <div class="text-center">
        Product Type Name<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TypeNameTxts" runat="server" Width="318px"></asp:TextBox>
&nbsp;<asp:Label ID="TypeTxt" runat="server" CssClass="text-danger"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<%--        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TypeNameTxt" CssClass="text-danger" ErrorMessage="Name Must Be More Than 5 Characters"></asp:RangeValidator>--%>
&nbsp;&nbsp;&nbsp;
        <br />
        Product Type Description<br />
        <asp:TextBox ID="TypeDescriptionTxts" runat="server" Width="322px"></asp:TextBox>
        <asp:Label ID="DescLabel" runat="server" ForeColor="Red" CssClass="text-danger"></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnSubmit" runat="server" CssClass="btn-primary" OnClick="BtnEdit_Click" Text="Submit" />
    </div>
</asp:Content>
