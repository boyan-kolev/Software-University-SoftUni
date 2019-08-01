function solve(input) {
    let array = [];

    for (let i = 0; i < input.length; i++) {
        let splitted = input[i].split(" ");
        let command = splitted[0];
        let argument = Number(splitted[1]);

        if (command === "add") {
            array.push(argument);
        }
        else if (command === "remove") {
            if (argument <= array.length - 1) {
                array.splice(argument, 1);
            }
        }
    }

    for (let num of array) {
        console.log(num);
    }
}


solve(["add 3", "add 5", "add 4", "remove 2", "add 7"]);