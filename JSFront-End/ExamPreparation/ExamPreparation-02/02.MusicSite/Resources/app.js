window.addEventListener('load', solve);

function solve() {
    const inputDOMSelectors = {
        genre: document.getElementById('genre'),
        name: document.getElementById('name'),
        author: document.getElementById('author'),
        date: document.getElementById('date'),
    };

    const otherDOMSelectors = {
        addBtn: document.getElementById('add-btn'),
        divContainer: document.querySelector('#all-hits > div'),
        form: document.querySelector('form'),
        paragraphLikes: document.querySelector('#total-likes > div > p'),
        divSavedSongs: document.querySelector('#saved-hits > div'),
    };

    otherDOMSelectors.addBtn.addEventListener('click', addSongHandler);

    function addSongHandler(e) {
        if (e) {
            e.preventDefault();
        }

        const areAllInputsFilled = Object.values(inputDOMSelectors)
            .every((i) => i.value !== '');

        if(!areAllInputsFilled) {
            return;
        }

        const divHits = createElement('div', otherDOMSelectors.divContainer, null, null, ['hits-info']);
        createElement('img', divHits, null, null, null, { src: './static/img/img.png' });
        createElement('h2', divHits, `Genre: ${inputDOMSelectors.genre.value}`);
        createElement('h2', divHits, `Name: ${inputDOMSelectors.name.value}`);
        createElement('h2', divHits, `Author: ${inputDOMSelectors.author.value}`);
        createElement('h3', divHits, `Date: ${inputDOMSelectors.date.value}`);
        const saveBtn = createElement('button', divHits, 'Save song', null, ['save-btn']);
        const likeBtn = createElement('button', divHits, 'Like song', null, ['like-btn']);
        const deleteBtn = createElement('button', divHits, 'Delete', null, ['delete-btn']);

        saveBtn.addEventListener('click', saveSongHandler);
        likeBtn.addEventListener('click', likeSongHandler);
        deleteBtn.addEventListener('click', deleteSongHandler);
        
        otherDOMSelectors.form.reset();
    }

    function saveSongHandler(e) {
        const divSong = e.currentTarget.parentNode;

        otherDOMSelectors.divSavedSongs.appendChild(divSong);

        const saveBtn = divSong.querySelector('.save-btn');
        const likeBtn = divSong.querySelector('.like-btn');

        saveBtn.remove();
        likeBtn.remove();
    }

    function likeSongHandler(e) {
        let [ text, likesCount ] = otherDOMSelectors.paragraphLikes.textContent.split(': ');
        likesCount = Number(likesCount);

        likesCount++;

        otherDOMSelectors.paragraphLikes.textContent = text + ': ' + likesCount;

        e.currentTarget.setAttribute('disabled', true);
    }

    function deleteSongHandler(e) {
        e.currentTarget.parentNode.remove();
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