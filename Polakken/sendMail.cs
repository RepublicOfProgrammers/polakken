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
        public static string email { get; set; }
        public static string password { get; set; }
        private static string module = "sendMail";
        private static NetworkCredential mCredentials;
        public static bool warningSentSend { get; set; }

        //Metode som sender mail til alle som er oppført i databasen
        public static void sendToAll(string subject, string body)
        {
            try
            {
                warningSentSend = false;
                string mailTo;
                //Oppretter ny SmtpClient
                mCredentials = new NetworkCredential(email, password);
                using (SmtpClient client = new SmtpClient(host, port))
                {
                    //Login info for programmets email
                    client.Credentials = mCredentials;
                    client.EnableSsl = true;
                    //Løkke som henter ut alle e-mails fra databasen
                    foreach (DataRow dtRow in GUI_FORM.dtEmails.Rows)
                    {
                        mailTo = dtRow["Adresser"].ToString();
                        client.Send(email, mailTo, subject, body);
                        Logger.Info("Sendt email til alle mottakere.", module);
                    }
                }
            }
            catch (Exception ex)
            {
                if (warningSentSend == false)
                {
                    warningSentSend = true;
                    Logger.Error(ex, module);
                }
                
            }
        }

        //Metode som bare sender mail til en person
        public static void sendToOne(string subject, string body, string mailTo)
        {
            try
            {
                warningSentSend = false;
                //Oppretter ny SmtpClient
                mCredentials = new NetworkCredential(email, password);
                using (SmtpClient client = new SmtpClient(host, port))
                {
                    //Login info for programmets email
                    client.Credentials = mCredentials;
                    client.EnableSsl = true;

                    client.Send(email, mailTo, subject, body);
                    Logger.Info("Sendt email til " + mailTo + ".", module);
                }

            }
            catch (Exception ex)
            {
                if (warningSentSend == false)
                {
                    warningSentSend = true;
                    Logger.Error(ex, module);
                }
            }
        }
    }
}