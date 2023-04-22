function solve() {
    const inputDOMSelectors = {
        firstName: document.getElementById('fname'),
        lastName: document.getElementById('lname'),
        email: document.getElementById('email'),
        birthDate: document.getElementById('birth'),
        position: document.getElementById('position'),
        salary: document.getElementById('salary'),
    };

    const otherDOMSelectors = {
        hireBtn: document.getElementById('add-worker'),
        form: document.querySelector('form'),
        tableBody: document.getElementById('tbody'),
        budget: document.getElementById('sum'),
    };

    otherDOMSelectors.hireBtn.addEventListener('click', hireHandler);

    function hireHandler(e) {
        if (e) {
            e.preventDefault();
        }

        const areAllInputsFilled = Object.values(inputDOMSelectors)
            .every((i) => i.value !== '');

        if (!areAllInputsFilled) {
            return;
        }

        const tableRow = createElement('tr', otherDOMSelectors.tableBody);
        createElement('td', tableRow, `${inputDOMSelectors.firstName.value}`);
        createElement('td', tableRow, `${inputDOMSelectors.lastName.value}`);
        createElement('td', tableRow, `${inputDOMSelectors.email.value}`);
        createElement('td', tableRow, `${inputDOMSelectors.birthDate.value}`);
        createElement('td', tableRow, `${inputDOMSelectors.position.value}`);
        createElement('td', tableRow, `${inputDOMSelectors.salary.value}`);
        const tableData = createElement('td', tableRow);
        const firedBtn = createElement('button', tableData, 'Fired', null, ['fired']);
        const editBtn = createElement('button', tableData, 'Edit', null, ['edit']);

        firedBtn.addEventListener('click', fireHandler);
        editBtn.addEventListener('click', editHandler);

        let neededBudget = Number(otherDOMSelectors.budget.textContent);
        neededBudget += Number(inputDOMSelectors.salary.value);
        
        otherDOMSelectors.budget.textContent = neededBudget.toFixed(2);
        
        otherDOMSelectors.form.reset();
    }

    function fireHandler(e) {
        const tableRow = e.currentTarget.parentNode.parentNode;

        const salary = Number(((Array.from(tableRow.querySelectorAll('td')))[5]).textContent);

        tableRow.remove();

        decrementNeededBudget(salary);
    }

    function editHandler(e) {
        const tableRow = e.currentTarget.parentNode.parentNode;

        const [ firstName, lastName, email, birthDate, position, salary ] = Array.from(tableRow.children)
            .map((td) => td.textContent);

        tableRow.remove();

        inputDOMSelectors.firstName.value = firstName;
        inputDOMSelectors.lastName.value = lastName;
        inputDOMSelectors.email.value = email;
        inputDOMSelectors.birthDate.value = birthDate;
        inputDOMSelectors.position.value = position;
        inputDOMSelectors.salary.value = salary;

        decrementNeededBudget(salary);
    }

    function decrementNeededBudget(salary) {
        let neededBudget = Number(otherDOMSelectors.budget.textContent);
        neededBudget -= Number(salary);
        
        otherDOMSelectors.budget.textContent = neededBudget.toFixed(2);
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