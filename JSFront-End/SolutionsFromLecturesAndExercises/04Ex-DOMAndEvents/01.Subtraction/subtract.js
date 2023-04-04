function subtract() {
    const firstInput = document.getElementById('firstNumber');
    const secondInput = document.getElementById('secondNumber');
    const resultDiv = document.getElementById('result');

    let firstNumber = Number(firstInput.value);
    let secondNumber = Number(secondInput.value);

    resultDiv.textContent = firstNumber - secondNumber;
}