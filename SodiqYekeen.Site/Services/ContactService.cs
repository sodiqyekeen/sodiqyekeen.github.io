using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Mailjet.Client.TransactionalEmails;
using Newtonsoft.Json.Linq;
using SodiqYekeen.Site.Models;

namespace SodiqYekeen.Site.Services
{
    public class ContactService
    {
        private readonly MailjetClient _mailjetClient;

        //public ContactService(MailjetClient mailjetClient) => _mailjetClient = mailjetClient;

        public void SubmitContactForm(ContactFormModel form)
        {
            var credentials = new NetworkCredential("olatechlove@gmail.com", "password");
            var mail = new MailMessage
            {
                From = new MailAddress("olatechlove@gmail.com"),
                Subject = "Website Inquiry - sodiqyekeen.github.io",
                Body = FormatMailBody(form.Name, form.Email, form.Subject, form.Message)
            };

            mail.IsBodyHtml = true;
            mail.To.Add(new MailAddress("sodiq.yekeen.o@gmail.com"));
            var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = credentials
            };

            client.Send(mail);
        }

        private string FormatMailBody(string name, string email, string subject, string message)
        {
            var senderInfo = String.Format("<b>From</b>: {0}<br/><b>Email</b>: {1}<br/><b>Subject</b>: {2}<br/><br/>", name, email, subject);
            return senderInfo + message;
        }

        //private bool Validate(string gResponse)
        //{
        //    using (var client = new WebClient())
        //    {
        //        try
        //        {
        //            // Enter your reCAPTCHA private key here
        //            string secretKey = "YourGoogleSecretKeyHere";
        //            var gReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}",
        //                    secretKey, gResponse));

        //            var jsonReturned = JsonSerializer.Deserialize<ReCaptcha>(gReply);
        //            return (jsonReturned.Success.ToLower() == "true");
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //}

        public async Task RunAsync()
        {
            try
            {
                MailjetClient client = new MailjetClient("b13f92a47060e40650e90fca1716fe85", "0271d2f81f7aeb11cdd055b1d9b4f53f")
                {
                    BaseAdress = "https://api.us.mailjet.com",
                }; 

                MailjetRequest request = new MailjetRequest
                {
                    Resource = Send.Resource,
                }
               .Property(Send.FromEmail, "zolalekan@gmail.com")
               .Property(Send.FromName, "Sodiq")
               .Property(Send.To, "olatechlove@gmail.com")
               .Property(Send.Subject, "Greetings from Mailjet.")
               .Property(Send.TextPart, "My first Mailjet email")
               .Property(Send.HtmlPart, "<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!");

                MailjetResponse response = await client.PostAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
                    Console.WriteLine(response.GetData());
                }
                else
                {
                    Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
                    Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
                    Console.WriteLine(response.GetData());
                    Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
