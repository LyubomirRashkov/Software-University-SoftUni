function oddOccurrences(input) {
    input = input.toLowerCase();

    let elements = input.split(" ");

    let tuples = {};

    for (const element of elements) {
        if (!(tuples.hasOwnProperty(element))) {
            tuples[element] = 1;
        } else {
            tuples[element]++;
        }
    }

    let filteredEntries = Object.entries(tuples)
        .filter((e) => e[1] % 2 !== 0)
        .map((e) => e[0])
        .join(" ");

    console.log(filteredEntries);
}

oddOccurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
oddOccurrences('Cake IS SWEET is Soft CAKE sweet Food');