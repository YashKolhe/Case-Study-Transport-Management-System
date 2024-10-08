using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementApp.Model
{
    public class Passengers
    {
        private int passengerID;
        public int PassengerID { get { return passengerID; } set { passengerID = value; } }
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private string gender;
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public Passengers() { }
        public Passengers(int passengerID, string firstName, string gender, int age, string email, string phoneNumber)
        {
            this.passengerID = passengerID;
            this.firstName = firstName;
            this.gender = gender;
            this.age = age;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }
        public override string ToString()
        {
            return $"Passenger ID : {passengerID}\t First Name : {firstName}\t Gender : {gender}\t Age : {age}\t Email : {email}\t Phone Number : {phoneNumber}";
        }
    }
}
