// function towns(input) {
//     let listOfTowns = [];

//     for (const element of input) {
//         let [ town, latitude, longitude ] = element.split(" | ");

//         let townObj = { 
//             town: town,
//             latitude: Number(latitude).toFixed(2),
//             longitude: Number(longitude).toFixed(2),
//          };

//         listOfTowns.push(townObj);
//     }

//     for (const item of listOfTowns) {
//         console.log(item);
//     }
// }

function towns(input) {
    input
        .map((el) => el.split(" | "))
        .map(([town, latitude, longitude]) => ({
            town: town,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2),
        }))
        .forEach((obj) => console.log(obj));
}

towns(
    [
        'Sofia | 42.696552 | 23.32601',
        'Beijing | 39.913818 | 116.363625'
    ]
);

towns(['Plovdiv | 136.45 | 812.575']);