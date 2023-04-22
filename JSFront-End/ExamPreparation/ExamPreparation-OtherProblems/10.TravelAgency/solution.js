window.addEventListener('load', solution);

function solution() {
  const inputDOMSelectors = {
    name: document.getElementById('fname'),
    email: document.getElementById('email'),
    phone: document.getElementById('phone'),
    address: document.getElementById('address'),
    code: document.getElementById('code'),
  };

  const otherDOMSelectors = {
    submitBtn: document.getElementById('submitBTN'),
    ulContainer: document.getElementById('infoPreview'),
    editBtn: document.getElementById('editBTN'),
    continueBtn: document.getElementById('continueBTN'),
    divMain: document.getElementById('block'),
  };

  otherDOMSelectors.submitBtn.addEventListener('click', submitHandler);
  otherDOMSelectors.editBtn.addEventListener('click', editHandler);
  otherDOMSelectors.continueBtn.addEventListener('click', continueHandler);

  let info = {};

  function submitHandler(e) {
    if (inputDOMSelectors.name.value === '' || inputDOMSelectors.email.value === '') {
      return;
    }

    createElement('li', otherDOMSelectors.ulContainer, `Full Name: ${inputDOMSelectors.name.value}`);
    createElement('li', otherDOMSelectors.ulContainer, `Email: ${inputDOMSelectors.email.value}`);
    createElement('li', otherDOMSelectors.ulContainer, `Phone Number: ${inputDOMSelectors.phone.value}`);
    createElement('li', otherDOMSelectors.ulContainer, `Address: ${inputDOMSelectors.address.value}`);
    createElement('li', otherDOMSelectors.ulContainer, `Postal Code: ${inputDOMSelectors.code.value}`);

    for (const key in inputDOMSelectors) {
      info[key] = inputDOMSelectors[key].value;
      inputDOMSelectors[key].value = '';
    }

    e.currentTarget.setAttribute('disabled', true);

    otherDOMSelectors.editBtn.removeAttribute('disabled');
    otherDOMSelectors.continueBtn.removeAttribute('disabled');
  }

  function editHandler() {
    for (const key in inputDOMSelectors) {
      inputDOMSelectors[key].value = info[key];
    }

    otherDOMSelectors.editBtn.setAttribute('disabled', true);
    otherDOMSelectors.continueBtn.setAttribute('disabled', true);

    otherDOMSelectors.submitBtn.removeAttribute('disabled');

    otherDOMSelectors.ulContainer.innerHTML = '';
  }

  function continueHandler() {
    otherDOMSelectors.divMain.innerHTML = '';

    createElement('h3', otherDOMSelectors.divMain, 'Thank you for your reservation!');
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