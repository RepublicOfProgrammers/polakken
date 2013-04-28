using System;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace Polakken
{
    internal static class SendMail
    {
        private const string Host = "smtp.gmail.com";
        private const int Port = 587;
        private const string Module = "sendMail";
        private static NetworkCredential _mCredentials;
        public static string Email { get; set; }
        public static string Password { get; set; }
        public static bool WarningSentSend { get; set; }

        //Metode som sender mail til alle som er oppført i databasen
        public static void SendToAll(string subject, string body)
        {
            try
            {
                //Oppretter ny SmtpClient
                _mCredentials = new NetworkCredential(Email, Password);
                using (var client = new SmtpClient(Host, Port))
                {
                    //Login info for programmets email
                    client.Credentials = _mCredentials;
                    client.EnableSsl = true;
                    //Løkke som henter ut alle e-mails fra databasen
                    foreach (DataRow dtRow in GuiForm.DtEmails.Rows)
                    {
                        string mailTo = dtRow["Adresser"].ToString();
                        client.Send(Email, mailTo, subject, body);
                        Logger.Info("Sendt email til alle mottakere.", Module);
                    }
                }

                WarningSentSend = false;
            }
            catch (Exception ex)
            {
                if (WarningSentSend == false)
                {
                    WarningSentSend = true;
                    Logger.Error(ex, Module);
                }
            }
        }

        //Metode som bare sender mail til en person
        public static void SendToOne(string subject, string body, string mailTo)
        {
            try
            {
                //Oppretter ny SmtpClient
                _mCredentials = new NetworkCredential(Email, Password);
                using (var client = new SmtpClient(Host, Port))
                {
                    //Login info for programmets email
                    client.Credentials = _mCredentials;
                    client.EnableSsl = true;

                    client.Send(Email, mailTo, subject, body);
                    Logger.Info("Sendt email til " + mailTo + ".", Module);
                }

                WarningSentSend = false;
            }
            catch (Exception ex)
            {
                if (WarningSentSend == false)
                {
                    WarningSentSend = true;
                    Logger.Error(ex, Module);
                }
            }
        }
    }
}