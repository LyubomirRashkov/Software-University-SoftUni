function attachEventsListeners() {
    const btn = document.getElementById('convert');

    btn.addEventListener('click', convert);

    function convert() {
        const input = document.getElementById('inputDistance');
        const inputUnits = Array.from(document.getElementById('inputUnits').children)
            .filter((i) => i.selected)[0]
            .value;
        const outputUnits = Array.from(document.getElementById('outputUnits').children)
            .filter((i) => i.selected)[0]
            .value;
        const output = document.getElementById('outputDistance');

        let inputValue = Number(input.value);

        let inputMultiplier = getMultiplier(inputUnits);

        let meters = inputValue * inputMultiplier;

        let outputMultiplier = getMultiplier(outputUnits);

        let result = meters / outputMultiplier;

        output.value = result;
    }

    function getMultiplier(units) {
        switch (units) {
            case 'km':
                return 1000;
            case 'm':
                return 1;
            case 'cm':
                return 0.01;
            case 'mm':
                return 0.001;
            case 'mi':
                return 1609.39;
            case 'yrd':
                return 0.9144;
            case 'ft':
                return 0.3048;
            case 'in':
                return 0.0254;
        }
    }
}