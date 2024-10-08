using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementApp.Exceptions;
using TransportManagementApp.Model;
using TransportManagementApp.Repository;

namespace TransportManagementApp.MainModule
{
    internal class TransportApp
    {
        readonly TransportManagementService _transportManagementService;
        readonly UserInput _userInput;
        readonly VehicleNotFoundException _vehicleNotFoundException;
        readonly BookingNotFoundException _bookingNotFoundException;
        public TransportApp()
        {
            _transportManagementService = new TransportManagementServiceImpl();
            _userInput = new UserInput();
            _vehicleNotFoundException = new VehicleNotFoundException("Vehicle Not Found!!");
            _bookingNotFoundException = new BookingNotFoundException("Booking Not Found!!");
        }
        public void UserRun()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to the Transport Management System");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Schedule Trip");
                Console.WriteLine("2. Cancel Trip");
                Console.WriteLine("3. Book Trip");
                Console.WriteLine("4. Cancel Booking");
                Console.WriteLine("5. Get Bookings By Passenger");
                Console.WriteLine("6. Get Bookings By Trip");
                Console.WriteLine("7. Get Available Drivers");
                Console.WriteLine("8. Get Details of all the Vehicles");
                Console.WriteLine("9. Get Details of all the Bookings");
                Console.WriteLine("10. Get Details of all the Drivers");
                Console.WriteLine("11. Get Details of all the Passengers");
                Console.WriteLine("12. Get Details of all the Routes");
                Console.WriteLine("13. Get Details of all the Trips");

                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                int input = int.Parse(Console.ReadLine());
                {
                    switch (input)
                    {                      
                        case 1:
                            List<Vehicles> v = _transportManagementService.GetAllVehicleDetails() ;
                            List<Routes> r = _transportManagementService.GetAllRoutesDetails();
                            int vehicleID = _userInput.VehicleIDInput();
                            int routeID = _userInput.RouteIDInput();
                            DateTime departureDate = _userInput.DepartureDateInput();
                            DateTime arrivalDate = _userInput.ArrivalDateInput();
                            bool result3 = _transportManagementService.ScheduleTrip(vehicleID, routeID, departureDate, arrivalDate);
                            if (result3)
                            {
                                Console.WriteLine("Trip Scheduled Successfully");
                            }
                            break;

                        case 2:
                            List<Trips> t = _transportManagementService.GetAllTripsDetails();
                            int tripID = _userInput.TripIDInput();
                            bool result4 = _transportManagementService.CancelTrip(tripID);
                            if (result4)
                            {
                                Console.WriteLine("Trip cancelled successfully");
                            }
                            break;

                        case 3:
                            List<Trips> t1 = _transportManagementService.GetAllTripsDetails();
                            List<Passengers> p = _transportManagementService.GetAllPassengersDetails();
                            int tripID1 = _userInput.TripIDInput();
                            int passengerID = _userInput.PassengerIDInput();
                            bool result5 = _transportManagementService.BookTrip(tripID1,passengerID);
                            if (result5)
                            {
                                Console.WriteLine("Trip Booked Successfully ");
                            }
                            break;

                        case 4:
                            List<Bookings> b = _transportManagementService.GetAllBookingsDetails();
                            int bookingID = _userInput.BookingIDInput();
                            try
                            {
                                bool result6 = _transportManagementService.CancelBooking(bookingID);
                                if (result6)
                                {
                                    Console.WriteLine("Booking Cancelled Successfully. ");
                                }
                            }
                            catch (BookingNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case 5:
                            List<Passengers> p1 = _transportManagementService.GetAllPassengersDetails();
                            int passengerID1 = _userInput.PassengerIDInput();
                            try
                            {
                                List<Bookings> booking1 = _transportManagementService.GetBookingsByPassenger(passengerID1);
                                if (booking1.Count > 0)
                                {
                                    Console.WriteLine($"Displaying the Booking by passengerID = {passengerID1} ");
                                }
                            }
                            catch (BookingNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case 6:
                            List<Trips> t2 = _transportManagementService.GetAllTripsDetails();
                            int tripID2 = _userInput.TripIDInput();
                            try
                            {
                                List<Bookings> booking2 = _transportManagementService.GetBookingsByTrip(tripID2);
                                if (booking2.Count > 0)
                                {
                                    Console.WriteLine($"Displaying the Booking by tripID = {tripID2}");
                                }
                            }
                            catch (BookingNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case 7:
                            _transportManagementService.GetAvailableDrivers();
                            break;

                        case 8:
                            _transportManagementService.GetAllVehicleDetails();
                            break;

                        case 9:
                            _transportManagementService.GetAllBookingsDetails();
                            break;
                        case 10:
                            _transportManagementService.GetAllDriversDetails();
                            break;
                        case 11:
                            _transportManagementService.GetAllPassengersDetails();
                            break;
                        case 12:
                            _transportManagementService.GetAllRoutesDetails();
                            break;
                        case 13:
                            _transportManagementService.GetAllTripsDetails();
                            break;

                        case 0:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }

            }

            Console.WriteLine("Thank you for using the Transport Management System!");
        }
        public void AdminRun()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to the Transport Management System");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Delete Vehicle");
                Console.WriteLine("3. Allocate Driver");
                Console.WriteLine("4. Deallocate Driver");
                Console.WriteLine("5. Get all Vehicle Details");
                Console.WriteLine("6. Get all Driver Details");

                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                int input = int.Parse(Console.ReadLine());
                {
                    switch (input)
                    {
                        case 1:
                            List<Vehicles> v = _transportManagementService.GetAllVehicleDetails();
                            Vehicles vehicle = _userInput.VehicleInput();
                            bool result1 = _transportManagementService.AddVehicle(vehicle);
                            if (result1)
                            {
                                Console.WriteLine("Vehicle added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to add the vehicle.");
                            }
                            break;

                        case 2:
                            List<Vehicles> v1 = _transportManagementService.GetAllVehicleDetails();
                            int VehicleID = _userInput.VehicleIDInput();
                            try
                            {
                                bool result2 = _transportManagementService.DeleteVehicle(VehicleID);
                                if (result2)
                                {
                                    Console.WriteLine("Vehicle added successfully.");
                                }
                            }
                            catch (VehicleNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 3:
                            List<Drivers> d = _transportManagementService.GetAllDriversDetails();
                            List<Trips> t = _transportManagementService.GetAllTripsDetails();
                            int driverID = _userInput.DriverIDInput();
                            int tripID3 = _userInput.TripIDInput();
                            bool result7 = _transportManagementService.AllocateDriver(driverID, tripID3);
                            if (result7)
                            {
                                Console.WriteLine($"Driver with Driver ID {driverID} successfully allocated to the trip {tripID3}");
                            }
                            break;

                        case 4:
                            List<Drivers> d1 = _transportManagementService.GetAllDriversDetails();
                            int driverID1 = _userInput.DriverIDInput();
                            bool result8 = _transportManagementService.DeAllocateDriver(driverID1);
                            if (result8)
                            {
                                Console.WriteLine($"The driver with DriverID {driverID1} Deallocated Successfully");
                            }
                            break;
                        case 5:
                            _transportManagementService.GetAllVehicleDetails();
                            break;
                        case 6:
                            _transportManagementService.GetAllDriversDetails();
                            break;


                        case 0:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
            }
        }

    }
}
