<?php
session_start();
include 'connection.php';
$query = "CREATE TABLE IF NOT EXISTS `users`(
        id INT AUTO_INCREMENT,
        name TEXT,
        pass TEXT,
        img_name MEDIUMBLOB,
        img_tmp MEDIUMBLOB,
        PRIMARY KEY(id)
    )";
$res = mysqli_query($conn, $query) or die("Error: ".mysqli_error($conn));

$_SESSION['name'] = "";
?>

<html>
<head>
    <meta charset="UTF-8">
    <title>Вход в аккаунт</title>
    <link rel="stylesheet" href="../css/style.css">
</head>
<body>
    <div>
        <form action="" method="post" class="aut_form">
            <div class="logo0">
                <img src="../image/LOGO.png" height="70px" alt="АРГО">
            </div>
            <div>Вход в систему</div>
            <input name="name" type="text" placeholder="Логин">
            <input name="pass" type="password" placeholder="Пароль">
            <input name="entr" type="submit" value="Вход">
            <div>Ещё не завели аккаунт?</div>
            <div><a href="registration.php">Зарегистрироваться</a></div>
        </form>
        <?php
        if(isset($_POST['entr'])){
            $name = $_POST['name'];
            $pass = $_POST['pass'];
            $sql = "SELECT * FROM `users` WHERE name='$name'";
            $res = mysqli_query($conn,$sql) or die("Error: ".mysqli_error($conn));
            $row =  $res->fetch_array(MYSQLI_ASSOC);
            if(password_verify($pass, $row['pass'])){
                $_SESSION['name'] = $name;
                echo('<script>document.location.href="profile.php"</script>');
            }
            else{
                echo('Пользователя с таким логином не существует');
            }
        }
        ?>
    </div>
</body>
</html>
