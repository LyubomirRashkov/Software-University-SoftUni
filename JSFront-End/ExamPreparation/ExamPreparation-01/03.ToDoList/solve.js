function attachEvents() {
    const BASE_URL = "http://localhost:3030/jsonstore/tasks/";

    const loadBtn = document.getElementById('load-button');
    const addBtn = document.getElementById('add-button');
    const ulContainer = document.getElementById('todo-list');
    const input = document.getElementById('title');

    loadBtn.addEventListener('click', loadAllTasksHandler);
    addBtn.addEventListener('click', addTaskHandler);

    function loadAllTasksHandler(e) {
        e?.preventDefault();

        ulContainer.innerHTML = '';

        fetch(BASE_URL)
            .then((res) => res.json())
            .then((response) => {
                let data = Object.values(response);

                for (const obj of data) {
                    const liItem = createElement('li', ulContainer, null, obj._id);
                    createElement('span', liItem, obj.name);
                    const removeBtn = createElement('button', liItem, 'Remove');
                    const editBtn = createElement('button', liItem, 'Edit');

                    removeBtn.addEventListener('click', removeTaskHandler);
                    editBtn.addEventListener('click', editTaskHandler);
                }
            })
            .catch((err) => {
                console.error(err);
            })
    }

    function addTaskHandler(e) {
        e?.preventDefault();

        const httpHeaders = {
            method: 'POST',
            body: JSON.stringify({
                name: input.value,
            }),
        };

        fetch(BASE_URL, httpHeaders)
            .then(() => {
                loadAllTasksHandler();

                input.value = '';
            })
            .catch((err) => {
                console.error(err);
            });
    }

    function removeTaskHandler(e) {
        e?.preventDefault();

        const id = e.currentTarget.parentNode.id;

        const httpHeaders = {
            method: 'DELETE',
        };

        fetch(`${BASE_URL}${id}`, httpHeaders)
            .then(() => loadAllTasksHandler())
            .catch((err) => {
                console.error(err);
            })
    }

    function editTaskHandler(e) {
        e?.preventDefault();

        const liItem = e.currentTarget.parentNode;
        const span = liItem.querySelector('span');

        let itemName = span.textContent;

        const input = createElement('input', null, itemName);
        liItem.prepend(input);
        const submitBtn = createElement('button', liItem, 'Submit');

        submitBtn.addEventListener('click', submitTaskHandler);

        span.remove();
        e.currentTarget.remove();
    }

    function submitTaskHandler(e) {
        e?.preventDefault();

        const liItem = e.currentTarget.parentNode;
        const input = liItem.querySelector('input');

        const id = liItem.id;

        const httpHeaders = {
            method: 'PATCH',
            body: JSON.stringify({
                name: input.value,
            }),
        };

        fetch(`${BASE_URL}${id}`, httpHeaders)
            .then(() => loadAllTasksHandler())
            .catch((err) => {
                console.error(err);
            });
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

attachEvents();
