function phoneBook(input) {
    let book = {};

    for (const element of input) {
        let [name, phoneNumber] = element.split(" ");

        book[name] = phoneNumber;
    }

    for (const key in book) {
        console.log(`${key} -> ${book[key]}`);
    }
}

phoneBook(
    ['Tim 0834212554',
        'Peter 0877547887',
        'Bill 0896543112',
        'Tim 0876566344']
);

phoneBook(
    ['George 0552554',
        'Peter 087587',
        'George 0453112',
        'Bill 0845344']
);