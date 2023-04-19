window.addEventListener('load', solve);

function solve() {
    const BASE_URL = "http://localhost:3030/jsonstore/grocery/";

    const inputDomSelectors = {
        product: document.getElementById('product'),
        count: document.getElementById('count'),
        price: document.getElementById('price'),
    };

    const otherDOMSelectors = {
        loadBtn: document.getElementById('load-product'),
        tableBody: document.getElementById('tbody'),
        addBtn: document.getElementById('add-product'),
        form: document.querySelector('form'),
        updateBtn:document.getElementById('update-product'),
    };

    otherDOMSelectors.loadBtn.addEventListener('click', loadAllProductsHandler);
    otherDOMSelectors.addBtn.addEventListener('click', addProductHandler);

    let productsCollection = {};
    let idOfEditedProduct = null;

    function loadAllProductsHandler(e) {
        if (e) {
            e.preventDefault();
        }

        otherDOMSelectors.tableBody.innerHTML = '';

        fetch(BASE_URL)
            .then((res) => res.json())
            .then((response) => {
                const data = Object.values(response);

                for (const obj of data) {
                    const tableRow = createElement('tr', otherDOMSelectors.tableBody, null, obj._id);
                    createElement('td', tableRow, obj.product, null, ['name']);
                    createElement('td', tableRow, obj.count, null, ['count-product']);
                    createElement('td', tableRow, obj.price, null, ['product-price']);
                    const tableData = createElement('td', tableRow, null, null, ['btn']);
                    const updateBtn = createElement('button', tableData, 'Update', null, ['update']);
                    const deleteBtn = createElement('button', tableData, 'Delete', null, ['delete']);

                    updateBtn.addEventListener('click', updateProductHandler);
                    deleteBtn.addEventListener('click', deleteProductHandler);

                    productsCollection[obj._id] = {
                        product: obj.product,
                        count: obj.count,
                        price: obj.price,
                    };
                }
            })
            .catch((err) => {
                console.error(err);
            });
    }

    function addProductHandler(e) {
        if (e) {
            e.preventDefault();
        }

        const httpHeaders = {
            method: 'POST',
            body: JSON.stringify({
                product: inputDomSelectors.product.value,
                count: inputDomSelectors.count.value,
                price: inputDomSelectors.price.value,
            }),
        };

        fetch(BASE_URL, httpHeaders)
            .then(() => {
                loadAllProductsHandler();

                otherDOMSelectors.form.reset();
            })
            .catch((err) => {
                console.error(err);
            });
    }

    function updateProductHandler(e) {
        const productId = e.currentTarget.parentNode.parentNode.id;
        idOfEditedProduct = productId;

        const product = productsCollection[productId];

        for (const key in inputDomSelectors) {
            inputDomSelectors[key].value = product[key];
        }

        otherDOMSelectors.addBtn.setAttribute('disabled', true);
        otherDOMSelectors.updateBtn.removeAttribute('disabled');

        otherDOMSelectors.updateBtn.addEventListener('click', submitProductChangesHandler);
    }

    function submitProductChangesHandler(e) {
        if (e) {
            e.preventDefault();
        }

        const httpHeaders = {
            method: 'PATCH',
            body: JSON.stringify({
                product: inputDomSelectors.product.value,
                count: inputDomSelectors.count.value,
                price: inputDomSelectors.price.value,
            }),
        };

        fetch(`${BASE_URL}${idOfEditedProduct}`, httpHeaders)
            .then(() => {
                loadAllProductsHandler();

                otherDOMSelectors.form.reset();

                otherDOMSelectors.addBtn.removeAttribute('disabled');
                otherDOMSelectors.updateBtn.setAttribute('disabled', true);
            });
    }

    function deleteProductHandler(e) {
        const productId = e.currentTarget.parentNode.parentNode.id;

        const httpHeaders = {
            method: 'Delete',
        };

        fetch(`${BASE_URL}${productId}`, httpHeaders)
            .then(() => loadAllProductsHandler())
            .catch((err) => {
                console.error(err);
            });
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