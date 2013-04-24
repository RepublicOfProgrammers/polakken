using System;
using System.Windows.Forms;
using System.Threading;

namespace Polakken
{
    static class Program
    {
        private static DbHandler mDbHandler;
        public static bool needRefresh { get; set; }
        public static int readingCounter { get; set; }
        private static bool alarmSent;
        private static bool batterySent { get; set; }
        public static bool isRunningOnBattery { get; set; }

        [STAThread]
        static void Main()
        {
            //Sjekker om datamaskinen har strøm
            isRunningOnBattery = (System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline);

            needRefresh = false;
            readingCounter = 0;
            alarmSent = true;
            new Logger(); // kaller konstruktøren til logger classen kun for å opprette ny logg tekstfil. 
            mDbHandler = new DbHandler(); // Fungerer som en sjekk på at databasen fungerer. brukes også i tråden for tempmåling tMålTemp_method()

            Thread tMålTemp = new Thread(new ThreadStart(tMålTemp_method));
            tMålTemp.Start(); // Starter måleprosessen. Main() venter ikke på denne tråden før den går videre.

            //TODO: Sjekke sist innlogging via databasen. Rapportere til bruker at konfigurasjoner er i orden, polakken starter arbeid.
            //Eventuelt TODO: sletting av eldgammel data som ikke trengs og som tar opp plass/resusser.

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new lblDelEmail());
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
                        Logger.Warning("Får ikke kontakt med måleenhet (se foregående error fra SensorCom), skriver ikke til database, Polakken blunder en times tid.", "Polakken");

                        //Sjekker om datamaskinen har strøm
                        isRunningOnBattery = (System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline);

                        //E_mail_handler.sendToAll("Brudd med sensor", "Får ikke kontakt med sensor, skriver ikke til database, Polakken blunder en times tid.");                    
                        Thread.Sleep(36000);
                    }
                    else
                    {
                        if (lblDelEmail.test == false)
                        {
                            mDbHandler.SetReading(DateTime.Now, (int)SensorCom.temp(), lblDelEmail.test);
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
                        readingCounter++;
                        if (SensorCom.temp() < SensorCom.alarmLimit)
                        {
                            if (alarmSent == true)
                            {
                                sendMail.sendToAll("Alarm", "Sensoren har målt en temperatur som er under den alarmgrensen. Send \"STS 0\" for status.");
                                Logger.Warning("Måling er under alarmgrensen, sendt ut mail til alle abonnenter", "Polakken");
                            }
                            else
                            {
                                Logger.Warning("Måling er fremdeles under alarmgrensen, sender ikke mail", "Polakken");
                            }
                            alarmSent = false;
                        }
                        else if (SensorCom.temp() > SensorCom.alarmLimit)
                        {
                            alarmSent = true;
                        }

                        //Sjekker om datamaskinen har strøm
                        isRunningOnBattery = (System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline);
                        if (isRunningOnBattery == true & batterySent == true)
                        {
                            sendMail.sendToAll("Strøm advarsel", "Datamaskinen kjører nå på batteristrøm");
                            batterySent = false;
                        }
                        else if (isRunningOnBattery == false & batterySent == false)
                        {
                            batterySent = true;
                        }


                        //Venter gitt måleintervall, ganget opp med 60 000, for å få i minutter.
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
