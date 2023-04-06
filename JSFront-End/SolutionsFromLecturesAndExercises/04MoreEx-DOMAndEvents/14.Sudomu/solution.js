function solve() {
    const [checkBtn, clearBtn] = Array.from(document.getElementsByTagName('button'));
    const rows = Array.from(document.querySelectorAll('tbody > tr'));
    const table = document.querySelector('table');
    const divOutput = document.getElementById('check');
    const paragraphOutput = (Array.from(divOutput.children))[0];

    checkBtn.addEventListener('click', check);
    clearBtn.addEventListener('click', clear);

    function check() {
        let isValid = true;

        for (const row of rows) {
            const rowChildren = Array.from(row.children);

            let numbers = [1, 2, 3];

            for (const child of rowChildren) {
                let inputValue = Number(Array.from(child.children)[0].value);

                let index = numbers.indexOf(inputValue);

                if (index === -1) {
                    isValid = false;
                    break;
                }

                numbers.splice(index, 1);
            }

            if (!isValid) {
                break;
            }
        }

        if (isValid) {
            for (let i = 0; i < 3; i++) {
                let inputNumbers = [];

                for (const row of rows) {
                    const rowChildren = Array.from(row.children);
                    let inputNum = Number((Array.from(rowChildren[i].children))[0].value);
                    inputNumbers.push(inputNum);
                }

                let numbers = [1, 2, 3];

                for (let j = 0; j < numbers.length; j++) {
                    let index = inputNumbers.indexOf(numbers[j]);

                    if (index === -1) {
                        isValid = false;
                        break;
                    }

                    inputNumbers.splice(index, 1);
                }

                if(!isValid) {
                    break;
                }
            }
        }

        table.style.borderWidth = '2px';
        table.style.borderStyle = 'solid';

        if (isValid) {
            table.style.borderColor = 'green';

            paragraphOutput.style.color = 'green';
            paragraphOutput.textContent = 'You solve it! Congratulations!';
        } else {
            table.style.borderColor = 'red';

            paragraphOutput.style.color = 'red';
            paragraphOutput.textContent ='NOP! You are not done yet...';
        }
    }

    function clear() {
        for (let i = 0; i < rows.length; i++) {
            const rowChildren = Array.from(rows[i].children);

            for (let j = 0; j < rowChildren.length; j++) {
                const input = (Array.from(rowChildren[j].children))[0];
                
                input.value = '';
            }
        }

        table.style = 'none';

        paragraphOutput.textContent = '';
    }
}