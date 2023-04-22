function solve() {
    const inputDOMSelectors = {
        recipient: document.getElementById('recipientName'),
        title: document.getElementById('title'),
        message: document.getElementById('message'),
    };

    const otherDOMSelectors = {
        addBtn: document.getElementById('add'),
        resetBtn: document.getElementById('reset'),
        ulList: document.getElementById('list'),
        ulSent: document.querySelector('.sent-list'),
        ulDeleted: document.querySelector('.delete-list'),
    };

    otherDOMSelectors.addBtn.addEventListener('click', addHandler);
    otherDOMSelectors.resetBtn.addEventListener('click', resetHandler);

    function addHandler(e) {
        if (e) {
            e.preventDefault();
        }

        const areAllInputsFilled = Object.values(inputDOMSelectors)
            .every((i) => i.value !== '');

        if (!areAllInputsFilled) {
            return;
        }

        const liItem = createElement('li', otherDOMSelectors.ulList);
        createElement('h4', liItem, `Title: ${inputDOMSelectors.title.value}`);
        createElement('h4', liItem, `Recipient Name: ${inputDOMSelectors.recipient.value}`);
        createElement('span', liItem, inputDOMSelectors.message.value);
        const divActions = createElement('div', liItem, null, 'list-action');
        const sendBtn = createElement('button', divActions, 'Send', 'send', null, { type: 'submit' });
        const deleteBtn = createElement('button', divActions, 'Delete', 'delete', null, { type: 'submit' });

        sendBtn.addEventListener('click', sendHandler);
        deleteBtn.addEventListener('click', deleteHandler);

        clearInputs();
    }

    function resetHandler(e) {
        if (e) {
            e.preventDefault();
        }

        clearInputs();
    }

    function sendHandler(e) {
        if (e) {
            e.preventDefault();
        }

        const liItem = e.currentTarget.parentNode.parentNode;

        const [h4One, h4Two] = Array.from(liItem.querySelectorAll('h4'));

        liItem.remove();

        const recipient = h4Two.textContent.substring(16);
        const title = h4One.textContent.substring(7);

        const newLiItem = createElement('li', otherDOMSelectors.ulSent);
        createElement('span', newLiItem, `To: ${recipient}`);
        createElement('span', newLiItem, `Title: ${title}`);
        const divBtns = createElement('div', newLiItem, null, null, ['btn']);
        const deleteBtn = createElement('button', divBtns, 'Delete', null, ['delete'], { type: 'submit' });

        deleteBtn.addEventListener('click', deleteHandler);
    }

    function deleteHandler(e) {
        if (e) {
            e.preventDefault();
        }

        const parent = e.currentTarget.parentNode;

        let liItem = parent.parentNode;

        if (parent.id === 'list-action') {
            const [h4One, h4Two] = Array.from(liItem.querySelectorAll('h4'));

            const recipient = h4Two.textContent.substring(16);
            const title = h4One.textContent.substring(7);

            liItem.innerHTML = '';

            createElement('span', liItem, `To: ${recipient}`);
            createElement('span', liItem, `Title: ${title}`);
        } else {
            const divBtns = liItem.querySelector('div');
            divBtns.remove();
        }
        
        otherDOMSelectors.ulDeleted.appendChild(liItem);
    }

    function clearInputs() {
        for (const key in inputDOMSelectors) {
            inputDOMSelectors[key].value = '';
        }
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

solve()