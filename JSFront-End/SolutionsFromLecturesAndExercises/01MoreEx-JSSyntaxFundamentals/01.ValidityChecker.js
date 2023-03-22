function solver(x1, y1, x2, y2) {
    let distance = calculateDistance(x1, y1, 0, 0);

    let output = "";

    if (Number.isInteger(distance)) {
        output = "valid";
    } else {
        output = "invalid";
    }

    console.log(`{${x1}, ${y1}} to {0, 0} is ${output}`);

    distance = calculateDistance(x2, y2, 0, 0);

    if (Number.isInteger(distance)) {
        output = "valid";
    } else {
        output = "invalid";
    }

    console.log(`{${x2}, ${y2}} to {0, 0} is ${output}`);

    distance = calculateDistance(x1, y1, x2, y2);

    if (Number.isInteger(distance)) {
        output = "valid";
    } else {
        output = "invalid";
    }

    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${output}`);

    function calculateDistance(p1x, p1y, p2x, p2y) {
        let result = Math.sqrt(((p2x - p1x) ** 2) + ((p2y -p1y) ** 2));

        return result;
    }
}

solver(3, 0, 0, 4);
solver(2, 1, 1, 1);