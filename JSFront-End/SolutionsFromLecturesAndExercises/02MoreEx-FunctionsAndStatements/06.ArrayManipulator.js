function arrayManipulator(numbers = [], commands = []) {

    for (const command of commands) {
        let tokens = command.split(" ");

        if (tokens[0] === "add") {
            let index = Number(tokens[1]);
            let element = Number(tokens[2]);

            numbers.splice(index, 0, element);
        } else if (tokens[0] === "addMany") {
            let i = Number(tokens[1]);
            let elements = tokens.slice(2).map(Number);

            numbers.splice(i, 0, ...elements);
        } else if (tokens[0] === "contains") {
            let el = Number(tokens[1]);

            console.log(numbers.indexOf(el));
        } else if (tokens[0] === "remove") {
            let indexToRemove = Number(tokens[1]);

            numbers.splice(indexToRemove, 1);
        } else if (tokens[0] === "shift") {
            let positions = Number(tokens[1]);

            for (let i = 0; i < positions; i++) {
                let value = numbers.shift();
                numbers.push(value);
            }
        } else if (tokens[0] === "sumPairs") {
            let newNumbers = [];

            for (let i = 0; i < numbers.length; i += 2) {
                let sum = 0;

                if (i === numbers.length - 1) {
                    sum = numbers[i];
                } else {
                    sum = numbers[i] + numbers[i + 1];
                }

                newNumbers.push(sum);
            }

            numbers = newNumbers;
        } else {
            console.log(`[ ${numbers.join(", ")} ]`)
            break;
        }
    }
}

arrayManipulator([1, 2, 4, 5, 6, 7], ['add 1 8', 'contains 1', 'contains 3', 'print']);
arrayManipulator([1, 2, 3, 4, 5], ['addMany 5 9 8 7 6 5', 'contains 15', 'remove 3', 'shift 1', 'print']);