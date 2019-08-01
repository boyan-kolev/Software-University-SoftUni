
<?php
$sortedLines = "";
if (isset($_GET['lines'])){
    $lines = explode("\r\n", $_GET['lines']);
    $lines = array_map('trim', $lines);

    sort($lines);
    $sortedLines = implode("\r\n", $lines);
}
?>

<form>
  <textarea rows="10" name="lines"><?= $sortedLines
      ?></textarea> <br>
    <input type="submit" value="Sort">
</form>


