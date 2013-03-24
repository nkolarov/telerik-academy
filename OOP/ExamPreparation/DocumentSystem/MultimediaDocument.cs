using System;
using System.Collections.Generic;

public abstract class MultimediaDocument : BinaryDocument
{
    public int? Length { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "length":
                this.Length = int.Parse(value);
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("length", this.Length));
        base.SaveAllProperties(output);
    }
}