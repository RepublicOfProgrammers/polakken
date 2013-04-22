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
        private static string host = "smtp.gmail.com";
        private static int port = 587;
        private static string username = "republicofprogrammers@gmail.com";
        private static string password = "polakken";
        private static string module = "E-mail handler";


        public static  SmtpClient client = new SmtpClient(host, port) //Lager en ny SmtpClient med host-navn og port
         {
             Credentials = new NetworkCredential(username, password), //Login-informasjon for emailen vi sender fra
             EnableSsl = true //Legger til sikkerhetslaget Ssl
         };
        

        //Metode som sender mail til alle som er oppført i databasen
        public static void sendToAll(string subject, string body)
        {
            try
            {

                DataTable sendMail = new DataTable();
                sendMail = GUI.dtEmails;

                string mailTil;

                //Løkke som går gjennom databasen for å hente ut alle e-mails
                foreach (DataRow dtRow in sendMail.Rows)
                {
                    mailTil = dtRow["Adresser"].ToString();
                    client.Send(username, mailTil, subject, body);
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
                client.Send(username, mailAdress, subject, body);
                Logger.Info("Sendt email til " + mailAdress + ".", module);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, module);
            }
        }
    }
}