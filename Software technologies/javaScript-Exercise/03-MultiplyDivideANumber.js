function solve(arr) {
    let num = Number(arr[0]);
    let x = Number(arr[1]);
    let result;

    if (x >= num){
        result = num * x;
    }
    else {
        result = num / x;
    }

    console.log(result);
}

solve(["13", "13"])