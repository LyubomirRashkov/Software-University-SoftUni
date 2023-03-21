function solver(text) {
    let someWords = text
        .split(" ")
        .filter(w => w.startsWith("#") && w.length > 1)
        .map(w => w = w.substring(1, w.length));

    for (const word of someWords) {
        let chars = word.split("");

        let doesConsistOnlyOfLetters = true;

        for (const char of chars) {
            let asciiCode = char.charCodeAt(0);

            if ((asciiCode < 65)
                || (asciiCode > 90 && asciiCode < 97)
                || (asciiCode > 122)) {
                    doesConsistOnlyOfLetters = false;
                }
        }

        if (doesConsistOnlyOfLetters) {
            console.log(word);
        }
    }
}