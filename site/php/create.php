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
        geotags TEXT,
        helptags TEXT,
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
else {
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
    <div class="right">
        <div class="head">
            <div class="headimg"><img src="../meta/Create.png" height="30pt"></div>
            <div class="headtext">Создать квест</div>
        </div>
        <div class="logo" onclick="loadMain()">
            <img src="../meta/LOGO.png" height="90%" alt="АРГО">
        </div>
        <div class="list">
            <form action="" method="post" enctype="multipart/form-data">
                <div class="col1">
                    <div style="display:block;">
                        <div class="crealabel">Название</div>
                        <input type="text" name="name" size="40" placeholder="Введите название вашего квеста" required>
                    </div>
                    <div style="display:block;">
                        <div class="crealabel">Описание</div>
                        <textarea name="text" cols="40" rows="5" placeholder="Введите описание вашего квеста" style="resize:none;"></textarea>
                    </div>
                </div>
                <div class="col2">
                    <div class="crealabel">Обложка</div>
                    <input type="file" name="img" accept="image/*">
                    <input type="checkbox" name="def" checked="true" >Выбрать обложку по умолчанию
                </div>
                <div class="fdown">
                    <div class="fdate">
                        <div class="crealabel">День</div>
                        <input type="date" name="date" required>
                    </div>
                    <div class="ftime">
                        <div class="crealabel">Начало</div>
                        <input type="time" name="time" required>
                    </div>
                    <div class="flong">
                        <div class="crealabel">Длительность</div>
                        <input type=text list="long" name="long" required>
                        <datalist id="long">
                            <option>Бессрочно</option>
                            <option>1 неделя</option>
                            <option>2 недели</option>
                            <option>3 недели</option>
                            <option>1 месяц</option>
                        </datalist>
                    </div>
                </div>
                <div class="fnext">
                    <button name="next">Далее</button>
                </div>
            </form>');
    if (isset($_POST['next'])) {
        $name = $_POST['name'];
        $text = $_POST['text'];
        $date = $_POST['date'];
        $time = $_POST['time'];
        $def = $_POST['def'];
        if ($def != true) {
            $img_name = $_FILES['img']['name'];
            $img_tmp = addslashes(file_get_contents($_FILES['img']['tmp_name']));
        } else {
            $img_name = "default";
            $img_tmp = addslashes(file_get_contents("../meta/LOGOplane1.png"));
        }
        $long = $_POST['long'];
        $creator = $_SESSION['name'];
        /*$sql = "SELECT id FROM `users` WHERE name='$creator'";
        $res = mysqli_query($conn, $sql) or die('Ошибка: ' . mysqli_error($conn));
        $row = $res->fetch_array(MYSQLI_ASSOC);
        $creator = $row['id'];*/

        $sql = "INSERT INTO `quests` (id,name,text,date,time,longing,creator) VALUES(
                    id,
                    '$name',
                    '$text',
                    '$date',
                    '$time',
                    '$long',
                    '$creator'
                )";
        $res = mysqli_query($conn, $sql) or die('Ошибка: ' . mysqli_error($conn));

        $sql = "SELECT id FROM `quests` ORDER BY `id` DESC LIMIT 1";
        $res = mysqli_query($conn, $sql) or die('Ошибка: ' . mysqli_error($conn));
        $row = $res->fetch_array(MYSQLI_ASSOC);
        $id = $row['id'];
        $_SESSION['quest_id'] = $id;

        $sql = "INSERT INTO `quests_cover` (id,img_name,img_tmp) VALUES(
                    '$id',
                    '$img_name',
                    '$img_tmp'
                )";
        $res = mysqli_query($conn, $sql) or die('Ошибка: ' . mysqli_error($conn));
        echo('<script>document.location.href="create1.php"</script>');
    }
    echo('</div>
    </div>');}
    ?>
</div>

</body>
</html>