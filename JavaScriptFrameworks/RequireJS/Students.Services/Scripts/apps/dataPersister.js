/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/rsvp.min.js" />

define(["httpRequester"], function (request) {
    function getStudents(success, error) {
        return request.getJSON("api/students").then(success, error);
    }

    function gerMarksForStudent(studentId, success, error) {
        return request.getJSON("api/students/" + studentId + "/marks").then(success, error);
    }

	return {
	    getAllStudents: getStudents,
	    getStudentMarks: gerMarksForStudent
	}
});