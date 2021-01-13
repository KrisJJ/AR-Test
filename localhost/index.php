<?php
session_start();
include 'connection.php';
$query = "CREATE TABLE IF NOT EXISTS `users`(
        id INT AUTO_INCREMENT,
        name TEXT,
        pass TEXT,
        email TEXT,
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
    <div class="main">
        <form action="" method="post" class="aut_form">
            <div class="logo0">
                <img src="../meta/LOGO.png" height="70px" alt="АРГО">
            </div>
            <div class="autor">
                <p>Вход в аккаунт</p>
                <input name="name" type="text" placeholder="Имя пользователя" pattern="^[A-Za-zА-Яа-яЁё0-9\s\_]+$">
                <input name="pass" type="password" placeholder="Пароль" pattern="^[A-Za-zА-Яа-яЁё0-9\s\_]+$">
            </div>
            <button name="entr" style="padding: 8px 55px;">Вход</button>
            <div class="wannareg">Ещё не завели аккаунт?<br>
            <a href="registration.php">Зарегистрируйтесь!</a></div>
        </form>
        <?php
        if(isset($_POST['entr'])){
            $name = $_POST['name'];
            $pass = $_POST['pass'];
            $sql = "SELECT * FROM `users` WHERE name='$name'";
            $res = mysqli_query($conn,$sql) or die("Error: ".mysqli_error($conn));
            $row =  $res->fetch_array(MYSQLI_ASSOC);
            if($row==null){
                echo('Пользователя с таким именем не существует');
            }
            if(md5($pass) === $row['pass']){
                $_SESSION['name'] = $name;
                echo('<script>document.location.href="profile.php"</script>');
            }
            else{
                echo('Пароль неверный');
            }
        }
        ?>
    </div>
</body>
</html>
