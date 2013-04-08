using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Data;

namespace Polakken
{
    class E_mail_handler
    {
        public SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
         {
             Credentials = new NetworkCredential("republicofprogrammers@gmail.com", "polakken"),
             EnableSsl = true
         };



        


        public void nyTabell()
        {
            GUI piss = new GUI();

            DataTable sendEmail = new DataTable();
            piss.GetEmail(sendEmail);

            string mailTil;

            // on all table's rows
            foreach (DataRow dtRow in sendEmail.Rows)
            {
                mailTil = dtRow["Adresser"].ToString();
                client.Send("republicofprogrammers@gmail.com", mailTil, "Hei", "Hei");
            }
        }

    }
}