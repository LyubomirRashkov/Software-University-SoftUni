function solver(wordsAsString, text) {
    let words = wordsAsString.split(", ");

    let textWords = text.split(" ");

    for (const word of words) {
        let secretWord = "*".repeat(word.length);

        for (let i = 0; i < textWords.length; i++) {            
            if (textWords[i] === secretWord) {
                textWords[i] = word;
            }
        }
    }

    text = textWords.join(" ");

    console.log(text);
}