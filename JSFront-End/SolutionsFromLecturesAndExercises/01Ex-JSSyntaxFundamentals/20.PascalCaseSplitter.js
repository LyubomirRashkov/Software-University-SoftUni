function solver(str) {
    let chars = str.split("");

    let words = [];

    let currentWord = "";

    for (let i = 0; i < chars.length; i++) {
        let asciiCode = chars[i].charCodeAt(0);
        
        if (asciiCode >= 65 && asciiCode <= 90) {
            if (currentWord !== "") {
                words.push(currentWord);
            }

            currentWord = chars[i];
        } else {
            currentWord += chars[i];
        }
    }

    words.push(currentWord);

    console.log(words.join(", "));
}

solver('SplitMeIfYouCanHaHaYouCantOrYouCan');
solver('HoldTheDoor');
solver('ThisIsSoAnnoyingToDo');