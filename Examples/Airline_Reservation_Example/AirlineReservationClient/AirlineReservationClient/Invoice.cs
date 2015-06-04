using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

using Aspose.Pdf.Generator;
using AirlineReservationClient.FlyNowAirline;

namespace AirlineReservationClient
{

    //creates invoice
    public class Invoice
    {

        string path;
        System.Globalization.CultureInfo locale = new System.Globalization.CultureInfo("en-US");

        public Invoice(string curPath)
        {
            path = curPath;

        }

        public Aspose.Pdf.Generator.Pdf GetInvoice(FlightInfo flightInfo, PassengerInfo passengerInfo, BookingInfo bookingInfo)
        {
            //create a Pdf object
            Aspose.Pdf.Generator.Pdf pdf = new Aspose.Pdf.Generator.Pdf();
            pdf.IsTruetypeFontMapCached = false;

            //bind XML file
            string xmlFile = path + "\\Invoice.xml";
            pdf.BindXML(xmlFile, null);

            //create header
            HeaderFooter headerFooter = pdf.Sections[0].OddHeader;
            Image logoImage = (Image)headerFooter.Paragraphs[0];
            logoImage.ImageInfo.File = path + "\\flynowairlinelogoandinvoice.jpg";
            logoImage.ImageScale = 0.74F;

            //call the method to create invoice
            PutOrder(pdf, flightInfo, passengerInfo, bookingInfo);

            return pdf;
        }

        private void PutOrder(Aspose.Pdf.Generator.Pdf pdf, FlightInfo flightInfo, PassengerInfo passengerInfo, BookingInfo bookingInfo)
        {

            //add customer address at the top       
            PutAdress(pdf, passengerInfo);
            //add order summary
            PutSummary(pdf, passengerInfo, flightInfo);
            //create a table and add order details in row(s)
            Table table = AddTable(pdf);
            AddRow(pdf, table, flightInfo);
            PutAmount(pdf, flightInfo.Fare, 0);
           

        }

        private void PutAdress(Aspose.Pdf.Generator.Pdf pdf, PassengerInfo passengerInfo)
        {
            //create table to add address of the customer
            Table adressTable = new Table();
            adressTable.IsFirstParagraph = true;
            adressTable.ColumnWidths = "60 180 60 180";
            adressTable.DefaultCellTextInfo.FontSize = 10;
            adressTable.DefaultCellTextInfo.LineSpacing = 3;
            adressTable.DefaultCellPadding.Bottom = 3;
            //add this table in the first section/page
            Section section = pdf.Sections[0];
            section.Paragraphs.Add(adressTable);
            //add a new row in the table
            Row row1AdressTable = new Row(adressTable);
            adressTable.Rows.Add(row1AdressTable);
            //add cells and text
            Aspose.Pdf.Generator.TextInfo tf1 = new Aspose.Pdf.Generator.TextInfo();
            tf1.Color = new Aspose.Pdf.Generator.Color(111, 146, 188);
            tf1.FontName = "Helvetica-Bold";

            row1AdressTable.Cells.Add("Bill To:", tf1);
            row1AdressTable.Cells.Add(passengerInfo.Name + "#$NL" +
                passengerInfo.Address + "#$NL" + passengerInfo.Email + "#$NL" +
                passengerInfo.PhoneNumber);

        }

