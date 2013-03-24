using System;
using System.Collections.Generic;

public class PDFDocument : EncriptableDocument
{
    public int? Pages { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "pages":
                this.Pages = int.Parse(value);
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("pages", this.Pages));
        base.SaveAllProperties(output);
    }
}