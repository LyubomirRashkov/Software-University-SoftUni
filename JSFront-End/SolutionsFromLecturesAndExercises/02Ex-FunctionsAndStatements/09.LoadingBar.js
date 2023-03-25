function printLoadingBar(percent) {
    let percentAsString = "%".repeat((percent / 10));
    percentAsString = percentAsString.padEnd(10, ".");

    if (percent === 100) {
        console.log("100% Complete!");
        console.log(`[${percentAsString}]`);
    } else {
        console.log(`${percent}% [${percentAsString}]`);
        console.log("Still loading...");
    }
}

printLoadingBar(30);
printLoadingBar(50);
printLoadingBar(100);