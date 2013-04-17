using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using Polakken.Properties;

namespace Polakken
{
    static class Program
    {
        private static DbHandler mDbHandler;
        public static bool needRefresh { get; set; }
        public static int readingCounter { get; set; }

        [STAThread]
        static void Main()
        {
            needRefresh = false;
            readingCounter = 0;
            new Logger(); // kaller konstruktøren til logger classen kun for å opprette ny logg tekstfil. 
            mDbHandler = new DbHandler(); // Fungerer som en sjekk på at databasen fungerer. brukes også i tråden for tempmåling tMålTemp_method()

            Thread tMålTemp = new Thread(new ThreadStart(tMålTemp_method));
            tMålTemp.Start(); // Starter måleprosessen. Main() venter ikke på denne tråden før den går videre.
            
            //Thread polakkenLytter = new Thread(new ThreadStart(polakkenLytter_Method));
            //polakkenLytter.Start();

            //TODO: Sjekke sist innlogging via databasen. Rapportere til bruker at konfigurasjoner er i orden, polakken starter arbeid.
            //Eventuelt TODO: sletting av eldgammel data som ikke trengs og som tar opp plass/resusser.

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI()); 
        }

        /// <summary>
        /// Denne metoden for tråden tMålTemp vil skrive en måling til databasen med datotid, temp og status på varmeovner. Deretter vil tråden sove frem til måleintervallet(mesIntervall) er utløpt
        /// </summary>
        private static void tMålTemp_method()
        {
            while (true)
            {
                if ((int)SensorCom.temp() == 999)
                {
                    Logger.Warning("Får ikke kontakt med måleenhet (se foregående error fra SensorCom), skriver ikke til database, Polakken blunder en times tid.", "Polakken");
                    //E_mail_handler.sendToAll("Brudd med sensor", "Får ikke kontakt med sensor, skriver ikke til database, Polakken blunder en times tid.");                    
                    Thread.Sleep(3600000);
                }
                else
                {
                    if (GUI.test == false)
                    {
                        mDbHandler.SetReading(DateTime.Now, (int)SensorCom.temp(), GUI.test);
                    }
                    else
                    {
                        Regulation.regulator(SensorCom.temp());
                        mDbHandler.SetReading(DateTime.Now, (int)SensorCom.temp(), Regulation.status);
                    }
                    Logger.Info("Utført måling, og skrevet til database.", "Polakken");
                    needRefresh = true;
                    readingCounter++;
                    if (SensorCom.temp() < SensorCom.alarmLimit)
                    {
                        E_mail_handler.sendToAll("Alarm", "Sensoren har målt en temperatur som er under den alarmgrensen. Send \"STS 0\" for status.");
                        Logger.Warning("Måling er under alarmgrensen, sendt ut mail til alle abonnenter", "Polakken");
                    }
                    Thread.Sleep(SensorCom.mesInterval * 6000); 
                }
            }
        }

        //private static void polakkenLytter_Method()
        //{
        //    while (true)
        //    {
        //        string message = "noe piss";
        //        MessageBox.Show(message);
        //        Thread.Sleep(1500);
        //    }   
        //}
    }
}
