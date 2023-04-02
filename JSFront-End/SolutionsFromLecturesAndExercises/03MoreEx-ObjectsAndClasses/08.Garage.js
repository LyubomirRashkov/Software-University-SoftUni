function garageSolver(input) {
    let garages = [];

    for (const element of input) {
        let [number, carInfo] = element.split(" - ");
        number = Number(number);

        let garage = garages.find((g) => g.number === number);

        if (!garage) {
            garage = {
                number,
                cars: [],
            };

            garages.push(garage);
        }

        let carTokens = carInfo.split(", ");

        let car = {};

        for (const carToken of carTokens) {
            let [key, value] = carToken.split(": ");

            car[key] = value;
        }

        garage.cars.push(car);
    }

    for (const garage of garages) {
        console.log(`Garage № ${garage.number}`);

        for (const car of garage.cars) {
            let entries = Object.entries(car);

            let outputs = [];

            for (const entry of entries) {
                let output = entry[0] + " - " + entry[1];

                outputs.push(output);
            }

            console.log(`--- ${outputs.join(", ")}`);
        }
    }
}

garageSolver(
    [
        '1 - color: blue, fuel type: diesel',
        '1 - color: red, manufacture: Audi',
        '2 - fuel type: petrol',
        '4 - color: dark blue, fuel type: diesel, manufacture: Fiat'
    ]
);

garageSolver(
    [
        '1 - color: green, fuel type: petrol',
        '1 - color: dark red, manufacture: WV',
        '2 - fuel type: diesel',
        '3 - color: dark blue, fuel type: petrol'
    ]
);