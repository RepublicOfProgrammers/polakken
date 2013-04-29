using System;
using System.Data;
using System.IO;
using AE.Net.Mail;
using AE.Net.Mail.Imap;
using Polakken.Properties;

namespace Polakken
{
    internal class MottaMail
    {
        private const string Host = "imap.gmail.com";
        private const int Port = 993;
        private const bool Secure = true;
        private const string Module = "mottaMail";

        public static string From { get; private set; }
        public static string Subject { get; private set; }
        public static string Body { get; private set; }
        private static int _connectionAttempts = 0;

        //Metode for å hente inn mail
        public static void HentMail()
        {
            ImapClient ic = null;
            try
            {
                //Lager nytt objekt av klassen ImapClient
                ic = new ImapClient(Host, SendMail.Email, SendMail.Password,
                                    ImapClient.AuthMethods.Login, Port, Secure);
                ic.SelectMailbox("INBOX");

                //Array som henter inn alle mail i innboksen
                MailMessage[] mail = ic.GetMessages(0, 10, false, true);

                //If-setning som sjekker om det er mail i innboksen
                if (mail.Length != 0)
                {
                    //Tre variabler som henter ut informasjon fra den siste motatte mailen
                    From = mail[mail.Length - 1].From.Address;

                    //Løkke med if-setning som sjekker om mailen er lagt til i databasen
                    foreach (DataRow dtRow in GuiForm.DtEmails.Rows)
                    {
                        if (From == dtRow["Adresser"].ToString())
                        {
                            Subject = mail[mail.Length - 1].Subject;
                            Body = mail[mail.Length - 1].Body;
                        }
                    }
                    //Løkke som sletter alle mail etter den har hentet inn den siste
                    foreach (MailMessage m in mail) ic.DeleteMessage(m);
                }
                _connectionAttempts = 0;
            }
            catch (Exception ex)
            {
                _connectionAttempts++;
                if (_connectionAttempts == 3)
                {
                    Logger.Error(ex, Module);
                }
            }
            finally
            {
                if (ic != null) ic.Dispose();
            }
        }

