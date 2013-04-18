﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AE.Net.Mail;
using System.Text.RegularExpressions;
using System.IO;
using Polakken.Properties;

namespace Polakken
{
    class MottaMail
    {
        GUI gui = new GUI();
        public static string fra { get; set; }
        public static string emne { get; set; }
        public static string innhold { get; set; }
        private static string module = "mottaMail";
        public static void mottaMail()
        {
            //Metode for å hente inn mail.
            try
            {
                ImapClient ic = new ImapClient("imap.gmail.com", "republicofprogrammers@gmail.com", "polakken",
                     ImapClient.AuthMethods.Login, 993, true);
                ic.SelectMailbox("INBOX");
                MailMessage[] mail = ic.GetMessages(0, 10000, false, true);
                //Lazy<MailMessage>[] mail = ic.SearchMessages(SearchCondition.Unseen(), false);
                if (mail.Length != 0)
                {
                    fra = mail[mail.Length - 1].From.Address;
                    emne = mail[mail.Length - 1].Subject;
                    innhold = mail[mail.Length - 1].Body;
                }
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


            string status = "";
            int length;
            string command;
            string value;
            string response;
            int intvalue = 0;
            bool success = true;

            string ugyldig = "Du har oppgitt en ugyldig kommando, send \"HLP 1\" for liste over kommandoer eller \"HLP 0\" for hele hjelp filen";

            innhold = innhold.TrimEnd('\r', '\n');
            if (innhold.Length > 3)
            {
                command = innhold.Substring(0, 3);
                length = innhold.Length;
                value = innhold.Substring(3, Convert.ToInt32(length - 3));
                value = value.Trim();
                try
                {
                    intvalue = Convert.ToInt32(value);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, module);
                    E_mail_handler.sendToOne("Ugyldig kommando", ugyldig, fra);
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
                                E_mail_handler.sendToOne("Feil i endring av setpunkt", response, fra);
                            }
                            else if (intvalue > 100)
                            {
                                response = "Setpunktet kan ikke være høyere enn 100, setpunktet forblir på siste verdi som er " + Convert.ToString(Regulation.setpoint);
                                E_mail_handler.sendToOne("Feil i endring av setpunkt", response, fra);
                            }
                            else if (intvalue > 0)
                            {
                                Regulation.setpoint = intvalue;
                                Settings.Default.setpoint = intvalue;
                                response = "Setpunktet har blitt endret til " + Convert.ToString(Regulation.setpoint);
                                E_mail_handler.sendToOne("Endring av setpunkt", response, fra);
                            }
                            break;
                        case "INT":
                            //E-mail kommando for endring av måleinterval. 
                            if (intvalue < 0)
                            {
                                response = "Måleintervallet kan ikke være mindere enn null, intervallet forblir på siste verdi som er " + Convert.ToString(SensorCom.mesInterval);
                                E_mail_handler.sendToOne("Feil i endring av måleinterval", response, fra);
                            }
                            else
                            {
                                SensorCom.mesInterval = intvalue;
                                Settings.Default.mesInterval = intvalue;
                                response = "Måleintervallet har blitt endret til " + Convert.ToString(SensorCom.mesInterval);
                                E_mail_handler.sendToOne("Endring av måleinterval", response, fra);
                            }
                            break;
                        case "STS":
                            //E-mail kommando for å få status sendt på mail. 
                            //string temp = Convert.ToString(Math.Round(SensorCom.temp(), 0));



                            string alarm = Convert.ToString(SensorCom.alarmLimit);
                            string interval = Convert.ToString(SensorCom.mesInterval);
                            DateTime now = DateTime.Now;
                            string time = now.ToString();
                            string temp = GUI.lastR;
                            if (GUI.test == false)
                            {
                                status = "Status " + time + " :\r\nTemperatur: " + temp + "\r\nAlarmgrense: " + alarm + "\r\nMåleinterval: " + interval;
                            }
                            else
                            {
                                string setpoint = Convert.ToString(Regulation.setpoint);
                                string tolerance = Convert.ToString(Regulation.tolerance);
                                status = "Status " + time + " :\r\nTemperatur: " + temp + "\r\nAlarmgrense: " + alarm + "\r\nMåleinterval: " + interval + "\r\nSetpunkt: " +
                                    setpoint + "\r\nToleranse: " + tolerance;
                            }
                            E_mail_handler.sendToOne("Status", status, fra);
                            break;
                        case "TLR":
                            //E-mail kommando for endring av toleranse. 
                            if (intvalue < 0)
                            {
                                response = "Toleransen kan ikke være mindere enn null, toleransen forblir på siste verdi som er " + Convert.ToString(Regulation.tolerance);
                                E_mail_handler.sendToOne("Feil i endring av toleranse", response, fra);
                            }
                            else
                            {
                                Regulation.tolerance = intvalue;
                                Settings.Default.tolerance = intvalue;
                                response = "Toleransen har blitt endret til " + Convert.ToString(Regulation.tolerance);
                                E_mail_handler.sendToOne("Endring av toleranse", response, fra);
                            }
                            break;
                        case "ALG":
                            //E-mail kommando for endring av alarmgrense.
                            SensorCom.alarmLimit = intvalue;
                            Settings.Default.alarmLimit = intvalue;
                            response = "Alarmgrensen har blitt endret til " + Convert.ToString(SensorCom.alarmLimit);
                            E_mail_handler.sendToOne("Endring av alarmgrense", response, fra);
                            break;
                        case "HLP":
                            //E-mail kommando for å få tilsendt hjelp teksten. 
                            response = help();
                            E_mail_handler.sendToOne("Help", response, fra);
                            break;
                        case "LOG":
                            //E-mail kommando for uthenting av siste logg.
                            var fs = new FileStream(Logger.currentLog, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                            using (var sr = new StreamReader(fs))
                            {
                                response = sr.ReadToEnd();
                                E_mail_handler.sendToOne("Logg", response, fra);
                            }
                            break;
                        default:
                            E_mail_handler.sendToOne("Ugyldig kommando", ugyldig, fra);
                            break;
                    }
                    GUI.settingsupdate = true;
                }
            }
            else
            {
                E_mail_handler.sendToOne("Ugyldig kommando", ugyldig, fra);
            }
            MottaMail.fra = null;
            MottaMail.emne = null;
            MottaMail.innhold = null;
        }
    }
}
