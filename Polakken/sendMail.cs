using System;
using System.Net;
using System.Net.Mail;
using System.Data;

namespace Polakken
{
    static class sendMail
    {
        private static string host = "smtp.gmail.com";
        private static int port = 587;
        private static string email = "republicofprogrammers@gmail.com";
        private static string password = "polakken";
        private static string module = "sendMail";
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
                    //Løkke som henter ut alle e-mails fra databasen
                    foreach (DataRow dtRow in lblDelEmail.dtEmails.Rows)
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