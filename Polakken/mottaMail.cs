using System;
using AE.Net.Mail;
using System.IO;
using Polakken.Properties;
using System.Reflection;

namespace Polakken
{
    class MottaMail
    {
        private static string host = "imap.gmail.com";
        private static string username = "republicofprogrammers@gmail.com";
        private static string password = "polakken";
        private static int port = 993;
        private static bool secure = true;
        public static string from { get; private set; }
        public static string subject { get; private set; }
        public static string body { get; private set; }
        private static string module = "mottaMail";

        //Metode for å hente inn mail
        public static void mottaMail()
        {
            ImapClient ic = null;
            try
            {
                //Lager nytt objekt av klassen ImapClient
                ic = new ImapClient(host, username, password,
                     ImapClient.AuthMethods.Login, port, secure);
                ic.SelectMailbox("INBOX");
                //Array som henter inn alle mail i innboksen
                MailMessage[] mail = ic.GetMessages(0, 1, false, true);
                //If-setning som sjekker om det er mail i innboksen
                if (mail.Length != 0)
                {
                    //Tre variabler som henter ut informasjon fra den siste motatte mailen
                    from = mail[mail.Length - 1].From.Address;
                    subject = mail[mail.Length - 1].Subject;
                    body = mail[mail.Length - 1].Body;
                }
                //Løkke som sletter alle mail etter den har hentet inn den siste
                foreach (MailMessage m in mail)
                {
                    ic.DeleteMessage(m);
                }
            }


            catch (Exception ex)
            {
                Logger.Error(ex, "mottaMail");
            }

            finally
            {
                ic.Dispose();
            }
        }

        public static string help()
        //Leser teksfila fra den angitte banen og returnerer den som string
        {
            string help = "";

            help = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\..\\..\\Resources\\hjelpPolakken.txt");

            return help;
        }

