using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrApp_WebAPI.BusinessLogic.Interfaces;
using HrApp_WebAPI.Data.Entities.Companies;
using MailKit.Net.Smtp;
using MimeKit;

namespace HrApp_WebAPI.BusinessLogic.Email2
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly CompanyContext _companyContext;

        public EmailSender(EmailConfiguration emailConfig, CompanyContext companyContext)
        {
            _emailConfig = emailConfig;
            _companyContext = companyContext;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var employee = _companyContext.Employees.FirstOrDefault(e => e.EmployeeId == 12);

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = string.Format("<h1 style='color: red'>WELCOME TO UCMS !</h1>" + $"{employee.Photo}.png")
            };

            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                    client.Send(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
