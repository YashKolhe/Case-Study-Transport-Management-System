using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementApp.Model
{
    public class Routes
    {
        private int routeID;
        public int RouteID
        {
            get { return routeID; }
            set { routeID = value; }
        }
        private string startDestination;
        public string StartDestination
        {
            get { return startDestination; }
            set { startDestination = value; }
        }
        private string endDestination;
        public string EndDestination
        {
            get { return endDestination; }
            set { endDestination = value; }
        }
        private decimal distance;
        public decimal Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        public Routes()
        {
        }
        public Routes(int routeID, string startDestination, string endDestination, decimal distance)
        {
            this.routeID = routeID;
            this.startDestination = startDestination;
            this.endDestination = endDestination;
            this.distance = distance;
        }
        public override string ToString()
        {
            return $"Route ID : {routeID}\t Start Destination : {startDestination}\t End Destination : {endDestination}\t Distance : {distance}";
        }
    }
}
