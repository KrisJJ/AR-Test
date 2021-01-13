<?PHP
$QuestName = $_POST['QuestName'];
$coordinates = $_POST['coordinates'];
$dbhost = '127.0.0.1:3306';
$dbuser = 'root';
$dbpass = 'root';
$dbname = 'main';
$con = mysqli_connect($dbhost, $dbuser, $dbpass,$dbname);


$check = mysqli_query($con, "SELECT * FROM coordinates WHERE `QuestName`='".$QuestName."'");
$numrows = mysqli_num_rows($check);
if ($numrows == 0){
	die ("no coordinates");
}
else
{
	while($row = mysqli_fetch_array($check)){
		$coordinates=$row['coordinates'];
		echo "$coordinates";
	}
}

?>