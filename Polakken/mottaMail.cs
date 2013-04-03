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

       public static void mottaMail()
       {
           try
           {

               ImapClient ic = new ImapClient("imap.gmail.com", "republicofprogrammers@gmail.com", "polakken",
                    ImapClient.AuthMethods.Login, 993, true);
               ic.SelectMailbox("INBOX");
               MailMessage[] mail = ic.GetMessages(0, 10, false);
               fra = Convert.ToString(mail[0].From);
               emne = Convert.ToString(mail[0].Subject);
               innhold = Convert.ToString(StripHTML(mail[0].BodyHtml));
               ic.Dispose();
           }

           catch (Exception)
           {

           }

       }
    }
}
