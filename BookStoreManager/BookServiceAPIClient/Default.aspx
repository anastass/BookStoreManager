<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookServiceAPIClient.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul>
        <li><a href="Books.aspx">Books</a></li>
        <li><a href="http://localhost:14941/api/books">WEB API call: /api/books</a></li>
        <li><a href="http://localhost:14941/api/books/1">WEB API call: /api/books/1</a></li>
    </ul>
</asp:Content>
