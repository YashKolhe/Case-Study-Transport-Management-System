using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementApp.Model
{
    public class Bookings
    {
        private int bookingID;
        public int BookingID
        {
            get { return bookingID; }
            set { bookingID = value; }
        }
        private int passengerID;
        public int PassengerID
        {
            get { return passengerID; }
            set { passengerID = value; }
        }
        private int tripID;
        public int TripID
        {
            get { return tripID; }
            set { tripID = value; }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        private DateTime bookingDate;
        public DateTime BookingDate
        {
            get { return bookingDate; }
            set { bookingDate = value; }
        }
        public Bookings() { }
        public Bookings(int bookingID, int passengerID, int tripID, string status, DateTime bookingDate)
        {
            this.bookingID = bookingID;
            this.passengerID = passengerID;
            this.tripID = tripID;
            this.status = status;
            this.bookingDate = bookingDate;
        }
        public  override string ToString()
        {
            return $"Booking ID : {bookingID}\t Passenger ID : {passengerID}\t Trip ID : {tripID}\t Status : {status}\t Booking Date : {bookingDate}";
        }
    }
}
