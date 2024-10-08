using TransportManagementApp.Model;
using TransportManagementApp.Repository;
using NUnit.Framework;
using TransportManagementApp.Exceptions;

namespace TransportTest
{
    public class Tests
    {
        //[SetUp]


        [Test]
        public void Test_To_Book_Trip()
        {
            TransportManagementService TMTest = new TransportManagementServiceImpl();
            int tripID = 2;
            int passengerID = 5;
            
            bool bookTripStatus = TMTest.BookTrip(tripID,passengerID);
            Assert.That(bookTripStatus, Is.True, "Trip Booked Successfully");

        }

        [Test]
        public void GetBookingsByPassenger_Throws_Exception()
        {

            TransportManagementService TMTest = new TransportManagementServiceImpl();
            int passengerID = 13; 

            var ex = Assert.Throws<BookingNotFoundException>(() => TMTest.GetBookingsByPassenger(passengerID));
            Assert.That(ex.Message, Is.EqualTo($"No bookings found for Passenger ID: {passengerID}"));
        }
        [Test]
        public void GetBookingsByTrip_Throws_Exception()
        {

            TransportManagementService TMTest = new TransportManagementServiceImpl();
            int tripID = 21;

            var ex = Assert.Throws<BookingNotFoundException>(() => TMTest.GetBookingsByTrip(tripID));
            Assert.That(ex.Message, Is.EqualTo($"No bookings found for Trip ID: {tripID}"));
        }
        [Test]
        public void DeleteVehicle_Throws_Exception()
        {

            TransportManagementService TMTest = new TransportManagementServiceImpl();
            int vehicleID = 14;

            var ex = Assert.Throws<VehicleNotFoundException>(() => TMTest.DeleteVehicle(vehicleID));
            Assert.That(ex.Message, Is.EqualTo($"Vehicle with ID {vehicleID} not found."));
        }
    }
}