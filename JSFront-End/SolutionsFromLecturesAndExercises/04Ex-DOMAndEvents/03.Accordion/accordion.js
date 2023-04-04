function toggle() {
    const btn = Array.from(document.getElementsByClassName('button'))[0];
    const divContent = document.getElementById('extra');

    if (btn.textContent === 'More') {
        divContent.style.display = 'block';

        btn.textContent = 'Less';
    } else {
        divContent.style.display = 'none';

        btn.textContent = 'More';
    }
}