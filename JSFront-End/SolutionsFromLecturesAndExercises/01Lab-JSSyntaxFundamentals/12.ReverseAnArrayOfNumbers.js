function solver(num, numbers) {
    let takenNumbers = [];

    if (num > numbers.length) {
        num = numbers.length;
    }

    for (let i = 1; i <= num; i++) {
        takenNumbers.push(numbers.shift());
    }

    takenNumbers.reverse();

    console.log(takenNumbers.join(" "));
}