function addItem() {
    const inputText = document.getElementById('newItemText');
    const inputValue = document.getElementById('newItemValue');
    const select = document.getElementById('menu');

    let newOption = document.createElement('option');
    newOption.textContent = inputText.value;
    newOption.value = inputValue.value;

    select.appendChild(newOption);

    inputText.value = '';
    inputValue.value = '';
}