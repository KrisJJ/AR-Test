<?PHP
$name = $_POST['creator'];
$pass = $_POST['password'];
$QuestName = $_POST['QuestName'];
$dbhost = '127.0.0.1:3306';
$dbuser = 'root';
$dbpass = 'root';
$dbname = 'arbase';
$con = mysqli_connect($dbhost, $dbuser, $dbpass,$dbname);


$check = mysqli_query($con, "SELECT * FROM quests WHERE `creator`='123123'");
$numrows = mysqli_num_rows($check);
if ($numrows == 0){
	die ("no qusets");
}
else
{
	while($row = mysqli_fetch_array($check)){
		$name=$row['name'];
		echo "$name|NEXT|";
	}
}

?>