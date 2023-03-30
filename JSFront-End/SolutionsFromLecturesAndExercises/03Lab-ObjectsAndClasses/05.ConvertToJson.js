function convertToJson(firstName, lastName, hairColor) {
    let obj = {
        name: firstName,
        lastName: lastName,
        hairColor: hairColor,
    };

    let stringAsJson = JSON.stringify(obj);

    console.log(stringAsJson);
}

convertToJson('George', 'Jones', 'Brown');
convertToJson('Peter', 'Smith', 'Blond');