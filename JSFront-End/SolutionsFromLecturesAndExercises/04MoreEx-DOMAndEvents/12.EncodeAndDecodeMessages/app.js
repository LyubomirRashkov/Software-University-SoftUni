function encodeAndDecodeMessages() {
    const [encodeBtn, decodeBtn] = Array.from(document.getElementsByTagName('button'));
    const [inputTextarea, outputTextarea] = Array.from(document.getElementsByTagName('textarea'));

    encodeBtn.addEventListener('click', encode);
    decodeBtn.addEventListener('click', decode);

    function encode() {
        let input = inputTextarea.value;

        let output = input
            .split('')
            .map((s) => s.charCodeAt(0) + 1)
            .map((s) => String.fromCharCode(s))
            .join('');

        inputTextarea.value = '';
        outputTextarea.value = output;
    }

    function decode() {
        let input = outputTextarea.value;

        let output = input
            .split('')
            .map((s) => s.charCodeAt(0) - 1)
            .map((s) => String.fromCharCode(s))
            .join('');

        outputTextarea.value = output;
    }
}