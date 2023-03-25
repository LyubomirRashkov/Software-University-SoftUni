function getSmallestNumber (...numbers) {
    console.log(Math.min.apply(Math, numbers));
}

getSmallestNumber(2, 5, 3);
getSmallestNumber(600, 342, 123);
getSmallestNumber(25, 21, 4);
getSmallestNumber(2, 2, 2);