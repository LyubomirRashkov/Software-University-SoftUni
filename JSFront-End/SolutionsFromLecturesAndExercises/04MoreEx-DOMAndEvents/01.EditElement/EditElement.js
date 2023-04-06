function editElement(element, match, replacer) {
    let content = element.textContent;

    while (content.includes(match)) {
       content = content.replace(match, replacer);
    }

    element.textContent = content;
}