using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AE.Net.Mail;
using System.Text.RegularExpressions;

namespace Polakken
{
    class MottaMail
    {
       public static string StripHTML(string inputString)
        {
            const string HTML_TAG_PATTERN = "<.*?>";
            return Regex.Replace
              (inputString, HTML_TAG_PATTERN, string.Empty);
        }

       public static string fra { get; set; }
       public static string emne { get; set; }
       public static string innhold { get; set; }
       private static string module = "mottaMail";

       public static void mottaMail()
       {
           try
           {

               ImapClient ic = new ImapClient("imap.gmail.com", "republicofprogrammers@gmail.com", "polakken",
                    ImapClient.AuthMethods.Login, 993, true);
               ic.SelectMailbox("INBOX");
               MailMessage[] mail = ic.GetMessages(0, 100000000, false);
               fra = Convert.ToString(mail[mail.Length-1].From);
               emne = Convert.ToString(mail[mail.Length-1].Subject);
               innhold = Convert.ToString(StripHTML(mail[mail.Length-1].BodyHtml));
               ic.Dispose();
           }

           catch (Exception ex)
           {
               Logger.Error(ex, "mottaMail");
           }

           

       }

       public static string help()
       {
           string help = "";

           help = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\..\\..\\Resources\\hjelpPolakken.txt");

           return help;
       }

       public static void getCommand()
       {
           string status = ""; 
           //innhold = "INT 55\r\n"; //hentes inn fra mail, bør byttes ut overalt med den stringen. 
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
                           Regulation.setpoint = intvalue;
                           response = "Setpunktet har blitt endret til " + Convert.ToString(Regulation.setpoint);
                           E_mail_handler.sendToOne("Endring av setpunkt", response, fra);
                           break;
                       case "INT":
                           //E-mail kommando for endring av måleinterval. 
                           SensorCom.mesInterval = intvalue;
                           response = "Måleintervallet har blitt endret til " + Convert.ToString(SensorCom.mesInterval);
                           E_mail_handler.sendToOne("Endring av måleinterval", response, fra);
                           break;
                       case "STS":
                           //E-mail kommando for å få status sendt på mail. 
                           string temp = Convert.ToString(Math.Round(SensorCom.temp(), 0));
                           string alarm = Convert.ToString(SensorCom.alarmLimit);
                           string interval = Convert.ToString(SensorCom.mesInterval);
                           DateTime now = DateTime.Now;
                           string time = now.ToString();
                            
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
                           Regulation.tolerance = intvalue;
                           response = "Toleransen har blitt endret til " + Convert.ToString(Regulation.tolerance);
                           E_mail_handler.sendToOne("Endring av toleranse", response, fra);
                           break;
                       case "ALG":
                           //E-mail kommando for endring av alarmgrense.
                           SensorCom.alarmLimit = intvalue;
                           response = "Alarmgrensen har blitt endret til " + Convert.ToString(SensorCom.alarmLimit);
                           E_mail_handler.sendToOne("Endring av alarmgrense", response, fra);
                           break;
                       case "HLP":
                           //E-mail kommando for å få tilsendt hjelp teksten. 
                           response = help();
                           E_mail_handler.sendToOne("Help", response, fra);
                           break;
                       default:
                           E_mail_handler.sendToOne("Ugyldig kommando", ugyldig, fra);
                           break;
                   }
               }
           }
           else
           {
               E_mail_handler.sendToOne("Ugyldig kommando", ugyldig, fra);
           }
       }
    }
}
