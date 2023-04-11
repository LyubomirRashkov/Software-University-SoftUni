function attachEvents() {
  const BASE_URL = "http://localhost:3030/jsonstore/collections/students";

  const submitBtn = document.getElementById('submit');

  window.addEventListener("load", getEntries);
  submitBtn.addEventListener('click', submitHandler);

  function submitHandler() {
    const inputFirstName = document.querySelector('input[name="firstName"]');
    const inputLastName = document.querySelector('input[name="lastName"]');
    const inputFacultyNumber = document.querySelector('input[name="facultyNumber"]');
    const inputGrade = document.querySelector('input[name="grade"]');

    let firstName = inputFirstName.value;
    let lastName = inputLastName.value;
    let facultyNumber = inputFacultyNumber.value;
    let grade = inputGrade.value;

    // if (areValid(firstName, lastName, facultyNumber, grade)) {
      // facultyNumber = Number(facultyNumber);
      // grade = Number(grade);

      const httpHeaders = {
        method: 'POST',
        body: JSON.stringify({
          firstName,
          lastName,
          facultyNumber,
          grade,
        }),
      };

      fetch(BASE_URL, httpHeaders)
        .then((res) => res.json())
        .then(() => {
          getEntries();

          inputFirstName.value = '';
          inputLastName.value = '';
          inputFacultyNumber.value = '';
          inputGrade.value = '';
        })
        .catch((err) => {
          console.error(err);
        });
    // }
  }

  function areValid(firstName, lastName, facultyNumber, grade) {
    if (firstName && lastName && facultyNumber && grade) {
      let facultyNumberRegEx = /^[\d]+$/g;

      let gradeRegEx = /^[\d]\.?[\d]{0,2}$/g;

      if (facultyNumberRegEx.test(facultyNumber) && gradeRegEx.test(grade)) {
        return true;
      }
    }

    return false;
  }

  function getEntries() {
    const tableBody = Array.from(document.getElementsByTagName('tbody'))[0];

    tableBody.innerHTML = '';

    fetch(BASE_URL)
      .then((res) => res.json())
      .then((response) => {
        let values = Object.values(response);

        for (const value of values) {
          let tableRow = createElement('tr', undefined, undefined, undefined, undefined, tableBody);
          createElement('td', value.firstName, undefined, undefined, undefined, tableRow);
          createElement('td', value.lastName, undefined, undefined, undefined, tableRow);
          createElement('td', value.facultyNumber, undefined, undefined, undefined, tableRow);
          createElement('td', (value.grade).toFixed(2), undefined, undefined, undefined, tableRow);
        }
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