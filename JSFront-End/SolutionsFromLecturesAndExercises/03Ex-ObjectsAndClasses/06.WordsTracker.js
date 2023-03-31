function wordsTracker(input) {
    let words = input.shift().split(" ");

    let tuples = {};

    for (const word of words) {
        let count = input.filter((el) => el === word).length;

        tuples[word] = count;
    }

    let entries = Object.entries(tuples);

    let sortedEntries = entries.sort((entryA, entryB) => {
        let [_wordA, countA] = entryA;
        let [_wordB, countB] = entryB;

        return countB - countA;
    })

    for (const [ word, count] of sortedEntries) {
        console.log(`${word} - ${count}`);
    }
}

wordsTracker(
    [
        'this sentence',
        'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ]
);

wordsTracker(
    [
        'is the',
        'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence'
    ]
);