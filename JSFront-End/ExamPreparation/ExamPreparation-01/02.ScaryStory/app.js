window.addEventListener("load", solve);

function solve() {
  const inputDOMSelectors = {
    firstName: document.getElementById('first-name'),
    lastName: document.getElementById('last-name'),
    age: document.getElementById('age'),
    storyTitle: document.getElementById('story-title'),
    genre: document.getElementById('genre'),
    storyText: document.getElementById('story'),
  };

  const otherDOMSelectors = {
    publishBtn: document.getElementById('form-btn'),
    ulContainer: document.getElementById('preview-list'),
    form: document.querySelector('form'),
    divMain: document.getElementById('main'),
    body: document.querySelector('body'),
  };

  otherDOMSelectors.publishBtn.addEventListener('click', publishStoryHandler);

  let storyObj = {};

  function publishStoryHandler(e) {
    const areAllInputsFilled = Object.values(inputDOMSelectors)
      .every((input) => input.value !== '');

    if (!areAllInputsFilled) {
      return;
    }

    for (const key in inputDOMSelectors) {
      storyObj[key] = inputDOMSelectors[key].value;
    }

    const liItem = createElement('li', otherDOMSelectors.ulContainer, null, null, ['story-info']);
    const article = createElement('article', liItem);
    createElement('h4', article, `Name: ${inputDOMSelectors.firstName.value} ${inputDOMSelectors.lastName.value}`);
    createElement('p', article, `Age: ${inputDOMSelectors.age.value}`);
    createElement('p', article, `Title: ${inputDOMSelectors.storyTitle.value}`);
    createElement('p', article, `Genre: ${inputDOMSelectors.genre.value}`);
    createElement('p', article, `${inputDOMSelectors.storyText.value}`);
    const saveBtn = createElement('button', liItem, 'Save Story', null, ['save-btn']);
    const editBtn = createElement('button', liItem, 'Edit Story', null, ['edit-btn']);
    const deleteBtn = createElement('button', liItem, 'Delete Story', null, ['delete-btn']);

    saveBtn.addEventListener('click', saveStoryHandler);
    editBtn.addEventListener('click', editStoryHandler);
    deleteBtn.addEventListener('click', deleteStoryHandler);

    otherDOMSelectors.form.reset();

    e.currentTarget.setAttribute('disabled', true);
  }

  function saveStoryHandler(e) {
    otherDOMSelectors.divMain.remove();

    const div = createElement('div', otherDOMSelectors.body, null, 'main');
    createElement('h1', div, 'Your scary story is saved!');
  }

  function editStoryHandler(e) {
    for (const key in inputDOMSelectors) {
      inputDOMSelectors[key].value = storyObj[key];
    }

    otherDOMSelectors.publishBtn.removeAttribute('disabled');

    e.currentTarget.parentNode.remove();
  }

  function deleteStoryHandler(e) {
    e.currentTarget.parentNode.remove();

    otherDOMSelectors.publishBtn.removeAttribute('disabled');
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