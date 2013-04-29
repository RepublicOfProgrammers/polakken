using System;
using System.Threading;
using System.Windows.Forms;

namespace Polakken
{
    internal static class Program
    {
        private static bool _alarmSent;
        private static bool _batterySent;
        public static Thread MålTemp; // Denne threaden må være public slik at GUI kan stoppe den når GUI lukkes.
        public static DbHandler MDbHandler;

        // Klasse-egenskaper som polakken har nytte av i andre klasser. 
        public static bool IsRunningOnBattery { get; set; }
        public static bool SensorSent { get; set; }
        public static bool NeedRefresh { get; set; }
        public static bool SensorInUse { get; set; }
        // Brukes slik at ikke sensorbruk kan kræsje med bruk av sensor koblingstesten i SensorCom klassen. 

        [STAThread]
        private static void Main()
        {
            // Sjekker om datamaskinen har strøm
            IsRunningOnBattery = (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline);

            // Initierer variabler og klasser.
            NeedRefresh = false;
            _alarmSent = false;
            SensorSent = false;

            new Logger(); // kaller konstruktøren til logger classen kun for å opprette ny logg tekstfil. 
            MDbHandler = new DbHandler();
            // Fungerer som en sjekk på at databasen fungerer. brukes også i tråden for tempmåling tMålTemp_method()


            // Starter GUI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var loginForm = new LogIn())
            {
                loginForm.StartPosition = FormStartPosition.CenterScreen;
                DialogResult result = loginForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Starter måleprosessen. Main() venter ikke på denne tråden før den går videre.
                    MålTemp = new Thread(tMålTemp_method);
                    MålTemp.Start();

                    // login was successful
                    Application.Run(new GuiForm());
                }
            }
        }

        /// <summary>
        ///     Denne metoden for tråden tMålTemp vil skrive en måling til databasen med datotid, temp og status på varmeovner. Deretter vil tråden sove frem til måleintervallet(mesIntervall) er utløpt.
        ///     Denne metoden sender også mailer og advarsler om nødvendig, og foretar tester på systemet.
        /// </summary>
        private static void tMålTemp_method()
        {
            int retryCount = 0;
            while (true) // Skal alltid være true, bruker threaden til å stoppe loopen. 
            {
                SensorInUse = true;
                int temp = Convert.ToInt32(SensorCom.Temp());

                // Dersom temp == 999 har sensorcom returnert en feil
                if (temp == 999)
                {
                    // Prøver på nytt maksimum 3 ganger, med 5 sekunders mellomrom. 
                    if (retryCount < 3)
                    {
                        retryCount++;
                        Logger.Warning(
                            "Får ikke kontakt med sensor. Forsøk nr: " + retryCount + ". Prøver igjen om 5 sekunder.",
                            "Polakken");
                        Thread.Sleep(5000);
                        continue;
                    }
                    retryCount = 0;
                    if (SensorSent == false)
                        // Sender mail-advarsel dersom brudd med sensor og advarsel ikke er sendt.
                    {
                        Logger.Warning(
                            "Får ikke kontakt med måleenhet (se foregående error fra SensorCom), skriver ikke til database, sender mail til alarm abonnenter, Polakken blunder en times tid.",
                            "Polakken");

                        SensorSent = true; // Unngår mail spamming.
                        SendMail.SendToAll("Brudd med sensor",
                                           "Får ikke kontakt med sensor, skriver ikke til database, Polakken blunder en times tid.");

                        // Sensoren er ikke lengre i bruk. 
                        SensorInUse = false;

                        Thread.Sleep(3600000); // sover 1 time
                        continue; // Hopper over resten av denne loop-iterasjonen (starter loopen på nytt)
                    }
                    Logger.Warning(
                        "Får ikke kontakt med måleenhet (se foregående error fra SensorCom), skriver ikke til database, sender ikke ny mail, Polakken blunder en times tid.",
                        "Polakken");

                    // Sensoren er ikke lengre i bruk. 
                    SensorInUse = false;

                    Thread.Sleep(3600000); // sover 1 time
                    continue; // Hopper over resten av denne loop-iterasjonen (starter loopen på nytt)
                }
                if (temp > 60)
                {
                    if (temp < SensorCom.AlarmLimit)
                    {
                        if (_alarmSent == false)
                        {
                            SendMail.SendToAll("Alarm",
                                               "Sensoren har målt en temperatur som er over 60 grader celsius. Send \"STS 0\" for status.");
                            Logger.Warning("Måling er over 60 grader celsius, sendt ut mail til alle abonnenter",
                                           "Polakken");
                        }
                        else
                        {
                            Logger.Warning("Måling er fremdeles over 60 grader celsius, sender ikke mail", "Polakken");
                        }
                        _alarmSent = true; // Unngår mail spamming.
                    }
                }
                else
                {
                    if (GuiForm.Test == false) // Sjekker om regulering er aktiv.
                    {
                        MDbHandler.SetReading(DateTime.Now, temp, GuiForm.Test);
                    }
                    else
                    {
                        // Dersom regulering er aktiv spørres Regulation klassen om ovn-status.
                        Regulation.Regulator(temp);
                        MDbHandler.SetReading(DateTime.Now, temp, Regulation.Status);
                    }
                    Logger.Info(
                        "Utført måling. temp = " + temp + ". Ny måling om: " + SensorCom.MesInterval + " minutt(er).",
                        "Polakken");
                    NeedRefresh = true; // Sier ifra til tickeventen i gui'en at den trenger oppdatering

                    // Sender alarm til mail-abonnenter dersom gitt alarmgrense er brutt. Sender ikke dobbelt opp, men på ny dersom temp 
                    // kommer innenfor grense og deretter bryter grense. 
                    if (temp < SensorCom.AlarmLimit)
                    {
                        if (_alarmSent == false)
                        {
                            SendMail.SendToAll("Alarm",
                                               "Sensoren har målt en temperatur som er under alarmgrensen. Send \"STS 0\" for status.");
                            Logger.Warning("Måling er under alarmgrensen, sendt ut mail til alle abonnenter", "Polakken");
                        }
                        else
                        {
                            Logger.Warning("Måling er fremdeles under alarmgrensen, sender ikke mail", "Polakken");
                        }
                        _alarmSent = true; // Unngår mail spamming.
                    }
                    else if (temp > SensorCom.AlarmLimit && temp < 60)
                    {
                        _alarmSent = false;
                    }

                    // Sender alarm til mail-abonnenter dersom maskinen ikke har strøm. Sender ikke dobbelt opp, men sier ifra dersom strøm kommer tilbake. 
                    if (IsRunningOnBattery && _batterySent == false)
                    {
                        SendMail.SendToAll("Strøm advarsel", "Datamaskinen kjører nå på batteristrøm");
                        _batterySent = true;
                    }
                    else if (IsRunningOnBattery == false && _batterySent)
                    {
                        SendMail.SendToAll("Strøm varsel", "Datamaskinen kjører ikke lenger på batteristrøm");
                        _batterySent = false;
                    }

                    // Følgende bool må settes til false igjen slik at mail kan bli sent dersom maskin får kontakt med sensor, og deretter mister kontakt igjen. 
                    SensorSent = false;

                    // Sensoren er ikke lengre i bruk. 
                    SensorInUse = false;

                    //Venter gitt måleintervall, ganget opp med 60 000 siden det er oppgitt i minutter.
                    Thread.Sleep(SensorCom.MesInterval*60000);
                }
            }
        }
    }
}