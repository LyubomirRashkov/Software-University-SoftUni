window.addEventListener('load', solve);

function solve() {
    const inputDOMSelectors = {
        firstName: document.getElementById('first-name'),
        lastName: document.getElementById('last-name'),
        numberOfPeople: document.getElementById('people-count'),
        fromDate: document.getElementById('from-date'),
        daysCount: document.getElementById('days-count'),
    };

    const otherDOMSelectors = {
        nextBtn: document.getElementById('next-btn'),
        ulPreview: document.querySelector('.ticket-info-list'),
        form: document.querySelector('form'),
        ulConfirm: document.querySelector('.confirm-ticket'),
        main: document.getElementById('main'),
        body: document.getElementById('body'),
    };

    let ticket = {};

    otherDOMSelectors.nextBtn.addEventListener('click', nextStepHandler);

    function nextStepHandler(e) {
        if (e) {
            e.preventDefault();
        }

        const areAllInputsFilled = Object.values(inputDOMSelectors)
            .every((i) => i.value !== '');

        if (!areAllInputsFilled) {
            return;
        }

        const liItem = createElement('li', otherDOMSelectors.ulPreview, null, null, ['ticket']);
        const article = createElement('article', liItem);
        createElement('h3', article, `Name: ${inputDOMSelectors.firstName.value} ${inputDOMSelectors.lastName.value}`);
        createElement('p', article, `From date: ${inputDOMSelectors.fromDate.value}`);
        createElement('p', article, `For ${inputDOMSelectors.daysCount.value} days`);
        createElement('p', article, `For ${inputDOMSelectors.numberOfPeople.value} people`);
        const editBtn = createElement('button', liItem, 'Edit', null, ['edit-btn']);
        const continueBtn = createElement('button', liItem, 'Continue', null, ['continue-btn']);+

        editBtn.addEventListener('click', editInfoHandler);
        continueBtn.addEventListener('click', continueHandler);

        for (const key in inputDOMSelectors) {
            ticket[key] = inputDOMSelectors[key].value;
        }

        otherDOMSelectors.form.reset();
        e.currentTarget.setAttribute('disabled', true);
    }

    function editInfoHandler(e) {
        for (const key in inputDOMSelectors) {
            inputDOMSelectors[key].value = ticket[key];
        }

        otherDOMSelectors.nextBtn.removeAttribute('disabled');

        e.currentTarget.parentNode.remove();
    }

    function continueHandler(e) {
        const liItem = e.currentTarget.parentNode;

        otherDOMSelectors.ulConfirm.appendChild(liItem);

        const editBtn = liItem.querySelector('.edit-btn');
        const continueBtn = liItem.querySelector('.continue-btn');

        const confirmBtn = createElement('button', liItem, 'Confirm', null, ['confirm-btn']);
        const cancelBtn = createElement('button', liItem, 'Cancel', null, ['cancel-btn']);
        
        confirmBtn.addEventListener('click', confirmHandler);
        cancelBtn.addEventListener('click', cancelHandler);
        
        editBtn.remove();
        continueBtn.remove();
    }

    function confirmHandler() {
        otherDOMSelectors.main.remove();

        createElement('h1', otherDOMSelectors.body, 'Thank you, have a nice day!', 'thank-you');
        const backBtn = createElement('button', otherDOMSelectors.body, 'Back', 'back-btn');

        backBtn.addEventListener('click', backHandler);
    }

    function backHandler() {
        window.location.reload();
    }

    function cancelHandler(e) {
        e.currentTarget.parentNode.remove();

        otherDOMSelectors.nextBtn.removeAttribute('disabled');
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