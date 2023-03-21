function solver(number) {
    let areAllDigitsSame = true;
    
    let digit = number % 10;
    let sum = digit;

    number = Math.floor(number / 10);
    
    while(number !== 0) {
        let newDigit = number % 10;
        sum += newDigit;

        if (newDigit !== digit) {
            areAllDigitsSame = false;
        }

        number = Math.floor(number / 10);
    }

    console.log(areAllDigitsSame);
    console.log(sum);
}