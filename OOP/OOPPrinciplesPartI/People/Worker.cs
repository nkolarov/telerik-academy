using System;

class Worker : Human
{
    //Fields
    private decimal weekSalary;
    private int workHoursPerDay;
    private const int WorkdaysInWeek = 5;
    
    //Properties
    public int WorkHoursPerDay
    {
        get
        {
            return this.workHoursPerDay;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.workHoursPerDay = value;
        }
    }

    public decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.weekSalary = value;
        }
    }

    //Constructor
    public Worker(string firstName, string lastName, int workHoursPerDay, decimal weekSalary)
        : base(firstName, lastName)
    {
        this.WorkHoursPerDay = workHoursPerDay;
        this.WeekSalary = weekSalary;

    }

    //Methods
    public decimal MoneyPerHour()
    {
        return Math.Round(this.WeekSalary / WorkdaysInWeek / this.WorkHoursPerDay,2);
    }
}