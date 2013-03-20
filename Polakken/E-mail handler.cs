using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace Polakken
{
    class E_mail_handler
    {
        public SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
         {
             Credentials = new NetworkCredential("republicofprogrammers@gmail.com", "polakken"),
             EnableSsl = true
         };

        public void send(string til)
        {
                
            client.Send("republicofprogrammers@gmail.com", til, "Hei", "Hei");
            


        }

    }
}