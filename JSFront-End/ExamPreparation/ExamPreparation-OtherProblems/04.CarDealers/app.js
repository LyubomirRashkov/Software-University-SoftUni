window.addEventListener("load", solve);

function solve() {
  const inputDOMSelectors = {
    make: document.getElementById('make'),
    model: document.getElementById('model'),
    year: document.getElementById('year'),
    fuelType: document.getElementById('fuel'),
    originalPrice: document.getElementById('original-cost'),
    sellingPrice: document.getElementById('selling-price'),
  };

  const otherDOMSelectors = {
    publishBtn: document.getElementById('publish'),
    tableBody: document.getElementById('table-body'),
    ulContainer: document.getElementById('cars-list'),
    profitValue: document.getElementById('profit'),
  };

  otherDOMSelectors.publishBtn.addEventListener('click', publishHandler);

  function publishHandler(e) {
    if (e) {
      e.preventDefault();
    }

    const areAllInputsFilled = Object.values(inputDOMSelectors)
      .every((i) => i.value !== '');

    if (!areAllInputsFilled) {
      return;
    }

    const priceOriginal = Number(inputDOMSelectors.originalPrice.value);
    const priceSelling = Number(inputDOMSelectors.sellingPrice.value);

    if (priceOriginal >= priceSelling) {
      return;
    }

    const tableRow = createElement('tr', otherDOMSelectors.tableBody, null, null, ['row']);
    createElement('td', tableRow, `${inputDOMSelectors.make.value}`);
    createElement('td', tableRow, `${inputDOMSelectors.model.value}`);
    createElement('td', tableRow, `${inputDOMSelectors.year.value}`);
    createElement('td', tableRow, `${inputDOMSelectors.fuelType.value}`);
    createElement('td', tableRow, `${inputDOMSelectors.originalPrice.value}`);
    createElement('td', tableRow, `${inputDOMSelectors.sellingPrice.value}`);
    const tableData = createElement('td', tableRow);
    const editBtn = createElement('button', tableData, 'Edit', null, ['action-btn', 'edit']);
    const sellBtn = createElement('button', tableData, 'Sell', null, ['action-btn', 'sell']);

    editBtn.addEventListener('click', editHandler);
    sellBtn.addEventListener('click', sellHandler);

    for (const key in inputDOMSelectors) {
      inputDOMSelectors[key].value = '';
    }
  }

  function editHandler(e) {
    const tableRow = e.currentTarget.parentNode.parentNode;

    const [ make, model, year, fuelType, originalPrice, sellingPrice ] = Array.from(tableRow.children)
      .map((td) => td.textContent);

    tableRow.remove();

    inputDOMSelectors.make.value = make;
    inputDOMSelectors.model.value = model;
    inputDOMSelectors.year.value = year;
    inputDOMSelectors.fuelType.value = fuelType;
    inputDOMSelectors.originalPrice.value = originalPrice;
    inputDOMSelectors.sellingPrice.value = sellingPrice;
  }

  function sellHandler(e) {
    const tableRow = e.currentTarget.parentNode.parentNode;

    const [ make, model, year, _fuelType, originalPrice, sellingPrice ] = Array.from(tableRow.children)
      .map((td) => td.textContent);

    tableRow.remove();

    const profit = Number(sellingPrice) - Number(originalPrice);

    const liItem = createElement('li', otherDOMSelectors.ulContainer, null, null, ['each-list']);
    createElement('span', liItem, `${make} ${model}`);
    createElement('span', liItem, `${year}`);
    createElement('span', liItem, profit);

    updateTotalProfit(profit);
  }

  function updateTotalProfit(currentProfit) {
    let profit = Number(otherDOMSelectors.profitValue.textContent);

    profit += currentProfit;

    otherDOMSelectors.profitValue.textContent = profit.toFixed(2);
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