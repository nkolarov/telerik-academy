using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Teacher : Person, ICommentable
{
    //Fields
    private List<string> comments;
    private List<Discipline> disciplines;
    
    //Properties
    public List<Discipline> Disciplines
    {
        get
        {
            return this.disciplines;
        }
        set
        {
            this.disciplines = value;
        }
    }

    public List<string> Comments
    {
        get
        {
            return this.comments;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            this.comments = value;
        }
    }

    //Constructors
    public Teacher(string name) : base(name)
    {
        this.Disciplines = new List<Discipline>();
        this.Comments = new List<string>();
    }

    //Methods
    public void Comment(string comment)
    {
        Comments.Add(comment);
    }
}