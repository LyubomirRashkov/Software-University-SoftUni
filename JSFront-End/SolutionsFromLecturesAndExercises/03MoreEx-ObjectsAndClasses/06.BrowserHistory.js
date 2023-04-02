function browserHistory(obj, commands) {
    for (const command of commands) {
        if (command === "Clear History and Cache") {
            obj["Open Tabs"] = [];
            obj["Recently Closed"] = [];
            obj["Browser Logs"] = [];

            continue;
        }

        let [action, tab] = command.split(" ");

        let log = action + " " + tab;

        if (action === "Open") {
            obj["Open Tabs"].push(tab);
            obj["Browser Logs"].push(log);
        } else {
            let index = obj["Open Tabs"].indexOf(tab);

            if (index !== -1) {
                obj["Open Tabs"].splice(index, 1);
                obj["Recently Closed"].push(tab);
                obj["Browser Logs"].push(log);
            }
        }
    }

    console.log(`${obj["Browser Name"]}`);
    console.log(`Open Tabs: ${obj["Open Tabs"].join(", ")}`);
    console.log(`Recently Closed: ${obj["Recently Closed"].join(", ")}`);
    console.log(`Browser Logs: ${obj["Browser Logs"].join(", ")}`);

    // let entries = Object.entries(obj);

    // console.log(entries[0][1]);
    // console.log(`${entries[1][0]}: ${entries[1][1].join(", ")}`);
    // console.log(`${entries[2][0]}: ${entries[2][1].join(", ")}`);
    // console.log(`${entries[3][0]}: ${entries[3][1].join(", ")}`);
}

browserHistory(
    {
        "Browser Name": "Google Chrome",
        "Open Tabs": ["Facebook", "YouTube", "Google Translate"],
        "Recently Closed": ["Yahoo", "Gmail"],
        "Browser Logs": ["Open YouTube", "Open Yahoo", "Open Google Translate", "Close Yahoo", "Open Gmail", "Close Gmail", "Open Facebook"]
    },
    ["Close Facebook", "Open StackOverFlow", "Open Google"]
);

browserHistory(
    {
        "Browser Name": "Mozilla Firefox",
        "Open Tabs": ["YouTube"],
        "Recently Closed": ["Gmail", "Dropbox"],
        "Browser Logs": ["Open Gmail", "Close Gmail", "Open Dropbox", "Open YouTube", "Close Dropbox"]
    },
    ["Open Wikipedia", "Clear History and Cache", "Open Twitter"]
);