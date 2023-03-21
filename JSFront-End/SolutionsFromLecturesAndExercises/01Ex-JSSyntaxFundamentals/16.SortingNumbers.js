function solver(numbers) {
    numbers.sort((num1, num2) => num1 - num2);

    let output = [];

    while(numbers.length > 0) {
        output.push(numbers.shift());

        if (numbers.length === 0) {
            break;
        }

        output.push(numbers.pop());
    }

    return output;
}