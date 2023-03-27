function carWash(commands) {
    let percentClean = 0;

    const soap = (percentClean) => percentClean + 10;
    const water = (percentClean) => percentClean * 1.2;
    const vacuumCleaner = (percentClean) => percentClean * 1.25;
    const mud = (percentClean) =>  percentClean * 0.9;

    let commandMap = {
        "soap": soap,
        "water": water,
        "vacuum cleaner": vacuumCleaner,
        "mud": mud
    };

    for (const command of commands) {
        percentClean = commandMap[command](percentClean);
    }

    console.log(`The car is ${percentClean.toFixed(2)}% clean.`);
}

carWash(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']);
carWash(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]);