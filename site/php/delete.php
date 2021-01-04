<?php
session_start();

include 'connection.php';
$query = "CREATE TABLE IF NOT EXISTS `quests`(
        id INT AUTO_INCREMENT,
        name TEXT,
        text TEXT,
        date DATE,
        time TIME,
        longing TEXT,
        creator TEXT,
        PRIMARY KEY(id)
    )";
$res = mysqli_query($conn, $query) or die("Error: ".mysqli_error($conn));

$id = $_GET['id'];
$query = "DELETE FROM `quests` WHERE id='$id'";
$res = mysqli_query($conn, $query) or die("Error: ".mysqli_error($conn));

$query = "DELETE FROM `quests_cover` WHERE id='$id'";
$res = mysqli_query($conn, $query) or die("Error: ".mysqli_error($conn));

echo('<script>document.location.href="profile.php"</script>');
?>