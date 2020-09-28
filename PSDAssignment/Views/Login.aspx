<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PSDAssignment.Views.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style1" style="text-align: center">
        Login</div>
    <div style="text-align: center">
        <br />
        <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
        <br />
        <asp:TextBox ID="EmailTxt" runat="server" Width="396px"></asp:TextBox>
        <asp:Label ID="EmailLabel" runat="server" CssClass="text-danger"></asp:Label>
        <br />
        <br />
        <br />
        Password<br />
        <asp:TextBox ID="PasswordTxt" runat="server" TextMode="Password" Width="364px"></asp:TextBox>
        <asp:Label ID="PasswordLabel" runat="server" CssClass="text-danger"></asp:Label>
        <br />
        <asp:CheckBox ID="CookieBox" runat="server"/>
        <asp:Label ID="Label2" runat="server" Text="Remember Me"></asp:Label>
        <br />
        <asp:Label ID="MessageFailText" runat="server" CssClass="text-danger"></asp:Label>
        <br />
        <asp:Button ID="LoginBtn" runat="server" CssClass="btn-primary" Height="41px" Text="Login" Width="148px" OnClick="Login_Check" />
    </div>
</asp:Content>

