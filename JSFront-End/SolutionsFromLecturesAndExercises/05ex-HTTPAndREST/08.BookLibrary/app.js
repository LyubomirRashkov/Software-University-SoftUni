function attachEvents() {
  const BASE_URL = "http://localhost:3030/jsonstore/collections/books";

  const formTitle = document.querySelector('#form > h3');
  const inputTitle = document.querySelector('input[name="title"]');
  const inputAuthor = document.querySelector('input[name="author"]');
  const loadBtn = document.getElementById('loadBooks');
  const submitBtn = document.querySelector('#form > button');

  loadBtn.addEventListener('click', loadHandler);
  submitBtn.addEventListener('click', submitHandler);

  let books = {};
  let bookId = null;

  function loadHandler() {
    const tableBody = document.querySelector('tbody');

    tableBody.innerHTML = '';

    fetch(BASE_URL)
      .then((res) => res.json())
      .then((response) => {

        for (const key in response) {
          let tableRow = createElement('tr', undefined, undefined, undefined, undefined, tableBody);
          createElement('td', response[key].title, undefined, undefined, undefined, tableRow);
          createElement('td', response[key].author, undefined, undefined, undefined, tableRow);
          let tableCell = createElement('td', undefined, undefined, undefined, undefined, tableRow);
          let editBtn = createElement('button', 'Edit', key, undefined, undefined, tableCell);
          let deleteBtn = createElement('button', 'Delete', key, undefined, undefined, tableCell);

          editBtn.addEventListener('click', editHandler);
          deleteBtn.addEventListener('click', deleteHandler);
        }

        books = response;
      })
      .catch((err) => {
        console.error(err);
      });
  }

  function submitHandler() {
    let title = inputTitle.value;
    let author = inputAuthor.value;

    let url = BASE_URL;

    if (title && author) {
      const httpHeaders = {
        method: 'POST',
        body: JSON.stringify({
          author,
          title,
        }),
      }

      if (submitBtn.textContent === 'Save') {
        httpHeaders.method = 'PUT';

        url += `/${bookId}`;
      }

      fetch(url, httpHeaders)
        .then((res) => res.json())
        .then(() => {
          loadHandler();

          formTitle.textContent = 'FORM';
          inputTitle.value = '';
          inputAuthor.value = '';
          submitBtn.textContent = 'Submit';
        })
        .catch((err) => {
          console.error(err);
        })
    }
  }

  function editHandler(e) {
    let btn = e.currentTarget;

    formTitle.textContent = 'Edit FORM';
    inputTitle.value = (books[btn.id]).title;
    inputAuthor.value = (books[btn.id].author);
    submitBtn.textContent = 'Save';
    
    bookId = btn.id;
  }

  function deleteHandler(e) {
    let btn = e.currentTarget;

    const httpHeaders = {
      method: 'DELETE',
    };

    fetch(`${BASE_URL}/${btn.id}`, httpHeaders)
      .then((res) => res.json())
      .then(loadHandler)
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