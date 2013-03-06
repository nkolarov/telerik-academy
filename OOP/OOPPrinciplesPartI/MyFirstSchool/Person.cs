using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    //Fields
    private string name;

    //Properties
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            this.name = value;
        }
    }

    //Methods
    public Person(string name)
    {
        this.Name = name;
    }
}