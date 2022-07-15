using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace ConsoleApp1.Services
{
    public static class MailService
    {
        public static string SendMail(SendMailModel model)
        {
            string msg = "";

            try
            {
                if (model != null && model.mailTo != null && model.mailTo.Count > 0 && !string.IsNullOrWhiteSpace(model.subject))
                {
                    SmtpClient sc = new SmtpClient();
                    sc.Host = ConfigurationService.GetMailServer();
                    sc.Port = 25;
                    sc.EnableSsl = false;
                    sc.UseDefaultCredentials = true;

                    string mailFrom = ConfigurationService.GetSmtpMailFrom();
                    MailAddress sendFrom = new MailAddress(mailFrom);

                    MailMessage myMessage = new MailMessage();
                    myMessage.From = sendFrom;
                    foreach (string mail in model.mailTo)
                    {
                        myMessage.To.Add(
                            new MailAddress(mail)
                        );
                    }

                    string mailCC = ConfigurationService.GetSmtpMailCC();
                    if(!string.IsNullOrWhiteSpace(mailCC))
                    {
                        List<string> cc = mailCC.Split(",").ToList();
                        foreach (string mail in cc)
                        {
                            myMessage.CC.Add(
                                new MailAddress(mail)
                            );
                        }
                    }

                    myMessage.BodyEncoding = Encoding.UTF8;
                    myMessage.IsBodyHtml = true;
                    myMessage.Subject = model.subject;
                    myMessage.Body = model.content;

                    sc.Send(myMessage);
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }

        public class SendMailModel
        {
            public List<string> mailTo { get; set; }

            public string subject { get; set; }

            public string content { get; set; }
        }
    }
}
