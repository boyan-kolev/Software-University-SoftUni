function solve(arr) {
    let keyFind = arr.pop();
    let objects = {};

    for (let i = 0; i < arr.length; i++) {
        let splitted = arr[i].split(" ");
        let key = splitted[0];
        let value = splitted[1];

        if (objects[key] === undefined){
            objects[key] = [];
            objects[key].push(value);
        }
        else {
            objects[key].push(value);
        }
    }

    if (objects[keyFind] === undefined){
        console.log("None");
    }
    else {
        let values = objects[keyFind];

        for (let value of values) {
            console.log(value);
        }
    }
}