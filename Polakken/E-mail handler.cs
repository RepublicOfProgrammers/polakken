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
            DataTable sendEmail = new DataTable();
            GetEmail(sendEmail);

        //    MySQLProcessor.DTTable(mysqlCommand, out sendEmail);

        //    // on all table's rows
        //    foreach (DataRow dtRow in sendEmail.Rows)
        //    {
        //        // on all table's columns
        //        foreach (DataColumn dc in sendEmail.Columns)
        //        {
        //            var field1 = dtRow[dc].ToString();
        //        }
        //    }
        }

        public DataTable GetEmail(DataTable GetEmails)
        {
            Debug.WriteLine("er i get email");
            DbHandler db = new DbHandler();



            GetEmails.Columns.Add("Adresser", typeof(string));
            db.OpenDb();
            SqlCeDataReader emReader = db.GetEmails();

            while (emReader.Read())
            {
                var row = GetEmails.NewRow();
                for (int i = 0; i < 2; i++)
                {

                    string Reading = emReader[i].ToString();
                    row["Adresser"] = Reading;

                }
                GetEmails.Rows.Add(row);

            }

            emReader.Close();


            db.CloseDb();

            

            return GetEmails;
        }

        public void send()
        {
            client.Send("republicofprogrammers@gmail.com", "", "Hei", "Hei");
        }

    }
}