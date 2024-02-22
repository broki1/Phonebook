using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Phonebook;

internal class EmailController
{

    internal static void SendEmail(string subject, string body, string toEmail)
    {

        var fromEmail = new MailAddress(ConfigurationManager.AppSettings.Get("email"));
        var fromEmailPassword = ConfigurationManager.AppSettings.Get("emailPassword");


        var email = new MailMessage();
        email.From = fromEmail;
        email.To.Add(toEmail);
        email.Subject = subject;
        email.Body = body;

        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.UseDefaultCredentials = false;
        smtp.EnableSsl = true;

        smtp.Credentials = new NetworkCredential(fromEmail.ToString(), fromEmailPassword);

        try
        {
            smtp.Send(email);
            Console.WriteLine("Email sent successfully!");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
            Console.ReadLine();
        }
    }

}
