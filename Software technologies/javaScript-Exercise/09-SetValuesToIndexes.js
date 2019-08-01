function solve(input) {
    let length = Number(input[0]);
    let array = [];
    for (let i = 0; i < length; i++) {
        array[i] = 0;
    }

    for (let i = 1; i < input.length; i++) {
        let splitted = input[i].split(" - ");
        let index = splitted[0];
        let value = splitted[1];

        array[index] = value;
    }

    for (let num of array) {
        console.log(num);
    }

}

solve([ '3', '0 - 5', '1 - 6', '2 - 7' ]);