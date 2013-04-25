using System;
using System.Windows.Forms;
using System.Threading;

namespace Polakken
{
    static class Program
    {
        private static DbHandler mDbHandler;
        public static bool needRefresh { get; set; }
        public static bool readingSent { get; set; }
        private static bool alarmSent;
        public static bool sensorSent { get; set; }
        private static bool batterySent;
        public static bool isRunningOnBattery { get; set; }

        [STAThread]
        static void Main()
        {
            //Sjekker om datamaskinen har strøm
            isRunningOnBattery = (System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline);

            needRefresh = false;
            readingSent = false;
            alarmSent = false;
            sensorSent = false;
            new Logger(); // kaller konstruktøren til logger classen kun for å opprette ny logg tekstfil. 
            mDbHandler = new DbHandler(); // Fungerer som en sjekk på at databasen fungerer. brukes også i tråden for tempmåling tMålTemp_method()

            Thread tMålTemp = new Thread(new ThreadStart(tMålTemp_method));
            tMålTemp.Start(); // Starter måleprosessen. Main() venter ikke på denne tråden før den går videre.

            //TODO: Sjekke sist innlogging via databasen. Rapportere til bruker at konfigurasjoner er i orden, polakken starter arbeid.
            //Eventuelt TODO: sletting av eldgammel data som ikke trengs og som tar opp plass/resusser.

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI_FORM());
        }

        /// <summary>
        /// Denne metoden for tråden tMålTemp vil skrive en måling til databasen med datotid, temp og status på varmeovner. Deretter vil tråden sove frem til måleintervallet(mesIntervall) er utløpt
        /// </summary>
        private static void tMålTemp_method()
        {
            //int lastTemp = 0;
            while (true)
            {
                //if (lastTemp != (int)SensorCom.temp())
                //{
                    if ((int)SensorCom.temp() == 999)
                    {
                        isRunningOnBattery = (System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline);
                        if (sensorSent == false)
                        {
                            Logger.Warning("Får ikke kontakt med måleenhet (se foregående error fra SensorCom), skriver ikke til database, sender mail til alarm abonnenter, Polakken blunder en times tid.", "Polakken");

                            //Sjekker om datamaskinen har strøm
                            sensorSent = true;
                            sendMail.sendToAll("Brudd med sensor", "Får ikke kontakt med sensor, skriver ikke til database, Polakken blunder en times tid.");
                            Thread.Sleep(3600000);
                        }
                        else
                        {
                            Logger.Warning("Får ikke kontakt med måleenhet (se foregående error fra SensorCom), skriver ikke til database, sender ikke ny mail, Polakken blunder en times tid.", "Polakken");
                            Thread.Sleep(3600000);
                        }
                    }
                    else
                    {
                        if (GUI_FORM.test == false)
                        {
                            mDbHandler.SetReading(DateTime.Now, (int)SensorCom.temp(), GUI_FORM.test);
                            //lastTemp = (int)SensorCom.temp();
                        }
                        else
                        {
                            Regulation.regulator(SensorCom.temp());
                            mDbHandler.SetReading(DateTime.Now, (int)SensorCom.temp(), Regulation.status);
                            //lastTemp = (int)SensorCom.temp();
                        }
                        Logger.Info("Utført måling, og skrevet til database.", "Polakken");

                        needRefresh = true;
                        readingSent = true;
                        if (SensorCom.temp() < SensorCom.alarmLimit)
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
                            alarmSent = true;
                        }
                        else if (SensorCom.temp() > SensorCom.alarmLimit)
                        {
                            alarmSent = false;
                        }

                        //Sjekker om datamaskinen har strøm
                        isRunningOnBattery = (System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline);
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
                        sensorSent = false;

                        //Venter gitt måleintervall, ganget opp med 60 000 siden det er oppgitt i minutter.
                        Thread.Sleep(SensorCom.mesInterval * 60000);
                    }
                //}
                //else
                //{
                    //Logger.Info("Uendret temperatur, har ikke lagret måling.", "Polakken");
                    //needRefresh = true;
                    //Thread.Sleep(SensorCom.mesInterval * 6000);
                //}
            }
        }
    }
}
