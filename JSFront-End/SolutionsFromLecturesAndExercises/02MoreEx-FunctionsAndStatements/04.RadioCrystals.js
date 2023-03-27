// function radioCrystals(numbers) {
//     let target = numbers.shift();

//     for (let i = 0; i < numbers.length; i++) {
//         let number = numbers[i];

//         console.log(`Processing chunk ${number} microns`);

//         let operation = "";
//         let count = 0;

//         while (number !== target && number !== target - 1) {
//             if (number / 4 >= target - 1) {
//                 number /= 4;

//                 if (operation === "Cut") {
//                     count++;
//                 } else {
//                     operation = "Cut";
//                     count = 1;
//                 }

//                 continue;
//             }

//             if (number * 0.8 >= target - 1) {
//                 number *= 0.8;

//                 if (operation === "Lap") {
//                     count++;
//                 } else {
//                     if (operation !== "") {
//                         console.log(`${operation} x${count}`);
//                         console.log("Transporting and washing");
//                     }

//                     number = Math.floor(number);

//                     operation = "Lap";
//                     count = 1;
//                 }

//                 continue;
//             }

//             if (number - 20 >= target - 1) {
//                 number -= 20;

//                 if (operation === "Grind") {
//                     count++;
//                 } else {
//                     if (operation !== "") {
//                         console.log(`${operation} x${count}`);
//                         console.log("Transporting and washing");
//                     }

//                     number = Math.floor(number);

//                     operation = "Grind";
//                     count = 1;
//                 }

//                 continue;
//             }

//             if (number - 2 >= target - 1) {
//                 number -= 2;

//                 if (operation === "Etch") {
//                     count++;
//                 } else {
//                     if (operation !== "") {
//                         console.log(`${operation} x${count}`);
//                         console.log("Transporting and washing");
//                     }

//                     number = Math.floor(number);

//                     operation = "Etch";
//                     count = 1;
//                 }
//             }
//         }

//         if (operation !== "" && count !== 0) {
//             console.log(`${operation} x${count}`);
//             console.log("Transporting and washing");
//         }

//         if (number === target - 1) {
//             console.log("X-ray x1")
//         }

//         console.log(`Finished crystal ${target} microns`);
//     }
// }

function radioCrystals(numbers) {
    let target = numbers.shift();

    for (let i = 0; i < numbers.length; i++) {
        console.log(`Processing chunk ${numbers[i]} microns`);

        let count = 0;

        while (numbers[i] / 4 >= target - 1) {
            numbers[i] /= 4;
            count++;
        }

        if (count > 0) {
            console.log(`Cut x${count}`);
            console.log("Transporting and washing");
            numbers[i] = Math.floor(numbers[i])
            count = 0;
        }

        while (numbers[i] * 0.8 >= target - 1) {
            numbers[i] *= 0.8;
            count++;
        }

        if (count > 0) {
            console.log(`Lap x${count}`);
            console.log("Transporting and washing");
            numbers[i] = Math.floor(numbers[i])
            count = 0;
        }

        while (numbers[i] - 20 >= target - 1) {
            numbers[i] -= 20;
            count++;
        }

        if (count > 0) {
            console.log(`Grind x${count}`);
            console.log("Transporting and washing");
            count = 0;
        }

        while (numbers[i] - 2 >= target - 1) {
            numbers[i] -= 2;
            count++;
        }

        if (count > 0) {
            console.log(`Etch x${count}`);
            console.log("Transporting and washing");
        }

        if (numbers[i] === target - 1) {
            numbers[i] = target;
            console.log("X-ray x1")
        }

        console.log(`Finished crystal ${target} microns`);
    }
}

radioCrystals([1375, 50000]);
radioCrystals([1000, 4000, 8100]);
radioCrystals([9998,10000]);
radioCrystals([9980,10000]);
radioCrystals([8000,10000]);