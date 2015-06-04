using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.BarCode;

namespace FlyNowAirlineBookingService
{

    //create barcode images
    class BarCode
    {

        string path;

        public BarCode(string curPath) {

            path = curPath;

            Aspose.BarCode.License lic = new Aspose.BarCode.License();
            lic.SetLicense(@"c:\tempfiles\Aspose.Total.lic");
        }


        public string CreateBarCode(string barcodeText, bool isReturn)
        {
            string barcodeFileName = "";

            if (!isReturn)
                barcodeFileName = path + "\\barcodeleave.jpg";
            else
                barcodeFileName = path + "\\barcodereturn.jpg";


            //Instantiate BarCodeBuilder object
            BarCodeBuilder barcode = new BarCodeBuilder();
            //Set the Code text for the barcode
            barcode.CodeText = barcodeText;
            //Set the symbology type to Code39Standard
            barcode.SymbologyType = Symbology.Code39Standard;
            //Set the width of the bars to 1 millimeter
            barcode.xDimension = 1f;
            //Save the barcode image
            barcode.Save(barcodeFileName, System.Drawing.Imaging.ImageFormat.Jpeg);

            return barcodeFileName;
        }
       




    }
}
