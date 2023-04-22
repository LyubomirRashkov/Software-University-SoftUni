function solve() {
   const inputDOMSelectors = {
      author: document.getElementById('creator'),
      title: document.getElementById('title'),
      category: document.getElementById('category'),
      content: document.getElementById('content'),
   };

   const otherDOMSelectors = {
      createBtn: document.querySelector('.create'),
      sectionPosts: document.querySelector('.site-content > main > section'),
      form: document.querySelector('form'),
      olArchived: document.querySelector('ol'),
   };

   otherDOMSelectors.createBtn.addEventListener('click', createHandler);

   let archived = [];

   function createHandler(e) {
      if (e) {
         e.preventDefault();
      }

      const article = createElement('article', otherDOMSelectors.sectionPosts);
      createElement('h1', article, inputDOMSelectors.title.value);
      const paragraphOne = createElement('p', article, 'Category: ');
      createElement('strong', paragraphOne, inputDOMSelectors.category.value);
      const paragraphTwo = createElement('p', article, 'Creator: ');
      createElement('strong', paragraphTwo, inputDOMSelectors.author.value);
      createElement('p', article, inputDOMSelectors.content.value);
      const divBtns = createElement('div', article, null, null, ['buttons']);
      const deleteBtn = createElement('button', divBtns, 'Delete', null, ['btn', 'delete']);
      const archiveBtn = createElement('button', divBtns, 'Archive', null, ['btn', 'archive']);

      deleteBtn.addEventListener('click', deleteHandler);
      archiveBtn.addEventListener('click', archiveHandler);

      otherDOMSelectors.form.reset();
   }

   function archiveHandler(e) {
      const article = e.currentTarget.parentNode.parentNode;

      const title = (article.querySelector('h1')).textContent;

      article.remove();

      otherDOMSelectors.olArchived.innerHTML = '';

      archived.push(title);

      archived = archived.sort((a, b) => a.localeCompare(b));

      for (const item of archived) {
         createElement('li', otherDOMSelectors.olArchived, item);
      }
   }

   function deleteHandler(e) {
      const article = e.currentTarget.parentNode.parentNode;

      article.remove();
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