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
    <link rel="stylesheet" href="../css/style.css">
    <script>
        let c = 0;
        function newQuest(){
            document.location.href="create.php";
        }
        function exitAcc(){
            document.location.href="index.php";
        }
        function loadMain(){
            document.location.href="profile.php";
        }
        function changeProfile(){
            document.location.href="profile_change.php";
        }
        function openText(x){
            var disp = document.getElementById(x).style.display;
            if(disp=="none"){
                document.getElementById(x).style.display = "block";
            }
            if(disp=="block"){document.getElementById(x).style.display = "none";}
        }
        function delQuest(x){
            if (x==c) {
                let str = "delete.php?id="+x;
                document.location.href=str;
            }
            else {
                c = x;
                alert("Вы точно хотите удалить выбранный квест? Для удаления повторите нажатие на кнопку");
            }
        }
    </script>
</head>
<body>
<div class="main">
    <?php
    $name = $_SESSION['name'];
    if($name==null){
        echo('<div class="list">
                <div style="margin-top:10%; margin-bottom:5%;">Вы вышли из аккаунта<br>
                Войдите в аккаунт, чтобы иметь возможность работать с квестами</div>
                <button onclick="exitAcc()">Войти в аккаунт</button>
            </div>
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
                    <img src="data:meta/png;base64,'.base64_encode($img).'" width="170px" class="round">
                </div>
                <div class="login"><b>'.$name. '</b><br>
                <a onclick="changeProfile()">Редактировать профиль</a></div>
                <button onclick="exitAcc()">Выйти из аккаунта</button>
            </div>
                <div class="right">     <!-------------------колонка квестов---------------->
                    <div class="head">
                        <div class="headimg"><img src="../meta/Profile.png" height="30pt"></div>
                        <div class="headtext">Мои квесты</div>
                    </div>
                    <div class="logo" onclick="loadMain()">
                        <img src="../meta/LOGO.png" height="90%" alt="АРГО">
                    </div>
                <div class="list">
        ');
    $creator = $_SESSION['name'];
    /*$sql = "SELECT `id` FROM `users` WHERE name='$creator'";
        $res = mysqli_query($conn, $sql) or die('Ошибка: ' . mysqli_error($conn));
        $row = $res->fetch_array(MYSQLI_ASSOC);
        $creator = $row['id'];*/
    $sql = "SELECT * FROM `quests` WHERE creator='$creator'";
    $res = mysqli_query($conn, $sql) or die("Error: ".mysqli_error($conn));
    if(mysqli_num_rows($res)==0){
        echo('<div class="emptylist">
                   <p>Вы еще не создали ни одного квеста<br>
                   Начните прямо сейчас!</p>
              </div>
                ');
    }
    else{
        echo('
                <div class="stripe0"><b>
                    <div class="pict"></div>
                    <div class="name">Название</div>
                    <div class="long">Дата завершения</div>
                    <div class="text">Описание</div>
                    <div class="del">Удалить</div>
                </b></div>
                ');
        while ($row = $res->fetch_assoc()){
            $id = $row['id'];
            $name = $row['name'];
            $text = $row['text'];
            $date = $row['date'];
            $time = $row['time'];
            $long = $row['longing'];
            $num = $row['numtags'];
            $flag = TRUE;
            switch($long){
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
                default:
                    $flag = TRUE;
                    $date = NULL;
                    break;
            }

            $curdate = date_create(date('d.m.Y H:i:s'))->modify('+7 hour');
            if($flag==FALSE) {
                $date = $date->format('d.m.Y');
                $setdate = $date.' '.$time;
                $setdate = date_create($setdate);
            }
            if($flag==TRUE||$setdate>$curdate) {
                $sql1 = "SELECT `img_tmp` FROM `quests_cover` WHERE id='$id'";
                $res1 = mysqli_query($conn, $sql1) or die('Ошибка: ' . mysqli_error($conn));
                $row1 = $res1->fetch_array(MYSQLI_ASSOC);
                $img = $row1['img_tmp'];
                echo('
                        <div class="stripe">
                            <div class="pict"><img src="data:meta/png;base64,'.base64_encode($img).'" width="32px" class="round" style="transform:translate(0,-6px)"></div>
                            <div class="name">' . $name . '</div>
                        ');
                if($flag==FALSE){
                    echo('<div class="long">' . $date .', '.$time.'</div>');
                }
                else{
                    echo('<div class="long">Бессрочно</div>');
                }
                echo('
                            <div class="text"><img src="../meta/Down.png" height="20pt" onclick="openText('.$id.')" style="cursor:pointer;"></div>
                            <div class="del"><img src="../meta/Delete.png" height="25pt" onclick="delQuest('.$id.')" style="cursor:pointer; transform:translate(0,-2px)"></div>
                        </div>
                        <div class="annot" id="'.$id.'" style="display:none;">
                            <div>Описание: ' . $text . '</div>
                            <div>Задействовано мест: ' . $num . '</div>
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