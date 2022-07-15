using System;
using System.Collections.Generic;
using System.Text;

using System.Configuration;

namespace ConsoleApp1.Services
{
    public static class ConfigurationService
    {
        public static string GetDbConnectionString()
        {
            return ConfigurationManager.AppSettings["DbConnectionString"];
        }

        public static string GetMailServer()
        {
            return ConfigurationManager.AppSettings["SmtpServer"];
        }
        public static string GetSmtpMailFrom()
        {
            return ConfigurationManager.AppSettings["SmtpSendFrom"];
        }

        public static string GetSmtpMailCC()
        {
            return ConfigurationManager.AppSettings["SmtpMailCC"];
        }
    }
}
