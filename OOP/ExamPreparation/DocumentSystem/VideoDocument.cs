using System;
using System.Collections.Generic;

public class VideoDocument : MultimediaDocument
{
    public int? FrameRate { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "framerate":
                this.FrameRate = int.Parse(value);
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
        base.SaveAllProperties(output);
    }
}