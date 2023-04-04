function create(words) {
   const divWrapper = document.getElementById('content');

   for (const word of words) {
      let paragraph = document.createElement('p');
      paragraph.textContent = word;
      paragraph.style.display = 'none';

      let div = document.createElement('div');
      div.appendChild(paragraph);
      div.addEventListener('click', clickHandler);

      divWrapper.appendChild(div);
   }

   function clickHandler(e) {
      let paragraph = Array.from(e.currentTarget.children)[0];

      paragraph.style.display = 'block';
   }
}