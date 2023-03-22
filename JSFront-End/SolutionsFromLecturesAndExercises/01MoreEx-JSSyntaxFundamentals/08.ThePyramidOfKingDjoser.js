function solver(size, increment) {
    let stone = 0;
    let marble = 0;
    let lapisLazuli = 0;

    let floor = 0;

    while (size > 2) {
        floor++;

        stone += ((size - 2) ** 2) * increment;

        let decoration = ((size ** 2) - ((size - 2) ** 2)) * increment;

        if (floor % 5 === 0) {
            lapisLazuli += decoration;
        } else {
            marble += decoration;
        }

        size -= 2;
    }

    let gold = (size ** 2) * increment;

    console.log(`Stone required: ${Math.ceil(stone)}`);
    console.log(`Marble required: ${Math.ceil(marble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapisLazuli)}`);
    console.log(`Gold required: ${Math.ceil(gold)}`);
    console.log(`Final pyramid height: ${Math.floor((floor + 1) * increment)}`);
}