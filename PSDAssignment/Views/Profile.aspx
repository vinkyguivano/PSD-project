<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PSDAssignment.Views.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center">
        <asp:Label ID="Label1" runat="server" style="text-align: center; font-size: x-large" Text="My Profile"></asp:Label>
        <br />
        <br />
        Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
        <asp:Label ID="LabelName" runat="server"></asp:Label>
        <br />
        Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;
        <asp:Label ID="LabelEmail" runat="server"></asp:Label>
        <br />
        Gender&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;
        <asp:Label ID="LabelGender" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="BtnEdit" runat="server" CssClass="btn-primary" OnClick="BtnEdit_Click" Text="Update Profile" />
        <br />
    </div>
</asp:Content>
