function solve(input) {
    let pieces = {};

    let numberOfInitialPieces = Number(input.shift());
    
    for (let i = 0; i < numberOfInitialPieces; i++) {
        let line = input.shift();
        let [ piece, composer, key ] = line.split('|');

        pieces[piece] = { composer, key };
    }

    let commandParser = {
        'Add': addFunction,
        'Remove': removeFunction,
        'ChangeKey': changeKeyFunction,
    };

    while(true) {
        let line = input.shift();

        if (line === 'Stop') {
            break;
        }

        let tokens = line.split('|');

        let command = tokens.shift();

        commandParser[command](...tokens);
    }

    for (const key in pieces) {
        console.log(`${key} -> Composer: ${pieces[key].composer}, Key: ${pieces[key].key}`);
    }

    function addFunction(piece, composer, key) {
        if (pieces.hasOwnProperty(piece)) {
            console.log(`${piece} is already in the collection!`)
        } else {
            pieces[piece] = { composer, key };

            console.log(`${piece} by ${composer} in ${key} added to the collection!`);
        }
    }

    function removeFunction(piece) {
        if (pieces.hasOwnProperty(piece)) {
            delete pieces[piece];

            console.log(`Successfully removed ${piece}!`);
        } else {
            console.log(`Invalid operation! ${piece} does not exist in the collection.`);
        }
    }

    function changeKeyFunction(piece, newKey) {
        if (pieces.hasOwnProperty(piece)) {
            pieces[piece].key = newKey;

            console.log(`Changed the key of ${piece} to ${newKey}!`);
        } else {
            console.log(`Invalid operation! ${piece} does not exist in the collection.`);
        }
    }
}

solve(
    [
        '3',
        'Fur Elise|Beethoven|A Minor',
        'Moonlight Sonata|Beethoven|C# Minor',
        'Clair de Lune|Debussy|C# Minor',
        'Add|Sonata No.2|Chopin|B Minor',
        'Add|Hungarian Rhapsody No.2|Liszt|C# Minor',
        'Add|Fur Elise|Beethoven|C# Minor',
        'Remove|Clair de Lune',
        'ChangeKey|Moonlight Sonata|C# Major',
        'Stop'
    ]
);

solve(
    [
        '4',
        'Eine kleine Nachtmusik|Mozart|G Major',
        'La Campanella|Liszt|G# Minor',
        'The Marriage of Figaro|Mozart|G Major',
        'Hungarian Dance No.5|Brahms|G Minor',
        'Add|Spring|Vivaldi|E Major',
        'Remove|The Marriage of Figaro',
        'Remove|Turkish March',
        'ChangeKey|Spring|C Major',
        'Add|Nocturne|Chopin|C# Minor',
        'Stop'
    ]
);