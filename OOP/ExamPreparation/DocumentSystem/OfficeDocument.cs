using System;
using System.Collections.Generic;

public abstract class OfficeDocument : EncriptableDocument
{
    public string Version { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "version":
                this.Version = value;
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("version", this.Version));
        base.SaveAllProperties(output);
    }
}