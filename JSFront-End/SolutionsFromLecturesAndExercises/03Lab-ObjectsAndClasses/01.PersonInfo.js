function personInfo(...input) {
    let firstName = input[0];
    let lastName = input[1];
    let age = Number(input[2]);

    let person = {
        firstName: firstName,
        lastName: lastName,
        age: age,
    }

    return person;
}

console.log(personInfo("Peter", "Pan", "20"));
console.log(personInfo("George", "Smith", "18"));