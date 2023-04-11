function attachEvents() {
    const BASE_URL = "http://localhost:3030/jsonstore/forecaster/";

    const submitBtn = document.getElementById('submit');
    const inputLocation = document.getElementById('location');
    const divForecast = document.getElementById('forecast');
    const divCurrent = document.getElementById('current');
    const divUpcoming = document.getElementById('upcoming');

    let newDiv = document.createElement('div');
    newDiv.id = 'error';
    newDiv.textContent = 'Error';
    newDiv.style.display = 'none';
    divForecast.appendChild(newDiv);

    submitBtn.addEventListener('click', forecastHandler);

    function forecastHandler() {
        let location = inputLocation.value;

        divForecast.style.display = 'block';

        fetch(`${BASE_URL}locations`)
            .then((res) => res.json())
            .then((response) => {
                let isLocationValid = false;

                for (const item of response) {
                    if (item.name === location) {
                        isLocationValid = true;

                        divCurrent.style.display = 'block';
                        divUpcoming.style.display = 'block';
                        newDiv.style.display = 'none';

                        let itemCode = item.code;

                        fetch(`${BASE_URL}today/${itemCode}`)
                            .then((resToday) => resToday.json())
                            .then((responseToday) => {
                                let divCurrentChildren = Array.from(divCurrent.children);

                                for (let i = 1; i < divCurrentChildren.length; i++) {
                                    divCurrentChildren[i].remove();
                                }

                                let newDiv = createElement('div', undefined, undefined, ['forecasts'], undefined, divCurrent);
                                newDiv.style.display = 'flex';
                                newDiv.style.width = 'fit-content';
                                newDiv.style.margin = '20px auto';
                                newDiv.style.alignItems = 'center';

                                let spanConditionSymbol = createElement('span', undefined, undefined, ['condition', 'symbol'], undefined, newDiv);
                                spanConditionSymbol.innerHTML = `${getCodeOfWeatherSymbol(responseToday.forecast.condition)}`;

                                let spanCondition = createElement('span', undefined, undefined, ['condition'], undefined, newDiv);

                                createElement('span', responseToday.name, undefined, ['forecast-data'], undefined, spanCondition);

                                let spanForecastData = createElement('span', undefined, undefined, ['forecast-data'], undefined, spanCondition);
                                spanForecastData.innerHTML = `${responseToday.forecast.low}${getCodeOfWeatherSymbol('Degrees')}/${responseToday.forecast.high}${getCodeOfWeatherSymbol('Degrees')}`;

                                createElement('span', responseToday.forecast.condition, undefined, ['forecast-data'], undefined, spanCondition);
                            })
                            .catch(() => {
                                displayError();
                            });

                        fetch(`${BASE_URL}upcoming/${itemCode}`)
                            .then((resUpcoming) => resUpcoming.json())
                            .then((responseUpcoming) => {
                                let divUpcomingChildren = Array.from(divUpcoming.children);

                                for (let i = 1; i < divUpcomingChildren.length; i++) {
                                    divUpcomingChildren[i].remove();
                                }

                                let newDiv = createElement('div', undefined, undefined, ['forecast-info'], undefined, divUpcoming);

                                let spanUpcomingOne = createElement('span', undefined, undefined, ['upcoming'], undefined, newDiv);
                                let spanUpcomingOneSymbol = createElement('span', undefined, undefined, ['symbol'], undefined, spanUpcomingOne);
                                spanUpcomingOneSymbol.innerHTML = getCodeOfWeatherSymbol((responseUpcoming.forecast)[0].condition);
                                let spanUpcomingOneForecastDataOne = createElement('span', undefined, undefined, ['forecast-data'], undefined, spanUpcomingOne);
                                spanUpcomingOneForecastDataOne.innerHTML = `${(responseUpcoming.forecast)[0].low}${getCodeOfWeatherSymbol('Degrees')}/${(responseUpcoming.forecast)[0].high}${getCodeOfWeatherSymbol('Degrees')}`;
                                createElement('span', (responseUpcoming.forecast)[0].condition, undefined, ['forecast-data'], undefined, spanUpcomingOne);

                                let spanUpcomingTwo = createElement('span', undefined, undefined, ['upcoming'], undefined, newDiv);
                                let spanUpcomingTwoSymbol = createElement('span', undefined, undefined, ['symbol'], undefined, spanUpcomingTwo);
                                spanUpcomingTwoSymbol.innerHTML = getCodeOfWeatherSymbol((responseUpcoming.forecast)[1].condition);
                                let spanUpcomingTwoForecastDataOne = createElement('span', undefined, undefined, ['forecast-data'], undefined, spanUpcomingTwo);
                                spanUpcomingTwoForecastDataOne.innerHTML = `${(responseUpcoming.forecast)[1].low}${getCodeOfWeatherSymbol('Degrees')}/${(responseUpcoming.forecast)[1].high}${getCodeOfWeatherSymbol('Degrees')}`;
                                createElement('span', (responseUpcoming.forecast)[1].condition, undefined, ['forecast-data'], undefined, spanUpcomingTwo);

                                let spanUpcomingThree = createElement('span', undefined, undefined, ['upcoming'], undefined, newDiv);
                                let spanUpcomingThreeSymbol = createElement('span', undefined, undefined, ['symbol'], undefined, spanUpcomingThree);
                                spanUpcomingThreeSymbol.innerHTML = getCodeOfWeatherSymbol((responseUpcoming.forecast)[2].condition);
                                let spanUpcomingThreeForecastDataOne = createElement('span', undefined, undefined, ['forecast-data'], undefined, spanUpcomingThree);
                                spanUpcomingThreeForecastDataOne.innerHTML = `${(responseUpcoming.forecast)[2].low}${getCodeOfWeatherSymbol('Degrees')}/${(responseUpcoming.forecast)[2].high}${getCodeOfWeatherSymbol('Degrees')}`;
                                createElement('span', (responseUpcoming.forecast)[2].condition, undefined, ['forecast-data'], undefined, spanUpcomingThree);
                            })
                            .catch(() => {
                                displayError();
                            })

                        break;
                    }
                }

                if (!isLocationValid) {
                    displayError();
                }
            })
            .catch(() => {
                displayError();
            })
    }

    function displayError() {
        divCurrent.style.display = 'none';
        divUpcoming.style.display = 'none';
        newDiv.style.display = 'block';
    }
}

function getCodeOfWeatherSymbol(condition) {
    switch (condition) {
        case 'Sunny':
            return '&#x2600';
        case 'Partly sunny':
            return '&#x26C5';
        case 'Overcast':
            return '&#x2601';
        case 'Rain':
            return '&#x2614';
        case 'Degrees':
            return '&#176';
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