using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace SendingMails.BusinessLayer
{
    public class Mailer
    {
        public static bool SendMail(List<string> deletedFiles)
        {
            bool result = false;

            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            // setup Smtp authentication
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("swamibabulal@gmail.com", "");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("swamibabulal@gmail.com");
            msg.To.Add(new MailAddress(""));

            msg.Subject = "This is a test Email subject";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<html><head></head><body><h2>List of files deleted : </h2>" + body + "</body>");

            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}