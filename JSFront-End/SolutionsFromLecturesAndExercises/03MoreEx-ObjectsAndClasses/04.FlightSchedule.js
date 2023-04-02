function flightSchedule(input) {
    let [allFlights, changedStatuses, targetStatus] = input;

    let flights = [];

    for (const element of allFlights) {
        let tokens = element.split(" ");
        
        let number = tokens.shift();
        let destination = tokens.join(" ");

        let flight = {
            number,
            destination,
            status: "",
        };

        flights.push(flight);
    }

    for (const element of changedStatuses) {
        let [number, newStatus] = element.split(" ");

        let flight = flights.find((f) => f.number === number);

        if (flight) {
            flight.status = newStatus;
        }
    }

    if (targetStatus[0] === "Ready to fly") {
        let targetFlights = flights.filter((f) => f.status === "");

        for (const flight of targetFlights) {
            flight.status = "Ready to fly";
        }

        targetFlights.forEach((f) => print(f));
    } else {
        flights
            .filter((f) => f.status === targetStatus[0])
            .forEach((f) => print(f));
    }

    function print(flight) {
        console.log(`{ Destination: '${flight.destination}', Status: '${flight.status}' }`);
    }
}

flightSchedule(
    [
        ['WN269 Delaware',
            'FL2269 Oregon',
            'WN498 Las Vegas',
            'WN3145 Ohio',
            'WN612 Alabama',
            'WN4010 New York',
            'WN1173 California',
            'DL2120 Texas',
            'KL5744 Illinois',
            'WN678 Pennsylvania'
        ],
        [
            'DL2120 Cancelled',
            'WN612 Cancelled',
            'WN1173 Cancelled',
            'SK430 Cancelled'
        ],
        ['Cancelled']
    ]
);

flightSchedule(
    [
        ['WN269 Delaware',
            'FL2269 Oregon',
            'WN498 Las Vegas',
            'WN3145 Ohio',
            'WN612 Alabama',
            'WN4010 New York',
            'WN1173 California',
            'DL2120 Texas',
            'KL5744 Illinois',
            'WN678 Pennsylvania'
        ],
        [
            'DL2120 Cancelled',
            'WN612 Cancelled',
            'WN1173 Cancelled',
            'SK330 Cancelled'
        ],
        ['Ready to fly']
    ]
);