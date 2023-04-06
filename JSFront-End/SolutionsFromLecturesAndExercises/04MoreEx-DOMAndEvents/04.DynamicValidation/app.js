function validate() {
    const input = document.getElementById('email');

    input.addEventListener('change', validateHandler);

    function validateHandler(e) {
        let content = e.currentTarget.value;

        let regex = /^([a-z]+)@([a-z]+)\.([a-z]+)$/;

        if (regex.test(content)) {
            e.currentTarget.classList.remove('error');
        } else {
            e.currentTarget.classList.add('error');
        }
    }
}