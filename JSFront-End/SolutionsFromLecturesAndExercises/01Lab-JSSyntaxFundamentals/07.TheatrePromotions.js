function solver(dayOfWeek, age) {
    let output = "";

    if (age < 0 || age > 122) {
        output = "Error!";
    } else {
        switch (dayOfWeek) {
            case "Weekday":
                if (age > 18 && age <= 64) {
                    output = "18$";
                } else {
                    output = "12$";
                }
                break;

            case "Weekend":
                if (age > 18 && age <= 64) {
                    output = "20$";
                } else {
                    output = "15$";
                }
                break;

            case "Holiday":
                if (age <= 18) {
                    output = "5$";
                } else if (age <= 64) {
                    output = "12$";
                } else {
                    output = "10$";
                }
                break;
        }
    }

    console.log(output);
}