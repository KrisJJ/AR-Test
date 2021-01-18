<?php
session_start();
include 'connection.php';

$query = "CREATE TABLE IF NOT EXISTS `quests_images`(
        quest_id INT,
        task_id INT,
        img_tmp MEDIUMBLOB,
        img_name MEDIUMBLOB
    )";
$res = mysqli_query($conn, $query) or die("Error: ".mysqli_error($conn));
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
            let t = document.createElement('textarea');
            t.name = "t"+i;
            t.id = "t"+i;
            t.cols = 21;
            t.rows= 4;
            t.placeholder = "Введите подсказку к нахождению места";
            t.style.resize = "none";
            document.getElementById("form").append(t);
            let div = document.createElement('div');
            div.id = "div"+i;
            div.classList.add("tagfile");
            document.getElementById("form").append(div);
            let img = document.createElement('input');
            img.type = "file";
            img.name = "i"+i;
            img.id = "i"+i;
            t.cols = 21;
            img.accept="image/*";
            document.getElementById("div"+i).append(img);
            document.getElementById("amo").value = i;
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
                <form action="" method="post" id="form"  enctype="multipart/form-data">
                    <p>Место №' .$x.'</p>
                    <input type="text" name="'.$x.'" id="'.$x.'" placeholder="Вставьте координаты">
                    <textarea id="t'.$x.'" name="t'.$x.'" cols="21" rows="4" placeholder="Введите подсказку к нахождению места" style="resize:none;"></textarea>
                    <div id="div'.$x.'" class="tagfile">
                        <input type="file" id="i'.$x.'" name="i'.$x.'" accept="image/*">
                    </div>
                    <input type="hidden" name="amo" id="amo" value="1">
                </form>
                <button onclick="moreTags()">Больше мест</button>
                <textarea form="form" name="last" cols="21" rows="4" placeholder="Введите сообщение, завершающее квест" style="resize:none;" required></textarea>
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
                <div class="helptext">Если у места не будут указаны координаты или формат координат будет неверен, то оно не будет добавлено в квест.
                Также необходимо каждому месту задать картинку, которую игрок должен будет найти на указанном месте. Без картинки место тоже не будет добавлено.
                Если у места есть координаты и нет подсказки, то оно добавлено будет.<br>
                Будьте внимательны и напишите подсказку к нахождению каждого места, чтобы игроки смогли найти их</div>
                <button onclick="closeIntro()" style="margin-top:10px;">Закрыть инструкцию</button>
            </div>
        </div>
    </div>
    ');}
    if (isset($_POST['fin'])){
        $str = "";
        $textstr = "";
        $num = 0;
        for($j=1;$j<=$_POST['amo'];$j++){
            if(!empty($_POST[$j])){
                if(preg_match("|^[\d]*\.[\d]*\, [\d]*\.[\d]*$|", $_POST[$j])){
                    if(($_FILES['i'.$j]['error']==0)&($_FILES['i'.$j]['size']>0)){
                        $num += 1;
                        $str = $str."|NEXT|".$_POST[$j];
                        $textstr = $textstr."|NEXT|".$_POST["t".$j];

                        $img_name = $_FILES['i'.$j]['name'];
                        $img_tmp = addslashes(file_get_contents($_FILES['i'.$j]['tmp_name']));
                        $sql = "INSERT INTO `quests_images` (quest_id,task_id,img_tmp,img_name) VALUES(
                            '$quest',
                            '$num',
                            '$img_name',
                            '$img_tmp'
                        )";
                        $res = mysqli_query($conn, $sql) or die('Ошибка: ' . mysqli_error($conn));
                    }
                }
            }
        }
        $textstr = $textstr."|NEXT|".$_POST['last'];
        $str = substr($str, 6, strlen($str)-1);
        $textstr = substr($textstr, 6, strlen($textstr)-1);
        $sql = "UPDATE `quests` SET geotags='$str', numtags='$num', helptags='$textstr' WHERE id='$quest'";
        $res = mysqli_query($conn, $sql) or die('Ошибка: ' . mysqli_error($conn));
        echo('<script>document.location.href="profile.php"</script>');
    }
    ?>
</div>
</body>
</html>