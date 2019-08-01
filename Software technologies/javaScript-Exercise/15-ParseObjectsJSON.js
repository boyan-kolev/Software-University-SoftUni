function solve(arr) {
    let objects = {};

    for (let i = 0; i < arr.length; i++) {
        let splitted = arr[i].split(" -> ");
        let key = splitted[0];
        let value = splitted[1];
        if (isNaN(Number(value))){
            objects[key] = value;
        }
        else {
            objects[key] = Number(value);
        }
    }

    console.log(JSON.stringify(objects));
}