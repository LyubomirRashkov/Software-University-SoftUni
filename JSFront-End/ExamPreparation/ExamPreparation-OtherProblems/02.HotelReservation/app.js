window.addEventListener('load', solve);

function solve() {
    const inputDOMSelectors = {
        firstName: document.getElementById('first-name'),
        lastName: document.getElementById('last-name'),
        dateIn: document.getElementById('date-in'),
        dateOut: document.getElementById('date-out'),
        peopleCount: document.getElementById('people-count'),
    };

    const otherDOMSelectors = {
        nextBtn: document.getElementById('next-btn'),
        ulInfo: document.querySelector('.info-list'),
        form: document.querySelector('form'),
        ulConfirm: document.querySelector('.confirm-list'),
        message: document.getElementById('verification'),
    };

    otherDOMSelectors.nextBtn.addEventListener('click', nextStepHandler);

    let info = {};

    function nextStepHandler(e) {
        if (e) {
            e.preventDefault();
        }

        const areAllInputsFilled = Object.values(inputDOMSelectors)
            .every((i) => i.value !== '');

        if (!areAllInputsFilled) {
            return;
        }

        const inDate = new Date(inputDOMSelectors.dateIn.value);
        const outDate = new Date(inputDOMSelectors.dateOut.value);

        if (inDate >= outDate) {
            return;
        }

        const liItem = createElement('li', otherDOMSelectors.ulInfo, null, null, ['reservation-content']);
        const article = createElement('article', liItem);
        createElement('h3', article, `Name: ${inputDOMSelectors.firstName.value} ${inputDOMSelectors.lastName.value}`);
        createElement('p', article, `From date: ${inputDOMSelectors.dateIn.value}`);
        createElement('p', article, `To date: ${inputDOMSelectors.dateOut.value}`);
        createElement('p', article, `For ${inputDOMSelectors.peopleCount.value} people`);
        const editBtn = createElement('button', liItem, 'Edit', null, ['edit-btn']);
        const continueBtn = createElement('button', liItem, 'Continue', null, ['continue-btn']);

        editBtn.addEventListener('click', editInfoHandler);
        continueBtn.addEventListener('click', continueHandler);

        for (const key in inputDOMSelectors) {
            info[key] = inputDOMSelectors[key].value;
        }

        otherDOMSelectors.form.reset();
        otherDOMSelectors.nextBtn.setAttribute('disabled', true);
    }

    function editInfoHandler(e) {
        e.currentTarget.parentNode.remove();
        
        for (const key in inputDOMSelectors) {
            inputDOMSelectors[key].value = info[key];
        }

        otherDOMSelectors.nextBtn.removeAttribute('disabled');
    }

    function continueHandler(e) {
        const liItem = e.currentTarget.parentNode;

        otherDOMSelectors.ulConfirm.appendChild(liItem);

        const confirmBtn = createElement('button', liItem, 'Confirm', null, ['confirm-btn']);
        const cancelBtn = createElement('button', liItem, 'Cancel', null, ['cancel-btn']);

        confirmBtn.addEventListener('click', confirmHandler);
        cancelBtn.addEventListener('click', cancelHandler);

        const editBtn = liItem.querySelector('.edit-btn');
        const continueBtn = liItem.querySelector('.continue-btn');

        editBtn.remove();
        continueBtn.remove();
    }

    function confirmHandler(e) {
        e.currentTarget.parentNode.remove();

        otherDOMSelectors.nextBtn.removeAttribute('disabled');

        otherDOMSelectors.message.classList.remove('reservation-cancelled');
        otherDOMSelectors.message.classList.add('reservation-confirmed');
        otherDOMSelectors.message.textContent = 'Confirmed.';
    }

    function cancelHandler(e) {
        e.currentTarget.parentNode.remove();

        otherDOMSelectors.nextBtn.removeAttribute('disabled');

        otherDOMSelectors.message.classList.remove('reservation-confirmed');
        otherDOMSelectors.message.classList.add('reservation-cancelled');
        otherDOMSelectors.message.textContent = 'Cancelled.';
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