function attachEvents() {
    const BASE_URL = " http://localhost:3030/jsonstore/messenger";

    const btnRefresh = document.getElementById('refresh');
    const btnSubmit = document.getElementById('submit');

    btnRefresh.addEventListener('click', getMessagesHandler);
    btnSubmit.addEventListener('click', postMessageHandler);

    function getMessagesHandler() {
        const textarea = document.getElementById('messages');

        fetch(BASE_URL)
            .then((res) => res.json())
            .then((response) => {
                let values = Object.values(response);

                let messages = [];

                for (const value of values) {
                    let message = `${value.author}: ${value.content}`;

                    messages.push(message);
                }

                let output = messages.join('\n');

                textarea.textContent = output;
            })
            .catch((err) => {
                console.error(err)
            });
    }

    function postMessageHandler() {
        const inputName = document.querySelector('input[name="author"]');
        const inputMessage = document.querySelector('input[name="content"]');

        let name = inputName.value;
        let message = inputMessage.value;

        const httpHeaders = {
            method: 'POST',
            body: JSON.stringify({
                author: name,
                content: message,
            }),
        };

        fetch(BASE_URL, httpHeaders)
            .then((res) => res.json())
            .then(() => {
                inputName.value = '';
                inputMessage.value = '';
            })
            .catch((err) => {
                console.error(err);
            });
    }
}

attachEvents();