window.addEventListener("load", solve);

function solve() {
  const inputDOMSelectors = {
    firstName: document.getElementById('first-name'),
    lastName: document.getElementById('last-name'),
    age: document.getElementById('age'),
    gender: document.getElementById('genderSelect'),
    description: document.getElementById('task'),
  };

  const otherDOMSelectors = {
    submitBtn: document.getElementById('form-btn'),
    ulInProgress: document.getElementById('in-progress'),
    form: document.querySelector('form'),
    counter: document.getElementById('progress-count'),
    ulFinished: document.getElementById('finished'),
    clearBtn: document.getElementById('clear-btn'),
  };

  otherDOMSelectors.submitBtn.addEventListener('click', submitHandler);
  otherDOMSelectors.clearBtn.addEventListener('click', clearHandler);

  function submitHandler(e) {
    if (e) {
      e.preventDefault();
    }

    const areAllInputsFilled = Object.values(inputDOMSelectors)
      .every((i) => i.value !== '');

    if (!areAllInputsFilled) {
      return;
    }

    const liItem = createElement('li', otherDOMSelectors.ulInProgress, null, null, ['each-line']);
    const article = createElement('article', liItem);
    createElement('h4', article, `${inputDOMSelectors.firstName.value} ${inputDOMSelectors.lastName.value}`);
    createElement('p', article, `${inputDOMSelectors.gender.value}, ${inputDOMSelectors.age.value}`);
    createElement('p', article, `Dish description: ${inputDOMSelectors.description.value}`);
    const editBtn = createElement('button', liItem, 'Edit', null, ['edit-btn']);
    const completeBtn = createElement('button', liItem, 'Mark as complete', null, ['complete-btn']);

    editBtn.addEventListener('click', editHandler);
    completeBtn.addEventListener('click', completeHandler);

    otherDOMSelectors.form.reset();

    let count = Number(otherDOMSelectors.counter.textContent);
    count++;
    otherDOMSelectors.counter.textContent = count;
  }

  function editHandler(e) {
    const liItem = e.currentTarget.parentNode;

    const name = (liItem.querySelector('article > h4')).textContent;
    const [ firstName, lastName ] = name.split(' ');

    const [ paragraphOne, paragraphTwo] = Array.from(liItem.querySelectorAll('p'));
    const [ gender, age ] = (paragraphOne.textContent).split(', ');
    const description = paragraphTwo.textContent.substring(18);

    liItem.remove();

    inputDOMSelectors.firstName.value = firstName;
    inputDOMSelectors.lastName.value = lastName;
    inputDOMSelectors.age.value = age;
    inputDOMSelectors.gender.value = gender;
    inputDOMSelectors.description.value = description;

    decrementCount();
  }

  function completeHandler(e) {
    const liItem = e.currentTarget.parentNode;

    otherDOMSelectors.ulFinished.appendChild(liItem);

    decrementCount();

    const editBtn = liItem.querySelector('.edit-btn');
    const completeBtn = liItem.querySelector('.complete-btn');

    editBtn.remove();
    completeBtn.remove();
  }

  function clearHandler() {
    otherDOMSelectors.ulFinished.innerHTML = '';
  }

  function decrementCount() {
    let count = Number(otherDOMSelectors.counter.textContent);
    count--;
    otherDOMSelectors.counter.textContent = count;
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