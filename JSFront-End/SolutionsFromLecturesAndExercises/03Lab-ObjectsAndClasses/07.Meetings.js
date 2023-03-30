function meetings(input) {
    let listOfMeetings = {};

    for (const element of input) {
        let [weekday, name] = element.split(" ");

        if (listOfMeetings.hasOwnProperty(weekday)) {
            console.log(`Conflict on ${weekday}!`);
        } else {
            listOfMeetings[weekday] = name;

            console.log(`Scheduled for ${weekday}`);
        }
    }

    for (const key in listOfMeetings) {
        console.log(`${key} -> ${listOfMeetings[key]}`);
    }
}

meetings(
    ['Monday Peter',
        'Wednesday Bill',
        'Monday Tim',
        'Friday Tim']
);

meetings(
    ['Friday Bob',
        'Saturday Ted',
        'Monday Bill',
        'Monday John',
        'Wednesday George']
);