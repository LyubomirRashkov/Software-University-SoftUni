function passwordValidator(password) {
    let hasValidLength = (pass) => pass.length >= 6 && pass.length <= 10;
    let consistsOnlyOfLettersAndDigits = (pass) => /^[A-Za-z\d]+$/g.test(pass);
    let hasAtLeastTwoDigits = (pass) => [...pass.matchAll(/\d/g)].length >= 2;

    let isValid = true;

    if (!(hasValidLength(password))) {
        isValid = false;
        console.log("Password must be between 6 and 10 characters");
    }

    if (!(consistsOnlyOfLettersAndDigits(password))) {
        isValid = false;
        console.log("Password must consist only of letters and digits");
    }

    if (!(hasAtLeastTwoDigits(password))) {
        isValid = false;
        console.log("Password must have at least 2 digits");
    }

    if (isValid) {
        console.log("Password is valid");
    }
}

passwordValidator('logIn');
passwordValidator('MyPass123');
passwordValidator('Pa$s$s');