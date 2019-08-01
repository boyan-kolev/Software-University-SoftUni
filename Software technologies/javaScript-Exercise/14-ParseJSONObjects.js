function solve(arr) {

    for (let i = 0; i < arr.length; i++) {
        let objects = JSON.parse(arr[[i]]);

        for (let object in objects) {
            console.log(`${object[0].toUpperCase()}${object.substr(1, object.length)}: ${objects[object]}`)
        }
    }
}

solve(['{"name":"Gosho","age":10,"date":"19/06/2005"}',
    '{"name":"Tosho","age":11,"date":"04/04/2005"}',]);