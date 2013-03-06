using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Class : ICommentable
{
    //Fields
    private List<string> comments;
    private List<Student> students;
    private List<Teacher> teachers;
    private string identifier;

    //Properties
    public List<Student> Students
    {
        get
        {
            return this.students;
        }
        set
        {
            this.students = value;
        }
    }

    public List<Teacher> Teachers
    {
        get
        {
            return this.teachers;
        }
        set
        {
            this.teachers = value;
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

    public string Identifier
    {
        get
        {
            return this.identifier;
        }
        set
        {
            this.identifier = value;
        }
    }
    
    //Constructors
    public Class(string identifier)
    {
        this.Identifier = identifier;
        this.Teachers = new List<Teacher>();
        this.Students = new List<Student>();
        this.Comments = new List<string>();
    }
    
    //Methods
    public void  Comment(string comment)
    {
        Comments.Add(comment);
    }
}