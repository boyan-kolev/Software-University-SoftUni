function solve(arr) {
    let numbers = arr.map(Number);
    let numsSorted = numbers.sort((a,b) => b-a);
    let minValue = Math.min(numsSorted.length, 3);

    for (let i = 0; i < minValue; i++) {
        let maxNum = numsSorted.shift();
        console.log(maxNum);
    }

}

solve(["10", "30", "15", "20", "50", "5"]);