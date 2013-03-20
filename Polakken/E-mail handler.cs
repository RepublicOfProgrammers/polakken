//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Net;
//using System.Net.Mail;

//namespace Polakken
//{
//    class E_mail_handler
//    {
//        GUI gui = new GUI();
//       public SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
//        {
//            Credentials = new NetworkCredential("republicofprogrammers@gmail.com", "polakken"),
//            EnableSsl = true
//        };

//       public void SendMail()
//       {
//           try
//           {
//               if (txtEmail1.Text != "")
//               {
//                   client.Send("republicofprogrammers@gmail.com", txtEmail1.Text, "Hei", "Hei");
//               }
//               if (txtEmail2.Text != "")
//               {
//                   client.Send("republicofprogrammers@gmail.com", txtEmail2.Text, "Hei", "Hei");
//               }
//               if (txtEmail3.Text != "")
//               {
//                   client.Send("republicofprogrammers@gmail.com", txtEmail3.Text, "Hei", "Hei");
//               }
//               if (txtEmail4.Text != "")
//               {
//                   client.Send("republicofprogrammers@gmail.com", txtEmail4.Text, "Hei", "Hei");
//               }
//               MessageBox.Show("Mailen har blitt sendt");
//           }

//           catch (Exception ex)
//           {
//               MessageBox.Show(ex.Message);
//           }
//       }

//    }
//}
