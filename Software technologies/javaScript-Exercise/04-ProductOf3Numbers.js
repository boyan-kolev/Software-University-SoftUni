function solve(arr) {
    let numbers = arr.map(Number);
    let count = 0;
    let product = "Negative";

    for (let number of numbers) {
        if (number < 0){
            count++;
        }
    }

    if (count % 2 === 0){
        product = "Positive";
    }

    console.log(product);
}

solve(["5", "4", "3"]);