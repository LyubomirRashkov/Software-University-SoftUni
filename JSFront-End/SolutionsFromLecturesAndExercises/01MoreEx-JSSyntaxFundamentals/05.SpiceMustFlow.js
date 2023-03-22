function solver(yield) {
    let days = 0;
    let spiceAmount = 0;

    while(yield >= 100) {
        days++;
        spiceAmount += yield;
        spiceAmount -= 26;

        yield -= 10;
    }

    spiceAmount -= 26;

    if (spiceAmount < 0) {
        spiceAmount = 0;
    }

    console.log(days);
    console.log(spiceAmount);
}