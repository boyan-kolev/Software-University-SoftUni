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
        $f3 = 2;

        echo $f1 . PHP_EOL;
        echo $f2 . PHP_EOL;
        echo $f3 . PHP_EOL;

        for ($i = 3; $i < $num; $i++){
            $fCurr = $f1;
            $f1 = $f2;
            $f2 = $f3;
            $f3 = $fCurr + $f1 + $f2;

            echo $f3 . PHP_EOL;
        }

    }

    ?>
</body>
</html>