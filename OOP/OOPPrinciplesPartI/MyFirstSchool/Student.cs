using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Student : Person, ICommentable
{
    //Fields
    private int classNumber;
    private List<string> comments;

    //Properties
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

    public int ClassNumber
    {
        get
        {
            return this.classNumber;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.classNumber = value;
        }
    }

    //Constructors
    public Student(string name, int classNumber) : base(name)
    {
        this.ClassNumber = classNumber;
        this.Comments = new List<string>();
    }
    
    //Methods
    public void Comment(string comment)
    {
        Comments.Add(comment);
    }
}