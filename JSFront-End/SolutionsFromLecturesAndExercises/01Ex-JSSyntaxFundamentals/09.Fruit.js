function solver(fruitType, weightInGrams, pricePerKilogram) {
    let moneyNeed = (weightInGrams / 1000) * pricePerKilogram;

    console.log(`I need $${moneyNeed.toFixed(2)} to buy ${(weightInGrams / 1000).toFixed(2)} kilograms ${fruitType}.`);
}