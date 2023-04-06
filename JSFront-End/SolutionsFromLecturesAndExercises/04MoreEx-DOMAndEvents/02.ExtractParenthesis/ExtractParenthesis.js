function extract(content) {
    const paragraph = document.getElementById(content);

    let originalContent = paragraph.textContent;

    let symbols = originalContent.split('');
    let matches = [];

    while (symbols.length > 0) {
        let symbol = symbols.shift();

        if (symbol === '(') {
            symbol = symbols.shift();

            let match = '';

            while (symbol !== ')') {
                match += symbol;

                symbol = symbols.shift();
            }

            if (match !== '') {
                matches.push(match);
            }
        }
    }
    
    return matches.join('; ');
}