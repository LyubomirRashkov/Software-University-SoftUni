function inventory(input) {
    let heroes = [];

    for (const element of input) {
        let [name, level, items] = element.split(" / ");
        level = Number(level);

        let hero = { name, level, items };
        heroes.push(hero);
    }

    heroes
        .sort((heroA, heroB) => heroA.level - heroB.level)
        .forEach((h) => console.log(`Hero: ${h.name}\nlevel => ${h.level}\nitems => ${h.items}`))
}

inventory(
    [
        'Isacc / 25 / Apple, GravityGun',
        'Derek / 12 / BarrelVest, DestructionSword',
        'Hes / 1 / Desolator, Sentinel, Antara'
    ]
);

inventory(
    [
        'Batman / 2 / Banana, Gun',
        'Superman / 18 / Sword',
        'Poppy / 28 / Sentinel, Antara'
    ]
);