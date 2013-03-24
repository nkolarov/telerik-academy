using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TextDocument : Document, IEditable
{
    public string Charset { get; private set; }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "charset":
                this.Charset = value;
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("charset", this.Charset));
        base.SaveAllProperties(output);
    }
}