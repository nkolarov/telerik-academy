using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Discipline : ICommentable
{
    //Fields
    private List<string> comments;
    private string name;
    private int numberOfLectures;
    private int numberOfExercices;

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

    public int NumberOfLectures
    {
        get
        {
            return this.numberOfLectures;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.numberOfLectures = value;
        }
    }

    public int NumberOfExercises
    {
        get
        {
            return this.numberOfExercices;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.numberOfExercices = value;
        }
    }
    
    //Constructors
    public Discipline(string name, int numberOfLectures, int numberOfExercises)
    {
        this.Name = name;
        this.NumberOfExercises = numberOfExercises;
        this.NumberOfLectures = numberOfLectures;
        this.Comments = new List<string>();
    }
    
    //Methods
    public void Comment(string comment)
    {
        Comments.Add(comment);
    }
}