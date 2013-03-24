using System;
using System.Collections.Generic;

public class BinaryDocument : Document
{
    public int? Size { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "size":
                this.Size = int.Parse(value);
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("size", this.Size));
        base.SaveAllProperties(output);
    }


}