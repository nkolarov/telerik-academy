using System;

class TestSchool
{
    static void Main()
    {
        MYSchool university = new MYSchool();

        Class firstClass = new Class("firstClass");

        Teacher george = new Teacher("George");

        Discipline algebra = new Discipline("Algebra", 10, 10);
        algebra.Comments.Add("Required");

        george.Disciplines.Add(algebra);
        george.Comments.Add("Good Teacher");

        firstClass.Teachers.Add(george);
        university.Classes.Add(firstClass);

        Student ivan = new Student("Ivan", 20);
        ivan.Comments.Add("Smoker");

        firstClass.Students.Add(ivan);
    }
}