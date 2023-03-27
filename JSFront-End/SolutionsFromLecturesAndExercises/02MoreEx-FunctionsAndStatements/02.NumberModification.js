function numberModification(number) {
    const calculateAverageOfDigits = (num) => {
        let sum = 0;
        let count = 0;

        while (num > 0) {
            let digit = num % 10;

            sum += digit;
            count++;

            num = Math.floor(num / 10);
        }

        return sum / count;
    }

    while (calculateAverageOfDigits(number) < 5) {
        let numberAsString = number.toString();
        let newNumberAsString = numberAsString + "9";
        number = Number(newNumberAsString);
    }

    console.log(number);
}

numberModification(101);
numberModification(5835);