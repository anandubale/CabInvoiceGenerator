using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Cab invoice Generator");
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double fare = invoiceGenerator.CalculateFare(2.0, 5);
            double fare1 = invoiceGenerator.CalculateFare(3.0, 6);
            

            Console.WriteLine($"Fare : {fare}");
            Console.WriteLine($"Fare : {fare1}");


            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            int NoOfRides = rides.Length;

            Console.WriteLine(NoOfRides);
        }
    }
}
//localhost\SQLEXPRESS