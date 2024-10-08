using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementApp.Model;

namespace TransportManagementApp.Repository
{
    public interface TransportManagementService
    {
        public bool AddVehicle(Vehicles vehicle);
        public bool DeleteVehicle(int vehicleID);
        public bool ScheduleTrip(int vehicleID, int routeID, DateTime departureDate, DateTime arrivalDate);
        public bool CancelTrip(int tripID);
        public  bool BookTrip(int tripID, int passengerID);
        public bool CancelBooking(int bookingID);
        public  bool AllocateDriver(int driverID ,int tripID );
        public  bool DeAllocateDriver(int driverID);
        public List<Bookings> GetBookingsByPassenger(int passengerID);
        List<Bookings> GetBookingsByTrip(int tripID);
        List<Drivers> GetAvailableDrivers();
        List<Vehicles> GetAllVehicleDetails();
        List<Bookings> GetAllBookingsDetails();
        List<Drivers> GetAllDriversDetails();
        List<Passengers> GetAllPassengersDetails();
        List<Routes> GetAllRoutesDetails();
        List<Trips> GetAllTripsDetails();
    }
}
