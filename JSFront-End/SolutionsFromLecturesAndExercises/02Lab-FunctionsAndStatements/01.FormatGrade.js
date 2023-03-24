function formatGrade(grade) {
    let output = "";

    if (grade < 3.00) {
        output = "Fail (2)"
    } else if (grade < 3.50) {
        output = `Poor (${grade.toFixed(2)})`;
    } else if (grade < 4.50) {
        output = `Good (${grade.toFixed(2)})`;
    } else if (grade < 5.50) {
        output = `Very good (${grade.toFixed(2)})`;
    } else {
        output = `Excellent (${grade.toFixed(2)})`;
    }

    console.log(output);
}

formatGrade(3.33);
formatGrade(4.50);
formatGrade(2.99);