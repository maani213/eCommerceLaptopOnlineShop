using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace OnlineShop.Models
{
    public class EmailModel
    {
        public string from { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public void SendMail(string e)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(e);
            mail.From = new MailAddress("creatlist16@gmail.com");
            mail.Subject = "Welcom To Laptops Shop";
            mail.Body = "Hi.. you are warm Welcom to our customers";
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("creatlist16@gmail.com", "khuajaasif123");
            client.EnableSsl = true;
            client.Send(mail);
 
        }
    }
}