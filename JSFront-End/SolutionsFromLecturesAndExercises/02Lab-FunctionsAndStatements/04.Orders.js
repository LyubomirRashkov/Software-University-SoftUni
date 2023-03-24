function calculatePrice(product, quantity) {
    let singlePrice = 0;

    switch (product) {
        case "coffee":
            singlePrice = 1.50;
            break;

        case "water":
            singlePrice = 1.00;
            break;

        case "coke":
            singlePrice = 1.40;
            break;

        case "snacks":
            singlePrice = 2.00;
            break;
    }

    console.log((singlePrice * quantity).toFixed(2));
}

calculatePrice("water", 5);
calculatePrice("coffee", 2);