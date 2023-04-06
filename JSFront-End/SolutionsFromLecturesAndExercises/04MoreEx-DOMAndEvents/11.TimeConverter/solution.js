function attachEventsListeners() {
    const buttons = Array.from(document.querySelectorAll('input[type="button"]'));

    buttons.forEach((btn) => btn.addEventListener('click', convert));

    function convert(e) {
        const inputDays = document.getElementById('days');
        const inputHours = document.getElementById('hours');
        const inputMinutes = document.getElementById('minutes');
        const inputSeconds = document.getElementById('seconds');

        let parent = e.currentTarget.parentElement;
        let input = (Array.from(parent.children))[1];

        let type = input.id;
        let value = input.value;

        let seconds = 0;

        switch (type) {
            case 'seconds':
                seconds = value;
            break;

            case 'minutes':
                seconds = value * 60;
            break;

            case 'hours':
                seconds = value * 60 * 60;
            break;

            case 'days':
                seconds = value * 24 * 60 * 60;
            break;
        }

        inputSeconds.value = seconds;
        inputMinutes.value = seconds / 60;
        inputHours.value = seconds / 60 / 60;
        inputDays.value = seconds / 60 / 60 / 24;
    }
}