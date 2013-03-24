using System;
using System.Collections.Generic;

public class ExcelDocument : OfficeDocument
{
    public int? Rows { get; private set; }

    public int? Cols { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "rows":
                this.Rows = int.Parse(value);
                break;
            case "cols":
                this.Cols = int.Parse(value);
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("rows", this.Rows));
        output.Add(new KeyValuePair<string, object>("cols", this.Cols));
        base.SaveAllProperties(output);
    }
}