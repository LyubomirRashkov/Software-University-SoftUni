window.addEventListener("load", solve);

function solve() {
  const inputDOMSelectors = {
    title: document.getElementById('post-title'),
    category: document.getElementById('post-category'),
    content: document.getElementById('post-content'),
  };

  const otherDOMSelectors = {
    publishBtn: document.getElementById('publish-btn'),
    ulReview: document.getElementById('review-list'),
    form: document.querySelector('form'),
    ulPublished: document.getElementById('published-list'),
    clearBtn: document.getElementById('clear-btn'),
  };

  otherDOMSelectors.publishBtn.addEventListener('click', publishHandler);
  otherDOMSelectors.clearBtn.addEventListener('click', clearHandler);

  function publishHandler(e) {
    if (e) {
      e.preventDefault();
    }

    const areAllInputsFilled = Object.values(inputDOMSelectors)
      .every((i) => i.value !== '');

    if (!areAllInputsFilled) {
      return;
    }

    const liItem = createElement('li', otherDOMSelectors.ulReview, null, null, ['rpost']);
    const article = createElement('article', liItem);
    createElement('h4', article, `${inputDOMSelectors.title.value}`);
    createElement('p', article, `Category: ${inputDOMSelectors.category.value}`);
    createElement('p', article, `Content: ${inputDOMSelectors.content.value}`);
    const editBtn = createElement('button', liItem, 'Edit', null, ['action-btn', 'edit']);
    const approveBtn = createElement('button', liItem, 'Approve', null, ['action-btn', 'approve']);

    editBtn.addEventListener('click', editHandler);
    approveBtn.addEventListener('click', approveHandler);

    otherDOMSelectors.form.reset();
  }

  function editHandler(e) {
    const liItem = e.currentTarget.parentNode;

    const title = liItem.querySelector('h4').textContent;

    const [ paragraphOne, paragraphTwo ] = Array.from(liItem.querySelectorAll('p'));

    const category = paragraphOne.textContent.substring(10);
    const content = paragraphTwo.textContent.substring(9);

    liItem.remove();

    inputDOMSelectors.title.value = title;
    inputDOMSelectors.category.value = category;
    inputDOMSelectors.content.value = content;
  }

  function approveHandler(e) {
    const liItem = e.currentTarget.parentNode;

    otherDOMSelectors.ulPublished.appendChild(liItem);

    const editBtn = liItem.querySelector('.edit');
    const approveBtn = liItem.querySelector('.approve');

    editBtn.remove();
    approveBtn.remove();
  }

  function clearHandler(e) {
    if (e) {
      e.preventDefault();
    }

    otherDOMSelectors.ulPublished.innerHTML = '';
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