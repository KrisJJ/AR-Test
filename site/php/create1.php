<?php
session_start();
include 'connection.php';
?>

<html>
<head>
    <meta charset="UTF-8">
    <title>Создать квест</title>
    <link rel="stylesheet" href="style.css">
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
            </div>
    <div class="right">
        <div class="head">
            <p>Создать квест</p>
        </div>
        <div class="logo">
            <img src="LOGO.png" height="50px" alt="АРГО">
        </div>
        <div class="list">
            <div class="col2"></div>
            <div class="col1">
                <!--noindex--><iframe id="map" src="https://bestmaps.ru/map/osm/map/13/43.0877/131.8993" name="iframe" scrolling="auto"></iframe><!--/noindex-->
                <button>Инструкция по использованию карты</button>
            </div>
        </div>
        
    </div>
    ');}
    ?>
</div>
</body>
</html>