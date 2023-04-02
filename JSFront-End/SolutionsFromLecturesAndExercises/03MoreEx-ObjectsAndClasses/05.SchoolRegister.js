function schoolRegister(input) {
    let grades = [];

    for (const element of input) {
        let [nameProp, gradeProp, avgScoreProp] = element.split(", ");

        let nameTokens = nameProp.split(": ");
        let name = nameTokens[1];

        let gradeTokens = gradeProp.split(": ");
        let grade = Number(gradeTokens[1]);

        let avgScoreTokens = avgScoreProp.split(": ");
        let avgScore = Number(avgScoreTokens[1]);

        if (avgScore < 3) {
            continue;
        }

        let student = {
            name,
            avgScore,
        };

        let gradeObj = grades.find((g) => g.level === grade + 1);

        if (!gradeObj) {
            gradeObj = {
                level: grade + 1,
                students: [],
            };

            grades.push(gradeObj);
        }

        gradeObj.students.push(student);
    }

    let sortedGrades = grades.sort((gradeA, gradeB) => gradeA.level - gradeB.level);

    for (const grade of sortedGrades) {
        console.log(`${grade.level} Grade`);

        let students = grade.students.map((s) => s.name);
        console.log(`List of students: ${students.join(", ")}`);

        let scores = grade.students.map((s) => s.avgScore);
        let sumOfScores = scores.reduce((previous, current) => {
            return previous + current;
        }, 0);
        let average = sumOfScores / scores.length;
        console.log(`Average annual score from last year: ${average.toFixed(2)}`);

        console.log();
    }
}

schoolRegister(
    [
        "Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
        "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
        "Student name: George, Grade: 8, Graduated with an average score: 2.83",
        "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
        "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
        "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
        "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
        "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
        "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
        "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
        "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
        "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00"
    ]
);

schoolRegister(
    [
        'Student name: George, Grade: 5, Graduated with an average score: 2.75',
        'Student name: Alex, Grade: 9, Graduated with an average score: 3.66',
        'Student name: Peter, Grade: 8, Graduated with an average score: 2.83',
        'Student name: Boby, Grade: 5, Graduated with an average score: 4.20',
        'Student name: John, Grade: 9, Graduated with an average score: 2.90',
        'Student name: Steven, Grade: 2, Graduated with an average score: 4.90',
        'Student name: Darsy, Grade: 1, Graduated with an average score: 5.15'
    ]
);