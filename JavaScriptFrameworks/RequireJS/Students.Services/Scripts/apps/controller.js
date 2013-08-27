define(["jquery", "mustache", "controlls", "httpRequester", "dataPersister"], function ($, Mustache, controls, request, dataPersister) {
    var controller = controller || {};

    function loadStudents() {
        dataPersister.getAllStudents(
            function (students) {
                appendStudentsToBody(students);
            },
            function (err) {
                console.error("Error!" + err);
            });
    }

    function appendStudentsToBody(students) {
        var studentsTemplate = Mustache.compile(document.getElementById("students-template").innerHTML);
        var tableView = controls.getTableView(students, { cols: 1 });
        var tableViewHtml = tableView.render(studentsTemplate);
        
        document.getElementById("content").innerHTML = tableViewHtml;
        $(".student").bind("click", function () {
            if ($(this).hasClass('selected')) {
                $("#marks").empty();
                $(this).removeClass("selected")
                $("#marks").removeClass();
                $('.student').show('slow');
            }
            else {
                $(this).addClass("selected")
                $('.student').not(".selected").hide('slow');

                var id = $(this).attr('id');
                loadStudentMarks(id);
            }
        })
    }

    function appendMarksToBody(marks, studentId) {
        
        var marksTemplate = Mustache.compile(document.getElementById("marks-template").innerHTML);
        var tableView = controls.getTableView(marks, { cols: 2 });
        var tableViewHtml = tableView.render(marksTemplate);

        document.getElementById("marks").innerHTML = tableViewHtml;
        $("#marks").addClass("student-marks-" + studentId);
        $("#marks").show(100);
    }

    function loadStudentMarks(studentId) {
        $("#marks").hide(100);

        if ($("#marks").hasClass("student-marks-" + studentId)) {
            $("#marks").removeClass("student-marks-" + studentId);
            return;
        } else {
            $("#marks").removeClass();
        }

        dataPersister.getStudentMarks(studentId,
            function (marks) {
                appendMarksToBody(marks, studentId)
            },
            function (err) {
                console.error("Error!" + err);
            });
    }

    controller.initialize = function () {
        loadStudents();
    }

    return controller;
});