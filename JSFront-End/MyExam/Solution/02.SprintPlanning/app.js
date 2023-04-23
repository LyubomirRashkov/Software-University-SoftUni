window.addEventListener('load', solve);

function solve() {
    const inputDOMSelectors = {
        title: document.getElementById('title'),
        description: document.getElementById('description'),
        label: document.getElementById('label'),
        points: document.getElementById('points'),
        assignee: document.getElementById('assignee'),
    };

    const otherDOMSelectors = {
        createBtn: document.getElementById('create-task-btn'),
        deleteBtn: document.getElementById('delete-task-btn'),
        sectionSprints: document.getElementById('tasks-section'),
        inputId: document.getElementById('task-id'),
        deleteBtn: document.getElementById('delete-task-btn'),
        paragraphPoints: document.getElementById('total-sprint-points'),
    };

    otherDOMSelectors.createBtn.addEventListener('click', createHandler);
    otherDOMSelectors.deleteBtn.addEventListener('click', deleteTaskHandler);

    let tasksCount = 0

    const pointsKeeper = otherDOMSelectors.paragraphPoints.textContent.split(' ')[2];
    
    let arr = pointsKeeper.split();
    
    for (let i = 0; i < 3; i++) {
        arr.pop();        
    }
    
    let allPoints = Number(arr.join());

    function createHandler(e) {
        if (e) {
            e.preventDefault();
        }

        const areAllInputsFilled = Object.values(inputDOMSelectors)
            .every((i) => i.value !== '');

        if (!areAllInputsFilled) {
            return;
        }

        tasksCount++;
        const labelValue = inputDOMSelectors.label.value;

        const article = createElement('article', otherDOMSelectors.sectionSprints, null, `task-${tasksCount}`, ['task-card']);
        const divLabel = createElement('div', article, null, null, ['task-card-label']);
        
        if (labelValue === 'Feature') {
            divLabel.classList.add('feature');
            divLabel.innerHTML = `Feature &#8865;`;
        } else if (labelValue === 'Low Priority Bug') {
            divLabel.classList.add('low-priority');
            divLabel.innerHTML = `Low Priority Bug &#9737;`;
        } else if (labelValue === 'High Priority Bug') {
            divLabel.classList.add('high-priority');
            divLabel.innerHTML = `High Priority Bug &#9888;`;
        }

        createElement('h3', article, inputDOMSelectors.title.value, null, ['task-card-title']);
        createElement('p', article, inputDOMSelectors.description.value, null, ['task-card-description']);
        createElement('div', article, `Estimated at ${inputDOMSelectors.points.value} pts`, null, ['task-card-points']);
        createElement('div', article, `Assigned to: ${inputDOMSelectors.assignee.value}`, null, ['task-card-assignee']);
        const divBtn = createElement('div', article, null, null, ['task-card-actions']);
        const deleteBtn = createElement('button', divBtn, 'Delete');

        deleteBtn.addEventListener('click', deleteHandler);

        allPoints += Number(inputDOMSelectors.points.value);

        for (const key in inputDOMSelectors) {
            inputDOMSelectors[key].value = '';
        }

        otherDOMSelectors.paragraphPoints.textContent = `Total Points ${allPoints}pts`;
    }   

    function deleteHandler(e) {
        const article = e.currentTarget.parentNode.parentNode;

        const title = article.querySelector('.task-card-title').textContent;
        const description = article.querySelector('.task-card-description').textContent;

        const labelText = ((article.querySelector('.task-card-label').textContent).split(' '))[0];

        let label = null;
        if (labelText === 'Feature') {
            label = 'Feature';
        } else if (labelText === 'Low') {
            label = 'Low Priority Bug';
        } else if (labelText === 'High') {
            label = 'High Priority Bug';
        }

        const points = ((article.querySelector('.task-card-points').textContent).split(' '))[2];
        const assignee = ((article.querySelector('.task-card-assignee').textContent).split(': '))[1];
        const id = ((article.id).split('-'))[1];

        inputDOMSelectors.title.value = title;
        inputDOMSelectors.description.value = description;
        inputDOMSelectors.label.value = label;
        inputDOMSelectors.points.value = points;
        inputDOMSelectors.assignee.value = assignee;
        otherDOMSelectors.inputId.value = id;

        otherDOMSelectors.deleteBtn.removeAttribute('disabled');
        otherDOMSelectors.createBtn.setAttribute('disabled', true);

        for (const key in inputDOMSelectors) {
            inputDOMSelectors[key].setAttribute('disabled', true);
        }
    }

    function deleteTaskHandler(e) {
        if (e) {
            e.preventDefault();
        }

        let targetId = `task-${otherDOMSelectors.inputId.value}`;

        const article = otherDOMSelectors.sectionSprints.querySelector(`#${targetId}`);

        const points = ((article.querySelector('.task-card-points').textContent).split(' '))[2];

        article.remove();

        for (const key in inputDOMSelectors) {
            inputDOMSelectors[key].value = '';
            inputDOMSelectors[key].removeAttribute('disabled');
        }

        otherDOMSelectors.createBtn.removeAttribute('disabled');
        otherDOMSelectors.deleteBtn.setAttribute('disabled', true);

        allPoints -= Number(points);

        otherDOMSelectors.paragraphPoints.textContent = `Total Points ${allPoints}pts`;
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