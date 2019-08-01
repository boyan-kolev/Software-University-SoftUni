function solve(numbers) {
    let nums = numbers[0].split(" ").map(Number);
    let num1 = (nums[0]);
    let num2 = (nums[1]);
    let num3 = (nums[2]);
    
    if (num1 + num2 === num3) {
        if (num1 <= num2){
            return(`${num1} + ${num2} = ${num3}`)
        }
        else {
            return(`${num2} + ${num1} = ${num3}`)
        }
    }
    else if (num1 + num3 === num2) {
        if (num1 <= num3){
            return(`${num1} + ${num3} = ${num2}`)
        }
        else {
            return(`${num3} + ${num1} = ${num2}`)
        }
    }
    else if (num2 + num3 === num1) {
        if (num2 <= num3){
            return(`${num2} + ${num3} = ${num1}`)
        }
        else {
            return(`${num3} + ${num2} = ${num1}`)
        }
    }
    else {
        return("No")
    }
}

solve("1 2 3");