<?php
$text = "";
if (isset($_GET['text'])) {
    $text = $_GET['text'];
    preg_match_all('/\w+/', $text, $words);

    $upperWords = array_filter($words[0], function ($word) {
        return strtoupper($word) == $word;
    });
    echo implode(', ', $upperWords);
        }

?>


<form>
    <textarea rows="10" name="text"></textarea> <br>
    <input type="submit" value="Extract">
</form>
