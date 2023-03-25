function factorialDivision(numOne, numTwo) {
    console.log((calculateFactorial(numOne) / calculateFactorial(numTwo)).toFixed(2));

    function calculateFactorial(number) {
        if (number < 0) {
            return "Number must be non-negative!";
        }

        if (number === 0) {
            return 1;
        }

        if (number === 1) {
            return number;
        }

        return number * calculateFactorial(number - 1);
    }
}

factorialDivision(5, 2);
factorialDivision(6, 2);