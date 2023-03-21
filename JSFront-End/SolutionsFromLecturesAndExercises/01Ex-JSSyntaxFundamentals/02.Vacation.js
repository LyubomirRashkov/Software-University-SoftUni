function solver(peopleCount, groupType, dayOfWeek) {
    let totalPrice = 0;

    if (groupType === "Students") {
        if (dayOfWeek === "Friday") {
            totalPrice = peopleCount * 8.45;
        } else if (dayOfWeek === "Saturday") {
            totalPrice = peopleCount * 9.80;
        } else {
            totalPrice = peopleCount * 10.46;
        }

        if (peopleCount >= 30) {
            totalPrice *= 0.85;
        }
    } else if (groupType === "Business") {
        if (peopleCount >= 100) {
            peopleCount -= 10;
        }

        if (dayOfWeek === "Friday") {
            totalPrice = peopleCount * 10.90;
        } else if (dayOfWeek === "Saturday") {
            totalPrice = peopleCount * 15.60;
        } else {
            totalPrice = peopleCount * 16.00;
        }
    } else {
        if (dayOfWeek === "Friday") {
            totalPrice = peopleCount * 15.00;
        } else if (dayOfWeek === "Saturday") {
            totalPrice = peopleCount * 20.00;
        } else {
            totalPrice = peopleCount * 22.50;
        }

        if (peopleCount >= 10 && peopleCount <= 20) {
            totalPrice *= 0.95;
        }
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}