<?php
session_start();
include 'connection.php';
?>

<html>
<head>
    <meta charset="UTF-8">
    <title>Задать места</title>
    <link rel="stylesheet" href="../css/style.css">
    <script>
        let k = 0;
        let i = 1;
        function exitAcc(){
            document.location.href="index.php";
        }
        function loadMain(q){
            k++;
            if (k%2==1) alert("Выход на главную страницу приведёт к удалению создаваемого квеста. Для перехода на главную страницу повторите нажатие на кнопку")
            else {
                let str = "delete.php?id="+ q;
                document.location.href=str;
            }
        }
        function changeProfile(){
            document.location.href="profile_change.php";
        }
        function openIntro(){
            document.getElementById("coltag").style.display = "none";
            document.getElementById("colmap").style.display = "none";
            document.getElementById("help").style.display = "inline-block";
        }
        function closeIntro(){
            document.getElementById("coltag").style.display = "inline-block";
            document.getElementById("colmap").style.display = "inline-block";
            document.getElementById("help").style.display = "none";
        }
        function moreTags(){
            i += 1;
            let p = document.createElement('p');
            p.innerHTML = "Место №" + i;
            document.getElementById("form").append(p);
            let d = document.createElement('input');
            d.type = "text";
            d.name = i;
            d.id = i;
            d.placeholder = "Вставьте координаты";
            d.value = "";
            document.getElementById("form").append(d);
        }
    </script>
</head>
<body>
<div class="main">
<?php
$name = $_SESSION['name'];
$quest = $_SESSION['quest_id'];
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
    $x = 1;
    echo('
                <div class="user_img">
                    <img src="data:meta/png;base64,'.base64_encode($img).'" width="170px" class="round">
                </div>
                <div class="login"><b>'.$name. '</b><br>
                <a onclick="changeProfile()">Редактировать профиль</a></div>
                <button onclick="exitAcc()">Выйти из аккаунта</button>
            </div>
    <div class="right">
        <div class="head">
            <div class="headimg"><img src="../meta/Create.png" height="30pt"></div>
            <div class="headtext">Задать места</div>
        </div>
        <div class="logo" onclick="loadMain('.$quest. ')">
            <img src="../meta/LOGO.png" height="90%" alt="АРГО">
        </div>
        <div class="list">
            <div id="coltag" style="display:inline-block;">
                <form action="" method="post" id="form">
                    <p>Место №' .$x.'</p>
                    <input type="text" name="'.$x.'" id="'.$x.'" placeholder="Вставьте координаты">
                </form>
                <button onclick="moreTags()">Больше мест</button>
            </div>
            <div id="colmap" style="display:inline-block;">
                <!--noindex--><iframe id="map" src="https://bestmaps.ru/map/osm/map/11/43.0877/131.8993" name="iframe" scrolling="auto"></iframe><!--/noindex-->
                <button onclick="openIntro()" style="padding: 8px 20px;">Инструкция по использованию карты</button>
                <button name="fin" onclick="" form="form">Завершить</button>
            </div>
            <div id="help" style="display:none;">
                <div style="font-size:16pt;">Инструкция по использоваию карты</div>
                <div class="helptext">Для работы с координатами откройте меню карты</div>
                <div><img src="../meta/Help1.jpg" height="100%"></div>
                <div class="helptext">Нажмите на кнопку "Центр карты", для того, чтобы точнее определить координаты места</div>
                <div><img src="../meta/Help2.jpg" height="100%"></div>
                <div class="helptext">Нажмите на кнопку "Lat, Lon:", чтобы скопировать координаты текущего центра карты. После этого вы можете вставить их в поле слева</div>
                <div><img src="../meta/Help3.jpg" height="100%"></div>
                <button onclick="closeIntro()" style="margin-top:10px;">Закрыть инструкцию</button>
            </div>
        </div>
    </div>
    ');}
    if (isset($_POST['fin'])){
        $str = "";
        $num = 0;
        foreach($_POST as $a){
            if(!empty($a)){
                if(preg_match("|^[\d]*\.[\d]*\, [\d]*\.[\d]*$|", $a)){
                    $num += 1;
                    $str = $str.";".$a;
                }
            }
        }
        unset($a);
        $str = substr($str, 1, strlen($str)-1);
        $sql = "UPDATE `quests` SET geotags='$str', numtags='$num' WHERE id='$quest'";
        $res = mysqli_query($conn, $sql) or die('Ошибка: ' . mysqli_error($conn));
        echo('<script>document.location.href="profile.php"</script>');
    }
    ?>
</div>
</body>
</html>