function solver(inputs) {
    let username = inputs[0];

    let passwordReversedSymbols = username.split("");
    let passwordSymbols = passwordReversedSymbols.reverse();
    let password = passwordSymbols.join("");

    let invalidInputs = 0;

    for (let i = 1; i < inputs.length; i++) {
        if (inputs[i] === password) {
            console.log(`User ${username} logged in.`);

            break;
        } else {
            invalidInputs++;

            if (invalidInputs === 4) {
                console.log(`User ${username} blocked!`);

                break;
            }

            console.log("Incorrect password. Try again.");
        }        
    }
}