function solver(numbers) {
    let sum = numbers.shift();

    sum+= numbers.pop();

    console.log(sum);
}