function printCharacters(startChar, endChar) {
    let startCharAsciiCode = startChar.charCodeAt(0);
    let endCharAsciiCode = endChar.charCodeAt(0);

    let start = Math.min(startCharAsciiCode, endCharAsciiCode);
    let end = Math.max(startCharAsciiCode, endCharAsciiCode);

    let chars = [];

    for (let i = start + 1; i < end; i++) {
        chars.push(String.fromCharCode(i));        
    }

    console.log(chars.join(" "));
}

printCharacters('a', 'd');
printCharacters('#', ':');
printCharacters('C', '#');