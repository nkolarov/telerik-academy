using System;
using System.Text;

class Display
{
    private double? size;
    private ulong? colorsNumber;

    public Display() : this(null,null)
    { 
    }

    public Display(double? size) : this(size, null)
    {
    }

    public Display(double? size, ulong? colorsNumber)
    {
        this.Size = size;
        this.ColorsNumber = colorsNumber;
    }

    public ulong? ColorsNumber
    {
        get
        {
            return this.colorsNumber;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.colorsNumber = value;
        }
    }

    public double? Size
    {
        get
        {
            return this.size;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.size = value;
        }
    }

    public override string ToString()
    {
        StringBuilder displayInfo = new StringBuilder();

        if ((this.Size != null) || (this.ColorsNumber != null))
        {
            displayInfo.AppendLine("---Display---");
        }
        if (this.Size != null)
        {
            displayInfo.AppendLine("Size: " + this.Size.ToString());    
        }
        if (this.ColorsNumber != null)
        {
            displayInfo.AppendLine("ColorsNumber: " + this.ColorsNumber.ToString());    
        }

        return displayInfo.ToString();
    }
}