function solver(word, text) {
    let wordToLowerCase = word.toLowerCase();

    let textWords = text.split(" ");

    let isNotFound = true;

    for (const textWord of textWords) {
        if (textWord.toLowerCase() === wordToLowerCase) {
            isNotFound = false;

            console.log(word);

            break;
        }
    }

    if (isNotFound) {
        console.log(`${word} not found!`);
    }
}