﻿using System;
using System.Net;
using System.Net.Mail;
using System.Data;

namespace Polakken
{
    static class E_mail_handler
    {
        private static string host = "smtp.gmail.com";
        private static int port = 587;
        private static string email = "republicofprogrammers@gmail.com";
        private static string password = "polakken";
        private static string module = "E-mail handler";
        private static NetworkCredential mCredentials = new NetworkCredential(email, password);

        //Metode som sender mail til alle som er oppført i databasen
        public static void sendToAll(string subject, string body)
        {
            try
            {
                string mailTo;

                using (SmtpClient client = new SmtpClient(host, port))
                {
                    client.Credentials = mCredentials;
                    client.EnableSsl = true;

                    foreach (DataRow dtRow in GUI.dtEmails.Rows)
                    {
                        mailTo = dtRow["Adresser"].ToString();
                        client.Send(email, mailTo, subject, body);
                        Logger.Info("Sendt email til alle mottakere.", module);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, module);
            }
        }

        //Metode som bare sender mail til en person
        public static void sendToOne(string subject, string body, string mailTo)
        {
            try
            {
                using (SmtpClient client = new SmtpClient(host, port))
                {
                    client.Credentials = mCredentials;
                    client.EnableSsl = true;

                    client.Send(email, mailTo, subject, body);
                    Logger.Info("Sendt email til " + mailTo + ".", module);
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, module);
            }
        }
    }
}