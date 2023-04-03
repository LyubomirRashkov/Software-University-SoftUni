function extractText() {
    const liItems = Array.from(document.getElementsByTagName('li'));
    const result = document.getElementById('result');

    let textContents = [];

    for (const liItem of liItems) {
        textContents.push(liItem.textContent);
    }

    result.textContent = textContents.join('\n');
}