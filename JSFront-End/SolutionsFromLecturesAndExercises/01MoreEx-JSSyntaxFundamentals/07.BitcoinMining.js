function solver(numbers) {
    const bitcoinPrice = 11949.16;
    const goldPrice = 67.51;

    let bitcoinsCount = 0
    let dayOfFirstPurchase = 0;
    let money = 0;

    for (let i = 1; i <= numbers.length; i++) {
        if (i % 3 === 0) {
            numbers[i - 1] *= 0.7;
        }        

        money += (numbers[i - 1] * goldPrice);

        if (money >= bitcoinPrice) {
            if (dayOfFirstPurchase === 0) {
                dayOfFirstPurchase = i;
            }

            bitcoinsCount += Math.floor(money / bitcoinPrice);

            money %= bitcoinPrice;
        }
    }

    console.log(`Bought bitcoins: ${bitcoinsCount}`);

    if (dayOfFirstPurchase !== 0) {
        console.log(`Day of the first purchased bitcoin: ${dayOfFirstPurchase}`);
    }

    console.log(`Left money: ${money.toFixed(2)} lv.`);
}