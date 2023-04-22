window.addEventListener('load', solve);

function solve() {
    const inputDOMSelectors = {
        model: document.getElementById('model'),
        year: document.getElementById('year'),
        description: document.getElementById('description'),
        price: document.getElementById('price'),
    };

    const otherDOMSelectors = {
        addBtn: document.getElementById('add'),
        tableBody: document.getElementById('furniture-list'),
        form: document.querySelector('form'),
        tdTotalPrice: document.querySelector('.total-price'),
    };

    otherDOMSelectors.addBtn.addEventListener('click', addHandler);

    function addHandler(e) {
        if (e) {
            e.preventDefault();
        }

        const areAllInputsFilled = Object.values(inputDOMSelectors)
            .every((i) => i.value !== '');

        if (!areAllInputsFilled) {
            return;
        }

        const yearValue = Number(inputDOMSelectors.year.value);
        const priceValue = Number(inputDOMSelectors.price.value);

        if (yearValue <= 0 || priceValue <= 0) {
            return;
        }

        const tableRowInfo = createElement('tr', otherDOMSelectors.tableBody, null, null, ['info']);
        createElement('td', tableRowInfo, inputDOMSelectors.model.value);
        createElement('td', tableRowInfo, Number(inputDOMSelectors.price.value).toFixed(2));
        const tableData = createElement('td', tableRowInfo);
        const moreBtn = createElement('button', tableData, 'More Info', null, ['moreBtn']);
        const buyBtn = createElement('button', tableData, 'Buy it', null, ['buyBtn']);
        const tableRowHide = createElement('tr', otherDOMSelectors.tableBody, null, null, ['hide']);
        createElement('td', tableRowHide, `Year: ${inputDOMSelectors.year.value}`);
        createElement('td', tableRowHide, `Description: ${inputDOMSelectors.description.value}`, null, null, { colspan: '3' });

        moreBtn.addEventListener('click', moreHandler);
        buyBtn.addEventListener('click', buyHandler);

        otherDOMSelectors.form.reset();
    }

    function moreHandler(e) {
        const btn = e.currentTarget;

        const tableRowHide = btn.parentNode.parentNode.nextElementSibling;

        if (btn.textContent === 'More Info') {
            btn.textContent = 'Less Info';

            tableRowHide.setAttribute('style', 'display: contents;');
        } else {
            btn.textContent = 'More Info';

            tableRowHide.setAttribute('style', 'display: none;');
        }
    }

    function buyHandler(e) {
        const btn = e.currentTarget;

        const tableRowInfo = btn.parentNode.parentNode;
        const tableRowHide = tableRowInfo.nextElementSibling;

        const price = Number(((Array.from(tableRowInfo.querySelectorAll('td')))[1]).textContent);

        tableRowInfo.remove();
        tableRowHide.remove();

        let totalPrice = Number(otherDOMSelectors.tdTotalPrice.textContent);
        totalPrice += price;

        otherDOMSelectors.tdTotalPrice.textContent = totalPrice.toFixed(2);
    }

    // type = string
    // content = string
    // id = string
    // classes = array of strings
    // attributes = object
    // Trqbva da se dorazvie za textarea !!!
    function createElement(type, parentNode, content, id, classes, attributes) {
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