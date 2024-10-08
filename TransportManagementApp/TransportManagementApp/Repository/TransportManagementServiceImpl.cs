using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TransportManagementApp.Exceptions;
using TransportManagementApp.Model;
using TransportManagementApp.Utility;

namespace TransportManagementApp.Repository
{
    public class TransportManagementServiceImpl:TransportManagementService
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public TransportManagementServiceImpl()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnString());
            cmd = new SqlCommand();
        }
        //public bool SignIn(string eMail)
        //{

        //    using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString()))
        //    {
        //        cmd.CommandText = "Select Email from Passenger where Email = @eMail";

        //        cmd.Parameters.AddWithValue("@eMail", eMail);

        //        sqlConnection.Open();
        //       int count = (int)cmd.ExecuteScalar();
        //        sqlConnection.Close();
        //        return true;

        //    }
        //}
        public bool AddVehicle(Vehicles vehicle)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Insert Into Vehicle values(@Model,@Capacity,@Type,@Status)";
                cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                cmd.Parameters.AddWithValue("@Capacity", vehicle.Capacity);
                cmd.Parameters.AddWithValue("@Type", vehicle.Type);
                cmd.Parameters.AddWithValue("@Status", vehicle.Status);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int addVehicleStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                Console.WriteLine("Adding the Vehicle...");
                return addVehicleStatus > 0;
            }
        }
        public bool DeleteVehicle(int vehicleID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Delete from Vehicle where vehicleId = @vehicleID";
                cmd.Parameters.AddWithValue("@vehicleId", vehicleID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int deleteVehicleStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                if (deleteVehicleStatus == 0)
                {
                    throw new VehicleNotFoundException($"Vehicle with ID {vehicleID} not found.");
                }
                return deleteVehicleStatus > 0;
            }
        }
        public bool UpdateVehicle(string fieldName, object? newValue, int vehicleID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = $"Update Vehicle set {fieldName} = @newValue where vehicleId = @vehicleID";
                cmd.Parameters.AddWithValue("@vehicleID", vehicleID);
                cmd.Parameters.AddWithValue("@newValue", newValue);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int updateStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return updateStatus > 0;
            }
        }
        public bool ScheduleTrip(int vehicleID, int routeID, DateTime departureDate, DateTime arrivalDate)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Insert into Trip(VehicleID, RouteID, DepartureDate,ArrivalDate,Status) values(@vehicleID, @routeID, @departureDate, @arrivalDate,@Status)";
                string Status = "Scheduled";
                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);
                cmd.Parameters.AddWithValue("@RouteID", routeID);
                cmd.Parameters.AddWithValue("@DepartureDate", departureDate);
                cmd.Parameters.AddWithValue("@ArrivalDate", arrivalDate);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int tripStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return tripStatus > 0;
            }

        }
        public bool CancelTrip(int tripID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Update Trip set Status = 'Cancelled' where TripID = @tripID";
                cmd.Parameters.AddWithValue("@TripID", tripID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int tripStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return tripStatus > 0;
            }

        }
        public bool BookTrip( int tripID, int passengerID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Insert into Booking(TripID,PassengerID,BookingDate,Status) values(@tripID,@passengerID,@bookingDate,@Status)";
                string Status = "Confirmed";
                DateTime bookingDate = DateTime.Now;
                cmd.Parameters.AddWithValue("@tripID", tripID);
                cmd.Parameters.AddWithValue("@passengerID", passengerID);
                cmd.Parameters.AddWithValue("@bookingDate", bookingDate);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int tripStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return tripStatus > 0;
            }

        }

            public bool CancelBooking(int bookingID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Update Booking set Status = 'Cancelled' where BookingID = @bookingID";
                cmd.Parameters.AddWithValue("@BookingID", bookingID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int bookingStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                if (bookingStatus == 0)
                {
                    throw new BookingNotFoundException($"Booking with ID {bookingID} not found.");
                }
                return bookingStatus > 0;
            }


        }
        public bool AllocateDriver( int driverID, int tripID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Update Driver set TripID = @tripID";
                cmd.Parameters.AddWithValue("@tripID", tripID);
                cmd.Parameters.AddWithValue("@driverID", driverID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int allocatingDriver = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                
                return allocatingDriver > 0;


            }

        }
        public bool DeAllocateDriver(int driverID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Update Driver set TripID = null where DriverID = @driverID1";
                cmd.Parameters.AddWithValue("@driverID1", driverID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int deAllocatingDriver = cmd.ExecuteNonQuery();
        sqlConnection.Close();
                
                return deAllocatingDriver > 0;


            }

    }
    public List<Bookings> GetBookingsByPassenger(int passengerID)
        {
            List<Bookings> bookings = new List<Bookings>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Select * from Booking where PassengerID = @passengerID1";
                cmd.Parameters.AddWithValue("@passengerID1", passengerID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bookings bookingsByPassenger = new Bookings();
                    bookingsByPassenger.BookingID = reader["BookingID"] != DBNull.Value ? Convert.ToInt32(reader["BookingID"]) : -1;
                    bookingsByPassenger.TripID = reader["TripID"] != DBNull.Value ? Convert.ToInt32(reader["TripID"]) : -1;
                    bookingsByPassenger.PassengerID = reader["PassengerID"] != DBNull.Value ? Convert.ToInt32(reader["PassengerID"]) : -1;
                    bookingsByPassenger.BookingDate = reader["BookingDate"] != DBNull.Value ? (DateTime)reader["BookingDate"] : DateTime.MinValue;
                    bookingsByPassenger.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : null;

                    bookings.Add(bookingsByPassenger);
                }
                sqlConnection.Close();
            }
            if (bookings.Count == 0)
            {
                throw new BookingNotFoundException($"No bookings found for Passenger ID: {passengerID}");

            }
            foreach (Bookings item in bookings)
            {
                Console.WriteLine(item.ToString());
            }
            return bookings;

        }

        public List<Bookings> GetBookingsByTrip(int tripID)
        {
            List<Bookings> booking = new List<Bookings>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Select * from Booking where TripID = @tripID1";
                cmd.Parameters.AddWithValue("@tripID1", tripID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bookings bookingsByTrip = new Bookings();
                    bookingsByTrip.BookingID = reader["BookingID"] != DBNull.Value ? Convert.ToInt32(reader["BookingID"]) : -1;
                    bookingsByTrip.TripID = reader["TripID"] != DBNull.Value ? Convert.ToInt32(reader["TripID"]) : -1;
                    bookingsByTrip.PassengerID = reader["PassengerID"] != DBNull.Value ? Convert.ToInt32(reader["PassengerID"]) : -1;
                    bookingsByTrip.BookingDate = reader["BookingDate"] != DBNull.Value ? (DateTime)reader["BookingDate"] : DateTime.MinValue;
                    bookingsByTrip.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : null;

                    booking.Add(bookingsByTrip);
                }
                sqlConnection.Close();
            }
            if (booking.Count == 0)
            {
                throw new BookingNotFoundException($"No bookings found for Trip ID: {tripID}");
            }
            foreach(Bookings item in booking)
            {
                Console.WriteLine(item.ToString());
            }
            return booking;
        }

        public List<Drivers> GetAvailableDrivers()
        {
            List<Drivers> drivers = new List<Drivers>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;
            {
                cmd.CommandText = "Select * from Driver where TripID is null";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Drivers driver = new Drivers();
                    driver.DriverID = reader["DriverID"] != DBNull.Value ? Convert.ToInt32(reader["DriverID"]) : -1;
                    driver.TripID = reader["TripID"] != DBNull.Value ? Convert.ToInt32(reader["TripID"]) : -1;
                    driver.Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : null;

                    drivers.Add(driver);
                }
                sqlConnection.Close();
            }
            foreach (Drivers item in drivers)
            {
                Console.WriteLine(item.ToString());
            }
            return drivers;
        }
        public List<Vehicles> GetAllVehicleDetails()
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;

            {
                List<Vehicles> allVehicles = new List<Vehicles>();
                cmd.CommandText = "select * from Vehicle";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicles v1 = new Vehicles();
                    v1.VehicleID = reader["vehicleId"] != DBNull.Value ? Convert.ToInt32(reader["vehicleId"]) : -1;
                    v1.Model = reader["Model"] != DBNull.Value ? reader["Model"].ToString() : null;
                    v1.Capacity = (decimal)reader["Capacity"];
                    v1.Type = reader["Type"] != DBNull.Value ? reader["Type"].ToString() : null;
                    v1.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : null;

                    allVehicles.Add(v1);
                }
                sqlConnection.Close();
                Console.WriteLine("--------------- VEHICLES ---------------------");

                foreach (Vehicles item in allVehicles)
                {
                    Console.WriteLine(item.ToString());
                }
                return allVehicles;

            }
        }

        public List<Bookings> GetAllBookingsDetails()
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;

            {
                List<Bookings> allBookings = new List<Bookings>();
                cmd.CommandText = "select * from Booking";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bookings b1 = new Bookings();
                    b1.BookingID = reader["BookingID"] != DBNull.Value ? Convert.ToInt32(reader["BookingID"]) : -1;
                    b1.PassengerID = reader["PassengerID"] != DBNull.Value ? Convert.ToInt32(reader["PassengerID"]) : -1;
                    b1.TripID = reader["TripID"] != DBNull.Value ? Convert.ToInt32(reader["TripID"]) : -1;
                    b1.BookingDate = reader["BookingDate"] != DBNull.Value ? (DateTime)reader["BookingDate"]: DateTime.MinValue;
                    b1.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : null;

                    allBookings.Add(b1);
                }
                sqlConnection.Close();
                Console.WriteLine("--------------- BOOKINGS ---------------------");

                foreach (Bookings item in allBookings)
                {
                    Console.WriteLine(item.ToString());
                }
                return allBookings;
            }

        }
        public List<Passengers> GetAllPassengersDetails()
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;

            {
                List<Passengers> allPassengers = new List<Passengers>();
                cmd.CommandText = "select * from Passenger";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Passengers p1 = new Passengers();
                    p1.PassengerID = reader["PassengerID"] != DBNull.Value ? Convert.ToInt32(reader["PassengerID"]) : -1;
                    p1.FirstName = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : null;
                    p1.Gender = reader["gender"] != DBNull.Value ? reader["gender"].ToString() : null;
                    p1.Age = reader["age"] != DBNull.Value ? Convert.ToInt32(reader["age"]) : -1;
                    p1.Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null;
                    p1.PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : null;
                    allPassengers.Add(p1);
                }
                sqlConnection.Close();
                Console.WriteLine("--------------- PASSENGERS ---------------------");

                foreach (Passengers item in allPassengers)
                {
                    Console.WriteLine(item.ToString());
                }
                return allPassengers;
            }

        }
        public List<Routes> GetAllRoutesDetails()
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;

            {
                List<Routes> allRoutes = new List<Routes>();
                cmd.CommandText = "select * from Route";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Routes r1 = new Routes();
                    r1.RouteID = reader["RouteID"] != DBNull.Value ? Convert.ToInt32(reader["RouteID"]) : -1; 
                    r1.StartDestination = reader["StartDestination"] != DBNull.Value ? reader["StartDestination"].ToString() : null;
                    r1.EndDestination = reader["EndDestination"] != DBNull.Value ? reader["EndDestination"].ToString() : null;
                    r1.Distance = reader["Distance"] != DBNull.Value ? (decimal)reader["Distance"]:-1 ;
                    allRoutes.Add(r1);
                }
                sqlConnection.Close();
                Console.WriteLine("--------------- ROUTES ---------------------");

                foreach (Routes item in allRoutes)
                {
                    Console.WriteLine(item.ToString());
                }
                return allRoutes;
            }

        }
        public List<Trips> GetAllTripsDetails()
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;

            {
                List<Trips> allTrips = new List<Trips>();
                cmd.CommandText = "select * from Trip";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Trips t1 = new Trips();
                    t1.TripID = reader["TripID"] != DBNull.Value ? Convert.ToInt32(reader["TripID"]) : -1;
                    t1.VehicleID = reader["VehicleID"] != DBNull.Value ? Convert.ToInt32(reader["VehicleID"]) : -1;
                    t1.RouteID = reader["RouteID"] != DBNull.Value ? Convert.ToInt32(reader["RouteID"]) : -1;
                    t1.DepartureDate = reader["DepartureDate"] != DBNull.Value ? (DateTime)reader["DepartureDate"] : DateTime.MinValue;
                    t1.ArrivalDate = reader["ArrivalDate"] != DBNull.Value ? (DateTime)reader["ArrivalDate"] : DateTime.MinValue;
                    t1.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : null; 
                    t1.TripType = reader["TripType"] != DBNull.Value ? reader["TripType"].ToString() : null; 
                    t1.MaxPassengers = reader["MaxPassengers"] != DBNull.Value ? Convert.ToInt32(reader["MaxPassengers"]) : -1;
                    allTrips.Add(t1);
                }
                sqlConnection.Close();
                Console.WriteLine("--------------- TRIPS ---------------------");

                foreach (Trips item in allTrips)
                {
                    Console.WriteLine(item.ToString());
                }
                return allTrips;
            }

        }
        public List<Drivers> GetAllDriversDetails()
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConnUtil.GetConnString())) ;

            {
                List<Drivers> allDrivers = new List<Drivers>();
                cmd.CommandText = "select * from Driver";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Drivers d1 = new Drivers();

                    d1.DriverID = reader["DriverID"] != DBNull.Value ? Convert.ToInt32(reader["DriverID"]) : -1; 
                    d1.TripID = reader["TripID"] !=DBNull.Value ? Convert.ToInt32(reader["TripID"]):-1;
                    d1.Name = reader["Name"] !=DBNull.Value ? reader["Name"].ToString() : null; 
                    allDrivers.Add(d1);
                }
                sqlConnection.Close();
                Console.WriteLine("--------------- DRIVERS ---------------------");

                foreach (Drivers item in allDrivers)
                {
                    Console.WriteLine(item.ToString());
                }
                return allDrivers;
            }

        }
    }
}
