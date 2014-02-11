<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookServiceAPIClient.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BookServiceAPI</title>
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.1.0.js"></script>
    <script src="Scripts/dataService.js"></script>
</head>
<body>
    <h1>BookServiceAPI</h1>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>

    <ul>
        <li><a href="Books.aspx">Books</a></li>
        <li><a href="http://localhost:14941/api/books">WEB API call: /api/books</a></li>
        <li><a href="http://localhost:14941/api/books/1">WEB API call: /api/books/1</a></li>
    </ul>
</body>
</html>
