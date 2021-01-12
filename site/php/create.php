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
        creator INT,
        numtags INT,
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
    echo('
            <div>Вы вышли из аккаунта</div>
            <div>Войдите в аккаунт, чтобы иметь возможность работать с квестами</div>
            <button onclick="exitAcc()">Войти в аккаунт</button>
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
            <form action="" method="post">
                <div class="col1">
                    <div style="display:block;">
                        <p>Название</p>
                        <input type="text" name="name" size="40" placeholder="Введите название вашего квеста">
                    </div>
                    <div style="display:block;">
                        <p>Описание</p>
                        <textarea name="text" cols="40" rows="5" placeholder="Введите описание вашего квеста" style="resize:none;"></textarea>
                    </div>
                </div>
                <div class="col2">
                    <p>Обложка</p>
                    <input type="file" name="img" accept="image/*">
                    <input type="checkbox" name="def" checked="true" >Выбрать обложку по умолчанию
                </div>
                <div class="fdown">
                    <div class="fdate">
                        <p>День</p>
                        <input type="date" name="date">
                    </div>
                    <div class="ftime">
                        <p>Время начала</p>
                        <input type="time" name="time">
                    </div>
                    <div class="flong">
                        <p>Длительность</p>
                        <input list="long" name="long">
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
            echo('default');
        }
        $long = $_POST['long'];
        $creator = $_SESSION['name'];
        $sql = "SELECT id FROM `users` WHERE name='$creator'";
        $res = mysqli_query($conn, $sql) or die('Ошибка: ' . mysqli_error($conn));
        $row = $res->fetch_array(MYSQLI_ASSOC);
        $creator = $row['id'];

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