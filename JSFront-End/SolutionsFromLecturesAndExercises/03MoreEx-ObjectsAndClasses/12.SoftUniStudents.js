function softUniStudents(input) {
    let courses = [];

    for (const element of input) {
        if (element.includes(":")) {
            let [courseName, courseCapacity] = element.split(": ");
            courseCapacity = Number(courseCapacity);

            let course = courses.find((c) => c.name === courseName);

            if (course) {
                course.capacity += courseCapacity;
            } else {
                course = {
                    name: courseName,
                    capacity: courseCapacity,
                    students: [],
                };

                courses.push(course);
            }
        } else {
            let [userInfo, additionalInfo] = element.split(" with email ");

            let [userEmail, targetCourse] = additionalInfo.split(" joins ");

            let course = courses.find((c) => c.name === targetCourse);

            if (course && course.capacity > course.students.length) {
                let [username, impureCredits] = userInfo.split("[");
                impureCredits = impureCredits.split("");
                impureCredits.pop();
                let userCredits = Number((impureCredits.join("")));

                let student = {
                    name: username,
                    email: userEmail,
                    credits: userCredits,
                };

                course.students.push(student);
            }
        }
    }

    let sortedCourses = courses.sort((a, b) => b.students.length - a.students.length);

    for (const course of sortedCourses) {
        console.log(`${course.name}: ${course.capacity - course.students.length} places left`);

        let sortedStudents = course.students.sort((a, b) => b.credits - a.credits);

        for (const student of sortedStudents) {
            console.log(`--- ${student.credits}: ${student.name}, ${student.email}`);
        }
    }
}

softUniStudents(
    [
        'JavaBasics: 2',
        'user1[25] with email user1@user.com joins C#Basics',
        'C#Advanced: 3',
        'JSCore: 4',
        'user2[30] with email user2@user.com joins C#Basics',
        'user13[50] with email user13@user.com joins JSCore',
        'user1[25] with email user1@user.com joins JSCore',
        'user8[18] with email user8@user.com joins C#Advanced',
        'user6[85] with email user6@user.com joins JSCore',
        'JSCore: 2',
        'user11[3] with email user11@user.com joins JavaBasics',
        'user45[105] with email user45@user.com joins JSCore',
        'user007[20] with email user007@user.com joins JSCore',
        'user700[29] with email user700@user.com joins JSCore',
        'user900[88] with email user900@user.com joins JSCore'
    ]
);

softUniStudents(
    [
        'JavaBasics: 15',
        'user1[26] with email user1@user.com joins JavaBasics',
        'user2[36] with email user11@user.com joins JavaBasics',
        'JavaBasics: 5',
        'C#Advanced: 5',
        'user1[26] with email user1@user.com joins C#Advanced',
        'user2[36] with email user11@user.com joins C#Advanced',
        'user3[6] with email user3@user.com joins C#Advanced',
        'C#Advanced: 1',
        'JSCore: 8',
        'user23[62] with email user23@user.com joins JSCore'
    ]
);