<?PHP
$name = $_POST['name'];
$pass = $_POST['password'];
$email = $_POST['email'];
$dbhost = '127.0.0.1:3306';
$dbuser = 'root';
$dbpass = 'root';
$dbname = 'main';
$con = mysqli_connect($dbhost, $dbuser, $dbpass,$dbname);

$check = mysqli_query($con, "SELECT * FROM users WHERE `name`='".$name."'");

$numrows = mysqli_num_rows($check);

if ($numrows == 0)
{
	$pass = md5($pass);
	
	$ins = mysqli_query($con, "INSERT INTO  users ( `name` ,  `password` ,  `email` ) VALUES ( '".$name."' ,  '".$pass."' ,  '".$email."') ; ");
	
	if ($ins)
		die ("Succesfully Created User!");
	else
		die ("Error: " . mysqli_error());
}
else
{
	die("User allready exists!");
}
?>