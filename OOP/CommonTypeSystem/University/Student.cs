using System;
using System.Text;

namespace University
{
    public class Student : ICloneable, IComparable<Student>
    { /*1. Define a class Student, which contains data about a student – first, middle and last name, SSN, 
        * permanent address, mobile phone e-mail, course, specialty, university, faculty. 
        * Use an enumeration for the specialties, universities and faculties. 
        * Override the standard methods, inherited by  System.Object: Equals(), ToString(), 
        * GetHashCode() and operators == and !=.
        *
        * 2.Add implementations of the ICloneable interface. 
        * The Clone() method should deeply copy all object's fields into a new object of type Student.
        * 
        * 3. Implement the  IComparable<Student> interface to compare students by names 
        * (as first criteria, in lexicographic order) and by social security number 
        * (as second criteria, in increasing order).        */
        // Fields
        private string firstName;
        private string middleName;
        private string lastName;
        private ulong ssn;
        private string address;
        private string mobilePhone;
        private string email;
        private string course;

        // Contructor
        public Student(
            string firstName,
            string middleName,
            string lastName,
            ulong ssn,
            string address,
            string mobilePhone,
            string email,
            string course,
            Specialty speciality,
            University university,
            Faculty faculty)
        {
            this.FirstName = firstName;
            this.middleName = middleName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Speciality = speciality;
            this.University = university;
            this.Faculty = faculty;
        }

        // Properties
        public Specialty Speciality { get; set; }

        public University University { get; set; }

        public Faculty Faculty { get; set; }

        // Properties
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            set
            {
                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.lastName = value;
            }
        }

        public ulong Ssn
        {
            get
            {
                return this.ssn;
            }

            set
            {
                this.ssn = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.address = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }

            set
            {
                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        public string Course
        {
            get
            {
                return this.course;
            }

            set
            {
                this.course = value;
            }
        }
        
        // Methods
        public static bool operator ==(Student student1, Student student2)
        {
            return Student.Equals(student1, student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !Student.Equals(student1, student2);
        }
        
        public override bool Equals(object param)
        {
            // If the cast is invalid, the result will be null
            Student student = param as Student;

            // Check if we have valid not null Student object
            if (student == null)
            {
                return false;
            }

            // Compare First Name
            if (!object.Equals(this.FirstName, student.FirstName))
            {
                return false;
            }

            // Compare Middle Name
            if (!object.Equals(this.MiddleName, student.MiddleName))
            {
                return false;
            }

            // Compare Last Name
            if (!object.Equals(this.LastName, student.LastName))
            {
                return false;
            }

            // Compare SSN
            if (this.Ssn != student.Ssn)
            {
                return false;
            }

            // Compare Address
            if (!object.Equals(this.Address, student.Address))
            {
                return false;
            }

            // Compare MobilePhone
            if (!object.Equals(this.MobilePhone, student.MobilePhone))
            {
                return false;
            }
            
            // Compare Email
            if (!object.Equals(this.Email, student.Email))
            {
                return false;
            }

            // Compare Course
            if (!object.Equals(this.Course, student.Course))
            {
                return false;
            }

            // Compare Specialty
            if (this.Speciality != student.Speciality)
            {
                return false;
            }

            // Compare University
            if (this.University != student.University)
            {
                return false;
            }

            // Compare Faculty
            if (this.Faculty != student.Faculty)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.Ssn.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("Student: {0} {2} {1}", this.FirstName, this.LastName, this.MiddleName));
            result.AppendLine("SSN: " + this.Ssn);
            result.AppendLine("Address: " + this.Address);
            result.AppendLine("MobilePhone: " + this.MobilePhone);
            result.AppendLine("Email: " + this.Email);
            result.AppendLine("Course: " + this.Course);
            result.AppendLine("Speciality: " + this.Speciality);
            result.AppendLine("University: " + this.University);
            result.AppendLine("Faculty: " + this.Faculty);

            return result.ToString();
        }

        public object Clone()
        { // Return Deep Copy
            return new Student(
                string.Copy(this.FirstName),
                string.Copy(this.MiddleName),
                string.Copy(this.LastName),
                this.Ssn,
                string.Copy(this.Address),
                string.Copy(this.MobilePhone),
                string.Copy(this.Email),
                string.Copy(this.Course),
                this.Speciality,
                this.University,
                this.Faculty);
        }

        public int CompareTo(Student student)
        {
            if (this.FirstName != student.FirstName)
            { // Compare names
                return this.FirstName.CompareTo(student.FirstName);
            }
            else
            { // Compare SSN
                if (this.Ssn != student.Ssn)
                {
                    return this.Ssn.CompareTo(student.Ssn);
                }
            }

            return 0;
        }
    }
}