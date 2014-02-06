<?php
include "vendor/autoload.php";

$books = new Books();
$books->add(new Book("Programming Windows® 8 Apps with HTML, CSS, and JavaScript", "Kraig Brockschmidt", 0));
$books->add(new Book("Mastering Web Application Development with AngularJS", "Pawel Kozlowski", 15.13));
$books->add(new Book("JavaScript: The Good Parts", "Douglas Crockford", 12.65));
//var_dump($books);
//exit();

$app = new \Slim\Slim();
$app->get('/Book/:id', function ($id) use ($books) {
    $book = $books->getBook($id);
    echo $book->getBookInfoJSON();
});

$app->get('/AllBooks', function () use ($books) {
	foreach($books->getAllBooks() as $book) {
	    echo $book->getBookInfoJSON();
	}
});
$app->run();

class Book {
	private $_book;

	function __construct($title, $author, $price) {
		$this->_book = array(
			"Title" => $title,
			"Author" => $author,
			"Price" => $price
			);
		//var_dump($this->_book);
	}

	function getBookInfo() {
		return $this->_book;
	}

	function getBookInfoJSON() {
		return json_encode($this->getBookInfo());
	}
}

class Books {
	private $_books;

	function __construct(array $arg = array()) {
		$this->_books = $arg;
	}

	function add(Book $book) {
		$this->_books[] = $book;
	}

	function getBook($id) {
		if ($id > 0 && $id <= $this->count()) {
			return $this->_books[$id-1];
		} 
	}

	function getAllBooks() {
		return $this->_books;
	}

	function count() {
		return count($this->_books);
	}
}

?>