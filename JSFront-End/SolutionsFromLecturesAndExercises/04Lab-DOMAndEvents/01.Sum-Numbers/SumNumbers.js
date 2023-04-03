function calc() {
    const firstInput = document.getElementById('num1');
    const secondInput = document.getElementById('num2');
    const sumInput = document.getElementById('sum');

    let numOne = Number(firstInput.value);
    let numTwo = Number(secondInput.value);

    sumInput.value = numOne + numTwo;
}
