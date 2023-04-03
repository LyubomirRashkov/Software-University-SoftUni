function deleteByEmail() {
    const input = document.querySelector('input[name="email"]');
    const tableTdEmails = Array.from(document.querySelectorAll('td:nth-child(even)'));
    const divResult = document.getElementById('result');

    let email = input.value;

    let isFound = false;

    for (const tableTdEmail of tableTdEmails) {
        if (tableTdEmail.textContent === email) {
            isFound = true;

            let row = tableTdEmail.parentElement;
            row.remove();

            divResult.textContent = 'Deleted.';
            
            break;
        }
    }

    if (!isFound) {
        divResult.textContent = 'Not found.';
    }
}