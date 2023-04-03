function colorize() {
    const targetRows = Array.from(document.querySelectorAll('tr:nth-child(even)'))
        .forEach((r) => r.style.backgroundColor = 'Teal');
}