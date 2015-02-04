using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace SendingMails.BusinessLayer
{
    public class Mailer
    {
        /// <summary>
        /// Method to send mail with list of files deleted
        /// </summary>
        /// <param name="deletedFiles">List of files</param>
        /// <returns>Result of sending the mail.</returns>
        public static bool SendMail(List<string> deletedFiles)
        {
            bool result = false;

            //Body message
            string mailBody = "";

            //Get file names and add to body
            foreach (string file in deletedFiles)
            {
                mailBody += "<li>" + file + "</li>";
            }

            //Create SMTP client and configure it
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            // setup Smtp authentication
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(Messages.EmailID, Messages.Password);
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            //Create Message with From, To, Subject and body
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(Messages.EmailID);
            msg.To.Add(new MailAddress("swamibabulal@gmail.com"));

            msg.Subject = "Deleted files.";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<html><head></head><body><h2> Deleted files </h2> <ul>" + mailBody + "</ul></body></html>");

            //Send mail and check for Exceptions
            try
            {
                client.Send(msg);
                result = true;
            }
            catch (Exception ex)
            {
                //if any Exception found.
                result = false;
            }
            return result;
        }
    }
}