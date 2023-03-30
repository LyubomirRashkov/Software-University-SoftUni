function cats(input) {
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }

        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    for (const element of input) {
        let tokens = element.split(" ");

        let name = tokens[0];
        let age = Number(tokens[1]);

        let cat = new Cat(name, age);
        cat.meow();
    }
}

cats(['Mellow 2', 'Tom 5']);
cats(['Candy 1', 'Poppy 3', 'Nyx 2']);