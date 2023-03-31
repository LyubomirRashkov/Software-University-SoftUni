// function employees(input) {
//     let listOfEmployees = [];

//     for (const element of input) {
//         let employee = {
//             Name: element,
//             "Personal Number": element.length,
//         };

//         listOfEmployees.push(employee);
//     }

//     for (const employee of listOfEmployees) {
//         console.log(`Name: ${employee.Name} -- Personal Number: ${employee["Personal Number"]}`);
//     }
// }

function employees(input) {
    input
    .map((el) => ({ Name: el, "Personal Number": el.length }))
    .forEach((obj) => console.log(`Name: ${obj.Name} -- Personal Number: ${obj["Personal Number"]}`));
}

employees(
    [
        'Silas Butler',
        'Adnaan Buckley',
        'Juan Peterson',
        'Brendan Villarreal'
    ]
);

employees(
    [
        'Samuel Jackson',
        'Will Smith',
        'Bruce Willis',
        'Tom Holland'
    ]
);