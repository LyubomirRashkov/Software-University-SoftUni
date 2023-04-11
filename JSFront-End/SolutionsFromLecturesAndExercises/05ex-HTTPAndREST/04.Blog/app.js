function attachEvents() {
    const POSTS_URL = "http://localhost:3030/jsonstore/blog/posts";
    const COMMENTS_URL = "http://localhost:3030/jsonstore/blog/comments";

    const selectPosts = document.getElementById('posts');
    const title = document.getElementById('post-title');
    const paragraphBody = document.getElementById('post-body');
    const subtitle = Array.from(document.getElementsByTagName('h2'))[0];
    const ulContainer = document.getElementById('post-comments');
    const btnLoad = document.getElementById('btnLoadPosts');
    const btnView = document.getElementById('btnViewPost');

    title.textContent = '';
    subtitle.style.display = 'none';
    
    btnLoad.addEventListener('click', loadPostsHandler);
    btnView.addEventListener('click', loadCommentsHandler);
    
    let posts = [];
    
    function loadPostsHandler() {
        selectPosts.innerHTML = '';
        title.textContent = '';
        paragraphBody.textContent = '';
        subtitle.style.display = 'none';
        ulContainer.innerHTML = '';
        
        fetch(POSTS_URL)
            .then((res) => res.json())
            .then((response) => {
                let objs = Object.values(response);

                for (const obj of objs) {
                    posts.push(obj);

                    let option = createElement('option', obj.title, undefined, undefined, { value: obj.id }, selectPosts);
                }
            })
            .catch((err) => {
                console.error(err);
            })
    }

    async function loadCommentsHandler() {
        const selectedOption = document.querySelector('option:checked');

        ulContainer.innerHTML = '';

        fetch(COMMENTS_URL)
            .then((res) => res.json())
            .then((response) => {
                let objs = Object.values(response);

                let commentsAsObjs = [];

                for (const obj of objs) {
                    if (obj.postId === selectedOption.value) {
                        commentsAsObjs.push(obj);
                    }
                }

                let post = posts.find((p) => p.id === selectedOption.value);

                title.textContent = post.title;
                paragraphBody.textContent = post.body;
                subtitle.style.display = 'block';
                for (const comment of commentsAsObjs) {
                    let newLi = createElement('li', comment.text, undefined, undefined, undefined, ulContainer);
                }
            })
            .catch((err) => {
                console.error(err);
            });
    }
}

attachEvents();

// type = string
// content = string
// id = string
// classes = array of strings
// attributes = object
// Trqbva da se dorazvie za textarea !!!
function createElement(type, content, id, classes, attributes, parentNode) {
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