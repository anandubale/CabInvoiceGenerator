using NUnit.Framework;
using ConsoleApp4;

namespace TestProject1
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;


        //Test case for Checking Calculate Fare Function

        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {   
            //creating instance of invoice generator for normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;


            //calculate Fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;

            Assert.AreEqual(expected, fare);
        }

        //Test case  for Checking Calculated Fare Function for Multiple Rides 


        [Test]
        public void GivenMultipleRideShouldReturnInvoiceSumary()
        {
            //creating instance of invoice generator for normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            //int variable = rides.Length;

            //int expected = 2;

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expctedSummary = new InvoiceSummary(2, 30.0);
                
            //Asserting
            Assert.AreEqual(expctedSummary, summary);
            //Assert.AreEqual(expected, variable);



        }
    }
}