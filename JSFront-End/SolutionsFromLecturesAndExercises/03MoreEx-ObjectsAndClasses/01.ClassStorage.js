class Storage {
    constructor(capacity) {
        this.capacity = capacity;
        this.storage = [];
        this.totalCost = 0;
    }

    addProduct(product) {
        this.storage.push(product);
        this.capacity -= product.quantity;
        this.totalCost += (product.price * product.quantity);
    }

    getProducts() {
        return this.storage
            .map((el) => JSON.stringify(el))
            .join("\n");
    }
}

let productOne = { name: 'Cucamber', price: 1.50, quantity: 15 };
let productTwo = { name: 'Tomato', price: 0.90, quantity: 25 };
let productThree = { name: 'Bread', price: 1.10, quantity: 8 };
let storage = new Storage(50);
storage.addProduct(productOne);
storage.addProduct(productTwo);
storage.addProduct(productThree);
console.log(storage.getProducts());
console.log(storage.capacity);
console.log(storage.totalCost);

let productOneTwo = {name: 'Tomato', price: 0.90, quantity: 19};
let productTwoTwo = {name: 'Potato', price: 1.10, quantity: 10};
let storageTwo = new Storage(30);
storageTwo.addProduct(productOneTwo);
storageTwo.addProduct(productTwoTwo);
console.log(storageTwo.totalCost);
