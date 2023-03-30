function convertToObject(stringAsJson) {
    let obj = JSON.parse(stringAsJson);

    for (const key in obj) {
        console.log(`${key}: ${obj[key]}`);
    }
}

convertToObject('{"name": "George", "age": 40, "town": "Sofia"}');
convertToObject('{"name": "Peter", "age": 35, "town": "Plovdiv"}');