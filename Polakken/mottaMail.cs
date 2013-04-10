﻿using System;
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

       public static void getCommand()
       {
           string error; //feilmeldingen, logges som alt annet. 
           string result = ""; //alle tilfeller av result byttes ut med tilhørende kommandoer. 
           //innhold = "INT 55\r\n"; //hentes inn fra mail, bør byttes ut overalt med den stringen. 
           int length;
           string command;
           string value;
           string response;
           int intvalue = 0;
           bool success = true;

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
                   error = ex.ToString();
                   result = "ugyldig commando";
                   success = false;
               }
               if (success == true)
               {
                   switch (command)
                   {
                       case "STP":
                           Regulation.setpoint = intvalue;
                           response = "Setpunktet har blitt endret til " + Convert.ToString(Regulation.setpoint);
                           E_mail_handler.sendToOne("Endring av setpunkt", response, fra);
                           break;
                       case "INT":
                           SensorCom.mesInterval = intvalue;
                           response = "Måleintervallet har blitt endret til " + Convert.ToString(SensorCom.mesInterval);
                           E_mail_handler.sendToOne("Endring av Måleinterval", response, fra);
                           break;
                       case "STS":
                           result = "status";
                           break;
                       case "TLR":
                           Regulation.tolerance = intvalue;
                           response = "Toleransen har blitt endret til " + Convert.ToString(Regulation.tolerance);
                           E_mail_handler.sendToOne("Endring av toleranse", response, fra);
                           break;
                       case "ALG":
                           SensorCom.alarmGrense = intvalue;
                           response = "Alarmgrensen har blitt endret til " + Convert.ToString(SensorCom.alarmGrense);
                           E_mail_handler.sendToOne("Endring av toleranse", response, fra);
                           break;
                       case "HLP":
                           result = "hjelp";
                           break;
                       default:
                           result = "ugyldig commando";
                           break;
                   }
               }
           }
           else
           {
               result = "ugyldig commando";
           }
       }
    }
}
