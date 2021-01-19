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
        numtags INT,
        tagtype TEXT,
        helptags TEXT,
        geotags TEXT,
        PRIMARY KEY(id)
    )";
$res = mysqli_query($conn, $query) or die("Error: ".mysqli_error($conn));

$query = "CREATE TABLE IF NOT EXISTS `quests_cover`(
        id INT,
        img_tmp MEDIUMBLOB,
        img_name MEDIUMBLOB,
        PRIMARY KEY(id)
    )";
$res = mysqli_query($conn, $query) or die("Error: ".mysqli_error($conn));

$query = "CREATE TABLE IF NOT EXISTS `quests_images`(
        quest_id INT,
        task_id INT,
        img_tmp MEDIUMBLOB,
        img_name MEDIUMBLOB
    )";
$res = mysqli_query($conn, $query) or die("Error: ".mysqli_error($conn));



$id = $_GET['id'];
$query = "DELETE FROM `quests` WHERE id='$id'";
$res = mysqli_query($conn, $query) or die("Error: ".mysqli_error($conn));

$query = "DELETE FROM `quests_cover` WHERE id='$id'";
$res = mysqli_query($conn, $query) or die("Error: ".mysqli_error($conn));

$query = "DELETE FROM `quests_images` WHERE id='$id'";
$res = mysqli_query($conn, $query) or die("Error: ".mysqli_error($conn));

echo('<script>document.location.href="profile.php"</script>');
?>