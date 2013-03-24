using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EncriptableDocument : BinaryDocument, IEncryptable
{
    public bool IsEncrypted { get; private set; }

    public void Encrypt()
    {
        this.IsEncrypted = true;
    }

    public void Decrypt()
    {
        this.IsEncrypted = false;
    }

    public override string ToString()
    {
        if (this.IsEncrypted)
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append("[encrypted]");
            return result.ToString();
        }
        else
        {
            return base.ToString();
        }
    }
}