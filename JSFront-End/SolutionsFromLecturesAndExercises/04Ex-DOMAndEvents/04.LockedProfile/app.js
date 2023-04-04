function lockedProfile() {
    const buttons = Array.from(document.getElementsByTagName('button'));

    buttons.forEach((b) => b.addEventListener('click', toggleInformationHandler));

    function toggleInformationHandler(e) {
        const button = e.currentTarget;
        const divProfile = button.parentElement;

        const unlockInput = divProfile.querySelector('input:nth-of-type(2)');

        if (unlockInput.checked) {
            const divAdditionalInfo = Array.from(divProfile.getElementsByTagName('div'))[0];

            if (button.textContent === 'Show more') {
                button.textContent = 'Hide it';

                divAdditionalInfo.style.display = 'block';
            } else {
                button.textContent = 'Show more';

                divAdditionalInfo.style.display = 'none';
            }
        }
    }
}