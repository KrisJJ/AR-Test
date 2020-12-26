<?php
session_start();
include 'connection.php';
?>

<html>
<head>
    <meta charset="UTF-8">
    <title>Редактирование профиля</title>
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
    </script>
</head>
<body>
<div class="main">
    <?php
    $name = $_SESSION['name'];
    $sql = "SELECT * FROM `users` WHERE name='$name'";
    $res = mysqli_query($conn,$sql) or die("Error: ".mysqli_error($conn));
    $row = $res->fetch_array(MYSQLI_ASSOC);
    echo('
        <form action="" method="post" class="" enctype="multipart/form-data">
        <div>Изменить имя пользователя (только буквы, цифры, пробел, нижнее подчеркивание)</div>
        <input name="name" type="text" value="'.$name.'" pattern="^[A-Za-zА-Яа-яЁё0-9\s\_]+$">
        <div>Изменить пароль (только буквы, цифры, нижнее подчеркивание)</div>
        <input name="pass0" type="password" placeholder="Введите старый пароль" pattern="^[А-Яа-яЁёa-zA-Z0-9\_]+$">
        <input name="pass1" type="password" placeholder="Введите новый пароль" pattern="^[А-Яа-яЁёa-zA-Z0-9\_]+$">
        <input name="pass2" type="password" placeholder="Повторите новый пароль" pattern="^[А-Яа-яЁёa-zA-Z0-9\_]+$">
        <div>Изменить аватар</div>
        <input name="img" type="file" accept="image/*">
        <input name="conf" type="submit" value="Подтвердить изменения">
    </form>
    ');
    if(isset($_POST['conf'])){
        $flag = TRUE;
        $id = $row['id'];
        if($_POST['name']!=null){
            $name = $_POST['name'];
            if($name!=$_SESSION['name']){
                $sql = "UPDATE `users` SET name='$name' WHERE id='$id'";
                $res = mysqli_query($conn,$sql) or die("Error: ".mysqli_error($conn));
                $_SESSION['name'] = $name;
            }
        }
        else{
            $flag = FALSE;
            echo('Имя пользователя должно содержать хотя бы 1 символ');
        }
        $pass = $row['pass'];
        if($_POST['pass1']!=null){
            if(password_verify($_POST['pass0'], $pass)){
                if($_POST['pass1']==$_POST['pass2']){
                    $pass = password_hash($_POST['pass1'], PASSWORD_DEFAULT);
                    if($flag==TRUE){
                        $sql = "UPDATE `users` SET pass='$pass' WHERE id='$id'";
                        $res = mysqli_query($conn,$sql) or die("Error: ".mysqli_error($conn));
                    }
                }
                else{
                    $flag = FALSE;
                    echo('Ошибка в пароле. Повторите ввод или выберите другой пароль');
                }
            }
            else{
                $flag = FALSE;
                echo('Ошибка в пароле. Старый пароль введен неверно');
            }
        }
        if($_FILES['img']['name']!=null){
            if($flag==TRUE){
                $img_name = $_FILES['img']['name'];
                $img_tmp = addslashes(file_get_contents($_FILES['img']['tmp_name']));
                $sql = "UPDATE `users` SET img_tmp='$img_tmp',img_name='$img_name' WHERE id='$id'";
                $res = mysqli_query($conn,$sql) or die("Error: ".mysqli_error($conn));
            }
        }
        if($flag==TRUE){
            echo('<script>document.location.href="profile.php"</script>');
        }
    }
    ?>

</div>
</body>
</html>