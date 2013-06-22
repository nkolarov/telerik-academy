// Represents a Person
var Person = {
    init: function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    },
    introduce: function () {
        return getPropertiesAsString(this);
    }

}

// Represents a Student
var Student = Person.extend({
    init: function (firstName, lastName, age, grade) {
        this._super = Object.create(this._super);
        this._super.init(firstName, lastName, age);
        this.grade = grade;
    },
    introduce: function () {
        var introduction = "";
        introduction += this._super.introduce();
        introduction += getPropertiesAsString(this);
        return introduction;
    }
});

// Represents a Teacher
var Teacher = Person.extend({
    init: function (firstName, lastName, age, speciality) {
        this._super = Object.create(this._super);
        this._super.init(firstName, lastName, age);
        this.speciality = speciality;
    },
    introduce: function () {
        // Another way. We don`t need to call this._super.introduce() because getPropertiesAsString works recursively.
        return getPropertiesAsStringRecursively(this);
    }
});

// Represents a School
var School = {
    init: function (name, town, classes) {
        this.name = name;
        this.town = town;
        this.classes = classes;
    }
}

// Represents a Class
var Class = {
    init: function (name, capacity, students, formTeacher) {
        this.name = name;
        this.capacity = capacity;
        this.students = students;
        this.formTeacher = formTeacher;
    }
}

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

// Prints recursively all properies of an object which are not functions.
var getPropertiesAsStringRecursively = function (obj) {
    var introduction = "";
    for (var prop in obj) {
        if (typeof (obj[prop]) != "function") {
            if (typeof (obj[prop]) === "object") {
                introduction = getPropertiesAsString(obj[prop]);
            }
            else {
                introduction += prop + ": " + obj[prop] + ", ";
            }
        }
    }
    return introduction;
}