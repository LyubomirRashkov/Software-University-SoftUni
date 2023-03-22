function solver(lostGames, helmetPrice, swordPrice, shieldPrice, armorPrice) {
    let brokenHelmets = Math.floor(lostGames / 2);
    let brokenSwords = Math.floor(lostGames / 3);
    let brokenShields = Math.floor(lostGames / 6);
    let brokenArmors = Math.floor(lostGames / 12);

    let expenses = (brokenHelmets * helmetPrice)
        + (brokenSwords * swordPrice)
        + (brokenShields * shieldPrice)
        + (brokenArmors * armorPrice);

    console.log(`Gladiator expenses: ${expenses.toFixed(2)} aureus`);
}