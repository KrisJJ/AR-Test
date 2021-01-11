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

        }
        let i = 1;
        let intex = document.getElementById(i).value;
        alert(intex);
        /*if(intex!==""){
            let p = document.createElement('p');
            p.innerHTML = "Место №" + i;
            document.form.append(p);
            let d = document.createElement('input');
            d.type = "text";
            d.name = i;
            d.id = i;
            d.placeholder = "Вставьте координаты";
            d.value = "";
            document.form.append(d);
            i += 1;
        }*/
    </script>
</head>
<body>
<div class="main">
<?php
$name = $_SESSION['name'];
$quest = $_SESSION['quest_id'];
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
    $x = 1;
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
        <div class="logo" onclick="loadMain('.$quest.')">
            <img src="../image/LOGO.png" height="90%" alt="АРГО">
        </div>
        <div class="list">
            <div class="coltag">
                <form action="" method="post">
                    <p>Место №'.$x.'</p>
                    <input type="text" name="'.$x.'" id="'.$x.'" placeholder="Вставьте координаты" value="">
                </form>
            </div>
            <div class="colmap">
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