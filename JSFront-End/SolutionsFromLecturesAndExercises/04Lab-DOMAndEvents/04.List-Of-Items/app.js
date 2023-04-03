function addItem() {
    const input = document.getElementById('newItemText');
    const ul = document.getElementById('items');

    let content = input.value;

    let newLi = document.createElement('li');
    newLi.textContent = content;

    ul.appendChild(newLi);

    input.value = '';
}