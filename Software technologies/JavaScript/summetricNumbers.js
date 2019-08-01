function solve(arr) {
    let number = Number(arr[0]);

    for (let i = 1; i <= number; i++) {

        let revNum = i.toString().split('').reverse().join('');

        if (i == revNum){
            console.log(i);
        }
    }
}

solve(["100"]);