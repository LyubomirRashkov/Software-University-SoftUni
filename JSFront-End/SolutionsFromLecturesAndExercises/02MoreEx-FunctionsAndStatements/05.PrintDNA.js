function printDNA(number) {
    let symbols = "ATCGTTAGGG";

    let pointer = 0;

    for (let i = 0; i < number; i++) {
        let symbolOne = symbols[pointer];
        let symbolTwo = symbols[pointer + 1];

        if (i % 4 === 0) {
            console.log(`**${symbolOne}${symbolTwo}**`);
        } else if ( i % 4 === 1) {
            console.log(`*${symbolOne}--${symbolTwo}*`);
        } else if (i % 4 === 2) {
            console.log(`${symbolOne}----${symbolTwo}`);
        } else {
            console.log(`*${symbolOne}--${symbolTwo}*`);
        }
        
        pointer += 2;

        if (pointer === symbols.length) {
            pointer = 0;
        }
    }
}

printDNA(4);
printDNA(10);