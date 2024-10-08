using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementApp.Model
{
    public class Drivers
    {
        private int driverID;
        public int DriverID
        {
            get { return driverID; }
            set { driverID = value; }
        }
        private int tripID;
        public int TripID
        {
            get { return tripID; }
            set { tripID = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Drivers() { }
        public Drivers(int driverID, int tripID, string name)
        {
            this.driverID = driverID;
            this.tripID = tripID;
            this.name = name;
        }
        public override string ToString()
        {
            return $"Driver ID : {driverID}\t Trip ID : {tripID}\t Name of the driver : {name} ";
        }
    }
}
