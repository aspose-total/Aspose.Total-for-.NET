using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FlyNowAirlineBookingService
{

    //booking service interface
    [ServiceContract]
    public interface IBookingService
    {
        [OperationContract]
        FlightInfo GetFlightInfo(BookingInfo bookingInfo);

        [OperationContract]
        string BookFlight(FlightInfo flightInfo, PassengerInfo passengerInfo, BookingInfo bookingInfo);


    
    }

    //booking service data contracts
    [DataContract]
    public class BookingInfo
    {
        string departureLocation = "";
        DateTime departureDate = DateTime.MinValue;
        string destination = "";
        DateTime returnDate = DateTime.MinValue;

        [DataMember]
        public string DepartureLocation
        {
            get { return departureLocation; }
            set { departureLocation = value; }
        }

        [DataMember]
        public DateTime DepartureDate
        {
            get { return departureDate; }
            set { departureDate = value; }
        }

        [DataMember]
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        [DataMember]
        public DateTime ReturnDate
        {
            get { return returnDate; }
            set { returnDate = value; }
        }

    }
    
    [DataContract]
    public class FlightInfo
    {
        string departureLocation = "";
        string destination = "";

        DateTime departureDateandTime = DateTime.MinValue;
        DateTime arrivalDateandTimeDest = DateTime.MinValue;
        string flightNumberLeave = "";

        DateTime returnDateandTime = DateTime.MinValue;
        DateTime arrivalDateandTimeBack = DateTime.MinValue;
        string flightNumberReturn = "";

        string status = "";
        float fare = float.MinValue;

        string[] seats = { };

        [DataMember]
        public string DepartureLocation
        {
            get { return departureLocation; }
            set { departureLocation = value; }
        }

        [DataMember]
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        [DataMember]
        public DateTime DepartureDateandTime
        {
            get { return departureDateandTime; }
            set { departureDateandTime = value; }
        }

        [DataMember]
        public DateTime ArrivalDateandTimeDest
        {
            get { return arrivalDateandTimeDest; }
            set { arrivalDateandTimeDest = value; }
        }

        [DataMember]
        public string FlightNumberLeave
        {
            get { return flightNumberLeave; }
            set { flightNumberLeave = value; }
        }

        [DataMember]
        public DateTime ReturnDateandTime
        {
            get { return returnDateandTime; }
            set { returnDateandTime = value; }
        }

        [DataMember]
        public DateTime ArrivalDateandTimeBack
        {
            get { return arrivalDateandTimeBack; }
            set { arrivalDateandTimeBack = value; }
        }

        [DataMember]
        public string FlightNumberReturn
        {
            get { return flightNumberReturn; }
            set { flightNumberReturn = value; }
        }

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember]
        public float Fare
        {
            get { return fare; }
            set { fare = value; }
        }

        [DataMember]
        public string[] Seats
        {
            get { return seats; }
            set { seats = value; }
        }

    }

    [DataContract]
    public class PassengerInfo
    {

        string name = "";
        string address = "";
        string email = "";
        string phoneNumber = "";
        string seatNumber = "";

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        [DataMember]
        public string SeatNumber
        {
            get { return seatNumber; }
            set { seatNumber = value; }
        }

    }

}
