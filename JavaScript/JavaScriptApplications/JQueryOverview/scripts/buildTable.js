/* 03. By given an array of students, generate a table that represents these students.
Each student has first name,last name and grade.
Use jQuery. */
(function () {

    // Represents a Student.
    function Student(firstName, lastName, grade) {
        return {
            firstName: firstName,
            lastName: lastName,
            grade: grade
        }
    }

    var students = [
        new Student("Pesho", "Peshov", 3),
        new Student("Ivan", "Peshov", 1),
        new Student("Pesho", "Dimitrov", 3),
        new Student("Gosho", "Stoianov", 8),
        new Student("Mimi", "Peshova", 3),
        new Student("Koko", "Kokov", 2),
    ];
    
    var tableBody = $("<tbody></tbody>");
    for (var student in students) {
        tableBody.append(
            "<tr>" +
                "<td>" + students[student].firstName + "</td>" +
                "<td>" + students[student].lastName + "</td>" +
                "<td>" + students[student].grade + "</td>" +
            "</tr>");
    }

    var tableStructure = 
        "<table>" +
            "<thead>" +
                "<tr>" +
                    "<th>First Name</th>" +
                    "<th>Last Name</th>" +
                    "<th>Grade</th>" +
                "</tr>" +
            "</thead>" +
        "</table>";

    var studentsTable = $(tableStructure);
    var studentsData = $(tableBody);
    studentsTable.append(studentsData);
    $("#wrapper").append(studentsTable);
}(jQuery));