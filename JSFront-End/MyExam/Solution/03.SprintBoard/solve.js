function attachEvents() {
    const BASE_URL = "http://localhost:3030/jsonstore/tasks/";

    const loadBtn = document.getElementById('load-board-btn');
    const addBtn = document.getElementById('create-task-btn');

    const ulToDo = document.querySelector('#todo-section > ul');
    const ulInProgress = document.querySelector('#in-progress-section > ul');
    const ulCodeReview = document.querySelector('#code-review-section > ul');
    const ulDone = document.querySelector('#done-section > ul');

    const inputTitle = document.getElementById('title');
    const textareaDescription = document.getElementById('description');

    loadBtn.addEventListener('click', loadHandler);
    addBtn.addEventListener('click', addHandler);

    function loadHandler(e) {
        if (e) {
            e.preventDefault();
        }

        fetch(BASE_URL)
            .then((res) => res.json())
            .then((response) => {
                const data = Object.values(response);

                ulToDo.innerHTML = '';
                ulInProgress.innerHTML = '';
                ulCodeReview.innerHTML = '';
                ulDone.innerHTML = '';

                for (const item of data) {
                    const liItem = createElement('li', null, null, item._id, ['task']);
                    createElement('h3', liItem, item.title);
                    createElement('p', liItem, item.description);
                    const btn = createElement('button', liItem);

                    btn.addEventListener('click', btnHandler);

                    if (item.status === 'ToDo') {
                        btn.textContent = 'Move to In Progress';
                        ulToDo.appendChild(liItem);
                    } else if (item.status === 'In Progress') {
                        btn.textContent = 'Move to Code Review';
                        ulInProgress.appendChild(liItem);
                    } else if (item.status === 'Code Review') {
                        btn.textContent = 'Move to Done';
                        ulCodeReview.appendChild(liItem);
                    } else if (item.status === 'Done') {
                        btn.textContent = 'Close';
                        ulDone.appendChild(liItem);
                    }
                }
            })
            .catch((err) => {
                console.error(err);
            });
    }

    function addHandler(e) {
        if (e) {
            e.preventDefault();
        }

        const httpHeaders = {
            method: 'POST',
            body: JSON.stringify({
                title: inputTitle.value,
                description: textareaDescription.value,
                status: 'ToDo',
            }),
        };

        fetch(BASE_URL, httpHeaders)
            .then(() => {
                loadHandler();
                inputTitle.value = '';
                textareaDescription.value = '';
            })
            .catch((err) => {
                console.error(err);
            });
    }

    function btnHandler(e) {
        const btnText = e.currentTarget.textContent;
        const id = e.currentTarget.parentNode.id;

        let httpHeaders = null;

        if (btnText === 'Move to In Progress') {
            httpHeaders = {
                method: 'PATCH',
                body: JSON.stringify({
                    status: 'In Progress',
                }),
            };
        } else if (btnText === 'Move to Code Review') {
            httpHeaders = {
                method: 'PATCH',
                body: JSON.stringify({
                    status: 'Code Review',
                }),
            };
        } else if (btnText === 'Move to Done') {
            httpHeaders = {
                method: 'PATCH',
                body: JSON.stringify({
                    status: 'Done',
                }),
            };
        } else if (btnText === 'Close') {
            httpHeaders = {
                method: 'DELETE',
            };
        }

        fetch(`${BASE_URL}${id}`, httpHeaders)
            .then(() => loadHandler())
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