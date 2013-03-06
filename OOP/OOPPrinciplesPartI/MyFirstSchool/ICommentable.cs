using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface ICommentable
{
    //Properties
    List<string> Comments { get; set; }

    //Method
    void Comment(string comment);
}