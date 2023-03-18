function solver(text, word) {
    let textWords = text.split(" ");

    let counter = 0;

    for (const textWord of textWords) {
        if (textWord === word) {
            counter++;
        }
    }

    console.log(counter);
}