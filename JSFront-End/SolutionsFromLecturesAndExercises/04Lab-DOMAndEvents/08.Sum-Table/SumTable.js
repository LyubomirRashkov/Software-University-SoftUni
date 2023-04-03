function sumTable() {
    const firstTable = document.querySelector('table');
    const prices = Array.from(firstTable.querySelectorAll('td:nth-child(even)'));
    prices.pop();
    const sumTd = document.getElementById('sum');

    let sum = prices
        .map((td) => Number(td.textContent))
        .reduce((prev, curr) => prev + curr, 0);

    sumTd.textContent = sum;
}