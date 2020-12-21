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

$query = "CREATE TABLE IF NOT EXISTS `quests_cover`(
        id INT,
        img_tmp MEDIUMBLOB,
        img_name MEDIUMBLOB,
        PRIMARY KEY(id)
    )";
$res = mysqli_query($conn, $query) or die("Error: ".mysqli_error($conn));
?>

<html>
<head>
    <meta charset="UTF-8">
    <title>Создать квест</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
<div class="main">
    <div class="left">
        <p>
            <?php
            echo($_SESSION['name']);
            ?>
        </p>
    </div>
    <div class="right">
        <div class="head">
            <p>Создать квест</p>
        </div>
        <div class="logo">
            <img src="LOGO.png" height="50px" alt="АРГО">
        </div>
        <div class="list">
            <form action="" method="post">
                <div class="col1">
                    <p>Название</p>
                    <input type="text" name="name" placeholder="Введите название вашего квеста">
                    <p>Описание</p>
                    <input type="text" name="text" placeholder="Введите описание вашего квеста">
                    <p>День</p>
                    <input type="date" name="date">
                    <p>Время начала</p>
                    <input type="time" name="time">
                </div>
                <div class="col2">
                    <p>Обложка</p>
                    <input type="file" name="img" accept="image/*">
                    <input type="checkbox" name="def" checked="true">Выбрать обложку по умолчанию
                    <p>Длительность</p>
                    <input list="long" name="long" value="Бесконечно">
                    <datalist id="long">
                        <option>Бессрочно</option>
                        <option>1 неделя</option>
                        <option>2 недели</option>
                        <option>3 недели</option>
                        <option>1 месяц</option>
                    </datalist>
                    <input type="submit" name="next" value="Дальше">
                </div>
            </form>
            <?php
            if(isset($_POST['next'])){
                $name = $_POST['name'];
                $text = $_POST['text'];
                $date = $_POST['date'];
                $time = $_POST['time'];
                $def = $_POST['def'];
                if($def!=true){
                    $img_name = $_FILES['img']['name'];
                    $img_tmp = addslashes(file_get_contents($_FILES['img']['tmp_name']));
                }
                else{
                    echo('default');
                }
                $long = $_POST['long'];
                $creator = $_SESSION['name'];
                $sql = "INSERT INTO `quests` (id,name,text,date,time,longing,creator) VALUES(
                    id,
                    '$name',
                    '$text',
                    '$date',
                    '$time',
                    '$long',
                    '$creator'
                )";
                $res = mysqli_query($conn, $sql) or die('Ошибка: '.mysqli_error($conn));

                $sql = "SELECT id FROM `quests` ORDER BY `id` DESC LIMIT 1";
                $res = mysqli_query($conn, $sql) or die('Ошибка: '.mysqli_error($conn));
                $row = $res->fetch_array(MYSQLI_ASSOC);
                $id = $row['id'];
                $_SESSION['quest_id'] = $id;

                $sql = "INSERT INTO `quests_cover` (id,img_name,img_tmp) VALUES(
                    '$id',
                    '$img_name',
                    '$img_tmp'
                )";
                $res = mysqli_query($conn, $sql) or die('Ошибка: '.mysqli_error($conn));
                echo('<script>document.location.href="create1.php"</script>');
            }
            ?>
        </div>
    </div>
</div>

</body>
</html>