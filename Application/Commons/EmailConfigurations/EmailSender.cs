using Microsoft.AspNetCore.Hosting;
using MimeKit;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Application.Commons.EmailConfigurations
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;
       
        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public async Task SendEmailAsync(Message message , string path)
        {
            var emailMessage = CreateEmailMessage(message, path);
            await SendAsync(emailMessage);
           // await SendnewAsync(message, path);
        }
        private MimeMessage CreateEmailMessage(Message message ,string path)
        {
           
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            // Create MultiPart For Email Message
            var multipart = new Multipart("mixed");
           
            multipart.Add(new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content });

            // Create An Attachment For The File Located At Path
            var attachment = new MimePart("document", "pdf")
            {
                ContentObject = new ContentObject(File.OpenRead(path), ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(path)
            };

            // Add Attachment To MultiPart
            multipart.Add(attachment);
            emailMessage.Body = multipart;

            return emailMessage;
        }
        private async Task SendAsync(MimeMessage mailMessage)
        {
            //SmtpClient smtp = new SmtpClient();
            using (var client = new MailKit.Net.Smtp.SmtpClient())

            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
        private async Task SendnewAsync(Message message, string path)
        {
            var fromAddress = new MailAddress(_emailConfig.From);
            var fromPassword = _emailConfig.Password;
            var mails = message.To.ToArray() ;

            
            var toAddress = new MailAddress(mails[0].Address);

            var  subject = message.Subject;
           var  body = message.Content;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
           
            using (var messages = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
               
                
                
            })

              smtp.Send(messages);
        }
        
    }
}