        private void PutSummary(Aspose.Pdf.Generator.Pdf pdf, PassengerInfo passengerInfo, FlightInfo flightInfo)
        {
            //create a  table to hold summary of the order
            Table summaryTable = new Table();
            Aspose.Pdf.Generator.Color color = new Aspose.Pdf.Generator.Color(111, 146, 188);
            summaryTable.Margin.Top = 20;
            summaryTable.ColumnWidths = "60 80 80 80 80 80";
            summaryTable.DefaultCellTextInfo.FontSize = 10;
            summaryTable.DefaultCellBorder = new BorderInfo((int)BorderSide.All, color);
            summaryTable.DefaultCellPadding.Bottom = summaryTable.DefaultCellPadding.Top = 3;
            //add table to the first section/page
            Section section = pdf.Sections[0];
            section.Paragraphs.Add(summaryTable);
            //create row and add cells and contents
            Row row1SummaryTable = summaryTable.Rows.Add();

            Aspose.Pdf.Generator.TextInfo tf1 = new Aspose.Pdf.Generator.TextInfo();
            tf1.FontSize = 10;
            tf1.Color = new Aspose.Pdf.Generator.Color("White");
            tf1.FontName = "Helvetica-Bold";
            tf1.Alignment = AlignmentType.Center;
            Cell cell1Row1SummaryTable = row1SummaryTable.Cells.Add("Order ID", tf1);
            cell1Row1SummaryTable.BackgroundColor = color;

            Cell cell2Row1SummaryTable = row1SummaryTable.Cells.Add("Customer ID", tf1);
            cell2Row1SummaryTable.BackgroundColor = color;

            Cell cell3Row1SummaryTable = row1SummaryTable.Cells.Add("Agent ID", tf1);
            cell3Row1SummaryTable.BackgroundColor = color;

            Cell cell4Row1SummaryTable = row1SummaryTable.Cells.Add("Sales Person", tf1);
            cell4Row1SummaryTable.BackgroundColor = color;

            Cell cell5Row1SummaryTable = row1SummaryTable.Cells.Add("Required Date", tf1);
            cell5Row1SummaryTable.BackgroundColor = color;

            Cell cell6Row1SummaryTable = row1SummaryTable.Cells.Add("Shipped Date", tf1);
            cell6Row1SummaryTable.BackgroundColor = color;


            Row row2SummaryTable = summaryTable.Rows.Add();
            tf1 = new Aspose.Pdf.Generator.TextInfo();
            tf1.FontSize = 9;
            tf1.Color = new Aspose.Pdf.Generator.Color("Black");
            tf1.FontName = "Times-Roman";
            tf1.Alignment = AlignmentType.Center;

            row2SummaryTable.Cells.Add("90234", tf1);
            row2SummaryTable.Cells.Add("3762", tf1);
            row2SummaryTable.Cells.Add("AU89", tf1);
            row2SummaryTable.Cells.Add("James Smith", tf1);
            row2SummaryTable.Cells.Add(DateTime.Now.Date.ToString(), tf1);
            row2SummaryTable.Cells.Add(DateTime.Now.Date.ToString(), tf1);

        }

        private Table AddTable(Aspose.Pdf.Generator.Pdf pdf)
        {
            //create a table to hold order details
            Table detailTable = new Table();
            Aspose.Pdf.Generator.Color color = new Aspose.Pdf.Generator.Color(111, 146, 188);
            detailTable.Margin.Top = 20;
            detailTable.ColumnWidths = "60 150 60 80 60 80";
            //detailTable.DefaultCellBorder = new BorderInfo((int)(BorderSide.Top|BorderSide.Bottom), color);
            detailTable.DefaultCellBorder = new BorderInfo((int)(BorderSide.Top | BorderSide.Bottom | BorderSide.Right | BorderSide.Left), color);
            detailTable.DefaultCellTextInfo.FontSize = 10;
            detailTable.DefaultCellPadding.Bottom = detailTable.DefaultCellPadding.Top = 4;
            Section section = pdf.Sections[0];
            section.Paragraphs.Add(detailTable);

            Row row1DetailTable = detailTable.Rows.Add();

            Aspose.Pdf.Generator.TextInfo tf1 = new Aspose.Pdf.Generator.TextInfo();
            tf1.FontSize = 10;
            tf1.Color = new Aspose.Pdf.Generator.Color("White");
            tf1.FontName = "Helvetica-Bold";
            tf1.Alignment = AlignmentType.Center;

            Cell cell1Row1DetailTable = row1DetailTable.Cells.Add("Product ID", tf1);
            cell1Row1DetailTable.BackgroundColor = color;

            Cell cell2Row1DetailTable = row1DetailTable.Cells.Add("Product Name", tf1);
            cell2Row1DetailTable.BackgroundColor = color;

            Cell cell3Row1DetailTable = row1DetailTable.Cells.Add("Quantity", tf1);
            cell3Row1DetailTable.BackgroundColor = color;

            Cell cell4Row1DetailTable = row1DetailTable.Cells.Add("Unit Price", tf1);
            cell4Row1DetailTable.BackgroundColor = color;

            Cell cell5Row1DetailTable = row1DetailTable.Cells.Add("Discount", tf1);
            cell5Row1DetailTable.BackgroundColor = color;

            Cell cell6Row1DetailTable = row1DetailTable.Cells.Add("Extended Price", tf1);
            cell6Row1DetailTable.BackgroundColor = color;

            return detailTable;
        }

