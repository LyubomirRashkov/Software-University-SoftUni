window.addEventListener('load', solve);

function solve() {
    const inputDOMSelectors = {
        productType: document.getElementById('type-product'),
        description: document.getElementById('description'),
        name: document.getElementById('client-name'),
        phone: document.getElementById('client-phone'),
    };

    const otherDOMSelectors = {
        sendBtn: document.querySelector('#right button'),
        sectionReceived: document.getElementById('received-orders'),
        form: document.querySelector('form'),
        sectionCompleted: document.getElementById('completed-orders'),
        clearBtn: document.querySelector('.clear-btn'),
    };

    otherDOMSelectors.sendBtn.addEventListener('click', sendHandler);
    otherDOMSelectors.clearBtn.addEventListener('click', clearHandler);

    function sendHandler(e) {
        if (e) {
            e.preventDefault();
        }

        const areAllInputsFilled = Object.values(inputDOMSelectors)
            .every((i) => i.value !== '');

        if (!areAllInputsFilled
            || (inputDOMSelectors.productType.value !== 'Computer' && inputDOMSelectors.productType.value !== 'Phone')) {
            return;
        }

        const divContainer = createElement('div', otherDOMSelectors.sectionReceived, null, null, ['container']);
        createElement('h2', divContainer, `Product type for repair: ${inputDOMSelectors.productType.value}`);
        createElement('h3', divContainer, `Client information: ${inputDOMSelectors.name.value}, ${inputDOMSelectors.phone.value}`);
        createElement('h4', divContainer, `Description of the problem: ${inputDOMSelectors.description.value}`);
        const startBtn = createElement('button', divContainer, 'Start repair', null, ['start-btn']);
        const finishBtn = createElement('button', divContainer, 'Finish repair', null, ['finish-btn'], { disabled: true });

        startBtn.addEventListener('click', startHandler);

        otherDOMSelectors.form.reset();
    }

    function startHandler(e) {
        const startBtn = e.currentTarget;
        startBtn.setAttribute('disabled', true);

        const divContainer = startBtn.parentNode;

        const finishBtn = divContainer.querySelector('.finish-btn');
        finishBtn.removeAttribute('disabled');
        finishBtn.addEventListener('click', finishHandler);
    }

    function finishHandler(e) {
        const divContainer = e.currentTarget.parentNode;

        otherDOMSelectors.sectionCompleted.appendChild(divContainer);

        const startBtn = divContainer.querySelector('.start-btn');
        const finishBtn = divContainer.querySelector('.finish-btn');

        startBtn.remove();
        finishBtn.remove();
    }

    function clearHandler(e) {
        if (e) {
            e.preventDefault();
        }

        Array.from(otherDOMSelectors.sectionCompleted.querySelectorAll('div'))
            .map((div) => div.remove());
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