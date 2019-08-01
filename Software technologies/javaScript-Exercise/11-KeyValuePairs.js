function solve(arr) {
    let keyFind = arr.pop();
    let object = {};

    for (let i = 0; i < arr.length; i++) {
        let splitted = arr[i].split(" ");
        let key = splitted[0];
        let value = splitted[1];

        object[key] = value;
    }
    
    if (object[keyFind] === undefined){
        console.log("None");
    }
    else{
        console.log(object[keyFind]);
    }
}

solve(["key value", "key eulav", "test tset", "key"]);