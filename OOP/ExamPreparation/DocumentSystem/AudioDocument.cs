using System;
using System.Collections.Generic;

public class AudioDocument : MultimediaDocument
{
    public int? SampleRate { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "samplerate":
                this.SampleRate = int.Parse(value);
                break;
            default:
                base.LoadProperty(key, value);
                break;
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
        base.SaveAllProperties(output);
    }
}