function addressBook(input) {
    let book = {};

    for (const element of input) {
        let [name, address] = element.split(":");

        book[name] = address;
    }

    let entries = Object.entries(book);

    let sortedEntries = entries.sort(([keyA, valueA], [keyB, valueB]) => {
        return keyA.localeCompare(keyB);
    })

    for (const entry of sortedEntries) {
        console.log(`${entry[0]} -> ${entry[1]}`);
    }
}

addressBook(
    ['Tim:Doe Crossing',
        'Bill:Nelson Place',
        'Peter:Carlyle Ave',
        'Bill:Ornery Rd']
);

addressBook(
    ['Bob:Huxley Rd',
        'John:Milwaukee Crossing',
        'Peter:Fordem Ave',
        'Bob:Redwing Ave',
        'George:Mesta Crossing',
        'Ted:Gateway Way',
        'Bill:Gateway Way',
        'John:Grover Rd',
        'Peter:Huxley Rd',
        'Jeff:Gateway Way',
        'Jeff:Huxley Rd']
);