function signCheck(...numbers) {
    let output = "";

    numbers.filter(num => num < 0).length % 2 === 0 ? output = "Positive" : output = "Negative";

    console.log(output);
}

signCheck(5, 12, -15);
signCheck(-6, -12, 14);
signCheck(-1, -2, -3);
signCheck(-5, 1, 1);