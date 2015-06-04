/////////////////////////////////////////////////////////////////////////
// Copyright (C) 2002-2011 Aspose Pty Ltd.  All rights reserved.
//
// This file is part of Aspose.Pdf. The source code in this file 
// is only intended as a supplement to the documentation, and is provided 
// "as is", without warranty of any kind, either expressed or implied.
/////////////////////////////////////////////////////////////////////////

using System;
using Aspose.Pdf.Generator;

using System.Globalization;
using System.Data;

namespace FlyNowAirlineBookingService
{
	/// <summary>
	/// creates ticket 
	/// </summary>
	public class Ticket
	{

		string path;
		System.Globalization.CultureInfo locale = new System.Globalization.CultureInfo("en-US");


		public Ticket(string curPath)
		{
			path = curPath;

            Aspose.Pdf.License lic = new Aspose.Pdf.License();
            lic.SetLicense(@"c:\tempfiles\Aspose.Total.lic");
		}

		public Aspose.Pdf.Generator.Pdf GetTicket(PassengerInfo passengerInfo, FlightInfo flightInfo, BookingInfo bookingInfo)
		{
            
            Aspose.Pdf.Generator.Pdf pdf = new Aspose.Pdf.Generator.Pdf();
			pdf.IsTruetypeFontMapCached = false;
            			
            pdf.Sections.Add();
            MarginInfo marginInfo = new MarginInfo();
            marginInfo.Top = 50;
            marginInfo.Left = 50;
            marginInfo.Right = 50;

            pdf.Sections[0].PageInfo.Margin = marginInfo;

            PutOrder(pdf, passengerInfo, flightInfo, bookingInfo);

            return pdf;
		}

        private void PutOrder(Aspose.Pdf.Generator.Pdf pdf, PassengerInfo passengerInfo, FlightInfo flightInfo, BookingInfo bookingInfo)
		{
            //ticket for leaving             
            PutSummary(pdf, passengerInfo, bookingInfo, flightInfo, false);

            //ticket for returning
            PutSummary(pdf, passengerInfo, bookingInfo, flightInfo, true);

		}

        

