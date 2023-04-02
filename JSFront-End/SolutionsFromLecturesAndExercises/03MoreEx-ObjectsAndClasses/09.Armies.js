function armiesSolver(input) {
    let leaders = [];

    for (const element of input) {
        if (element.includes("arrives")) {
            let tokens = element.split(" ");

            tokens.pop();

            let name = tokens.join(" ");

            let leader = {
                name,
                armies: [],
                soldiers: 0,
            };

            leaders.push(leader);
        } else if (element.includes(":")) {
            let [name, armyInfo] = element.split(": ");

            let leader = leaders.find((l) => l.name === name);

            if (leader) {
                let [armyName, armyCount] = armyInfo.split(", ");
                armyCount = Number(armyCount);

                let army = {
                    name: armyName,
                    count: armyCount,
                };

                leader.armies.push(army);
                leader.soldiers += armyCount;
            }
        } else if (element.includes("+")) {
            let [armyName, armyCount] = element.split(" + ");
            armyCount = Number(armyCount);

            for (const leader of leaders) {
                for (const army of leader.armies) {
                    if (army.name === armyName) {
                        army.count += armyCount;
                        leader.soldiers += armyCount;
                        break;
                    }
                }
            }
        } else {
            let tokens = element.split(" ");

            tokens.pop();

            let name = tokens.join(" ");

            let leaderIndex = leaders.findIndex((l) => l.name === name);

            if (leaderIndex !== -1) {
                leaders.splice(leaderIndex, 1);
            }
        }
    }

    let sortedLeaders = leaders.sort((a, b) => b.soldiers - a.soldiers);

    for (const leader of sortedLeaders) {
        console.log(`${leader.name}: ${leader.soldiers}`);

        let sortedArmies = leader.armies.sort((a,b) => b.count - a.count);

        for (const army of sortedArmies) {
            console.log(`>>> ${army.name} - ${army.count}`);
        }
    }
}

armiesSolver(
    [
        'Rick Burr arrives',
        'Fergus: Wexamp, 30245',
        'Rick Burr: Juard, 50000',
        'Findlay arrives',
        'Findlay: Britox, 34540',
        'Wexamp + 6000',
        'Juard + 1350',
        'Britox + 4500',
        'Porter arrives',
        'Porter: Legion, 55000',
        'Legion + 302',
        'Rick Burr defeated',
        'Porter: Retix, 3205'
    ]
);

armiesSolver(
    [
        'Rick Burr arrives',
        'Findlay arrives',
        'Rick Burr: Juard, 1500',
        'Wexamp arrives',
        'Findlay: Wexamp, 34540',
        'Wexamp + 340',
        'Wexamp: Britox, 1155',
        'Wexamp: Juard, 43423'
    ]
);