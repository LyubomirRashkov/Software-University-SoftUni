function solve(input) {
    let assignees = {};

    const commandParser = {
        'Add New': addTaskFunction,
        'Change Status': changeStatusFunction,
        'Remove Task': removeTaskFunction,
    };

    const n = input.shift();

    for (let i = 0; i < n; i++) {
        const tokens = input.shift().split(':');

        const assigneeName = tokens.shift();

        if (!(assignees.hasOwnProperty(assigneeName))) {
            assignees[assigneeName] = [];
        }

        commandParser["Add New"](assigneeName, ...tokens);
    }

    for (let i = 0; i < input.length; i++) {
        const tokens = input[i].split(':');

        const command = tokens.shift();
        const assigneeName = tokens.shift();

        if (!(assignees.hasOwnProperty(assigneeName))) {
            console.log(`Assignee ${assigneeName} does not exist on the board!`);

            continue;
        }

        commandParser[command](assigneeName, ...tokens);
    }

    const allTasks = Object.values(assignees);

    let toDoPoints = 0;
    let inProgressPoints = 0;
    let codeReviewPoints = 0;
    let donePoints = 0;

    for (const assigneeTasks of allTasks) {
        for (const task of assigneeTasks) {
            const taskInfo = Object.values(task);

            if (taskInfo[0].status === 'ToDo') {
                toDoPoints += Number(taskInfo[0].points);
            } else if (taskInfo[0].status === 'In Progress') {
                inProgressPoints += Number(taskInfo[0].points);
            } else if (taskInfo[0].status === 'Code Review') {
                codeReviewPoints += Number(taskInfo[0].points);
            } else if (taskInfo[0].status === 'Done') {
                donePoints += Number(taskInfo[0].points);
            }
        }
    }

    console.log(`ToDo: ${toDoPoints}pts`);
    console.log(`In Progress: ${inProgressPoints}pts`);
    console.log(`Code Review: ${codeReviewPoints}pts`);
    console.log(`Done Points: ${donePoints}pts`);

    let points = toDoPoints + inProgressPoints + codeReviewPoints;

    if (donePoints >= points) {
        console.log('Sprint was successful!');
    } else {
        console.log('Sprint was unsuccessful...');
    }

    function addTaskFunction(assigneeName, taskId, title, status, points) {
        let taskInfo = {};

        taskInfo[taskId] = {
            title,
            status,
            points,
        };

        assignees[assigneeName].push(taskInfo);
    }

    function changeStatusFunction(assigneeName, taskId, newStatus) {
        let isFound = false;

        for (const item of assignees[assigneeName]) {
            if (item.hasOwnProperty(taskId)) {
                item[taskId].status = newStatus;

                isFound = true;
            }
        }

        if (!isFound) {
            console.log(`Task with ID ${taskId} does not exist for ${assigneeName}!`)
        }
    }

    function removeTaskFunction(assigneeName, index) {
        index = Number(index);

        if (index < 0 || index >= assignees[assigneeName].length) {
            console.log('Index is out of range!');
        } else {
            assignees[assigneeName].splice(index, 1);
        }
    }
}

solve(
    [
        '5',
        'Kiril:BOP-1209:Fix Minor Bug:ToDo:3',
        'Mariya:BOP-1210:Fix Major Bug:In Progress:3',
        'Peter:BOP-1211:POC:Code Review:5',
        'Georgi:BOP-1212:Investigation Task:Done:2',
        'Mariya:BOP-1213:New Account Page:In Progress:13',
        'Add New:Kiril:BOP-1217:Add Info Page:In Progress:5',
        'Change Status:Peter:BOP-1290:ToDo',
        'Remove Task:Mariya:1',
        'Remove Task:Joro:1',
    ]
);

solve(
    [
        '4',
        'Kiril:BOP-1213:Fix Typo:Done:1',
        'Peter:BOP-1214:New Products Page:In Progress:2',
        'Mariya:BOP-1215:Setup Routing:ToDo:8',
        'Georgi:BOP-1216:Add Business Card:Code Review:3',
        'Add New:Sam:BOP-1237:Testing Home Page:Done:3',
        'Change Status:Georgi:BOP-1216:Done',
        'Change Status:Will:BOP-1212:In Progress',
        'Remove Task:Georgi:3',
        'Change Status:Mariya:BOP-1215:Done',
    ]
);