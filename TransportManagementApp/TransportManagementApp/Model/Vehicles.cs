using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementApp.Model
{
    public class Vehicles
    {
        private int vehicleId;
        public int VehicleID
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }
        private string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private decimal capacity;
        public decimal Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public Vehicles()
        {

        }

        public Vehicles(int id)
        {
            vehicleId = id;

        }
        public Vehicles(int vehicleID, string model, decimal capacity, string type, string status)
        {
            this.vehicleId = vehicleID;
            this.model = model;
            this.capacity = capacity;
            this.type = type;
            this.status = status;

        }

        public override string ToString()
        {
            return $"Vehicle ID : {vehicleId}\t Model : {model}\t Type : {type}\t Capacity : {capacity}\t Status : {status} ";
        }
    }
}
