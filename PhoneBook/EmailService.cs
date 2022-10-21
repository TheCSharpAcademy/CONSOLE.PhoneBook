using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace PhoneBook;

public static class EmailService
{
    static IConfiguration configuration = (new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build());
    public static string emailAddress = configuration["EmailAddress"].ToString();
    public static string emailKey = configuration["EmailKey"].ToString();

    public static void SendEmail(string address, string subject, string body)
    {
        var addressFrom = new MailAddress(emailAddress, "Pablo de Souza");
        var addressTo = new MailAddress(address);
        var message = new MailMessage(addressFrom, addressTo);

        message.Subject = subject;
        message.Body = body;

        var client = new SmtpClient();
        client.Host = "smtp.gmail.com";
        client.Port = 587;
        client.EnableSsl = true;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential(emailAddress, emailKey);

        try
        {
            client.Send(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
