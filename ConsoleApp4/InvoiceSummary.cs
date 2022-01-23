using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4   
{
    public class InvoiceSummary
    {   
        //Variables
        private int numberOfRides;
        private double totalfare;
        private double averagefare;
        

        public InvoiceSummary(int numberOfRides, double totalfare)
        {
            this.numberOfRides = numberOfRides;
            this.totalfare = totalfare;
            this.averagefare = this.totalfare / this.numberOfRides;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            if (!(obj is InvoiceSummary)) return false;
            InvoiceSummary inputedObject = (InvoiceSummary)obj;
            return this.numberOfRides == inputedObject.numberOfRides && this.totalfare == inputedObject.totalfare && this.averagefare == inputedObject.averagefare;
        }


        public override int GetHashCode()
        {
            return this.numberOfRides.GetHashCode() ^ this.totalfare.GetHashCode() ^ this.averagefare.GetHashCode();
        }



    }   

}
 