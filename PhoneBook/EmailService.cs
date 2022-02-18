using System.Net.Mail;

namespace PhoneBook
{
    public static class EmailService
    {
        public static void SendEmail(string address, string subject, string body)
        {
            MailAddress addressFrom = new("pablo.the.souza@gmail.com", "Pablo de Souza");
            MailAddress addressTo = new(address);
            MailMessage message = new MailMessage(addressFrom, addressTo);

            message.Subject = subject;
           
            message.Body = body;

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("pablo.the.souza@gmail.com", "acoorakikctxolfh");
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
}
