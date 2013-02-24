using System;
using System.Text;

class GSM
{
    private string phoneModel;
    private string manufacturer;
    private decimal? price;
    private string owner;
    public Battery batteryData = new Battery();
    public Display displayData = new Display();

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
        this.batteryData = batteryData;
        this.displayData = display;
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

    public override string ToString()
    {
        StringBuilder mobileInfo = new StringBuilder();
        mobileInfo.AppendLine("GSM: ");
        mobileInfo.AppendLine(this.PhoneModel == null ? "" : "Model: "+this.PhoneModel);
        mobileInfo.AppendLine(this.Manufacturer == null ? "" : "Manufacturer: " + this.Manufacturer);
        mobileInfo.AppendLine(this.Price == null ? "" : "Price: " + this.Price);
        mobileInfo.AppendLine(this.Owner == null ? "" : "Owner: " + this.Owner);
        mobileInfo.AppendLine(this.displayData == null ? "" : "DisplayData: " + this.displayData.ToString());
        return mobileInfo.ToString();
    }
}