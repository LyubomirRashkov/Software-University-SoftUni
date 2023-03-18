function solver(text, word) {
    // let textWords = text.split(" ");

    // for (let i = 0; i < textWords.length; i++) {
    //     if (textWords[i] === word) {
    //         textWords[i] = "*".repeat(textWords[i].length);
    //     }
    // }

    // console.log(textWords.join(" "));

    while (text.includes(word)) {
        text = text.replace(word, "*".repeat(word.length));
    }

    console.log(text);
}