function simpleCalculator(numOne, numTwo, operator) {
    let add = (numOne, numTwo) => numOne + numTwo;
    let subtract = (numOne, numTwo) => numOne - numTwo;
    let multiply = (numOne, numTwo) => numOne * numTwo;
    let divide = (numOne, numTwo) => numOne / numTwo;

    let operationMap = {
        add: add,
        subtract: subtract,
        multiply: multiply,
        divide: divide
    }

    console.log(operationMap[operator](numOne, numTwo));
}

simpleCalculator(5, 5, 'multiply');
simpleCalculator(40, 8, 'divide');
simpleCalculator(12, 19, 'add');
simpleCalculator(50, 13, 'subtract');