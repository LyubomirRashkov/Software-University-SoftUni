function solve() {
    const [inputTextarea, outputTextarea] = Array.from(document.getElementsByTagName('textarea'));
    const [btnGenerate, btnBuy] = Array.from(document.getElementsByTagName('button'));
    const tbody = Array.from(document.getElementsByTagName('tbody'))[0]; 

    btnGenerate.addEventListener('click', generateHandler);
    btnBuy.addEventListener('click', buyHandler);

    function generateHandler() {

        let input = JSON.parse(inputTextarea.value);

        for (const obj of input) {
            let newTableRow = createElement('tr', undefined, undefined, undefined, undefined, tbody);
            let firstTd = createElement('td', undefined, undefined, undefined, undefined, newTableRow);
            createElement('img', undefined, undefined, undefined, { src: obj.img }, firstTd);
            let secondTd = createElement('td', undefined, undefined, undefined, undefined, newTableRow);
            createElement('p', obj.name, undefined, undefined, undefined, secondTd);
            let thirdTd = createElement('td', undefined, undefined, undefined, undefined, newTableRow);
            createElement('p', obj.price, undefined, undefined, undefined, thirdTd);
            let fourthTd = createElement('td', undefined, undefined, undefined, undefined, newTableRow);
            createElement('p', obj.decFactor, undefined, undefined, undefined, fourthTd);
            let fifthTd = createElement('td', undefined, undefined, undefined, undefined, newTableRow);
            createElement('input', undefined, undefined, undefined, { type: 'checkbox' }, fifthTd);
        }
    }

    function buyHandler() {
        const markedCheckboxes = Array.from(document.querySelectorAll('input[type="checkbox"]:checked'));

        let productNames = [];
        let totalPrice = 0;
        let totalDecFactor = 0;

        for (const checkbox of markedCheckboxes) {
            let row = checkbox.parentElement.parentElement;

            let tds = Array.from(row.getElementsByTagName('td'));

            let productName = (Array.from(tds[1].children))[0].textContent;
            productNames.push(productName);

            let productPrice = Number((Array.from(tds[2].children))[0].textContent);
            totalPrice += productPrice;

            let productDecFactor = Number((Array.from(tds[3].children))[0].textContent);
            totalDecFactor += productDecFactor;
        }

        let output = `Bought furniture: ${productNames.join(', ')}\n`;
        output += `Total price: ${totalPrice.toFixed(2)}\n`;
        output += `Average decoration factor: ${totalDecFactor / markedCheckboxes.length}`;

        outputTextarea.value = output;
    }

    function createElement(type, content, id, classes, attributes, parentNode) {
        const htmlElement = document.createElement(type);

        if (content && type !== 'input') {
            htmlElement.textContent = content;
        }

        if (content && type === 'input') {
            htmlElement.value = content;
        }

        if (id) {
            htmlElement.id = id;
        }

        if (classes) {
            htmlElement.classList.add(...classes);
        }

        if (attributes) {
            for (const key in attributes) {
                htmlElement.setAttribute(key, attributes[key]);
            }
        }

        if (parentNode) {
            parentNode.appendChild(htmlElement);
        }

        return htmlElement;
    }
}