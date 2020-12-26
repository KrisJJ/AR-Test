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
<div>
    <form action="" method="post" class="aut_form">
        <div class="logo0">
            <img src="../image/LOGO.png" height="70px" alt="АРГО">
        </div>
        <div>Регистрация</div>
        <input name="name" type="text" placeholder="Введите логин" pattern="^[A-Za-zА-Яа-яЁё0-9\s\_]+$">
        <input name="pass" type="password" placeholder="Введите пароль" pattern="^[А-Яа-яЁёa-zA-Z0-9\_]+$">
        <input name="pass1" type="password" placeholder="Повторите пароль" pattern="^[А-Яа-яЁёa-zA-Z0-9\_]+$">
        <input name="reg" type="submit" value="Зарегистрироваться">
        <div>Уже зарегистрированы?</div>
        <div><a href="index.php">Войти в аккаунт</a></div>
    </form>
    <?php
    if(isset($_POST['reg'])){
        $name = $_POST['name'];
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
                $code = password_hash($pass, PASSWORD_DEFAULT);
                $img_name = "default";
                $img_tmp = addslashes(file_get_contents("../image/LOGOplane1.png"));
                $sql = "INSERT INTO `users` (id,name,pass,img_name,img_tmp) VALUES(
                        id,
                        '$name',
                        '$code',
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
