function sequences(input) {
    input = input.map((el) => JSON.parse(el));
    input.forEach((el) => el.sort((elA, elB) => elB - elA));

    let uniques = [];

    for (let i = 0; i < input.length; i++) {
        let isUnique = true;

        for (let j = i + 1; j < input.length; j++) {
            if (input[i].toString() === input[j].toString()) {
                isUnique = false;
                input.splice(j, 1);
                i--;
                break;
            }
        }

        if (isUnique) {
            uniques.push(input[i]);
        }
    }

    uniques
        .sort((arrA, arrB) => arrA.length - arrB.length)
        .forEach((a) => console.log(`[${a.join(", ")}]`));
}

sequences(
    [
        "[-3, -2, -1, 0, 1, 2, 3, 4]",
        "[10, 1, -17, 0, 2, 13]",
        "[4, -3, 3, -2, 2, -1, 1, 0]"
    ]
);

sequences(
    [
        "[7.14, 7.180, 7.339, 80.099]",
        "[7.339, 80.0990, 7.140000, 7.18]",
        "[7.339, 7.180, 7.14, 80.099]"
    ]
);