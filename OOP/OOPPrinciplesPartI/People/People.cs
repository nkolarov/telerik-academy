using System;
using System.Collections.Generic;
using System.Linq;

class People
{
    static void Main()
    {
        List<Student> peoples = new List<Student>();

        peoples.Add(new Student("Ivan", "Ivanov", 3));
        peoples.Add(new Student("Gosho", "Geporgiev", 4));
        peoples.Add(new Student("Nemoga", "BLagodaria", 6));
        peoples.Add(new Student("Stoian", "Stoianov", 1));
        peoples.Add(new Student("Aneta", "Nikolova", 1));
        peoples.Add(new Student("Mimi", "Petrova", 1));
        peoples.Add(new Student("Alek", "Dimitrov", 2));
        peoples.Add(new Student("Nikolai", "Nikolov", 3));
        peoples.Add(new Student("Ani", "Angelova", 3));
        peoples.Add(new Student("Vania", "Dimitrova", 3));

        //Lambda order
        List<Student> orderedStudetns = new List<Student>(peoples.OrderBy(x => x.Grade));
        //Test LINQ
        //var orderedStudetns =
        //                            from st in peoples
        //                            orderby st.Grade
        //                            select new Student(st.FirstName,st.LastName,st.Grade);

        Console.WriteLine("STUDENTS:");
        foreach (var stud in orderedStudetns)
        {
            Console.WriteLine(stud.FirstName + " " + stud.LastName + ", Grade: " + stud.Grade);
        }

        List<Worker> workers = new List<Worker>()
        {
            new Worker("Dimitar", "Nikolov", 8,400),
            new Worker("Misho", "Petrov", 8,800),
            new Worker("Nina", "Angelova", 10,1400),
            new Worker("Dimitar", "Ivanov", 12,600),
            new Worker("Kliment", "Tzvetkov", 16,200),
            new Worker("Angel", "Tsonkov", 1,100),
            new Worker("Koko", "Dimitrov", 2,150),
            new Worker("Boiko", "Borisov", 20,50),
            new Worker("Tsvetan", "Tsvetanov", 11,4000),
            new Worker("Pisnami", "Ottezimena", 15,10)
        };

        //workers = new List<Worker>(workers.OrderByDescending(x => x.MoneyPerHour()));

        //Test LINQ
        //var sortedWorkers =
        //    from worker in workers
        //    orderby worker.MoneyPerHour() descending
        //    select worker;

        Console.WriteLine();
        Console.WriteLine("WORKERS:");
        foreach (var worker in workers)
        {
            Console.WriteLine(worker.FirstName + " " + worker.LastName + ", Salary: " + worker.MoneyPerHour());
        }

        List<Human> humans = new List<Human>(workers.Concat(new List<Human>(peoples)));
        humans = humans.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();

        Console.WriteLine();
        Console.WriteLine("HUMANS:");
        foreach (var person in humans)
        {
            Console.WriteLine(person.FirstName + " " + person.LastName);
        }
    }
}