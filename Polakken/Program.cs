using System;
using System.Windows.Forms;
using System.Threading;

namespace Polakken
{
    static class Program
    {
        private static DbHandler mDbHandler;
        private static bool alarmSent;
        private static bool batterySent;

        // Klasse-egenskaper som polakken har nytte av i andre klasser. 
        public static bool isRunningOnBattery { get; set; }
        public static bool sensorSent { get; set; }
        public static bool needRefresh { get; set; }
        public static bool sensorInUse { get; set; } // Brukes slik at ikke sensorbruk kan kræsje med bruk av sensor koblingstesten i SensorCom klassen. 
        public static Thread tMålTemp; // Denne threaden må være public slik at GUI kan stoppe den når GUI lukkes.

        [STAThread]
        static void Main()
        {
            // Sjekker om datamaskinen har strøm
            isRunningOnBattery = (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline);

            // Initierer variabler og klasser.
            needRefresh = false;
            alarmSent = false;
            sensorSent = false;

            new Logger(); // kaller konstruktøren til logger classen kun for å opprette ny logg tekstfil. 
            mDbHandler = new DbHandler(); // Fungerer som en sjekk på at databasen fungerer. brukes også i tråden for tempmåling tMålTemp_method()

            // Starter måleprosessen. Main() venter ikke på denne tråden før den går videre.
            tMålTemp = new Thread(new ThreadStart(tMålTemp_method));
            tMålTemp.Start();
            
            // Starter GUI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult result;
            using (var loginForm = new LogIn())
            {
                loginForm.StartPosition = FormStartPosition.CenterScreen;
                result = loginForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // login was successful
                    Application.Run(new GUI_FORM());
                }
            }
        }

        /// <summary>
        /// Denne metoden for tråden tMålTemp vil skrive en måling til databasen med datotid, temp og status på varmeovner. Deretter vil tråden sove frem til måleintervallet(mesIntervall) er utløpt
        /// </summary>
        private static void tMålTemp_method()
        {
            while (true) // Skal alltid være true, bruker threaden til å stoppe loopen. 
            {
                sensorInUse = true;
                int temp = Convert.ToInt32(SensorCom.temp());
                if (temp == 999)
                {
                    if (sensorSent == false) // Sender mail-advarsel dersom brudd med sensor og advarsel ikke er sendt.
                    {
                        Logger.Warning("Får ikke kontakt med måleenhet (se foregående error fra SensorCom), skriver ikke til database, sender mail til alarm abonnenter, Polakken blunder en times tid.", "Polakken");

                        sensorSent = true; // Unngår mail spamming.
                        sendMail.sendToAll("Brudd med sensor", "Får ikke kontakt med sensor, skriver ikke til database, Polakken blunder en times tid.");

                        // Sensoren er ikke lengre i bruk. 
                        sensorInUse = false;

                        Thread.Sleep(3600000); // sover 1 time
                        continue; // Hopper over resten av denne loop-iterasjonen (starter loopen på nytt)
                    }
                    else
                    {
                        Logger.Warning("Får ikke kontakt med måleenhet (se foregående error fra SensorCom), skriver ikke til database, sender ikke ny mail, Polakken blunder en times tid.", "Polakken");
                        
                        // Sensoren er ikke lengre i bruk. 
                        sensorInUse = false;

                        Thread.Sleep(3600000);// sover 1 time
                        continue; // Hopper over resten av denne loop-iterasjonen (starter loopen på nytt)
                    }
                }
                else if (temp > 60)
                {
                    if (temp < SensorCom.alarmLimit)
                    {
                        if (alarmSent == false)
                        {
                            sendMail.sendToAll("Alarm", "Sensoren har målt en temperatur som er over 60 grader celsius. Send \"STS 0\" for status.");
                            Logger.Warning("Måling er over 60 grader celsius, sendt ut mail til alle abonnenter", "Polakken");
                        }
                        else 
                        {
                            Logger.Warning("Måling er fremdeles over 60 grader celsius, sender ikke mail", "Polakken");
                        }
                        alarmSent = true; // Unngår mail spamming.
                    }
                }
                else
                {
                    if (GUI_FORM.test == false) // Sjekker om regulering er aktiv.
                    {
                        mDbHandler.SetReading(DateTime.Now, temp, GUI_FORM.test);
                    }
                    else
                    { // Dersom regulering er aktiv spørres Regulation klassen om ovn-status.
                        Regulation.regulator(temp);
                        mDbHandler.SetReading(DateTime.Now, temp, Regulation.status);
                    }

                    needRefresh = true; // Sier ifra til tickeventen i gui'en at den trenger oppdatering

                    // Sender alarm til mail-abonnenter dersom gitt alarmgrense er brutt. Sender ikke dobbelt opp, men på ny dersom temp 
                    // kommer innenfor grense og deretter bryter grense. 
                    if (temp < SensorCom.alarmLimit)
                    {
                        if (alarmSent == false)
                        {
                            sendMail.sendToAll("Alarm", "Sensoren har målt en temperatur som er under den alarmgrensen. Send \"STS 0\" for status.");
                            Logger.Warning("Måling er under alarmgrensen, sendt ut mail til alle abonnenter", "Polakken");
                        }
                        else
                        {
                            Logger.Warning("Måling er fremdeles under alarmgrensen, sender ikke mail", "Polakken");
                        }
                        alarmSent = true; // Unngår mail spamming.
                    }
                    else if (temp > SensorCom.alarmLimit & temp < 60)
                    {
                        alarmSent = false;
                    }

                    // Sender alarm til mail-abonnenter dersom maskinen ikke har strøm. Sender ikke dobbelt opp, men sier ifra dersom strøm kommer tilbake. 
                    if (isRunningOnBattery == true & batterySent == false)
                    {
                        sendMail.sendToAll("Strøm advarsel", "Datamaskinen kjører nå på batteristrøm");
                        batterySent = true;
                    }
                    else if (isRunningOnBattery == false & batterySent == true)
                    {
                        sendMail.sendToAll("Strøm varsel", "Datamaskinen kjører ikke lenger på batteristrøm");
                        batterySent = false;
                    }

                    // Følgende bool må settes til false igjen slik at mail kan bli sent dersom maskin får kontakt med sensor, og deretter mister kontakt igjen. 
                    sensorSent = false;

                    // Sensoren er ikke lengre i bruk. 
                    sensorInUse = false;

                    //Venter gitt måleintervall, ganget opp med 60 000 siden det er oppgitt i minutter.
                    Thread.Sleep(SensorCom.mesInterval * 60000);
                }                
            }
        }
    }
}
