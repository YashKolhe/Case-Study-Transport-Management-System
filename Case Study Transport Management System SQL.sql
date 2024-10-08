create database Transport_Management_System
use Transport_Management_System

create table Vehicles1 
(vehicleId INT IDENTITY(1,1) PRIMARY KEY,
 Model VARCHAR(255), 
 Capacity DECIMAL(10, 2), 
 Type VARCHAR(50) check(type in( 'Truck', 'Van', 'Bus') ), 
 Status VARCHAR(50) check(status in('Available','On Trip','Maintenance') ) )

 insert into Vehicles1
 values
 ('Tata', 1000.00, 'Truck', 'Available'),
('Toyota', 3000.00, 'Van', 'On Trip'),
('School Bus', 15000.00, 'Bus', 'Maintenance'),
('Mahindra', 1200.00, 'Truck', 'Available'),
('Suzuki', 1500.00, 'Van', 'Maintenance'),
('Volvo', 1250.00, 'Bus', 'Available'),
('Alto', 3500.00, 'Van', 'On Trip'),
('Himalayas', 20000.00, 'Bus', 'Available')
select* from Vehicles1

 create table Routes 
 (RouteID INT identity(1,1) PRIMARY KEY ,
 StartDestination VARCHAR(255) ,
 EndDestination VARCHAR(255) ,
 Distance DECIMAL(10, 2) )

 insert into Routes 
 values
 ('Mumbai', 'Goa', 445.00),
('Delhi', 'Manali', 680.00),
('Ladakh', 'Chennai', 2800.00),
('Goa', 'Kashmir', 2230.00),
('Ladakh', 'Mumbai', 2000.00),
('Delhi', 'kashmir', 395.00),
('Goa', 'Mumbai', 445.00),
('Mumbai', 'Delhi', 800.00)
select* from Routes 


 create table Trips1 
 (TripID INT identity(1,1) PRIMARY KEY, 
 VehicleID INT FOREIGN KEY REFERENCES Vehicles1(VehicleID), 
 RouteID INT FOREIGN KEY REFERENCES Routes(RouteID) ,
 DepartureDate DATETIME ,
 ArrivalDate DATETIME ,
 Status VARCHAR(50) check(status in ('Scheduled', 'In_Progress', 'Completed', 'Cancelled')), 
 TripType VARCHAR(50)DEFAULT 'Freight' check(triptype in ( 'Passenger', 'Freight')), 
 MaxPassengers INT)

 insert into Trips1
 values
 (1, 1, '2024-09-25', '2024-09-26', 'Scheduled', 'Freight', 2),
(2, 2, '2024-09-04', '2024-09-04', 'In_Progress', 'Passenger', 10),
(3, 3, '2022-09-23', '2022-09-23', 'Completed', 'Passenger', 20),
(4, 4, '2025-09-22', '2025-09-22', 'Scheduled', 'Freight', 3),
(5, 5, '2021-09-21', '2021-09-21', 'Cancelled', 'Passenger', 8),
(6, 6, '2021-09-04', '2021-09-04', 'In_Progress', 'Passenger', 19),
(7, 7, '2025-09-09', '2025-09-12', 'Scheduled', 'Freight', 12),
(8, 8, '2024-09-21', '2024-09-28', 'Scheduled', 'Freight', 6)
select* from Trips1

 create table Passengers 
 (PassengerID INT identity(1,1) PRIMARY KEY, 
 FirstName VARCHAR(255) ,
 gender VARCHAR(255) ,
 age INT ,
 Email VARCHAR(255) UNIQUE, 
 PhoneNumber VARCHAR(50)) 

 insert into Passengers
 values
 ('Virat', 'Male', 30, 'virat@example.com', '4444444444'),
('Smriti', 'Female', 25, 'smriti@example.com', '2222222222'),
('Sachin', 'Male', 35, 'sachin@example.com', '3333333333'),
('Shafali', 'Female', 28, 'shafali@example.com', '6666666666'),
('Rohit', 'Male', 40, 'rohit@example.com', '1111111111'),
('Rahul', 'Male', 40, 'rahul@example.com', '5555555555'),
('Priya', 'female', 40, 'priya@example.com', '7777777777'),
('Akash', 'Male', 40, 'akash@example.com', '8888888888')
select * from Passengers

 create table Bookings1  
 (BookingID INT identity(1,1) PRIMARY KEY, 
 TripID INT FOREIGN KEY REFERENCES Trips1 (TripID), 
 PassengerID INT FOREIGN KEY REFERENCES Passengers (PassengerID), 
 BookingDate DATETIME ,
 Status VARCHAR (50) check(status in ( 'Confirmed', 'Cancelled', 'Completed'))) 

 INSERT INTO Bookings1 (TripID, PassengerID, BookingDate, Status) VALUES
(1, 7, '2024-09-20 14:30:00', 'Confirmed'),
(1, 8, '2024-09-21 09:15:00', 'Confirmed'), 
(2, 9, '2024-09-03 10:00:00', 'Cancelled'),  
(3, 10, '2022-09-20 08:45:00', 'Completed'),
(4, 11, '2025-09-20 11:00:00', 'Confirmed'),  
(5, 12, '2021-09-20 16:30:00', 'Cancelled'), 
(6, 13, '2021-09-03 09:00:00', 'Confirmed'),  
(7, 14, '2025-09-08 14:00:00', 'Completed')


