function solve() {
    const inputDOMSelectors = {
        task: document.getElementById('task'),
        description: document.getElementById('description'),
        date: document.getElementById('date'),
    };

    const otherDOMSelectors = {
        addBtn: document.getElementById('add'),
        divOpen: (Array.from(((Array.from(document.querySelectorAll('section')))[1]).querySelectorAll('div')))[1],
        form: document.querySelector('form'),
        divInProgress: document.getElementById('in-progress'),
        divCompleted: (Array.from(((Array.from(document.querySelectorAll('section')))[3]).querySelectorAll('div')))[1],
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

        const article = createElement('article', otherDOMSelectors.divOpen);
        createElement('h3', article, inputDOMSelectors.task.value);
        createElement('p', article, `Description: ${inputDOMSelectors.description.value}`);
        createElement('p', article, `Due Date: ${inputDOMSelectors.date.value}`);
        const divFlex = createElement('div', article, null, null, ['flex']);
        const startBtn = createElement('button', divFlex, 'Start', null, ['green']);
        const deleteBtn = createElement('button', divFlex, 'Delete', null, ['red']);

        startBtn.addEventListener('click', startHandler);
        deleteBtn.addEventListener('click', deleteHandler);

        otherDOMSelectors.form.reset();
    }

    function startHandler(e) {
        const article = e.currentTarget.parentNode.parentNode;

        otherDOMSelectors.divInProgress.appendChild(article);

        const startBtn = article.querySelector('.green');
        startBtn.remove();

        const divFlex = article.querySelector('.flex');

        const finishBtn = createElement('button', divFlex, 'Finish', null, ['orange']);

        const deleteBtn = article.querySelector('.red');
        
        finishBtn.addEventListener('click', finishHandler);
        deleteBtn.addEventListener('click', deleteHandler);
    }

    function deleteHandler(e) {
        e.currentTarget.parentNode.parentNode.remove();
    }

    function finishHandler(e) {
        const article = e.currentTarget.parentNode.parentNode;

        otherDOMSelectors.divCompleted.appendChild(article);

        const divFlex = article.querySelector('.flex');

        divFlex.remove();
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