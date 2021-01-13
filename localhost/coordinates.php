<?PHP
$name = $_POST['name'];
$geotags = $_POST['geotags'];
$dbhost = '127.0.0.1:3306';
$dbuser = 'root';
$dbpass = 'root';
$dbname = 'arbase';
$con = mysqli_connect($dbhost, $dbuser, $dbpass,$dbname);


$check = mysqli_query($con, "SELECT * FROM quests WHERE `name`='".$name."'");
$numrows = mysqli_num_rows($check);
if ($numrows == 0){
	die ("no coordinates");
}
else
{
	while($row = mysqli_fetch_array($check)){
		$geotags=$row['geotags'];
		echo "$geotags";
	}
}

?>