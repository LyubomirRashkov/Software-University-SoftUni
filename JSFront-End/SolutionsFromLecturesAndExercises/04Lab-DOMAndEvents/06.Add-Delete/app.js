function addItem() {
    const input = document.getElementById('newItemText');
    const ul = document.getElementById('items');

    let content = input.value;

    let newLi = document.createElement('li');
    newLi.textContent = content;

    let newAnchor = document.createElement('a');
    newAnchor.textContent = '[Delete]';
    newAnchor.setAttribute('href', '#');
    newAnchor.addEventListener('click', deleteHandler);

    newLi.appendChild(newAnchor);

    ul.appendChild(newLi);

    input.value = '';

    function deleteHandler(e) {
        let li = e.currentTarget.parentElement;

        li.remove();
    }
}