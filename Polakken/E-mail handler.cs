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
    static class E_mail_handler
    {
        private static string email = "republicofprogrammers@gmail.com";
        private static string password = "polakken";
        private static string module = "E-mail handler";

        public static  SmtpClient client = new SmtpClient("smtp.gmail.com", 587) //Lager en ny SmtpClient med host-navn og port
         {
             Credentials = new NetworkCredential(email, password), //Login-informasjon for emailen vi sender fra
             EnableSsl = true //Legger til sikkerhetslaget Ssl
         };

        //Metode som sender mail til alle som er oppført i databasen
        public static void sendToAll(string subject, string body)
        {
            try
            {
                GUI gui = new GUI();


                DataTable sendEmail = new DataTable();
                gui.GetEmail(sendEmail);

                string mailTil;

                foreach (DataRow dtRow in sendEmail.Rows)
                {
                    mailTil = dtRow["Adresser"].ToString();
                    client.Send(email, mailTil, subject, body);
                    Logger.Info("Sendt email til alle mottakere." ,module);
                }
            }

            catch (Exception ex)
            {
                Logger.Error(ex, module);
            }
        }

        //Metode som bare sender mail til en person
        public static void sendToOne(string subject, string body, string mailAdress)
        {
            try
            {
                client.Send(email, mailAdress, subject, body);
                Logger.Info("Sendt email til " + mailAdress + ".", module);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, module);
            }
        }
    }
}