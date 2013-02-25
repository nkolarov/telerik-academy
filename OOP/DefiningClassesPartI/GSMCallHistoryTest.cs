using System;

class GSMCallHistoryTest
{
    static void Main()
    {
        //Test task 4
        GSM iPhone = new GSM("iPhone4s", "Apple");

        //Console.WriteLine(iPhone.ToString());

        //Task 7
        GSM[] phoneStore = new GSM[]
        {
            new GSM("N95","Nokia",123, "nobody", new Battery("1200",105,43), new Display(8d,16000000)),
            new GSM("X200","Samsung"),
            new GSM("eXperia","Sony",500)
        };

        //Sell a phone to Bai Pesho
        phoneStore[0].Owner = "Bai Pesho";

       // Console.WriteLine("Phones in Store:");
        foreach (var phone in phoneStore)
        {
            //Console.WriteLine(phone);
        }

        //Console.WriteLine(GSM.IPhone4S);

        GSM workPhone = new GSM("210", "Huavei", 5, "worker");
        workPhone.MakeCall(883555555, 150);
        workPhone.MakeCall(883556555, 190);
        workPhone.MakeCall(883566645, 212);

        foreach (var call in workPhone.CallHistory)
        {
            Console.WriteLine("Call to {0},  duration: {1}",call.PhoneNumber,call.CallDuration);
        }

        //Print Total Cost
        Console.WriteLine("Total Cost: " + workPhone.CalculateTotalPrice(0.37m));

        //Find and remove longest call
        ;
        ulong maxDuration = ulong.MinValue;

        foreach (var call in workPhone.CallHistory)
        {
            if (call.CallDuration>maxDuration)
            {
                maxDuration = call.CallDuration;
            }
        }

        if (maxDuration != ulong.MinValue)
        {
            workPhone.RemoveCallByDuration(maxDuration);
            Console.WriteLine();
            Console.WriteLine("Removed call with duration: " + maxDuration);
        }

        //Print Total Cost without longest duration
        
        Console.WriteLine("Total Cost: " + workPhone.CalculateTotalPrice(0.37m));
        Console.WriteLine();

        foreach (var call in workPhone.CallHistory)
        {
            Console.WriteLine(call.ToString());
        }

        workPhone.ClearCallHistory();
        //Print again
        Console.WriteLine("Call History: ");
        foreach (var call in workPhone.CallHistory)
        {
            Console.WriteLine(call.ToString());
        }
        //
    }
}