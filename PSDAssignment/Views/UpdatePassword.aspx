<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="PSDAssignment.Views.UpdatePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-size: large">
        Update Password<br />
        <br />
        <span class="auto-style1">Old Password</span>
        <asp:TextBox ID="OldTxt" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label ID="OldPassLbl" runat="server" CssClass="text-danger"></asp:Label>
        <br />
        <br />
        New Password
        <asp:TextBox ID="NewTxt" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label ID="NewPassLbl" runat="server" CssClass="text-danger"></asp:Label>
        <br />
        Confirm Password
        <asp:TextBox ID="ConfirmTxt" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label ID="ConfirmLabel" runat="server" CssClass="text-danger"></asp:Label>
        <br />
        <br />
        <asp:Button ID="SubmitBtn" runat="server" CssClass="btn-warning" Text="Submit" Width="143px" OnClick="SubmitBtn_Click" />
    </div>
</asp:Content>
