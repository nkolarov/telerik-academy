using System;
using System.Collections.Generic;

public class WordDocument : OfficeDocument, IEditable
{
    public int? Chars { get; private set; }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "chars":
                this.Chars = int.Parse(value);
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("chars", this.Chars));
        base.SaveAllProperties(output);
    }
}