        private void AddRow(Aspose.Pdf.Generator.Pdf pdf, Aspose.Pdf.Generator.Table tabel, FlightInfo flightInfo)
        {
            //add a new row in order detail. 
            Section section = pdf.Sections[0];

            Aspose.Pdf.Generator.TextInfo tf1 = new Aspose.Pdf.Generator.TextInfo();
            tf1.FontSize = 10;
            tf1.Alignment = AlignmentType.Center;

            Row row1DetailTable = tabel.Rows.Add();
            row1DetailTable.Cells.Add("1", tf1);
            tf1.Alignment = AlignmentType.Left;
            row1DetailTable.Cells.Add("Ticket: " + flightInfo.DepartureLocation + " to " + flightInfo.Destination, tf1);
            tf1.Alignment = AlignmentType.Center;
            row1DetailTable.Cells.Add("1", tf1);
            row1DetailTable.Cells.Add(flightInfo.Fare.ToString("c", locale), tf1);
            row1DetailTable.Cells.Add("0" + "%", tf1);
            row1DetailTable.Cells.Add(flightInfo.Fare.ToString("c", locale), tf1);
        }

        private void PutAmount(Aspose.Pdf.Generator.Pdf pdf, float fare, float tax)
        {

            //add total amount for this invoice
            Aspose.Pdf.Generator.Color color = new Aspose.Pdf.Generator.Color(111, 146, 188);

            CultureInfo culture = new CultureInfo("en-US");
            Table amountTable = new Table();
            amountTable.Margin.Top = 20;
            amountTable.Margin.Left = 370;
            amountTable.ColumnWidths = "60 60";
            amountTable.DefaultCellBorder = new BorderInfo((int)BorderSide.Bottom, color);
            amountTable.DefaultCellPadding.Bottom = amountTable.DefaultCellPadding.Top = 5;
            amountTable.DefaultCellTextInfo.FontSize = 10;

            Section section = pdf.Sections[0];
            section.Paragraphs.Add(amountTable);

            Row row1AmountTable = amountTable.Rows.Add();

            Aspose.Pdf.Generator.TextInfo tf1 = new Aspose.Pdf.Generator.TextInfo();
            tf1.FontSize = 10;
            tf1.Color = color;
            tf1.FontName = "Helvetica-Bold";

            row1AmountTable.Cells.Add("Subtotal", tf1);
            row1AmountTable.Cells.Add(fare.ToString("c", culture));

            Row row2AmountTable = amountTable.Rows.Add();

            row2AmountTable.Cells.Add("Tax", tf1);
            row2AmountTable.Cells.Add(tax.ToString("c", culture));

            Row row3AmountTable = amountTable.Rows.Add();

            row3AmountTable.Cells.Add("Total", tf1);
            row3AmountTable.Cells.Add((fare + tax).ToString("c", culture));
        }
    }

}
