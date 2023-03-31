// function storeProvision(stock, orderedProducts) {
//     let products = [];

//     for (let i = 0; i < stock.length; i += 2) {
//         let name = stock[i];
//         let quantity = Number(stock[i + 1]);

//         let product = { name: name, quantity: quantity};

//         products.push(product);
//     }

//     for (let i = 0; i < orderedProducts.length; i += 2) {
//         let name = orderedProducts[i];
//         let quantity = Number(orderedProducts[i + 1]);

//         let productInStock = products.find((p) => p.name === name);

//         if (productInStock) {
//             productInStock.quantity += quantity;
//         } else {
//             let product = {name: name, quantity: quantity};

//             products.push(product);
//         }
//     }

//     for (const product of products) {
//         console.log(`${product.name} -> ${product.quantity}`);
//     }
// }

// function storeProvision(stock, orderedProducts) {
//     let store = {};

//     for (let i = 0; i < stock.length; i += 2) {
//         let name = stock[i];
//         let quantity = Number(stock[i + 1]);

//         store[name] = quantity;
//     }

//     for (let i = 0; i < orderedProducts.length; i += 2) {
//         let name = orderedProducts[i];
//         let quantity = Number(orderedProducts[i + 1]);

//         if (store.hasOwnProperty(name)) {
//             store[name] += quantity;
//         } else {
//             store[name] = quantity;
//         }
//     }

//     let entries = Object.entries(store);

//     for (const [ product, quantity ] of entries) {
//         console.log(`${product} -> ${quantity}`);
//     }
// }

function storeProvision(stock, orderedProducts) {
    let all = [...stock, ...orderedProducts];

    let store = all
        .reduce((data, current, index) => {
            if (index % 2 === 0) {
                if (!(data.hasOwnProperty(current))) {
                    data[current] = 0;
                }
            } else {
                let value = Number(current);

                let previousProp = all[index - 1];

                data[previousProp] += value;
            }
            return data;
        }, {});

    for (const key in store) {
        console.log(`${key} -> ${store[key]}`);
    }
}

storeProvision(
    [
        'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
);

storeProvision(
    [
        'Salt', '2', 'Fanta', '4', 'Apple', '14', 'Water', '4', 'Juice', '5'
    ],
    [
        'Sugar', '44', 'Oil', '12', 'Apple', '7', 'Tomatoes', '7', 'Bananas', '30'
    ]
);