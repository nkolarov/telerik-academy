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
        batteryInfo.AppendLine("Battery");
        batteryInfo.Append("BatteryModel");
        batteryInfo.AppendLine(this.BatteryModel);
        batteryInfo.Append("HoursIdle");
        batteryInfo.AppendLine(this.HoursIdle.ToString());
        batteryInfo.Append("HoursTalk");
        batteryInfo.AppendLine(this.HoursTalk.ToString());
        batteryInfo.Append("BatteryType");
        batteryInfo.AppendLine(this.BatteryType.ToString());
        return batteryInfo.ToString();
    }
}