using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class InvoiceGenerator
    {
        RideType rideType;
        private RideRepository rideRepository;

        private readonly double MINIMUM_COST_PER_KM;
        private readonly int  COST_PER_TIME;
        private readonly double MINIMUM_FARE;

        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();
            try
            {
                if (rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;


                }
                else if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }

            }
            catch (CabInvoiceException)
            {

                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "INVALID RIDE TYPE");
            }
        }
        public double CalculateFare(double distance,int time)
        {
            double totalFare = 0;
            try
            {
                //Calculate total fare;
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;

            }
            catch (CabInvoiceException)
            {

                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
                }
                if (distance <=0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                }
                if (time <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }

        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalfare = 0;
            try
            {   

                //calculate total Fare 
                foreach (Ride ride in rides)
                {
                    totalfare += this.CalculateFare(ride.Distance, ride.time);
                }
            }
            catch (CabInvoiceException)
            {

                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Ride Are Null");
                }
            }
            return new InvoiceSummary(rides.Length, totalfare);
        }



       


    }   

}
//(localdb)\MSSQLLocalDB
