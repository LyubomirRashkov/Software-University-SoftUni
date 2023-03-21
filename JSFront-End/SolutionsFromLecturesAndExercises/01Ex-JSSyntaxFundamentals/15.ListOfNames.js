function solver(names) {
    console.log(
        names
            .sort((aName, bName) => aName.localeCompare(bName))
            .map((name, index) => { return `${index + 1}.${name}` })
            .join("\n"));
}