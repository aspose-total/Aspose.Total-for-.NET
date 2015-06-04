using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.Email;
using Aspose.Email.Mail;


namespace FlyNowAirlineBookingService
{
    class Email
    {
        string path;
        
        public Email(string curPath)
        {
            path = curPath;

            Aspose.Email.License lic = new Aspose.Email.License();
            lic.SetLicense(@"c:\tempfiles\Aspose.Total.lic");
        }

        public void SendEmail(string recipientName, string recipientEmail, string subject, string messageBody, string attachmentPath)
        {

            //declare message as MailMessage instance
            MailMessage message = new MailMessage();

            //sender's address
            message.From = "YOUR FROM ADDRESS";
            

            //txtTo.Text is the recipient's address
            message.To = recipientEmail;
            message.Subject = subject;

            //txtBody.Text is the Mail Message
            message.HtmlBody = messageBody;
            message.IsBodyHtml = true;

            //sent Mail using SmtpClient
            //Create an instance of SmtpClient Class
            SmtpClient client = new SmtpClient();

            //Specify your mailing host server
            client.Host = "YOUR HOST NAME";

            //Specify your mail user name
            client.Username = "YOUR SMTP USER NAME";

            //Specify your mail password
            client.Password = "YOUR PASSWORD";

            //Specify your Port #
            client.Port = 587;

            client.EnableSsl = true;


            //Adding attachment
            //Create an instance of Attachment class
            Attachment attachment;

            //Load an attachment
            attachment = new Attachment(attachmentPath);

            //Add attachment in instance of MailMessage class
            message.Attachments.Add(attachment);

            //Client.Send will send this message
            client.Send(message);


        }
    }
}
