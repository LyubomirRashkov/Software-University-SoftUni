function solver(num1, num2, operation) {
    let result = 0;

    switch (operation) {
        case "+":
            result = num1 + num2;
            break;

        case "-":
            result = num1 - num2;
            break;

        case "*":
            result = num1 * num2;
            break;

        case "/":
            result = num1 / num2;
            break;

        case "%":
            result = num1 % num2;
            break;

        case "**":
            result = num1 ** num2;
            break;
    }

    console.log(result);
}