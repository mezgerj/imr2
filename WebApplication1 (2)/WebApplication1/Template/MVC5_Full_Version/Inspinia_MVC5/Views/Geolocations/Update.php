<html>
  <?php
// UpDate.php
$dsn = 'mysql:localhost;dbname=Copy_IMR_Test;';
$username = 'username';
$password = 'password';
$dbh = new PDO($dsn, $username, $password);
// Update db based on col, value and id passed into $_POST from repairs.js
if ($_POST['col'] == 'GeolocationID') {
$sql = "UPDATE Geolocations SET GeolocationID = " ."'". $_POST['value']."'" . " WHERE item_num = " . $_POST['id'];
$dbh->exec($sql);
echo $_POST['value'];
} else if ($_POST['col'] == 'Name') {
$sql = "UPDATE Geolocations SET Name = " ."'". $_POST['value']."'" . "WHERE item_num = " . $_POST['id'];
$dbh->exec($sql);
echo $_POST['value'];
} else if ($_POST['col'] == 'Latitude') {
$sql = "UPDATE Geolocations SET Latitude = " ."'". $_POST['value']."'" . "WHERE item_num = " . $_POST['id'];
$dbh->exec($sql);
echo $_POST['value'];
} else if ($_POST['col'] == 'Longitude') {
$sql = "UPDATE Geolocations SET Longitude = " ."'". $_POST['value']."'" . "WHERE item_num = " . $_POST['id'];
$dbh->exec($sql);
echo $_POST['value'];
} else if ($_POST['col'] == 'Altitude') {
$sql = "UPDATE Geolocations SET Altitude = " ."'". $_POST['value']."'" . "WHERE item_num = " . $_POST['id'];
$dbh->exec($sql);
echo $_POST['value'];
} else if ($_POST['col'] == 'Description') {
$sql = "UPDATE Geolocations SET Description = " ."'". $_POST['value']."'" . "WHERE item_num = " . $_POST['id'];
$dbh->exec($sql);
echo $_POST['value'];
} else if ($_POST['col'] == 'Application_Id') {
$sql = "UPDATE Geolocations SET Application_Id = " ."'". $_POST['value']."'" . "WHERE item_num = " . $_POST['id'];
$dbh->exec($sql);
echo $_POST['value'];
} else if ($_POST['col'] == 'Parent_Geo_Id') {
$sql = "UPDATE Geolocations SET Parent_Geo_Id = " ."'". $_POST['value']."'" . "WHERE item_num = " . $_POST['id'];
$dbh->exec($sql);
echo $_POST['value'];
} else if ($_POST['col'] == 'Range') {
$sql = "UPDATE Geolocations SET Range = " ."'". $_POST['value']."'" . "WHERE item_num = " . $_POST['id'];
$dbh->exec($sql);
echo $_POST['value'];
} else if ($_POST['col'] == 'DownloadTime') {
$sql = "UPDATE Geolocations SET DownloadTime = " ."'". $_POST['value']."'" . "WHERE item_num = " . $_POST['id'];
$dbh->exec($sql);
echo $_POST['value'];
} else if ($_POST['col'] == '') {
echo 'You cannot change this column!!';
}	

?>
</html>