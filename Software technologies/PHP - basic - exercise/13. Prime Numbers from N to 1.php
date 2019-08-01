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

        for ($i = $num; $i >= 2; $i--){

            if (isPrimeNumber($i)){
                echo $i . " ";
            }
        }

    }


    function isPrimeNumber($i) {
        $n = 2;
        while ($n < $i) {
            if ($i % $n) {
                $n++;
                continue;
            }

            return false;
        }

        return true;
    }

    ?>
</body>
</html>