using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementApp.Model;
using TransportManagementApp.Utility;

namespace TransportManagementApp.Repository
{
    public class UserInput
    {
        public Vehicles VehicleInput()
        {
            Vehicles vehicle = new Vehicles();

            Console.WriteLine("Enter Vehicle Model:");
            vehicle.Model = Console.ReadLine();

            Console.WriteLine("Enter Vehicle Capacity:");
            vehicle.Capacity = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Vehicle Type (Truck Van or Bus):");
            vehicle.Type = Console.ReadLine();


            Console.WriteLine("Enter Vehicle Status:");
            vehicle.Status = Console.ReadLine();


            return vehicle;
        }
        public int VehicleIDInput()
        {

            int vehicleID;
            Console.WriteLine("Enter the ID of the Vehicle ");
            vehicleID = int.Parse(Console.ReadLine());
            return vehicleID;
        }
        public int RouteIDInput()
        {

            int routeID;
            Console.WriteLine("Enter the ID of the Route ");
            routeID = int.Parse(Console.ReadLine());
            return routeID;
        }
        public DateTime ArrivalDateInput()
        {

            DateTime arrivalDate;
            Console.WriteLine("Enter the Date of arrival");
            arrivalDate = DateTime.Parse(Console.ReadLine());
            return arrivalDate;
        }
        public DateTime DepartureDateInput()
        {

            DateTime departureDate;
            Console.WriteLine("Enter the Date of Departure");
            departureDate = DateTime.Parse(Console.ReadLine());
            return departureDate;
        }
        public int TripIDInput()
        {

            int tripID;
            Console.WriteLine("Enter the ID of the trip ");
            tripID = int.Parse(Console.ReadLine());
            return tripID;
        }
        public int BookingIDInput()
        {

            int bookingID;
            Console.WriteLine("Enter the ID of the Booking ");
            bookingID = int.Parse(Console.ReadLine());
            return bookingID;
        }
        public int PassengerIDInput()
        {

            int passengerID;
            Console.WriteLine("Enter the ID of the Passenger ");
            passengerID = int.Parse(Console.ReadLine());
            return passengerID;
        }
        public int DriverIDInput()
        {

            int driverID;
            Console.WriteLine("Enter the ID of the driver ");
            driverID = int.Parse(Console.ReadLine());
            return driverID;
        }

       
    }
}
