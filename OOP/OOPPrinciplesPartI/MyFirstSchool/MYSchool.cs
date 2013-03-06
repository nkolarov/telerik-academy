using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MYSchool
{
    //Fields
    private List<Class> classes;

    //Properties
    public List<Class> Classes
    {
        get
        {
            return this.classes;
        }
        set
        {
            this.classes = value;
        }
    }

    public MYSchool()
    {
        this.Classes = new List<Class>();
    }
}