function solve(arr) {
    let text = arr.join(",");
    let words = text.split(/\W+/);

    let nonEmptyWords = words.filter(w => w.length > 0);
    let upWords = nonEmptyWords.filter(isUpper);
    console.log(upWords.join(", "));

    function isUpper(word) {
        return word === word.toUpperCase();
    }
}
    solve(["We start by HTML, CSS, JavaScript, JSON and REST"]);