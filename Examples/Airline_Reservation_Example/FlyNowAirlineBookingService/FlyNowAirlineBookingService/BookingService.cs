using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FlyNowAirlineBookingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class BookingService : IBookingService
    {
        string path = @"C:\tempfiles\AirlineReservation";

                
        public FlightInfo GetFlightInfo(BookingInfo bookingInfo)
        {

            FlightInfo flightInfo = new FlightInfo();

            //this is dummy data. In real scenario, the data will come from database.
            if (bookingInfo.DepartureLocation == "New York" && bookingInfo.Destination == "London")
            {

                flightInfo.DepartureLocation = "New York";
                flightInfo.Destination = "London";

                flightInfo.DepartureDateandTime = new DateTime(2012, 4, 15, 7, 30, 0);
                flightInfo.ArrivalDateandTimeDest = new DateTime(2012, 4, 15, 11, 0, 0);
                flightInfo.FlightNumberLeave = "NY0723";

                flightInfo.ReturnDateandTime = new DateTime(2012, 4, 20, 10, 0, 0);
                flightInfo.ArrivalDateandTimeBack = new DateTime(2012, 4, 20, 13, 30, 0);
                flightInfo.FlightNumberReturn = "NY0582";

                flightInfo.Status = "Available";
                flightInfo.Fare = 575.0f;

                flightInfo.Seats = new string[] { "12B", "14C" };

            }

            return flightInfo;
        }

        public string BookFlight(FlightInfo flightInfo, PassengerInfo passengerInfo, BookingInfo bookingInfo)
        {

            //create barcodes for departure and arrival
            BarCode barcode = new BarCode(path);
            string barcodeFileLeave = barcode.CreateBarCode(flightInfo.FlightNumberLeave + passengerInfo.SeatNumber, false);
            string barcodeFileReturn = barcode.CreateBarCode(flightInfo.FlightNumberReturn + passengerInfo.SeatNumber, true);


            //based on flightinfo and passengerinfo create PDF ticket
            Aspose.Pdf.Generator.Pdf pdf;
            Ticket ticket = new Ticket(path);
            pdf = ticket.GetTicket(passengerInfo,flightInfo, bookingInfo);
            string fileName = "Ticket_" + flightInfo.DepartureLocation + "_" + flightInfo.Destination + ".pdf";
            pdf.Save(path + "\\" + fileName);
           
                      
            //send email to passenger at his/her email address
            Email email = new Email(path);
            string messageBody = "Hi " + passengerInfo.Name  + ",<br/>";
            messageBody += "Please find attached your ticket for " + flightInfo.DepartureLocation + " to " + flightInfo.Destination + "<br/><br/>";
            messageBody += "Thank you for traveling with FlyNow Airline.<br/>";
            email.SendEmail(passengerInfo.Name, passengerInfo.Email, "Ticket " + flightInfo.DepartureLocation + " to " + flightInfo.Destination, messageBody, path + "\\" + fileName);


            //if everything successful send a success message else sorry message and try again message. 
            return "Booking successful. Ticket is sent via email";
        }

        
    }
}
