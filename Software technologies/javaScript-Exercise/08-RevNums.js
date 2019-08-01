function solve(arr) {
    let numbers = arr.map(Number);

    for (let i = numbers.length -1; i >= 0; i--){
        console.log(numbers[i]);
    }
}

solve(["1", "2", "3"]);