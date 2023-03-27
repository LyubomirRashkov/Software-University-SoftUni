function pointsValidator(coordinates) {
    let x1 = coordinates[0];
    let y1 = coordinates[1];
    let x2 = coordinates[2];
    let y2 = coordinates[3];

    const isDistanceValid = (p1x, p1y, p2x, p2y) => {
        let distance = Math.sqrt(((p2x - p1x) ** 2) + ((p2y - p1y) ** 2));

        return Number.isInteger(distance);
    }

    const printResult = (p1x, p1y, p2x, p2y) => {
        if (isDistanceValid(p1x, p1y, 0, 0)) {
            console.log(`{${p1x}, ${p1y}} to {0, 0} is valid`);
        } else {
            console.log(`{${p1x}, ${p1y}} to {0, 0} is invalid`);
        }

        if (isDistanceValid(p2x, p2y, 0, 0)) {
            console.log(`{${p2x}, ${p2y}} to {0, 0} is valid`);
        } else {
            console.log(`{${p2x}, ${p2y}} to {0, 0} is invalid`);
        }

        if (isDistanceValid(p1x, p1y, p2x, p2y)) {
            console.log(`{${p1x}, ${p1y}} to {${p2x}, ${p2y}} is valid`);
        } else {
            console.log(`{${p1x}, ${p1y}} to {${p2x}, ${p2y}} is invalid`);
        }
    }

    printResult(x1, y1, x2, y2);
}

pointsValidator([3, 0, 0, 4]);
pointsValidator([2, 1, 1, 1]);