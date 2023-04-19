function solve(input) {
    let products = input.shift().split('!');

    while (true) {
        let line = input.shift();

        if (line === 'Go Shopping!') {
            break;
        }

        let tokens = line.split(' ');

        let command = tokens[0];
        let item = tokens[1];
        
        let index = products.indexOf(item);

        if (command === 'Urgent') {
            if (index < 0) {
                products.unshift(item);
            }
        } else if (command === 'Unnecessary') {
            if(index >= 0) {
                products.splice(index, 1);
            }
        } else if (command === 'Correct') {
            let newItem = tokens[2];

            if (index >= 0) {
                products.splice(index, 1, newItem);
            }
        } else if (command === 'Rearrange') {
            if (index >= 0) {
                products.splice(index, 1);
                products.push(item);
            }
        }
    }

    console.log(products.join(', '))
}

solve(
    [
        "Tomatoes!Potatoes!Bread",
        "Unnecessary Milk",
        "Urgent Tomatoes",
        "Go Shopping!"
    ]
);

solve(
    [
        "Milk!Pepper!Salt!Water!Banana",
        "Urgent Salt",
        "Unnecessary Grapes",
        "Correct Pepper Onion",
        "Rearrange Grapes",
        "Correct Tomatoes Potatoes",
        "Go Shopping!"
    ]
);