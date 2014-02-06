<?php
class Model {
  function __construct($dbfile) {
    if (!file_exists($dbfile)) $this->init($dbfile);
  }

  private function init($dbfile) {
    try {
      // Create (connect to) SQLite database in file
      $file_db = new PDO('sqlite:' . $dbfile);

      // Set errormode to exceptions
      $file_db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

      // Create table messages
      $file_db->exec("CREATE TABLE IF NOT EXISTS books (
                    id INTEGER PRIMARY KEY, 
                    title TEXT, 
                    author TEXT, 
                    price REAL)");

      // Array with some test data to insert to database             
      $books = array(
        array("title" => "Programming Windows® 8 Apps with HTML, CSS, and JavaScript", 
              "author" => "Kraig Brockschmidt", 
              "price" => 0),
        array("title" => "Mastering Web Application Development with AngularJS", 
              "author" => "Pawel Kozlowski", 
              "price" => 15.13),
        array("title" => "JavaScript: The Good Parts", 
              "author" => "Douglas Crockford", 
              "price" => 12.65)
        );

      // Prepare INSERT statement to SQLite3 file db
      $insert = "INSERT INTO books (title, author, price) VALUES (:title, :author, :price)";
      $stmt = $file_db->prepare($insert);
   
      // Bind parameters to statement variables
      $stmt->bindParam(':title', $title);
      $stmt->bindParam(':author', $author);
      $stmt->bindParam(':price', $price);
   
      // Loop thru all books and execute prepared insert statement
      foreach ($books as $book) {
        // Set values to bound variables
        $title = $book['title'];
        $author = $book['author'];
        $price = $book['price'];
   
        // Execute statement
        $stmt->execute();
      }
      
      // Close file db connection
      $file_db = null;
    }
    catch(PDOException $e) {
      // Print PDOException message
      echo $e->getMessage();
    }
  }
}

$mmodel = new Model("data.sqlite3");