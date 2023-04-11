function getInfo() {
    const BASE_URL = "http://localhost:3030/jsonstore/bus/businfo/";

    const inputStop = document.getElementById('stopId');
    const divStopName = document.getElementById('stopName');
    const ulContainer = document.getElementById('buses');

    divStopName.textContent = '';
    ulContainer.innerHTML = '';

    let stopId = inputStop.value;

    fetch(`${BASE_URL}${stopId}`)
        .then((res) => res.json())
        .then((response) => {

            divStopName.textContent = response.name;

            for (const key in response.buses) {
                let newLi = document.createElement('li');
                newLi.textContent = `Bus ${key} arrives in ${response.buses[key]} minutes`;

                ulContainer.appendChild(newLi);
            }
        })
        .catch((err) => {
            divStopName.textContent = 'Error';
        })
}