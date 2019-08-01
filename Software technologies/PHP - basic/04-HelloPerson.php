<?php
if (!isset($_GET['person'])) {
    ?>
    <form>
        Name: <input type="text" name="person">
        <input type="submit">
    </form>
    <?php
} else {

    $name = htmlspecialchars($_GET['person']);

    echo "Hello, $name";
}

?>