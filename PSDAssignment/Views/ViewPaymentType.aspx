<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="ViewPaymentType.aspx.cs" Inherits="PSDAssignment.Views.ViewPaymentType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="PaymentTypeTable" CssClass="table table-bordered text-center" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell CssClass="text-center">ID</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="text-center">Type</asp:TableHeaderCell>
            <asp:TableHeaderCell ColumnSpan="2" CssClass="text-center">Action</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <br/>
    <div style="text-align: center">
        <asp:Button ID="Btn_Insert" runat="server" CssClass="btn-primary" Height="41px" Width="200px" Text="Insert Payment Type" OnClick="Btn_Insert_Click" />
    </div>
</asp:Content>
