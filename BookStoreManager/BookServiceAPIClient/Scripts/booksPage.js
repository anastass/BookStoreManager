/// <reference path="jquery-2.1.0.js" />
var booksPage = function () {
    var showId = true,
    init = function () {
        $('#GetBooks').click(function () {
            getBooks();
        });

        $('#InsertBook').click(function () {
            insertBook();
        });

        $('#UpdateBook').click(function () {
            updateBook();
        });

        $('#DeleteBook').click(function () {
            deleteBook();
        });

        $('#GetBookJSONP').click(function () {
            getBookJSONP(1);
        });
    },

    getBooks = function () {
        dataService.getBooks().done(function (books) {
            var booksHtml = '';
            for (var i = 0; i < books.length; i++) {
                var msg = (showId ? '[' + books[i].Id + '] ' : '');
                booksHtml += '<li><a href="' + dataService.getUrlBase() + '/' + books[i].Id + '">' + msg +books[i].Title + ', ' + books[i].Author + ', ' + books[i].Price + '</a>&nbsp;</li>';
            }
            $('#BooksContainer').html(booksHtml);
        });
    },

    insertBook = function () {
        //Fake Book data
        var book = {
            ID: 10,
            Title: 'Crashkurs Charttechnik',
            Author: 'Markus Horntrich',
            Price: 13.99
        };
        dataService.insertBook(book)
            .done(function () {
                updateStatus('Inserted Book! Refreshing book list.');
                getBooks();
            }).
            fail(function (jqXHR, textStatus, err) {
                alert('Unable to insert book: ' + textStatus);
            });
    },

    updateBook = function () {
        //Fake Book data
        var book = {
            ID: 10,
            Title: 'Die Sturmkönige',
            Author: 'Kai Meyer',
            Price: 8.49
        };
        dataService.updateBook(book)
          .done(function () {
              updateStatus('Updated Book! Refreshing book list.');
              getBooks();
          })
          .fail(function (jqXHR, textStatus, err) {
              alert('Unable to update book: ' + textStatus);
          });

    },

    deleteBook = function () {
        dataService.deleteBook(10)
        .done(function () {
            updateStatus('Deleted Book! Refreshing book list.');
            getBooks();
        })
        .fail(function (jqXHR, textStatus, err) {
            alert('Unable to delete book: ' + textStatus);
        });
    },

    updateStatus = function (msg) {
        $('#OutputDiv').html(msg);
    },

    getBookJSONP = function (id) {
        dataService.getBookJSONP(id).done(function (book) {
            alert('Book retrieved using JSONP: {Title: "' + book.Title + '", Author: "' + book.Author + '", Price:' + book.Price + '}');
        });
    };

    return {
        init: init,
        getBooks: getBooks // expose getBooks() function
    };

}();