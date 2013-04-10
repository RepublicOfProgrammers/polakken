﻿using System;
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
        public SmtpClient client = new SmtpClient("smtp.gmail.com", 587) //Lager en ny SmtpClient med host-navn og port
         {
             Credentials = new NetworkCredential("republicofprogrammers@gmail.com", "polakken"), //Login-informasjon for emailen vi sender fra
             EnableSsl = true //Legger til sikkerhetslaget Ssl
         };



        

        //public void nyTabell()
        //{
        //    try
        //    {

        //        GUI gui = new GUI();

        //        DataTable sendEmail = new DataTable();
        //        gui.GetEmail(sendEmail);

        //        string mailTil;


        //        foreach (DataRow dtRow in sendEmail.Rows)
        //        {
        //            mailTil = dtRow["Adresser"].ToString();
        //            client.Send("republicofprogrammers@gmail.com", mailTil, "Hei", "Hei");
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}

        public void sendFromString(string subject, string body)
        {
            GUI gui = new GUI();

            DataTable sendEmail = new DataTable();
            gui.GetEmail(sendEmail);


            string mailTil;


            foreach (DataRow dtRow in sendEmail.Rows)
            {
                mailTil = dtRow["Adresser"].ToString();
                client.Send("republicofprogrammers@gmail.com", mailTil, subject, body);
            }
        }

        public void sendFromStringEmail(string subject, string body, string mailAdress)
        {
            client.Send("republicofprogrammers@gmail.com", mailAdress, subject, body);
        }
    }
}