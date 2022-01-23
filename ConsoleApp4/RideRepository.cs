using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = null;
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        public void AddRides(string userId,Ride[] rides)
        {
            bool ridesList = this.userRides.ContainsKey(userId);
            try
            {
                if (!ridesList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch (CabInvoiceException)
            {

                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are Null");
            }
        }
    }
}
