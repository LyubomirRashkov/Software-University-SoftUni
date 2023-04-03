function focused() {
    const inputs = Array.from(document.getElementsByTagName('input'));

    inputs.forEach((i) => i.addEventListener('focus', focusHandler));
    inputs.forEach((i) => i.addEventListener('blur', blurHandler));

    function focusHandler(e) {
        let div = e.currentTarget.parentElement;

        div.classList.add('focused');
    }

    function blurHandler(e) {
        let div = e.currentTarget.parentElement;

        if (div.classList.contains('focused')) {
            div.classList.remove('focused');
        }
    }
}