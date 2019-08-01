function solve(arr) {
    let objects = arr.map(JSON.parse);
    let towns = {};

    for (let object of objects) {
        if (!towns[object.town]){
            towns[object.town] = 0;
        }

        towns[object.town] += object.income;
    }

    let townsNames = Object.keys(towns).sort();

    for (let name of townsNames) {
        console.log(`${name} -> ${towns[name]}`);
    }
}

solve([
    '{"town":"Sofia","income":200}',
    '{"town":"Varna","income":120}',
    '{"town":"Pleven","income":60}',
    '{"town":"Varna","income":70}',
    ]);