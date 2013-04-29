using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace Polakken
{
    internal static class SendMail
    {
        private const string Host = "smtp.gmail.com";
        private const int Port = 587;
        private const string Module = "sendMail";
        private static NetworkCredential _mCredentials;
        private static int _retryCounter = 0;
        private static bool _retrying = false;
        public static string Email { get; set; }
        public static string Password { get; set; }
        public static bool WarningSentSend { get; set; }

        //Metode som sender mail til alle som er oppført i databasen
        public static void SendToAll(string subject, string body)
        {
            if (_retrying == true)
            {
                Thread.Sleep(300000);
                Logger.Warning("En annen epost prøver å bli sendt. Venter 5 minutter.", Module);
            }
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
                _retryCounter = 0;
                WarningSentSend = false;
            }
            catch
            {
                if (WarningSentSend == false)
                {
                    WarningSentSend = true;
                    Logger.Warning("Får ikke kontakt med epost servere, prøver igjen om 1 minutt.", Module);
                    RetrySendToAll(subject, body);
                }
            }
        }

        //metode som prøver å sende meldingen til alle igjen 2 ganger til før forkaster mail. 
        public static void RetrySendToAll(string subject, string body)
        {
            _retrying = true;
            Thread.Sleep(60000);
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
                _retryCounter = 0;
                WarningSentSend = false;
                _retrying = false;
            }
            catch
            {
                _retryCounter++;
                if (_retryCounter <= 2)
                {
                    Logger.Warning("Får ikke kontakt med epost servere, prøver igjen om 1 minutt.", Module);
                    RetrySendToAll(subject, body);
                }
                else if (_retryCounter == 3)
                {
                    _retrying = false;
                    Logger.Error("Får ikke kontakt med epost servere, alarmen kan ikke bli sendt.", Module);
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