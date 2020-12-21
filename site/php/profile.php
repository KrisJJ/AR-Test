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
?>

<html>
<head>
    <meta charset="UTF-8">
    <title>Профиль</title>
    <link rel="stylesheet" href="style.css">
    <script>
        function newQuest(){
            document.location.href="create.php";
        }
        function exitAcc(){
            document.location.href="index.php";
        }
    </script>
</head>
<body>
<div class="main">
    <?php
    $name = $_SESSION['name'];
    if($name==null){
        echo('
            <div>Вы вышли из аккаунта</div>
            <div>Войдите в аккаунт, чтобы иметь возможность работать с квестами</div>
            <button onclick="exitAcc()">Войти в аккаунт</button>
        ');
    }
    else{
        echo('<div class="left">     <!-------------------колонка профиля---------------->');
        $sql = "SELECT img_tmp FROM `users` WHERE name='$name'";
        $res = mysqli_query($conn,$sql) or die("Error: ".mysqli_error($conn));
        $row = $res->fetch_array(MYSQLI_ASSOC);
        $img = $row['img_tmp'];
        echo('
                <div class="user_img">
                    <img src="data:image/png;base64,'.base64_encode($img).'" width="200px" class="round">
                </div>
                <div><b>'.$name.'</b></div>
                <div><a href="profile_change.php">Редактировать профиль</a></div>
                <button onclick="exitAcc()">Выйти из аккаунта</button>
            </div>
                <div class="right">     <!-------------------колонка квестов---------------->
                    <div class="head">
                        <p>Мои квесты</p>
                    </div>
                    <div class="logo">
                        <img src="LOGO.png" height="55px" alt="АРГО">
                    </div>
                <div class="list">
        ');
    $creator = $_SESSION['name'];
    $sql = "SELECT * FROM `quests` WHERE creator='$creator'";
    $res = mysqli_query($conn, $sql) or die("Error: ".mysqli_error($conn));
    if(mysqli_num_rows($res)==0){
        echo('<p>Вы еще не создали ни одного квеста</p>
                    <p>Начните прямо сейчас!</p>
                ');
    }
    else{
        echo('
                <div class="stripe0"><b>
                    <div class="pict"></div>
                    <div class="name">Название</div>
                    <div class="long">Дата окончания</div>
                    <div class="text">Описание</div>
                </b></div>
                ');
        while ($row = $res->fetch_assoc()){
            $name = $row['name'];
            $text = $row['text'];
            $img = $row['img_tmp'];
            $date = $row['date'];
            $time = $row['time'];
            $long = $row['longing'];
            $flag = TRUE;
            switch($long){
                case 'Бессрочно':
                    $flag = TRUE;
                    $date = 'Бессрочно';
                    break;
                case '1 неделя':
                    $flag = FALSE;
                    $date = date_create($date);
                    $date = $date->modify('+1 week');
                    break;
                case '2 недели':
                    $flag = FALSE;
                    $date = date_create($date);
                    $date = $date->modify('+2 week');
                    break;
                case '3 недели':
                    $flag = FALSE;
                    $date = date_create($date);
                    $date = $date->modify('+3 week');
                    break;
                case '1 месяц':
                    $flag = FALSE;
                    $date = date_create($date);
                    $date = $date->modify('+1 month');
                    break;
            }

            $curdate = date_create(date('d.m.Y H:i:s'))->modify('+7 hour');
            if($flag==FALSE) {
                $date = $date->format('d.m.Y');
                $setdate = $date.' '.$time;
                $setdate = date_create($setdate);
            }
            if($flag==TRUE||$setdate>$curdate) {
                echo('
                        <div class="stripe">
                            <div class="pict">' . $img . '</div>
                            <div class="name">' . $name . '</div>
                        ');
                if($flag==FALSE){
                    echo('<div class="long">' . $date .', '.$time.'</div>');
                }
                else{
                    echo('<div class="long">' . $date .'</div>');
                }
                echo('
                            <div class="text">' . $text . '</div>
                        </div>
                        ');
            }
        }
    }
    echo('
                <button onclick="newQuest()">Добавить</button>
            </div>
        </div>
    ');
    }
    ?>

</div>
</body>
</html>