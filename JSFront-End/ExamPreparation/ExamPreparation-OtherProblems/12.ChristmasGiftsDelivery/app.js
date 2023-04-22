function solution() {
    const inputName = document.querySelector('input');
    const addBtn = Array.from(document.querySelectorAll('button'))[0];
    const ulContainer = ((Array.from(document.querySelectorAll('.card')))[1]).querySelector('ul');
    const ulSent = ((Array.from(document.querySelectorAll('.card')))[2]).querySelector('ul');
    const ulDiscard = ((Array.from(document.querySelectorAll('.card')))[3]).querySelector('ul');

    addBtn.addEventListener('click', addHandler);

    let allGifts = [];

    function addHandler() {
        ulContainer.innerHTML = '';

        allGifts.push(inputName.value);
        
        inputName.value = '';

        allGifts = allGifts.sort((a, b) => a.localeCompare(b));

        for (const item of allGifts) {
            const liItem = createElement('li', ulContainer, item, null, ['gift']);
            const sendBtn = createElement('button', liItem, 'Send', null, ['sendButton']);
            const discardBtn = createElement('button', liItem, 'Discard', null, ['discardButton']);

            sendBtn.addEventListener('click', sendHandler);
            discardBtn.addEventListener('click', discardHandler);
        }
    }

    function sendHandler(e) {
        const liItem = e.currentTarget.parentNode;
        
        const giftName = liItem.textContent;

        removeFromAllGifts(giftName);

        const sendBtn = liItem.querySelector('.sendButton');
        const discardBtn = liItem.querySelector('.discardButton');
        
        sendBtn.remove();
        discardBtn.remove();
        
        ulSent.appendChild(liItem);
    }

    function discardHandler(e) {
        const liItem = e.currentTarget.parentNode;

        const giftName = liItem.textContent;

        removeFromAllGifts(giftName);

        const sendBtn = liItem.querySelector('.sendButton');
        const discardBtn = liItem.querySelector('.discardButton');
        
        sendBtn.remove();
        discardBtn.remove();
        
        ulDiscard.appendChild(liItem);
    }

    function removeFromAllGifts(gift) {
        const index = allGifts.indexOf(gift);
        allGifts.splice(index, 1);
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