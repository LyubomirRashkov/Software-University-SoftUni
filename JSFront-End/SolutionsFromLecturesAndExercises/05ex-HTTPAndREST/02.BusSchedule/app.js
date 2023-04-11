function solve() {
    const BASE_URL = "http://localhost:3030/jsonstore/bus/schedule/";

    const spanInfo = document.querySelector('#info span');
    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');

    let stopId = 'depot';

    let stopName = '';

    function depart() {
        fetch(`${BASE_URL}${stopId}`)
            .then((res) => res.json())
            .then((response) => {
                stopId = response.next;

                spanInfo.textContent = `Next stop ${response.name}`;

                departBtn.disabled = true;
                arriveBtn.disabled = false;

                stopName = response.name;
            })
            .catch(() => {
                spanInfo.textContent = 'Error';

                departBtn.disabled = true;
                arriveBtn.disabled = true;
            })
    }

    async function arrive() {
        spanInfo.textContent = `Arriving at ${stopName}`;

        arriveBtn.disabled = true;
        departBtn.disabled = false;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();