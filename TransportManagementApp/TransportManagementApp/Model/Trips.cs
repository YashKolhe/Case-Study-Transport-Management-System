using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementApp.Model
{
    public class Trips
    {
        private int tripID;
        public int TripID
        {
            get { return tripID; }
            set { tripID = value; }
        }
        private int vehicleID;
        public int VehicleID
        {
            get { return vehicleID; }
            set { vehicleID = value; }
        }
        private int routeID;
        public int RouteID
        {
            get { return routeID; }
            set { routeID = value; }
        }

        private DateTime departureDate;
        public DateTime DepartureDate
        {
            get { return departureDate; }
            set { departureDate = value; }
        }
        private DateTime arrivalDate;
        public DateTime ArrivalDate
        {
            get { return arrivalDate; }
            set { arrivalDate = value; }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        private string tripType;
        public string TripType
        {
            get { return tripType; }
            set { tripType = value; }
        }
        private int maxPassengers;
        public int MaxPassengers
        {
            get { return maxPassengers; }
            set { maxPassengers = value; }
        }

        public Trips() { }
        public Trips(int tripID, int vehicleID, int routeID, DateTime departureDate, DateTime arrivalDate, string status, string tripType, int maxPassengers)
        {
            this.tripID = tripID;
            this.vehicleID = vehicleID;
            this.routeID = routeID;
            this.departureDate = departureDate;
            this.arrivalDate = arrivalDate;
            this.status = status;
            this.tripType = tripType;
            this.maxPassengers = maxPassengers;
        }
        public override string ToString()
        {
            return $"Trip ID : {tripID}\t Vehicle ID : {vehicleID}\t Route ID : {routeID}\t Departure Date : {departureDate}\t Arrival Date : {arrivalDate}\t Status : {status}\t Trip Type : {tripType}\t Maximum Passengers Allowed : {maxPassengers} ";
        }
    }
}
