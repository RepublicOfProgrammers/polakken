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
            try
            {
                //Lager nytt objekt av klassen ImapClient
                ImapClient ic = new ImapClient(host, username, password,
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
                ic.Dispose();
            }

            catch (Exception ex)
            {
                Logger.Error(ex, "mottaMail");
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
                            }
                            else if (intvalue > 100)
                            {
                                response = "Setpunktet kan ikke være høyere enn 100, setpunktet forblir på siste verdi som er " + Convert.ToString(Regulation.setpoint);
                                E_mail_handler.sendToOne("Feil i endring av setpunkt", response, from);
                            }
                            else
                            {
                                Regulation.setpoint = intvalue;
                                Settings.Default.setpoint = intvalue;
                                response = "Setpunktet har blitt endret til " + Convert.ToString(Regulation.setpoint);
                                E_mail_handler.sendToOne("Endring av setpunkt", response, from);
                            }
                            break;
                        case "INT":
                            //E-mail kommando for endring av måleinterval. 
                            if (intvalue < 1)
                            {
                                response = "Måleintervallet kan ikke være mindere enn 1, intervallet forblir på siste verdi som er " + Convert.ToString(SensorCom.mesInterval);
                                E_mail_handler.sendToOne("Feil i endring av måleinterval", response, from);
                            }
                            else
                            {
                                SensorCom.mesInterval = intvalue;
                                Settings.Default.mesInterval = intvalue;
                                response = "Måleintervallet har blitt endret til " + Convert.ToString(SensorCom.mesInterval);
                                E_mail_handler.sendToOne("Endring av måleinterval", response, from);
                            }
                            break;
                        case "STS":
                            //E-mail kommando for å få status sendt på mail. 

                            string alarm = Convert.ToString(SensorCom.alarmLimit);
                            string interval = Convert.ToString(SensorCom.mesInterval);
                            string time = GUI.LastRT;
                            string temp = GUI.lastR;
                            string statusDT = GUI.stsStatus;
                            if (GUI.test == false)
                            {
                                response = statusDT + "\r\n\r\n Siste Avlesning:" + time + " \r\nTemperatur: " + temp + "\r\nAlarmgrense: " + alarm + "\r\nMåleinterval: " + interval;
                            }
                            else
                            {
                                string setpoint = Convert.ToString(Regulation.setpoint);
                                string tolerance = Convert.ToString(Regulation.tolerance);
                                response = statusDT + "\r\n\r\n Siste Avlesning: " + time + " \r\nTemperatur: " + temp + "\r\nAlarmgrense: " + alarm + "\r\nMåleinterval: " + interval + "\r\nSetpunkt: " +
                                    setpoint + "\r\nToleranse: " + tolerance;
                            }
                            E_mail_handler.sendToOne("Status", response, from);
                            break;
                        case "TLR":
                            //E-mail kommando for endring av toleranse. 
                            if (intvalue < 0)
                            {
                                response = "Toleransen kan ikke være mindere enn null, toleransen forblir på siste verdi som er " + Convert.ToString(Regulation.tolerance);
                                E_mail_handler.sendToOne("Feil i endring av toleranse", response, from);
                            }
                            if (intvalue > 20)
                            {
                                response = "Toleransen kan ikke være høyere enn 20, toleransen forblir på siste verdi som er " + Convert.ToString(Regulation.tolerance);
                                E_mail_handler.sendToOne("Feil i endring av toleranse", response, from);
                            }
                            else
                            {
                                Regulation.tolerance = intvalue;
                                Settings.Default.tolerance = intvalue;
                                response = "Toleransen har blitt endret til " + Convert.ToString(Regulation.tolerance);
                                E_mail_handler.sendToOne("Endring av toleranse", response, from);
                            }
                            break;
                        case "ALG":
                            //E-mail kommando for endring av alarmgrense.
                            if (intvalue < 0)
                            {
                                response = "Alarmgrensen kan ikke være mindere enn null, Alarmgrensen forblir på siste verdi som er " + Convert.ToString(Regulation.setpoint);
                                E_mail_handler.sendToOne("Feil i endring av alarmgrensen", response, from);
                            }
                            else if (intvalue > 100)
                            {
                                response = "Alarmgrensen kan ikke være høyere enn 100, alarmgrensen forblir på siste verdi som er " + Convert.ToString(Regulation.setpoint);
                                E_mail_handler.sendToOne("Feil i endring av alarmgrensen", response, from);
                            }
                            else
                            {
                                SensorCom.alarmLimit = intvalue;
                                Settings.Default.alarmLimit = intvalue;
                                response = "Alarmgrensen har blitt endret til " + Convert.ToString(SensorCom.alarmLimit);
                                E_mail_handler.sendToOne("Endring av alarmgrense", response, from);
                            }
                            break;
                        case "HLP":
                            //E-mail kommando for å få tilsendt hjelp teksten. 
                            //response = help();
                            //Stream stream = Assembly.GetExecutingAssembly()
                            //                              .GetManifestResourceStream("Polakken.hjelpPolakken.txt");
                            //using (StreamReader reader = new StreamReader(stream))
                            //{
                            //    string result = reader.ReadToEnd();
                            //}
                            //Assembly _assembly;
                            //StreamReader _textStreamReader;

                            //_assembly = Assembly.GetExecutingAssembly();
                            //_textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("Polakken.hjelpPolakken.txt"));
                            if (GUI.test == false)
                            {
                                response = "Kommandoer: \r\n\rINT [1-999]\tEndrer måleintervallet i minutter\r\n" +
                                    "STS 0\tFår opp statusen til programmet." +
                                    "\r\nALG [0-100]\tEndrer alarmgrensen\r\n\r\nEksempel: \"ALG 10\" vil endre alarmgrensen til 10";
                            }
                            else
                            {
                                response = "Kommandoer: \r\n\r\nSTP [0-100]\tEndrer setpunktet for temperaturen\r\nINT [1-999]\tEndrer måleintervallet i minutter\r\n" +
                                    "STS 0\tFår opp statusen til programmet. \r\nTLR [0-20]\tEndrer toleransen over hvor mye temperaturen kan avvike" +
                                    "\r\nALG [0-100]\tEndrer alarmgrensen\r\n\r\nEksempel: \"STP 25\" vil endre setpunktet til 25\r\n\r\nSetpunkt og Toleranse er bare i bruk " +
                                    "dersom regulering av temperatur er implementert.";
                            }
                            break;
                        case "LOG":
                            //E-mail kommando for uthenting av siste logg.
                            var fs = new FileStream(Logger.currentLog, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                            using (var sr = new StreamReader(fs))
                            {
                                response = sr.ReadToEnd();
                                E_mail_handler.sendToOne("Logg", response, from);
                            }
                            break;
                        default:
                            E_mail_handler.sendToOne("Ugyldig kommando", ugyldig, from);
                            break;
                    }
                    Settings.Default.Save();
                    GUI.settingsupdate = true;
                }
            }
            else
            {
                E_mail_handler.sendToOne("Ugyldig kommando", ugyldig, from);
            }
            MottaMail.from = null;
            MottaMail.subject = null;
            MottaMail.body = null;
        }
    }
}