        private void PutSummary(Aspose.Pdf.Generator.Pdf pdf, PassengerInfo passengerInfo, BookingInfo bookingInfo, FlightInfo flightInfo, bool isReturn)
		{
            //create table structure for the ticket
			Table summaryTable  = new Table();
            Aspose.Pdf.Generator.Color color = new Aspose.Pdf.Generator.Color(111, 146, 188);
			summaryTable.Margin.Top = 20;
			summaryTable.ColumnWidths = "80 80 80 80";
			summaryTable.DefaultCellTextInfo.FontSize = 10;
			summaryTable.DefaultCellPadding.Bottom = summaryTable.DefaultCellPadding.Top = 3;
            summaryTable.Border = new BorderInfo((int)BorderSide.Box, 0.5f ,color);
            summaryTable.BackgroundColor = new Color(173, 202, 225);

            //add table to the PDF page
			Section section = pdf.Sections[0];
			section.Paragraphs.Add(summaryTable);

            //declare temporary variables
            Aspose.Pdf.Generator.TextInfo textInfo = new Aspose.Pdf.Generator.TextInfo();
            Cell tempCell;

            //add logo and barcode images
            Row row1SummaryTable = summaryTable.Rows.Add();
            textInfo = SetTextInfo("Times-Roman", 9, "Black", false);
            Cell cell1 = new Cell(row1SummaryTable);
            cell1.ColumnsSpan = 2;
            cell1.DefaultCellTextInfo = textInfo;

            Aspose.Pdf.Generator.Image img = new Aspose.Pdf.Generator.Image();
            img.ImageInfo.File = path + "\\FlyNowLogoOnly.jpg";
            img.ImageInfo.ImageFileType = Aspose.Pdf.Generator.ImageFileType.Jpeg;

            img.ImageInfo.FixWidth = 90;
            img.ImageInfo.FixHeight = 30;
            
            cell1.Paragraphs.Add(img);
            row1SummaryTable.Cells.Add(cell1);

            Cell cell2 = new Cell(row1SummaryTable);
            cell2.ColumnsSpan = 2;
            cell2.DefaultCellTextInfo = textInfo;
            cell2.Alignment = AlignmentType.Right;

            img = new Aspose.Pdf.Generator.Image();
            if(!isReturn)
                 img.ImageInfo.File = path + "\\barcodeleave.jpg";
            else
                img.ImageInfo.File = path + "\\barcodereturn.jpg";
            
            img.ImageInfo.ImageFileType = Aspose.Pdf.Generator.ImageFileType.Jpeg;
            img.ImageInfo.FixWidth = 160;
            img.ImageInfo.FixHeight = 30;
            
            cell2.Paragraphs.Add(img);
            row1SummaryTable.Cells.Add(cell2);


            Row row2SummaryTable = summaryTable.Rows.Add();
            textInfo = SetTextInfo("Times-Roman", 9, "Black", true);
            tempCell = AddTextToCell("Class:", row2SummaryTable, textInfo, true);
            row2SummaryTable.Cells.Add(tempCell);

            //cell2 = new Cell(row2SummaryTable);
            textInfo = SetTextInfo("Times-Roman", 9, "Black", false);
            tempCell = AddTextToCell("Economy", row2SummaryTable, textInfo, false);
            row2SummaryTable.Cells.Add(tempCell);

            //add emptry cells
            Cell cell3 = new Cell(row2SummaryTable);
            row2SummaryTable.Cells.Add(cell3);
            Cell cell4 = new Cell(row2SummaryTable);
            row2SummaryTable.Cells.Add(cell4);


            //add flight details
            Row row3SummaryTable = summaryTable.Rows.Add();
            
            textInfo = SetTextInfo("Times-Roman", 9, "Black", true);
            tempCell = AddTextToCell("Flight:  ", row3SummaryTable, textInfo,true);
            row3SummaryTable.Cells.Add(tempCell);

            textInfo = SetTextInfo("Times-Roman", 9, "Black", false);
            
            if(!isReturn)
                tempCell = AddTextToCell(flightInfo.FlightNumberLeave, row3SummaryTable, textInfo, false);
            else
                tempCell = AddTextToCell(flightInfo.FlightNumberReturn, row3SummaryTable, textInfo, false);

            row3SummaryTable.Cells.Add(tempCell);

            textInfo = SetTextInfo("Times-Roman", 9, "Black", true);
            tempCell = AddTextToCell("Seat Number:  ", row3SummaryTable, textInfo, true);
            row3SummaryTable.Cells.Add(tempCell);

            textInfo = SetTextInfo("Times-Roman", 9, "Black", false);
            tempCell = AddTextToCell(passengerInfo.SeatNumber, row3SummaryTable, textInfo, false);
            row3SummaryTable.Cells.Add(tempCell);

            Row row4SummaryTable = summaryTable.Rows.Add();

            textInfo = SetTextInfo("Times-Roman", 9, "Black", true);
            tempCell = AddTextToCell("From:  ", row3SummaryTable, textInfo, true);
            row4SummaryTable.Cells.Add(tempCell);

            textInfo = SetTextInfo("Times-Roman", 9, "Black", false);
            if(!isReturn)
                tempCell = AddTextToCell(flightInfo.DepartureLocation, row3SummaryTable, textInfo, false);
            else
                tempCell = AddTextToCell(flightInfo.Destination, row3SummaryTable, textInfo, false);

            row4SummaryTable.Cells.Add(tempCell);

            textInfo = SetTextInfo("Times-Roman", 9, "Black", true);
            tempCell = AddTextToCell("To:  ", row3SummaryTable, textInfo, true);
            row4SummaryTable.Cells.Add(tempCell);

            textInfo = SetTextInfo("Times-Roman", 9, "Black", false);
            if(!isReturn)
                tempCell = AddTextToCell(flightInfo.Destination, row3SummaryTable, textInfo, false);
            else
                tempCell = AddTextToCell(flightInfo.DepartureLocation, row3SummaryTable, textInfo, false);

            row4SummaryTable.Cells.Add(tempCell);


            Row row5SummaryTable = summaryTable.Rows.Add();

            textInfo = SetTextInfo("Times-Roman",9, "Black", true);
            tempCell = AddTextToCell("Departure:", row5SummaryTable, textInfo, true);
            row5SummaryTable.Cells.Add(tempCell);

            textInfo = SetTextInfo("Times-Roman", 9, "Black", false);
            if(!isReturn)
                 tempCell = AddTextToCell(flightInfo.DepartureDateandTime.ToString(), row5SummaryTable, textInfo, false);
            else
                tempCell = AddTextToCell(flightInfo.ReturnDateandTime.ToString(), row5SummaryTable, textInfo, false);

            row5SummaryTable.Cells.Add(tempCell);

            textInfo = SetTextInfo("Times-Roman", 9, "Black", true);
            tempCell = AddTextToCell("Arrival:", row5SummaryTable, textInfo, true);
            row5SummaryTable.Cells.Add(tempCell);

            textInfo = SetTextInfo("Times-Roman", 9, "Black", false);
            if(!isReturn)
                 tempCell = AddTextToCell(flightInfo.ArrivalDateandTimeDest.ToString(), row5SummaryTable, textInfo, false);
            else
                tempCell = AddTextToCell(flightInfo.ArrivalDateandTimeBack.ToString(), row5SummaryTable, textInfo, false);

            row5SummaryTable.Cells.Add(tempCell);


            
		}

        //create object with text styling information
        private Aspose.Pdf.Generator.TextInfo SetTextInfo(string fontName, float fontSize, string fontColor, bool isBold)
        {

            Aspose.Pdf.Generator.TextInfo textInfo = new Aspose.Pdf.Generator.TextInfo();
            textInfo.FontSize = fontSize;
            textInfo.Color = new Aspose.Pdf.Generator.Color(fontColor);
            textInfo.Alignment = AlignmentType.Center;
            textInfo.IsTrueTypeFontBold = isBold;
            textInfo.TruetypeFontFileName = fontName;

            return textInfo;
        }

        //create a new cell
        private Cell AddTextToCell(string strText, Row currentRow, Aspose.Pdf.Generator.TextInfo textInfo, bool isRightAligned)
        {
            Cell tempCell = new Cell(currentRow);
            Text text = new Text(strText);
            text.TextInfo = textInfo;

            if (isRightAligned)
                text.TextInfo.Alignment = AlignmentType.Right;
            else
                text.TextInfo.Alignment = AlignmentType.Left;

            tempCell.Paragraphs.Add(text);

            return tempCell;
        }

       
	}



    
  
     
}