        /// <summary>
        ///     Metode som henter ut kommando og verdi fra siste innsendte e-post og gjør endringer eller sender svar deretter. (sendMail.sendToOne)
        /// </summary>
        public static void GetCommand()
        {
            int intvalue = 0;
            string loggerInfo;
            bool success = true;

            const string ugyldig = "Du har oppgitt en ugyldig kommando, send \"HLP 0\" for liste over kommandoer.";
            //innhold i mail som sendes ved feil i kommando. 

            Body = Body.TrimEnd('\r', '\n'); //Fjerner eventuelle linjeskift fra slutten av mailen.
            if (Body.Length > 3)
            {
                string command = Body.Substring(0, 3);
                int length = Body.Length;
                string value = Body.Substring(3, Convert.ToInt32(length - 3));
                value = value.Trim();
                //Henter ut resten av mailen, med unntak av "blanke felt" (mellomrom) på begynnelsen og slutten av det gjenværende innholdet (uten de 3 første tegnene).
                try
                {
                    intvalue = Convert.ToInt32(value);
                }
                catch (Exception ex)
                    //Hvis den siste delen av mailen ikke inneholder kun et heltall, leses det som en feil kommando og sendes svar og error deretter. 
                {
                    loggerInfo = "Har mottatt en ugyldig kommando på mail fra " + From;
                    Logger.Error(ex, Module);
                    Logger.Info(loggerInfo, Module);
                    SendMail.SendToOne("Ugyldig kommando", ugyldig, From);
                    success = false;
                }
                if (success)
                {
                    string response;
                    switch (command)
                    {
                        case "STP":
                            //E-mail kommando for endring av setpunkt. Endrer bare dersom verdien er mellom 0 og 100. Sender svar om endring er gjort eller ikke.
                            if (intvalue < 0)
                            {
                                response =
                                    "Setpunktet kan ikke være mindre enn null, setpunktet forblir på siste verdi som er " +
                                    Convert.ToString(Regulation.Setpoint);
                                SendMail.SendToOne("Feil i endring av setpunkt", response, From);
                                loggerInfo =
                                    "Setpunktet har blitt forsøkt endret til en verdi utenfor grensene (0-100) ved e-mail kommando fra " +
                                    From + " setpunktet forblir uendret.";
                            }
                            else if (intvalue > 100)
                            {
                                response =
                                    "Setpunktet kan ikke være høyere enn 100, setpunktet forblir på siste verdi som er " +
                                    Convert.ToString(Regulation.Setpoint);
                                SendMail.SendToOne("Feil i endring av setpunkt", response, From);
                                loggerInfo =
                                    "Setpunktet har blitt forsøkt endret til en verdi utenfor grensene (0-100) ved e-mail kommando fra " +
                                    From + " setpunktet forblir uendret.";
                            }
                            else
                            {
                                Regulation.Setpoint = intvalue;
                                Settings.Default.setpoint = intvalue;
                                response = "Setpunktet har blitt endret til " + Convert.ToString(Regulation.Setpoint);
                                loggerInfo = "Setpunktet har blitt endret til " + Convert.ToString(Regulation.Setpoint) +
                                             " ved e-mail kommando fra " + From + ".";
                                SendMail.SendToOne("Endring av setpunkt", response, From);
                            }
                            Logger.Info(loggerInfo, Module);
                            break;
                        case "INT":
                            //E-mail kommando for endring av måleinterval. Endrer bare dersom verdien er mellom 1 og 999. Sender svar om endring er gjort eller ikke.
                            if (intvalue < 1)
                            {
                                response =
                                    "Måleintervallet kan ikke være mindre enn 1, intervallet forblir på siste verdi som er " +
                                    Convert.ToString(SensorCom.MesInterval);
                                SendMail.SendToOne("Feil i endring av måleinterval", response, From);
                                loggerInfo =
                                    "Måleintervallet har blitt forsøkt endret til en verdi utenfor grensene (1-999) ved e-mail kommando fra " +
                                    From + " måleintervallet forblir uendret.";

                                Logger.Info(loggerInfo, Module);
                                break;
                            }
                            
                            if (intvalue > 999)
                            {
                                response =
                                    "Måleintervallet kan ikke være høyere enn 999, intervallet forblir på siste verdi som er " +
                                    Convert.ToString(SensorCom.MesInterval);
                                SendMail.SendToOne("Feil i endring av måleinterval", response, From);
                                loggerInfo =
                                    "Måleintervallet har blitt forsøkt endret til en verdi utenfor grensene (1-999) ved e-mail kommando fra " +
                                    From + " måleintervallet forblir uendret.";
                            }
                            else
                            {
                                SensorCom.MesInterval = intvalue;
                                Settings.Default.mesInterval = intvalue;
                                response = "Måleintervallet har blitt endret til " +
                                           Convert.ToString(SensorCom.MesInterval);
                                loggerInfo = "Måleintervallet har blitt endret til " +
                                             Convert.ToString(SensorCom.MesInterval) + " ved e-mail kommando fra " +
                                             From + ".";
                                SendMail.SendToOne("Endring av måleinterval", response, From);
                            }
                            Logger.Info(loggerInfo, Module);
                            break;
                        case "STS":
                            //E-mail kommando for å få status sendt på mail.

                            string alarm = Convert.ToString(SensorCom.AlarmLimit);
                            string interval = Convert.ToString(SensorCom.MesInterval);
                            string time = GuiForm.LastRt;
                            string temp = GuiForm.LastR;
                            string statusDt = GuiForm.StsStatus;
                            if (GuiForm.Test == false)
                                //Regulering er ikke aktivert. Inneholder ikke variablene som har med regulering å gjøre. 
                            {
                                response = statusDt + "\r\n\r\n Siste Avlesning:" + time + " \r\nTemperatur: " + temp +
                                           "\r\nAlarmgrense: " + alarm + "\r\nMåleinterval: " + interval;
                            }
                            else //Regulering er aktivert. Inneholder også variablene som har med regulering å gjøre. 
                            {
                                string setpoint = Convert.ToString(Regulation.Setpoint);
                                string tolerance = Convert.ToString(Regulation.Tolerance);
                                response = statusDt + "\r\n\r\n Siste Avlesning: " + time + " \r\nTemperatur: " + temp +
                                           "\r\nAlarmgrense: " + alarm + "\r\nMåleinterval: " + interval +
                                           "\r\nSetpunkt: " +
                                           setpoint + "\r\nToleranse: " + tolerance;
                            }
                            loggerInfo = From + " har send kommando for å få tilsendt status.";
                            Logger.Info(loggerInfo, Module);
                            SendMail.SendToOne("Status", response, From);
                            break;
                        case "TLR":
                            //E-mail kommando for endring av toleranse. Endrer bare dersom verdien er mellom 0 og 20. Sender svar om endring er gjort eller ikke.
                            if (intvalue < 0)
                            {
                                response =
                                    "Toleransen kan ikke være mindre enn null, toleransen forblir på siste verdi som er " +
                                    Convert.ToString(Regulation.Tolerance);
                                loggerInfo =
                                    "Toleransen har blitt forsøkt endret til en verdi utenfor grensene (1-999) ved e-mail kommando fra " +
                                    From + " toleransen forblir uendret.";
                                Logger.Info(loggerInfo, Module);
                                SendMail.SendToOne("Feil i endring av toleranse", response, From);
                            }
                            else if (intvalue > 20)
                            {
                                response =
                                    "Toleransen kan ikke være høyere enn 20, toleransen forblir på siste verdi som er " +
                                    Convert.ToString(Regulation.Tolerance);
                                loggerInfo =
                                    "Toleransen har blitt forsøkt endret til en verdi utenfor grensene (1-999) ved e-mail kommando fra " +
                                    From + " toleransen forblir uendret.";
                                Logger.Info(loggerInfo, Module);
                                SendMail.SendToOne("Feil i endring av toleranse", response, From);
                            }
                            else
                            {
                                Regulation.Tolerance = intvalue;
                                Settings.Default.tolerance = intvalue;
                                response = "Toleransen har blitt endret til " + Convert.ToString(Regulation.Tolerance);
                                loggerInfo = "Toleransen har blitt endret til " + Convert.ToString(Regulation.Tolerance) +
                                             " ved e-mail kommando fra " + From + ".";
                                Logger.Info(loggerInfo, Module);
                                SendMail.SendToOne("Endring av toleranse", response, From);
                            }
                            break;
                        case "ALG":
                            //E-mail kommando for endring av alarmgrense. Endrer bare dersom verdien er mellom 0 og 100. Sender svar om endring er gjort eller ikke.
                            if (intvalue < 0)
                            {
                                response =
                                    "Alarmgrensen kan ikke være mindre enn null, Alarmgrensen forblir på siste verdi som er " +
                                    Convert.ToString(Regulation.Setpoint);
                                loggerInfo =
                                    "Alarmgrensen har blitt forsøkt endret til en verdi utenfor grensene (1-999) ved e-mail kommando fra " +
                                    From + " alarmgrensen forblir uendret.";
                                SendMail.SendToOne("Feil i endring av alarmgrensen", response, From);
                            }
                            else if (intvalue > 100)
                            {
                                response =
                                    "Alarmgrensen kan ikke være høyere enn 100, alarmgrensen forblir på siste verdi som er " +
                                    Convert.ToString(Regulation.Setpoint);
                                loggerInfo =
                                    "Alarmgrensen har blitt forsøkt endret til en verdi utenfor grensene (1-999) ved e-mail kommando fra " +
                                    From + " alarmgrensen forblir uendret.";
                                SendMail.SendToOne("Feil i endring av alarmgrensen", response, From);
                            }
                            else
                            {
                                SensorCom.AlarmLimit = intvalue;
                                Settings.Default.alarmLimit = intvalue;
                                response = "Alarmgrensen har blitt endret til " + Convert.ToString(SensorCom.AlarmLimit);
                                loggerInfo = "Alarmgrensen har blitt endret til " +
                                             Convert.ToString(SensorCom.AlarmLimit) + " ved e-mail kommando fra " + From +
                                             ".";
                                SendMail.SendToOne("Endring av alarmgrense", response, From);
                            }
                            Logger.Info(loggerInfo, Module);
                            break;
                        case "HLP":
                            //E-mail kommando for å få returnert hjelp teksten. 
                            if (GuiForm.Test == false)
                                //Regulering er ikke aktivert. Inneholder ikke kommandoene som har med regulering å gjøre. 
                            {
                                response =
                                    "Kommandoer: \r\n\rINT [1-999]\tEndrer måleintervallet (tid i minutter)\r\n" +
                                    "STS 0\t\tReturnerer statusen til programmet." +
                                    "\r\nALG [0-100]\tEndrer alarmgrensen (temperatur i grader celcius)\r\n\r\nEksempel: \"ALG 10\" vil endre alarmgrensen til 10";
                            }
                            else //Regulering er aktivert. Inneholder også kommandoene som har med regulering å gjøre. 
                            {
                                response =
                                    "Kommandoer: \r\n\r\nSTP [0-100]\tEndrer setpunktet for reguleringen (temperatur i grader celcius)\r\nINT [1-999]\tEndrer måleintervallet (tid i minutter)\r\n" +
                                    "STS 0\t\tReturnerer statusen til programmet. \r\nTLR [0-20]\tEndrer toleransen for reguleringen (temperatur i grader celcius)" +
                                    "\r\nALG [0-100]\tEndrer alarmgrensen (temperatur i grader celcius)\r\n\r\nEksempel: \"STP 25\" vil endre setpunktet til 25";
                            }
                            loggerInfo = From + " har sendt kommando for å få tilsendt hjelp teksten.";
                            Logger.Info(loggerInfo, Module);
                            SendMail.SendToOne("Hjelp", response, From);
                            break;
                        case "LOG":
                            //E-mail kommando for uthenting av siste logg.
                            FileStream fs = null;
                            try
                            {
                                fs = new FileStream(Logger.CurrentLog, FileMode.Open, FileAccess.Read,
                                                    FileShare.ReadWrite);
                                using (var sr = new StreamReader(fs))
                                {
                                    fs = null;
                                    response = sr.ReadToEnd();
                                    loggerInfo = From + " har sendt kommando for å få tilsendt log.";
                                    Logger.Info(loggerInfo, Module);
                                    SendMail.SendToOne("Logg", response, From);
                                }
                            }
                            finally
                            {
                                if (fs != null)
                                    fs.Dispose();
                            }
                            break;
                        default:
                            loggerInfo = "Har mottatt en ugyldig kommando på mail fra " + From;
                            Logger.Info(loggerInfo, Module);
                            SendMail.SendToOne("Ugyldig kommando", ugyldig, From);
                            break;
                    }
                    Settings.Default.Save(); //Lagrer verdiene som har blitt endret i settings. 
                    GuiForm.Settingsupdate = true; //Forteller GUI at det er gjort endringer. 
                }
            }
            else //Feilrutine dersom mailen ikke inneholder minst 3 tegn.
            {
                loggerInfo = "Har mottatt en ugyldig kommando på mail fra " + From;
                Logger.Info(loggerInfo, Module);
                SendMail.SendToOne("Ugyldig kommando", ugyldig, From);
            }
            From = null;
            Subject = null;
            Body = null;
        }
    }
}