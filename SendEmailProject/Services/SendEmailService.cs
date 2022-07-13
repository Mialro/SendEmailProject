using Microsoft.Extensions.Options;
using SendEmailProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailProject.Services
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IOptions<SMTPConfigModel> _configOption;

        public SendEmailService(IOptions<SMTPConfigModel> configOption)
        {
            _configOption = configOption;
        }
        public async Task sendEmail(MailOptionsModel mailOptionsModel)
        {
            NetworkCredential networkCredential = new NetworkCredential(_configOption.Value.UserName, _configOption.Value.Password);
            //var mailCollection = new MailAddressCollection();


            MailMessage mail = new MailMessage()
            {
                Subject = mailOptionsModel.Subject,
                IsBodyHtml = _configOption.Value.IsBodyHtml,
                From = new MailAddress(_configOption.Value.SenderAddress, _configOption.Value.SenderDisplayName),
                Body = mailOptionsModel.Body,
                BodyEncoding = Encoding.Default,
            };

            foreach (var email in mailOptionsModel.To)
            {
                mail.To.Add(email);
            }


            SmtpClient smtpClient = new SmtpClient()
            {
                Port = _configOption.Value.Port,
                Host = _configOption.Value.Host,
                EnableSsl = _configOption.Value.EnableSSl,
                UseDefaultCredentials = _configOption.Value.UseDefaultCredentials,
                Credentials = networkCredential,
            };

            await smtpClient.SendMailAsync(mail);
        }
    }
}
