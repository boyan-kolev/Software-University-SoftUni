<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>
    <?php
    if (isset($_GET['num'])){
        $num = intval($_GET['num']);
        $f1 = 1;
        $f2 = 1;

        echo 1 . PHP_EOL;
        echo 1 . PHP_EOL;

        for ($i = 2; $i < $num; $i++){
            $fCurr = $f1;
            $f1 = $f2;
            $f2 = $fCurr + $f1;

            echo $f2 . PHP_EOL;
        }
    }

    ?>
</body>
</html>