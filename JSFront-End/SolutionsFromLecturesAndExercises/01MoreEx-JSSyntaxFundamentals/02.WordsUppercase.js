function solver(text) {
    // let regex = /\W/;

    // let wordsAsString = text
    //     .split(regex)
    //     .filter(w => w.length > 0)
    //     .map(w => w.toUpperCase())
    //     .join(", ");

    // console.log(wordsAsString);

    let pattern = /\w+/;

    let regex = new RegExp(pattern, "g");

    let wordsAsString = text
        .match(regex)
        .map(w => w.toUpperCase())
        .join(", ");

    console.log(wordsAsString);
}