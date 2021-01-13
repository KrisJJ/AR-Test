<?PHP
$name = $_POST['name'];
$pass = $_POST['password'];
$QuestName = $_POST['QuestName'];
$dbhost = '127.0.0.1:3306';
$dbuser = 'root';
$dbpass = 'root';
$dbname = 'main';
$con = mysqli_connect($dbhost, $dbuser, $dbpass,$dbname);


$check = mysqli_query($con, "SELECT * FROM quests WHERE `name`='".$name."'");
$numrows = mysqli_num_rows($check);
if ($numrows == 0){
	die ("no qusets");
}
else
{
	while($row = mysqli_fetch_array($check)){
		$QuestName=$row['QuestName'];
		echo "$QuestName|NEXT|";
	}
}

?>