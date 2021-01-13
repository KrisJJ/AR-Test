<?php
session_start();
include 'connection.php';
?>

<html>
<head>
    <meta charset="UTF-8">
    <title>Регистрация</title>
    <link rel="stylesheet" href="../css/style.css">
</head>
<body>
<div class="main">
    <form action="" method="post" class="aut_form">
        <div class="logo0">
            <img src="../meta/LOGO.png" height="70px" alt="АРГО">
        </div>
        <div>
            <p>Регистрация</p>
            <input name="name" type="text" placeholder="Имя пользователя" pattern="^[A-Za-zА-Яа-яЁё0-9\s\_]+$" required>
            <input name="email" type="email" placeholder="Email" pattern="^[A-Za-zА-Яа-яЁё0-9\s\_\@]+$" required>
            <input name="pass" type="password" placeholder="Пароль" pattern="^[А-Яа-яЁёa-zA-Z0-9\_]+$" required>
            <input name="pass1" type="password" placeholder="Повторите пароль" pattern="^[А-Яа-яЁёa-zA-Z0-9\_]+$" required>
        </div>
        <button name="reg"  style="padding: 8px 17px;">Зарегистрироваться</button>
        <div class="wannareg">Уже зарегистрированы?<br>
        <a href="index.php">Войдите в аккаунт</a></div>
    </form>
    <?php
    if(isset($_POST['reg'])){
        $name = $_POST['name'];
        $email = $_POST['email'];
        $pass = $_POST['pass'];
        $pass1 = $_POST['pass1'];
        $sql = "SELECT * FROM `users` WHERE name='$name'";
        $res = mysqli_query($conn,$sql) or die("Error: ".mysqli_error($conn));
        $row = $res->fetch_array(MYSQLI_ASSOC);
        if ($row!=null){
            echo('Пользователь с таким именем уже существует');
        }
        else{
            if ($pass!=$pass1){
                echo('Ошибка в пароле. Повторите ввод или выберите другой пароль');
            }
            else{
                $code = md5($pass);
                $img_name = "default";
                $img_tmp = addslashes(file_get_contents("../meta/LOGOplane1.png"));
                $sql = "INSERT INTO `users` (id,name,pass,email,img_name,img_tmp) VALUES(
                        id,
                        '$name',
                        '$code',
                        '$email',
                        '$img_name',
                        '$img_tmp'
                    )";
                $result = mysqli_query($conn, $sql) or die('Ошибка: '.mysqli_error($conn));
                echo('<script>document.location.href="index.php"</script>');
            }
        }
    }
    ?>
</div>
</body>
</html>
