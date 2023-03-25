function printMatrix(sizeOfMatrix) {
    // let elements = [];

    // for (let i = 0; i < sizeOfMatrix; i++) {
    //     elements.push(sizeOfMatrix);
    // }

    // for (let i = 0; i < sizeOfMatrix; i++) {
    //     console.log(elements.join(" "));        
    // }

    new Array(sizeOfMatrix)
        .fill(new Array(sizeOfMatrix).fill(sizeOfMatrix))
        .forEach((row) => console.log(row.join(" ")));
}

printMatrix(3);
printMatrix(7);
printMatrix(2);