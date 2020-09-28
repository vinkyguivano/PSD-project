<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="PSDAssignment.Views.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="font-size: large">
        Update Profile<br />
        <br />
        Username
        <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
        <asp:Label ID="NameLabel" runat="server" CssClass="text-danger"></asp:Label>
        <br />
        Email&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="EmailTxt" runat="server"></asp:TextBox>
        <asp:Label ID="EmailLabel" runat="server" CssClass="text-danger"></asp:Label>
        <br />
        <br />
        Gender
        <asp:RadioButtonList ID="GenderList" runat="server" Height="17px" RepeatDirection="Horizontal" Width="219px">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="PasswordBtn" runat="server" CssClass="btn-warning" OnClick="PasswordBtn_Click" Text="Update Password" />
        <br />
        <br />
        <asp:Button ID="BtnSubmit" runat="server" CssClass="btn-primary" OnClick="BtnSubmit_Click" Text="Submit" Width="157px" />
        <br />
    </div>

</asp:Content>
