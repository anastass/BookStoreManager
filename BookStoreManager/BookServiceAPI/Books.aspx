<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookServiceAPI.Default" %>

<!DOCTYPE html>
<html>
<head>
    <title></title>
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.1.0.js"></script>
    <script src="Scripts/booksPage.js"></script>
    <script src="Scripts/dataService.js"></script>
    <script>
        $(document).ready(function () {
            booksPage.init();
        });
    </script>
</head>
<body>
    <div class="content-wrapper">
        <button id="GetBooks">Get Books</button>
        &nbsp;&nbsp;
        <button id="InsertBook">Insert Book</button>
        &nbsp;&nbsp;
        <button id="UpdateBook">Update Book</button>
        &nbsp;&nbsp;
        <button id="DeleteBook">Delete Book</button>
        &nbsp;&nbsp;
        <button id="GetBookJSONP">Get Book</button>

        <br />
        <h2>Books:</h2>
        <ul id="BooksContainer"></ul>

        <br />
        <div id="OutputDiv"></div>

        <script>
            dataService.getBooks().done(function (books) {
                var booksHtml = '';
                for (var i = 0; i < books.length; i++) {
                    booksHtml += '<li><a href="' + dataService.getUrlBase() + '/' + books[i].Id + '">' + books[i].Title + ', ' + books[i].Author + ', ' + books[i].Price + '</a>&nbsp;</li>';
                }
                $('#BooksContainer').html(booksHtml);
            });
        </script>
    </div>
</body>
</html>