        public static void getCommand()
        {
            int length;
            string command;
            string value;
            string response;
            int intvalue = 0;
            string loggerInfo;
            bool success = true;

            string ugyldig = "Du har oppgitt en ugyldig kommando, send \"HLP 1\" for liste over kommandoer eller \"HLP 0\" for hele hjelp filen";

            body = body.TrimEnd('\r', '\n');
            if (body.Length > 3)
            {
                command = body.Substring(0, 3);
                length = body.Length;
                value = body.Substring(3, Convert.ToInt32(length - 3));
                value = value.Trim();
                try
                {
                    intvalue = Convert.ToInt32(value);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, module);
                    E_mail_handler.sendToOne("Ugyldig kommando", ugyldig, from);
                    success = false;
                }
                if (success == true)
                {
                    switch (command)
                    {
                        case "STP":
                            //E-mail kommando for endring av setpunkt. 
                            if (intvalue < 0)
                            {
                                response = "Setpunktet kan ikke være mindere enn null, setpunktet forblir på siste verdi som er " + Convert.ToString(Regulation.setpoint);
                                E_mail_handler.sendToOne("Feil i endring av setpunkt", response, from);
                                loggerInfo = "Setpunktet har blitt forsøkt endret til en verdi utenfor grensene (0-100) ved e-mail kommando fra " + from + " setpunktet forblir uendret.";
                            }
                            else if (intvalue > 100)
                            {
                                response = "Setpunktet kan ikke være høyere enn 100, setpunktet forblir på siste verdi som er " + Convert.ToString(Regulation.setpoint);
                                E_mail_handler.sendToOne("Feil i endring av setpunkt", response, from);
                                loggerInfo = "Setpunktet har blitt forsøkt endret til en verdi utenfor grensene (0-100) ved e-mail kommando fra " + from + " setpunktet forblir uendret.";
                            }
                            else
                            {
                                Regulation.setpoint = intvalue;
                                Settings.Default.setpoint = intvalue;
                                response = "Setpunktet har blitt endret til " + Convert.ToString(Regulation.setpoint);
                                loggerInfo = "Setpunktet har blitt endret til " + Convert.ToString(Regulation.setpoint) + " ved e-mail kommando fra " + from + ".";
                                E_mail_handler.sendToOne("Endring av setpunkt", response, from);
                            }
                            Logger.Info(loggerInfo, module);
                            break;
                        case "INT":
                            //E-mail kommando for endring av måleinterval. 
                            if (intvalue < 1)
                            {
                                response = "Måleintervallet kan ikke være mindere enn 1, intervallet forblir på siste verdi som er " + Convert.ToString(SensorCom.mesInterval);
                                E_mail_handler.sendToOne("Feil i endring av måleinterval", response, from);
                                loggerInfo = "Måleintervallet har blitt forsøkt endret til en verdi utenfor grensene (1-999) ved e-mail kommando fra " + from + " måleintervallet forblir uendret.";
                            }
                            if (intvalue > 999)
                            {
                                response = "Måleintervallet kan ikke være høyere enn 999, intervallet forblir på siste verdi som er " + Convert.ToString(SensorCom.mesInterval);
                                E_mail_handler.sendToOne("Feil i endring av måleinterval", response, from);
                                loggerInfo = "Måleintervallet har blitt forsøkt endret til en verdi utenfor grensene (1-999) ved e-mail kommando fra " + from + " måleintervallet forblir uendret.";
                            }
                            else
                            {
                                SensorCom.mesInterval = intvalue;
                                Settings.Default.mesInterval = intvalue;
                                response = "Måleintervallet har blitt endret til " + Convert.ToString(SensorCom.mesInterval);
                                loggerInfo = "Måleintervallet har blitt endret til " + Convert.ToString(Regulation.setpoint) + " ved e-mail kommando fra " + from + ".";
                                E_mail_handler.sendToOne("Endring av måleinterval", response, from);
                            }
                            Logger.Info(loggerInfo, module);
                            break;
                        case "STS":
                            //E-mail kommando for å få status sendt på mail. 

                            string alarm = Convert.ToString(SensorCom.alarmLimit);
                            string interval = Convert.ToString(SensorCom.mesInterval);
                            string time = GUI.LastRT;
                            string temp = GUI.lastR;
                            string statusDT = GUI.stsStatus;
                            if (GUI.test == false) //Regulering er ikke aktivert. Inneholder ikke variablene som har med regulering å gjøre. 
                            {
                                response = statusDT + "\r\n\r\n Siste Avlesning:" + time + " \r\nTemperatur: " + temp + "\r\nAlarmgrense: " + alarm + "\r\nMåleinterval: " + interval;
                            }
                            else //Regulering er aktivert. Inneholder også variablene som har med regulering å gjøre. 
                            {
                                string setpoint = Convert.ToString(Regulation.setpoint);
                                string tolerance = Convert.ToString(Regulation.tolerance);
                                response = statusDT + "\r\n\r\n Siste Avlesning: " + time + " \r\nTemperatur: " + temp + "\r\nAlarmgrense: " + alarm + "\r\nMåleinterval: " + interval + "\r\nSetpunkt: " +
                                    setpoint + "\r\nToleranse: " + tolerance;
                            }
                            loggerInfo = from + "har send kommando for å få tilsendt status.";
                            Logger.Info(loggerInfo, module);
                            E_mail_handler.sendToOne("Status", response, from);
                            break;
                        case "TLR":
                            //E-mail kommando for endring av toleranse. 
                            if (intvalue < 0)
                            {
                                response = "Toleransen kan ikke være mindere enn null, toleransen forblir på siste verdi som er " + Convert.ToString(Regulation.tolerance);
                                loggerInfo = "Toleransen har blitt forsøkt endret til en verdi utenfor grensene (1-999) ved e-mail kommando fra " + from + " toleransen forblir uendret.";
                                Logger.Info(loggerInfo, module);
                                E_mail_handler.sendToOne("Feil i endring av toleranse", response, from);
                            }
                            if (intvalue > 20)
                            {
                                response = "Toleransen kan ikke være høyere enn 20, toleransen forblir på siste verdi som er " + Convert.ToString(Regulation.tolerance);
                                loggerInfo = "Toleransen har blitt forsøkt endret til en verdi utenfor grensene (1-999) ved e-mail kommando fra " + from + " toleransen forblir uendret.";
                                Logger.Info(loggerInfo, module);
                                E_mail_handler.sendToOne("Feil i endring av toleranse", response, from);
                            }
                            else
                            {
                                Regulation.tolerance = intvalue;
                                Settings.Default.tolerance = intvalue;
                                response = "Toleransen har blitt endret til " + Convert.ToString(Regulation.tolerance);
                                loggerInfo = "Toleransen har blitt endret til " + Convert.ToString(Regulation.setpoint) + " ved e-mail kommando fra " + from + ".";
                                Logger.Info(loggerInfo, module);
                                E_mail_handler.sendToOne("Endring av toleranse", response, from);
                            }
                            break;
                        case "ALG":
                            //E-mail kommando for endring av alarmgrense.
                            if (intvalue < 0)
                            {
                                response = "Alarmgrensen kan ikke være mindere enn null, Alarmgrensen forblir på siste verdi som er " + Convert.ToString(Regulation.setpoint);
                                loggerInfo = "Alarmgrensen har blitt forsøkt endret til en verdi utenfor grensene (1-999) ved e-mail kommando fra " + from + " alarmgrensen forblir uendret.";
                                E_mail_handler.sendToOne("Feil i endring av alarmgrensen", response, from);
                            }
                            else if (intvalue > 100)
                            {
                                response = "Alarmgrensen kan ikke være høyere enn 100, alarmgrensen forblir på siste verdi som er " + Convert.ToString(Regulation.setpoint);
                                loggerInfo = "Alarmgrensen har blitt forsøkt endret til en verdi utenfor grensene (1-999) ved e-mail kommando fra " + from + " alarmgrensen forblir uendret.";
                                E_mail_handler.sendToOne("Feil i endring av alarmgrensen", response, from);
                            }
                            else
                            {
                                SensorCom.alarmLimit = intvalue;
                                Settings.Default.alarmLimit = intvalue;
                                response = "Alarmgrensen har blitt endret til " + Convert.ToString(SensorCom.alarmLimit);
                                loggerInfo = "Alarmgrensen har blitt endret til " + Convert.ToString(Regulation.setpoint) + " ved e-mail kommando fra " + from + ".";
                                E_mail_handler.sendToOne("Endring av alarmgrense", response, from);
                            }
                            Logger.Info(loggerInfo, module);
                            break;
                        case "HLP":
                            //E-mail kommando for å få returnert hjelp teksten. 
                            if (GUI.test == false) //Regulering er ikke aktivert. Inneholder ikke kommandoene som har med regulering å gjøre. 
                            {
                                response = "Kommandoer: \r\n\rINT [1-999]\tEndrer måleintervallet (tid i minutter)\r\n" +
                                    "STS 0\t\tReturnerer statusen til programmet." +
                                    "\r\nALG [0-100]\tEndrer alarmgrensen (temperatur i grader celcius)\r\n\r\nEksempel: \"ALG 10\" vil endre alarmgrensen til 10";
                            }
                            else //Regulering er aktivert. Inneholder også kommandoene som har med regulering å gjøre. 
                            {
                                response = "Kommandoer: \r\n\r\nSTP [0-100]\tEndrer setpunktet for reguleringen (temperatur i grader celcius)\r\nINT [1-999]\tEndrer måleintervallet (tid i minutter)\r\n" +
                                    "STS 0\t\tReturnerer statusen til programmet. \r\nTLR [0-20]\tEndrer toleransen for reguleringen (temperatur i grader celcius)" +
                                    "\r\nALG [0-100]\tEndrer alarmgrensen (temperatur i grader celcius)\r\n\r\nEksempel: \"STP 25\" vil endre setpunktet til 25";
                            }
                            loggerInfo = from + "har sendt kommando for å få tilsendt hjelp teksten.";
                            Logger.Info(loggerInfo, module);
                            E_mail_handler.sendToOne("Hjelp", response, from);
                            break;
                        case "LOG":
                            //E-mail kommando for uthenting av siste logg.
                            FileStream fs = null;
                            try
                            {
                                fs = new FileStream(Logger.currentLog, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                                using (var sr = new StreamReader(fs))
                                {
                                    fs = null;
                                    response = sr.ReadToEnd();
                                    loggerInfo = from + "har sendt kommando for å få tilsendt log.";
                                    Logger.Info(loggerInfo, module);
                                    E_mail_handler.sendToOne("Logg", response, from);
                                }
                            }
                            finally
                            {
                                if (fs != null)
                                    fs.Dispose();
                            }
                            break;
                        default:
                            loggerInfo = "Har mottatt en ugyldig kommando på mail fra " + from;
                            Logger.Info(loggerInfo, module);
                            E_mail_handler.sendToOne("Ugyldig kommando", ugyldig, from);
                            break;
                    }
                    Settings.Default.Save();
                    GUI.settingsupdate = true;
                }
            }
            else
            {
                loggerInfo = "";
                Logger.Info(loggerInfo, module);
                E_mail_handler.sendToOne("Ugyldig kommando", ugyldig, from);
            }
            MottaMail.from = null;
            MottaMail.subject = null;
            MottaMail.body = null;
        }
    }
}
