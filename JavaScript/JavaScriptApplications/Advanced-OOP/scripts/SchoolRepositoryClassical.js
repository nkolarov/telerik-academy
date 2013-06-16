// Represents a Person
var Person = Class.create({
    init: function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    },
    introduce: function () {
        return getPropertiesAsString(this);
    }

});

// Represents a Student
var Student = Class.create({
    init: function (firstName, lastName, age, grade) {
        this._super = new this._super(firstName, lastName, age);
        this._super.init(firstName, lastName, age);
        this.grade = grade;
    },
    introduce: function () {
        var introduction = this._super.introduce();
        introduction += "grade: " + this.grade + ";";
        return introduction;
    }
});

Student.inherit(Person);

// Represents a Teacher
var Teacher = Class.create({
    init: function (firstName, lastName, age, speciality) {
        this._super = new this._super(firstName, lastName, age);
        this._super.init(firstName, lastName, age);
        this.speciality = speciality;
    },
    introduce: function () {
        var introduction = this._super.introduce();
        introduction += "speciality: " + this.speciality + ";";
        return introduction;
    }
});

Teacher.inherit(Person);

// Represents a School
var School = Class.create({
    init: function (name, town, classes) {
        this.name = name;
        this.town = town;
        this.classes = classes;
    }
});

// Represents a Course
var Course = Class.create({
    init: function (name, capacity, students, formTeacher) {
        this.name = name;
        this.capacity = capacity;
        this.students = students;
        this.formTeacher = formTeacher;
    }
});

// Prints all properies of an object which are not functions or objects.
var getPropertiesAsString = function (obj) {
    var introduction = "";
    for (var prop in obj) {
        if (typeof (obj[prop]) != "function" && typeof (obj[prop]) != "object") {
            introduction += prop + ": " + obj[prop] + "; ";
        }
    }
    return introduction;
}