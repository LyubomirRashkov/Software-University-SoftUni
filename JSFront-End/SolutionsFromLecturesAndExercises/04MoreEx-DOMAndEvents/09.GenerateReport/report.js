function generateReport() {
    const inputs = Array.from(document.getElementsByTagName('input'));
    const rows = Array.from(document.querySelectorAll('tbody > tr'));
    const textarea = document.getElementById('output');

    let listOfObjs = [];

    for (const row of rows) {
        let children = row.children;

        let obj = {};

        for (let i = 0; i < inputs.length; i++) {
            if (inputs[i].checked) {
                let key = inputs[i].name;
                let value = children[i].textContent;

                obj[key] = value;
            }
        }

        listOfObjs.push(obj);
    }

    textarea.textContent = JSON.stringify(listOfObjs, null, ' ');
}