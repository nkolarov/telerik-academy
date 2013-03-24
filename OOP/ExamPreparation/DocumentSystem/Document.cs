using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Document : IDocument
{
    public string Name { get; private set; }

    public string Content { get; set; }

    public virtual void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "name":
                this.Name = value;
                break;
            case "content":
                this.Content = value;
                break;
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(this.GetType().Name);
        result.Append("[");
        List<KeyValuePair<string, object>> attributes = new List<KeyValuePair<string, object>>();
        this.SaveAllProperties(attributes);
        var orderedAttributes = attributes.OrderBy(attr => attr.Key);
        foreach (var attribute in orderedAttributes)
        {
            if (attribute.Value != null)
            {
                result.Append(attribute.Key + "=" + attribute.Value + ";");
            }
        }
        result.Length--;
        result.Append("]");
        return result.ToString();
    }
}