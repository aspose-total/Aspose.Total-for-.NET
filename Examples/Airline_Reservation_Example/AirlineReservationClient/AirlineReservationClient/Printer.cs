using System;
using System.Collections.Generic;
using System.Text;

using Aspose.Pdf.Facades;

namespace AirlineReservationClient
{

        //prints PDF invoice to the default printer
        class Printer
        {
            string path;
            public Printer(string curPath)
            {
                path = curPath;
            }

            public void Print(bool useDefaultPrinter, string printerName)
            {

                //create PdfViewer object
                PdfViewer viewer = new PdfViewer();

                //open input PDF file
                viewer.OpenPdfFile(path);

                //set attributes for printing
                viewer.AutoResize = true;         //print the file with adjusted size
                viewer.AutoRotate = true;         //print the file with adjusted rotation
                viewer.PrintPageDialog = false;   //do not produce the page number dialog when printing

                //create objects for printer and page settings and PrintDocument
                System.Drawing.Printing.PrinterSettings ps = new System.Drawing.Printing.PrinterSettings();
                System.Drawing.Printing.PageSettings pgs = new System.Drawing.Printing.PageSettings();
                System.Drawing.Printing.PrintDocument prtdoc = new System.Drawing.Printing.PrintDocument();

                //set printer name
                if (useDefaultPrinter)
                    ps.PrinterName = prtdoc.PrinterSettings.PrinterName;
                else
                    ps.PrinterName = printerName;


                //set PageSize (if required)
                pgs.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1169);

                //set PageMargins (if required)
                pgs.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);

                //print document using printer and page settings
                viewer.PrintDocumentWithSettings(pgs, ps);

                //close the PDF file after priting
                viewer.ClosePdfFile();

            }

        }
    }
