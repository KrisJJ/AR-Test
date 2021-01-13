<?PHP
$name = $_POST['name'];
$pass = $_POST['password'];
$dbhost = '127.0.0.1:3306';
$dbuser = 'root';
$dbpass = 'root';
$dbname = 'main';
$con = mysqli_connect($dbhost, $dbuser, $dbpass,$dbname);

$check = mysqli_query($con, "SELECT * FROM users WHERE `name`='".$name."'");

$numrows = mysqli_num_rows($check);

if ($numrows == 0)
{
	die ("Username does not exist!");
}
else
{
	$pass = md5($pass);
	while($row = mysqli_fetch_assoc($check))
	{
		if ($pass == $row['password'])
			die("Success!");
		else
			die("Password does not match!");
	}
}
?>