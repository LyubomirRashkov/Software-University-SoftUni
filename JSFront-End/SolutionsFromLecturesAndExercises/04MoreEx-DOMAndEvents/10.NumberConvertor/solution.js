function solve() {
    const selectTo = document.getElementById('selectMenuTo');

    fillSelect(selectTo);

    const btn = document.querySelector('button');
    const inputResult = document.getElementById('result');

    btn.addEventListener('click', convertNumber);

    function convertNumber() {
        const input = document.getElementById('input');

        let number = Number(input.value);

        let targetFormat = (selectTo.querySelector('option:checked')).value;

        let isNegative = false;

        let digits = [];

        if (number === 0) {
            digits.push(0);
        } else {
            if (number < 0) {
                isNegative = true;

                number = Math.abs(number);
            }

            if (targetFormat === 'binary') {
                while (number > 0) {
                    let result = number / 2;
                    number = Math.floor(number / 2);

                    if (result === number) {
                        digits.push(0);
                    } else {
                        digits.push(1);
                    }
                }
            } else {
                while (number > 0) {
                    let result = number / 16;
                    number = Math.floor(number / 16);

                    if (result === number) {
                        digits.push(0);
                    } else {
                        let remainder = (result - number) * 16;

                        switch(remainder) {
                            case 10:
                                digits.push('A');
                            break;

                            case 11:
                                digits.push('B');
                            break;

                            case 12:
                                digits.push('C');
                            break;

                            case 13:
                                digits.push('D');
                            break;

                            case 14:
                                digits.push('E');
                            break;

                            case 15:
                                digits.push('F');
                            break;

                            default: 
                                digits.push(remainder);
                            break;
                        }
                    }
                }
            }
        }

        digits = digits.reverse();

        if (isNegative) {
            digits.unshift('-');
        }

        let output = digits.join('');

        inputResult.value = output;
    }

    function fillSelect(htmlSelectElement) {
        let child = Array.from(htmlSelectElement.children)[0];
        child.remove();

        let firstOption = document.createElement('option');
        firstOption.textContent = 'Binary';
        firstOption.value = 'binary';

        htmlSelectElement.appendChild(firstOption);

        let secondOption = document.createElement('option');
        secondOption.textContent = 'Hexadecimal';
        secondOption.value = 'hexadecimal';

        htmlSelectElement.appendChild(secondOption);
    }
}