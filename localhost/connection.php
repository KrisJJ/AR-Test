<?php
$servername = "localhost";
$username = "root";
$password = "root";
$db = "arbase";
$conn = mysqli_connect($servername, $username, $password, $db);
$conn -> set_charset("utf8");
if (!$conn){
    die("Connection failed: ".mysqli_connect_error());
}
?>