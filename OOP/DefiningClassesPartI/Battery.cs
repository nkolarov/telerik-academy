using System;
using System.Text;

class Battery
{
    private string batteryModel;
    private uint? hoursIdle;
    private uint? hoursTalk;
    private BatteryType? batteryType;
    
    public Battery() : this(null,null,null,null)
    { 
    }

    public Battery(string batteryModel) : this(batteryModel, null, null, null)
    {
    }

    public Battery(string batteryModel, uint? hoursIdle) : this(batteryModel, hoursIdle, null, null)
    {
    }

    public Battery(string batteryModel, uint? hoursIdle, uint? hoursTalk) : this(batteryModel, hoursIdle, hoursTalk, null)
    {
    }

    public Battery(string batteryModel, uint? hoursIdle, uint? hoursTalk, BatteryType? batteryType) 
    {
        this.BatteryModel = batteryModel;
        this.HoursIdle = hoursIdle;
        this.HoursTalk = hoursTalk;
        this.BatteryType = batteryType;
    }

    public BatteryType? BatteryType
    {
        get
        {
            return this.batteryType;
        }
        set
        {
            this.batteryType = value;
        }
    }

    public uint? HoursTalk
    {
        get
        {
            return this.hoursTalk;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.hoursTalk = value;
        }
    }

    public uint? HoursIdle
    {
        get
        {
            return this.hoursIdle;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.hoursIdle = value;
        }
    }

    public string BatteryModel
    {
        get
        {
            return this.batteryModel;
        }
        set
        {
            this.batteryModel = value;
        }
    }

    public override string ToString()
    {
        StringBuilder batteryInfo = new StringBuilder();
        if (this.BatteryModel != null || this.HoursIdle != null || this.HoursTalk != null || this.BatteryType != null)
        {
            batteryInfo.AppendLine("---Battery---");
        }
        if (this.BatteryModel != null)
        {
            batteryInfo.AppendLine("BatteryModel: " + this.BatteryModel);    
        }
        if (this.HoursIdle != null)
        {
            batteryInfo.AppendLine("HoursIdle: " + this.HoursIdle.ToString());            
        }
        if (this.HoursTalk != null)
        {
            batteryInfo.AppendLine("HoursTalk: " + this.HoursTalk.ToString());      
        }
        if (this.BatteryType != null)
        {
            batteryInfo.AppendLine( "BatteryType: " + this.BatteryType.ToString());  
        }

        return batteryInfo.ToString();
    }
}