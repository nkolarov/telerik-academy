using System;
using System.Text;

class Call
{
    private DateTime callDateAndTime;
    private ulong phoneNumber;
    private ulong callDuration;

    public Call(DateTime callDateAndTime, ulong phoneNumber, ulong callDuration)
    {
        this.CallDateAndTime = callDateAndTime;
        this.PhoneNumber = phoneNumber;
        this.CallDuration = callDuration;
    }

    public ulong CallDuration
    {
        get
        {
            return callDuration;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            callDuration = value;
        }
    }

    public ulong PhoneNumber
    {
        get
        {
            return phoneNumber;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            phoneNumber = value;
        }
    }

    public DateTime CallDateAndTime
    {
        get
        {
            return callDateAndTime;
        }
        set
        {
            callDateAndTime = value;
        }
    }

    public override string ToString()
    {
        StringBuilder callInfo = new StringBuilder();
        callInfo.AppendLine("---Call---");
        callInfo.AppendLine("CallDateAndTime: " + this.CallDateAndTime);
        callInfo.AppendLine("CallDuration: " + this.CallDuration);
        callInfo.AppendLine("PhoneNumber: " + this.PhoneNumber);
        return callInfo.ToString();
    }
}