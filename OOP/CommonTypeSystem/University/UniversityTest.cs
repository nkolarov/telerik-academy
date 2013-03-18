using System;

namespace University
{
    public class UniversityTest
    {
        public static void Main()
        {
            Student pesho = new Student(
                "Pesho",
                "Petrov",
                "Petrov",
                1111,
                "Sofia",
                "0888 88 88 88",
                "pesho@pesho.com",
                "first",
                Specialty.SoftwareEngineering,
                University.Telerik,
                Faculty.FEA);

            Student gosho = new Student(
                "Pesho",
                "Petrov",
                "Petrov",
                1111,
                "Sofia",
                "0888 88 88 88",
                "pesho@pesho.com",
                "first",
                Specialty.SoftwareEngineering,
                University.Telerik,
                Faculty.FEA);

            Student vanio = new Student(
                "Vesho",
                "Petrov",
                "Petrov",
                11111,
                "Sofia",
                "0888 88 88 88",
                "pesho@pesho.com",
                "first",
                Specialty.SoftwareEngineering,
                University.Telerik,
                Faculty.FEA);

            // Test Equals()
            Console.WriteLine("pesho.Equals(gosho)");
            Console.WriteLine(pesho.Equals(gosho));
            Console.WriteLine("gosho.Equals(vanio)");
            Console.WriteLine(gosho.Equals(vanio));

            // Test opperators
            Console.WriteLine("pesho == gosho");
            Console.WriteLine(pesho == gosho);
            Console.WriteLine("gosho != vanio");
            Console.WriteLine(gosho != vanio);
            Console.WriteLine();

            // Test ToString()
            Console.WriteLine(pesho);
            Console.WriteLine();

            // Test Cloning
            Student ivan = (Student)vanio.Clone();
            Console.WriteLine(vanio);
            Console.WriteLine(ivan);

            // Edit some data
            ivan.FirstName = "Ivan";
            ivan.Address = "nov000";
            ivan.Ssn = 123;
            ivan.Faculty = Faculty.FMU;
            vanio.Address = "4546";
            vanio.Ssn = 345;
            vanio.University = University.TU;

            // Check Result
            Console.WriteLine(vanio);
            Console.WriteLine(ivan);

            // Test Compare To
            Console.WriteLine(vanio.CompareTo(gosho));
            Console.WriteLine(pesho.CompareTo(gosho));
            Console.WriteLine(gosho.CompareTo(vanio));

            pesho.Ssn = 123;
            gosho.Ssn = 124;
            Console.WriteLine(pesho.CompareTo(gosho));
            Console.WriteLine(gosho.CompareTo(pesho));
        }
    }
}