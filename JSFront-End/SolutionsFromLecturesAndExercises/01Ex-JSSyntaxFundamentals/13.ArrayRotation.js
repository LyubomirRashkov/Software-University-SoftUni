function solver(numbers, rotationsCount) {
    rotationsCount %= numbers.length;

    for (let i = 1; i <= rotationsCount; i++) {
        let element = numbers.shift();
        numbers.push(element);
    }

    console.log(numbers.join(" "));
}