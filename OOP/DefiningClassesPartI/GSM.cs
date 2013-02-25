using System;
using System.Collections.Generic;
using System.Text;

class GSM
{
    private string phoneModel;
    private string manufacturer;
    private decimal? price;
    private string owner;
    private static GSM iPhone4S = new GSM("iPhone4S", "Apple", 1200m,"me");
    
    public Battery batteryData = new Battery();
    public Display displayData = new Display();

    private List<Call> callHistory = new List<Call>();

    public GSM(string model, string manufacturer) : this(model, manufacturer, null, null, null, null)
    {
    }

    public GSM(string model, string manufacturer, decimal price) : this(model, manufacturer, price, null, null, null)
    {
    }

    public GSM(string model, string manufacturer, decimal price, string owner) : this(model, manufacturer, price, owner, null, null)
    {
    }

    public GSM(string model, string manufacturer, decimal price, string owner, Battery batteryData) : this(model, manufacturer, price, owner, batteryData, null)
    {
    }

    public GSM(string model, string manufacturer, decimal? price, string owner, Battery batteryData, Display display)
    {
        this.PhoneModel = model;
        this.Manufacturer = manufacturer;
        this.Price = price;
        this.Owner = owner;
        if (batteryData != null)
        {
            this.batteryData = batteryData;
        }
        else
        {
            this.batteryData = new Battery();
        }
        if (batteryData != null)
        { 
            this.displayData = display;
        }
        else
        {
            this.displayData = new Display();
        }
    }

    public List<Call> CallHistory
    {
        get
        {
            return this.callHistory;
        }
    }

    public static GSM IPhone4S
    {
        get
        {
            return iPhone4S;
        }
        set
        {
            iPhone4S = value;
        }
    }

    public string Owner
    {
        get
        {
            return this.owner;
        }
        set
        {
            this.owner = value;
        }
    }

    public decimal? Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.price = value;
        }
    }

    public string Manufacturer
    {
        get
        {
            return this.manufacturer;
        }
        set
        {
            this.manufacturer = value;
        }
    }

    public string PhoneModel
    {
        get
        {
            return this.phoneModel;
        }
        set
        {
            this.phoneModel = value;
        }
    }

    public void MakeCall(ulong phoneNumber, ulong duration)
    { 
        CallHistory.Add(new Call(DateTime.Now, phoneNumber, duration));
    }

    public void RemoveCallByNumber(ulong number)
    {
        for (int i = 0; i < CallHistory.Count; i++)
        {
            if (CallHistory[i].PhoneNumber == number)
            {
                CallHistory.RemoveAt(i);
            }
        }
    }

    public void RemoveCallByDuration(ulong duration)
    {
        for (int i = 0; i < CallHistory.Count; i++)
        {
            if (CallHistory[i].CallDuration == duration)
            {
                CallHistory.RemoveAt(i);
            }
        }
    }

    public void ClearCallHistory()
    {
        CallHistory.Clear();
    }

    public decimal CalculateTotalPrice(decimal minutePrice) {
        decimal price = 0m;

        foreach (var call in CallHistory)
        {
            //Round up for 60 seconds
            price += Math.Ceiling(((decimal)call.CallDuration / 60)) * minutePrice ;
        }

        return price;
    }


    public override string ToString()
    {
        StringBuilder mobileInfo = new StringBuilder();
        mobileInfo.AppendLine("---GSM---");
        mobileInfo.AppendLine(this.PhoneModel == null ? "" : "Model: " + this.PhoneModel);
        mobileInfo.AppendLine(this.Manufacturer == null ? "" : "Manufacturer: " + this.Manufacturer);
        if (this.Price != null)
        {
            mobileInfo.AppendLine("Price: " + this.Price);    
        }
        if (this.Owner != null)
        {
            mobileInfo.AppendLine("Owner: " + this.Owner);  
        }
        if (this.displayData != null)
        {
            mobileInfo.Append(this.displayData.ToString());    
        }
        if (this.batteryData != null)
        {
            mobileInfo.Append(this.batteryData.ToString());
        }
        return mobileInfo.ToString();
    }
}