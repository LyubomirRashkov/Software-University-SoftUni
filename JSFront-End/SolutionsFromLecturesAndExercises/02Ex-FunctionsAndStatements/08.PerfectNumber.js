function checkIfPerfect(number) {
    let isPerfect = false;

    if (number > 0) {
        let divisorsSum = 0;

        for (let i = 1; i <= Math.floor(number / 2); i++) {
            if (number % i === 0) {
                divisorsSum += i;
            }
        }

        if (divisorsSum === number) {
            isPerfect = true;
        }
    }

    if(isPerfect) {
        console.log("We have a perfect number!");
    } else {
        console.log("It's not so perfect.");
    }
}

checkIfPerfect(6);
checkIfPerfect(28);
checkIfPerfect(1236498);