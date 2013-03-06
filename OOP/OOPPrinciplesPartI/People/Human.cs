using System;

abstract class Human
{
    //Fields
    private string firstName;
    private string lastName;

    //Properties
    public string FirstName 
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            this.firstName = value;
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
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            this.lastName = value;
        }
    }

    //Contructor
    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}