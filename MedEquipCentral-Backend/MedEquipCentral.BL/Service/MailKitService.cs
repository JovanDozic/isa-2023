using MailKit.Net.Smtp;
using MailKit.Security;
using MedEquipCentral.BL.Contracts.IService;
using MimeKit;

namespace MedEquipCentral.BL.Service
{
    public class MailKitService : IMailKitService
    {
        private bool SendEmail(MimeMessage message)
        {
            if (message == null)
            {
                return false;
            }

            try
            {
                using var client = new SmtpClient();

                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("covid23serbia@gmail.com", "pzty nfyd fyfn trqt");

                client.Send(message);

                client.Disconnect(true);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool SendPickupConfirmEmail(string emailTo)
        {
            var newMessage = BuildPickupConfirmMessage(emailTo);

            return SendEmail(newMessage);
        }

        private MimeMessage BuildPickupConfirmMessage(string emailTo)
        {
            var newMessage = new MimeMessage();

            newMessage.From.Add(new MailboxAddress("Med equip central team", "covid23serbia@gmail.com"));
            newMessage.To.Add(new MailboxAddress("Med equip central team", emailTo));

            // TODO: Ovde moze da se definise HTML template, ali nesto ne mogu to sad iskreno.

            newMessage.Subject = "Pickup confirmation - Med equip central";
            newMessage.Body = new TextPart("plain")
            {
                Text = @"Hello, your pickup has been confirmed. Please come to our office to pick up your equipment."
            };

            return newMessage;
        }

    }
}
