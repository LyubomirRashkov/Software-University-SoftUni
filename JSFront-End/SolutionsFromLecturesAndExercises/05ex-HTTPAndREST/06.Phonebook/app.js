function attachEvents() {
    const BASE_URL = "http://localhost:3030/jsonstore/phonebook";

    const ulContainer = document.getElementById('phonebook');
    const btnLoad = document.getElementById('btnLoad');
    const btnCreate = document.getElementById('btnCreate');

    btnLoad.addEventListener('click', loadHandler);
    btnCreate.addEventListener('click', createHandler);

    function loadHandler() {
        ulContainer.innerHTML = '';

        fetch(BASE_URL)
            .then((res) => res.json())
            .then((response) => {
                let values = Object.values(response);

                for (const value of values) {
                    let newLi = createElement('li', `${value.person}: ${value.phone}`, undefined, undefined, undefined, ulContainer);
                    let btnDelete = createElement('button', 'Delete', value._id, undefined, undefined, newLi);
                    btnDelete.addEventListener('click', deleteHandler);
                }
            })
            .catch((err) => {
                console.error(err);
            })
    }

    function deleteHandler(e) {
        let btn = e.currentTarget;

        const httpHeaders = {
            method: 'DELETE',
        }

        fetch(`${BASE_URL}/${btn.id}`, httpHeaders)
            .then((res) => res.json())
            .then(loadHandler)
            .catch((err) => {
                console.error(err);
            })
    }

    function createHandler() {
        const inputPerson = document.getElementById('person');
        const inputPhone = document.getElementById('phone');
        
        let person = inputPerson.value;
        let phone = inputPhone.value;

        const httpHeaders = {
            method: 'POST',
            body: JSON.stringify({
                person,
                phone
            }),
        }

        fetch(BASE_URL, httpHeaders)
            .then((res) => res.json())
            .then(() => {
                loadHandler();

                inputPerson.value = '';
                inputPhone.value = '';
            })
            .catch((err) => {
                console.error(err);
            });
    }
}

attachEvents();

// type = string
// content = string
// id = string
// classes = array of strings
// attributes = object
// Trqbva da se dorazvie za textarea !!!
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