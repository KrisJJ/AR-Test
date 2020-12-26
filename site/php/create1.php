<?php
session_start();
include 'connection.php';
?>

<html>
<head>
    <meta charset="UTF-8">
    <title>Создать квест</title>
    <link rel="stylesheet" href="../css/style.css">
    <script>
        let k = 0;
        function exitAcc(){
            document.location.href="index.php";
        }
        function loadMain(){
            k++;
            if (k%2==1) alert("Выход на главную страницу приведёт к удалению создаваемого квеста. Для перехода на главную страницу повторите нажатие на кнопку")
            else document.location.href="profile.php";
        }
        function changeProfile(){
            document.location.href="profile_change.php";
        }
        function openIntro(){

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
                <div style="margin-bottom: 15px;"><b>'.$name.'</b></div>
                <button onclick="changeProfile()">Редактировать профиль</button>
            <button onclick="exitAcc()">Выйти из аккаунта</button>
            </div>
    <div class="right">
        <div class="head">
            <p>Создать квест</p>
        </div>
        <div class="logo" onclick="loadMain()">
            <img src="../image/LOGO.png" height="90%" alt="АРГО">
        </div>
        <div class="list">
            <div class="col2"></div>
            <div class="col1">
                <!--noindex--><iframe id="map" src="https://bestmaps.ru/map/osm/map/11/43.0877/131.8993" name="iframe" scrolling="auto"></iframe><!--/noindex-->
                <button onclick="openIntro()">Инструкция по использованию карты</button>
            </div>
        </div>
        
    </div>
    ');}
    ?>
</div>
</body>
</html>