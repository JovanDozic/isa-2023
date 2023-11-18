using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts.Model;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MedEquipCentral.BL.Service;
public class EmailService : IEmailService
{
    private const string templatePath = @"EmailTemplate/{0}.html";
    private readonly SMTPConfig _smtpConfig;
    public EmailService(IOptions<SMTPConfig> smtpConfig) 
    { 
        _smtpConfig = smtpConfig.Value;
    }

    public async Task SendConfirmEmail(UserEmailOptionsDto userEmailOptions)
    {
        userEmailOptions.Subject = UpdatePlaceHolders("Hello {{UserName}}, Confirm your email id.", userEmailOptions.Placeholders);
        userEmailOptions.Body = UpdatePlaceHolders(GetEmailBody("EmailConfirm"), userEmailOptions.Placeholders);
        await SendEmail(userEmailOptions);
    }
    private async Task SendEmail(UserEmailOptionsDto emailOptions)
    {
        MailMessage mail = new MailMessage
        {
            Subject = emailOptions.Subject,
            Body = emailOptions.Body,
            From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
            IsBodyHtml = _smtpConfig.IsBodyHTML
        };

        mail.To.Add(emailOptions.ToEmail);

        NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.Username, _smtpConfig.Password);

        SmtpClient smtpClient = new SmtpClient
        {
            Host = _smtpConfig.Host,
            Port = _smtpConfig.Port,
            EnableSsl = _smtpConfig.EnableSSL,
            UseDefaultCredentials = _smtpConfig.UseDefaultCredentials,
            Credentials = networkCredential
        };

        mail.BodyEncoding = Encoding.Default;

        await smtpClient.SendMailAsync(mail);
    }

    private string GetEmailBody(string templateName)
    {
        var body = File.ReadAllText(string.Format(templatePath, templateName));
        return body;
    }

    private string UpdatePlaceHolders(string text, List<KeyValuePair<string, string>> keyValuePairs)
    {
        if (!string.IsNullOrEmpty(text) && keyValuePairs != null)
        {
            foreach (var placeholder in keyValuePairs)
            {
                if (text.Contains(placeholder.Key))
                {
                    text = text.Replace(placeholder.Key, placeholder.Value);
                }
            }
        }

        return text;
    }
}
