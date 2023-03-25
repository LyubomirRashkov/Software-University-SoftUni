function palindromeIntegers(numbers) {
    // for (const number of numbers) {
    //     let numAsString = number.toString();
    //     let arr = [...numAsString];
    //     let reversed = arr.reverse();
    //     let reversedAsString = reversed.join("");

    //     console.log(numAsString === reversedAsString);
    // }

    const isPalindrome = (num) => Number([...num.toString()].reverse().join("")) === num;

    numbers.forEach((num) => {
        console.log(isPalindrome(num))
    });
}

palindromeIntegers([123,323,421,121]);
palindromeIntegers([32,2,232,1010]);