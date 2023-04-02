function catalogue(input) {
    let dictionary = {};

    input.reduce((data, current) => {
        let [name, price] = current.split(" : ");
        data[name] = price;

        return data;
    }, dictionary)

    let entries = Object.entries(dictionary);

    let sortedEntries = entries
        .sort((entryA, entryB) => {
            let [nameA, priceA] = entryA;
            let [nameB, priceB] = entryB;

            return nameA.localeCompare(nameB);
        });

    let group = "";

    for (const [name, price] of sortedEntries) {
        if (group !== name[0]) {
            group = name[0];
            console.log(group);
        }

        console.log(`   ${name}: ${price}`);
    }
}

catalogue(
    [
        'Appricot : 20.4',
        'Fridge : 1500',
        'TV : 1499',
        'Deodorant : 10',
        'Boiler : 300',
        'Apple : 1.25',
        'Anti-Bug Spray : 15',
        'T-Shirt : 10'
    ]
);

catalogue(
    [
        'Omlet : 5.4',
        'Shirt : 15',
        'Cake : 59'
    ]
);