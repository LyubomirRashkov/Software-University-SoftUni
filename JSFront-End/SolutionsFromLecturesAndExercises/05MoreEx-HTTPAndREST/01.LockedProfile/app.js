function lockedProfile() {
    const BASE_URL = "http://localhost:3030/jsonstore/advanced/profiles";

    const main = document.getElementById('main');

    fetch(BASE_URL)
        .then((res) => res.json())
        .then((response) => {
            main.innerHTML = '';

            let values = Object.values(response);

            for (let i = 0; i < values.length; i++) {
                let divProfile = createElement('div', undefined, undefined, ['profile'], undefined, main);
                createElement('img', undefined, undefined, ['userIcon'], { src: './iconProfile2.png' }, divProfile);
                createElement('label', 'Lock', undefined, undefined, undefined, divProfile);
                createElement('input', undefined, undefined, undefined, { type: 'radio', name: `user${i + 1}Locked`, value: 'lock', checked: true }, divProfile);
                createElement('label', 'Unlock', undefined, undefined, undefined, divProfile);
                createElement('input', undefined, undefined, undefined, { type: 'radio', name: `user${i + 1}Locked`, value: 'unlock' }, divProfile);
                createElement('br', undefined, undefined, undefined, undefined, divProfile);
                createElement('hr', undefined, undefined, undefined, undefined, divProfile);
                createElement('label', 'Username', undefined, undefined, undefined, divProfile);
                createElement('input', undefined, undefined, undefined, { type: 'text', name: `user${i + 1}Username`, value: values[i].username, disabled: true, readonly: true }, divProfile);
                let divHidden = createElement('div', undefined, `user${i}HiddenFields`, undefined, undefined, divProfile);
                divHidden.style.display = 'none';
                createElement('hr', undefined, undefined, undefined, undefined, divHidden);
                createElement('label', 'Email:', undefined, undefined, undefined, divHidden);
                createElement('input', undefined, undefined, undefined, { type: 'email', name: `user${i + 1}Email`, value: values[i].email, disabled: true, readonly: true }, divHidden);
                createElement('label', 'Age:', undefined, undefined, undefined, divHidden);
                createElement('input', undefined, undefined, undefined, { type: 'email', name: `user${i + 1}Age`, value: values[i].age, disabled: true, readonly: true }, divHidden);
                let btnShow = createElement('button', 'Show more', undefined, undefined, undefined, divProfile);

                btnShow.addEventListener('click', toggleInfoHandler);
            }
        })
        .catch((err) => {
            console.error(err);
        });

        function toggleInfoHandler(e) {
            let btn = e.currentTarget;

            const parent = btn.parentElement;
            const inputUnlock = parent.querySelector('input[value="unlock"]');

            if (inputUnlock.checked) {
                const divHidden = Array.from(parent.getElementsByTagName('div'))[0];

                if (btn.textContent === 'Show more') {
                    divHidden.style.display = 'block';
                    btn.textContent = 'Hide it';
                } else {
                    divHidden.style.display = 'none';
                    btn.textContent = 'Show more';
                }
            }
        }
}

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