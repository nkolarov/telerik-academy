public class RefactorHuman
{
    /// <summary>
    /// Stores Types of Sex.
    /// </summary>
    private enum Sex
    {
        /// <summary>
        /// Represents sex - male.
        /// </summary>
        Male,

        /// <summary>
        /// Represents sex - female.
        /// </summary>
        Female
    }

    /// <summary>
    /// Creates a <see cref="Person"/> object.
    /// </summary>
    /// <param name="age">Age of the person.</param>
    public void CreatePerson(int age)
    {
        Person person = new Person();
        person.Age = age;
        if (age % 2 == 0)
        {
            person.Name = "Батката";
            person.Sex = Sex.Male;
        }
        else
        {
            person.Name = "Мацето";
            person.Sex = Sex.Female;
        }
    }

    /// <summary>
    /// Program entry point.
    /// </summary>
    private static void Main()
    {
        // Entry point.
    }
    
    /// <summary>
    /// Stores a Person.
    /// </summary>
    private class Person
    {
        /// <summary>
        /// Gets or sets Person sex.
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Gets or sets Person name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Person age.
        /// </summary>
        public int Age { get; set; }
    }
}