<?PHP
$name = $_POST['name'];
$pass = $_POST['password'];
$dbhost = '127.0.0.1:3306';
$dbuser = 'root';
$dbpass = 'root';
$dbname = 'arbase';
$con = mysqli_connect($dbhost, $dbuser, $dbpass,$dbname);


$check = mysqli_query($con, "SELECT * FROM users WHERE `name`='".$name."'");
$numrows = mysqli_num_rows($check);
if ($numrows == 0){
	die ("no qusets");
}
else
{
	while($row = mysqli_fetch_array($check)){
		$email=$row['email'];
		echo "$email";
	}
}

?>