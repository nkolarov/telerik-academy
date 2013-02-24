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
            this.size = value;
        }
    }

    public override string ToString()
    {
        this.Size = size;
        this.ColorsNumber = colorsNumber;

        StringBuilder displayInfo = new StringBuilder();
        displayInfo.AppendLine("Display");
        displayInfo.Append("Size");
        displayInfo.AppendLine(this.Size.ToString());
        displayInfo.Append("ColorsNumber");
        displayInfo.AppendLine(this.ColorsNumber.ToString());
        return displayInfo.ToString();
    }
}