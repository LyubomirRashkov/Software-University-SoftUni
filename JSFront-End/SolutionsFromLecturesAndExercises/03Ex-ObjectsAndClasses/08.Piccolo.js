function piccolo(input) {
    let cars = new Set();

    for (const element of input) {
        let [direction, carNumber] = element.split(", ");

        if (direction === "IN") {
            cars.add(carNumber);
        } else {
            cars.delete(carNumber);
        }
    }

    if (cars.size === 0) {
        console.log("Parking Lot is Empty");
    } else {
        let carsAsArray = [...cars];

        carsAsArray
            .sort((carNumA, carNumB) => carNumA.localeCompare(carNumB))
            .forEach((carNum) => console.log(carNum));
    }
}

piccolo(
    [
        'IN, CA2844AA',
        'IN, CA1234TA',
        'OUT, CA2844AA',
        'IN, CA9999TT',
        'IN, CA2866HI',
        'OUT, CA1234TA',
        'IN, CA2844AA',
        'OUT, CA2866HI',
        'IN, CA9876HH',
        'IN, CA2822UU'
    ]
);

piccolo(
    [
        'IN, CA2844AA',
        'IN, CA1234TA',
        'OUT, CA2844AA',
        'OUT, CA1234TA'
    ]
);