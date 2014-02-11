/// <reference path="jquery-2.1.0.js" />
var dataService = function () {
    var urlBase = 'http://localhost:14941/api/books',

    getBooks = function () {
        return $.getJSON(urlBase);
    },

    getBook = function (id) {
        return $.getJSON(urlBase + '/' + id);
    },

    getBookJSONP = function (id) {
        return $.getJSON(urlBase + '/' + id + '?callback=?');
    },

    insertBook = function (cust) {
        return $.ajax({
            url: urlBase,
            data: cust,
            type: 'POST'
        });
    },

    updateBook = function (cust) {
        return $.ajax({
            url: urlBase + '/' + cust.ID,
            data: cust,
            type: 'PUT'
        });
    },

    deleteBook = function (id) {
        return $.ajax({
            url: urlBase + '/' + id,
            type: 'DELETE'
        });
    },

    getUrlBase = function () {
        return urlBase;
    };

    return {
        getBooks: getBooks,
        getBook: getBook,
        getBookJSONP: getBookJSONP,
        updateBook: updateBook,
        insertBook: insertBook,
        deleteBook: deleteBook,
        getUrlBase: getUrlBase
    };
}();