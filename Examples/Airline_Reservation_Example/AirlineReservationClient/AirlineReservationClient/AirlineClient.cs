using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AirlineReservationClient
{
    public partial class AirlineClient : Form
    {
        //local variables
        string path = @"C:\tempfiles\AirlineReservation";
        FlyNowAirline.BookingServiceClient bookingService = new FlyNowAirline.BookingServiceClient();
        FlyNowAirline.FlightInfo flightInfo;
        FlyNowAirline.PassengerInfo passengerInfo;
        FlyNowAirline.BookingInfo bookingInfo;


        public AirlineClient()
        {
            InitializeComponent();
            
        }


        private void cmdExit_Click(object sender, EventArgs e)
        {
            //exit application
            Application.Exit();
        }

        private void cmdReserveSeat_Click(object sender, EventArgs e)
        {
            //reserve seat and update the customer
            string strName = txtName.Text.Trim();
            string strAddress = txtAddress.Text.Trim();
            string strEmail = txtEmail.Text.Trim();
            string strPhoneNumber = txtPhoneNumber.Text.Trim();
            string strSeatNumbers = txtSeatNumbers.Text.Trim();

            passengerInfo = new FlyNowAirline.PassengerInfo();
            //set passenger info
            passengerInfo.Name = strName;
            passengerInfo.Email = strEmail;
            passengerInfo.Address = strAddress;
            passengerInfo.PhoneNumber = strPhoneNumber;
            passengerInfo.SeatNumber = strSeatNumbers;

            bookingService.BookFlight(flightInfo, passengerInfo, bookingInfo);
            

            lblMessage.Text = "Your seat has been reserved and your ticket is sent at your email address";

            //generate an invoice to be printed for the customer
            Aspose.Pdf.Generator.Pdf pdf;
            Invoice invoice = new Invoice(path);
            pdf = invoice.GetInvoice(flightInfo, passengerInfo, bookingInfo);
            pdf.Save(path + "\\invoice.pdf");

        }

        private void cmdFindFlight_Click(object sender, EventArgs e)
        {
            //send reservation infomation and get flight information
            string departureLocation = txtDeparture.Text.Trim();
            string destinationLocation = txtDestination.Text.Trim();
            DateTime departureDate = dtDepartureDate.Value.Date;

            //create BookingInfo object 
            bookingInfo = new FlyNowAirline.BookingInfo();
            bookingInfo.DepartureLocation = departureLocation;
            bookingInfo.Destination = destinationLocation;
            bookingInfo.DepartureDate = departureDate;

            //get flight info
           flightInfo = bookingService.GetFlightInfo(bookingInfo);

            //set returned values to labels
            string strDepartureDateandTime = flightInfo.DepartureDateandTime.ToString();
            string strArrivalDateandTime = flightInfo.ArrivalDateandTimeDest.ToString();
            string strReturnDateandTime = flightInfo.ReturnDateandTime.ToString();
            string strArrivalDateandTimeReturn = flightInfo.ArrivalDateandTimeBack.ToString();
            string strStatus = flightInfo.Status;
            string strSeats = string.Join(",", flightInfo.Seats);
            string strFare = flightInfo.Fare.ToString();

            //set label values
            lblDepartureDateandTime.Text = strDepartureDateandTime;
            lblArrivalDateandTime.Text = strArrivalDateandTime;
            lblReturnDateandTime.Text = strReturnDateandTime;
            lblArrivalDateandTimeReturn.Text = strArrivalDateandTimeReturn;
            lblStatus.Text = strStatus;
            lblSeats.Text = strSeats;
            lblFare.Text = "$" + strFare;

        }

        private void cmdPrintInvoice_Click(object sender, EventArgs e)
        {
            //print invoice
            string invoicePath = path + "\\invoice.pdf";
            Printer printer = new Printer(invoicePath);
            printer.Print(true, "");

            lblMessage.Text = "The invoice is sent to the default printer";
        }

        private void AirlineClient_Load(object sender, EventArgs e)
        {
            //set license from file or embedded resource
            Aspose.Pdf.License pdfLicense = new Aspose.Pdf.License();
            pdfLicense.SetLicense(@"c:\tempfiles\Aspose.Total.lic");


        }


      
    }
}
