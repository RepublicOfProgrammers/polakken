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

        [STAThread]
        static void Main()
        {
            new Logger(); // kaller konstruktøren til logger classen kun for å opprette ny logg tekstfil. 
            mDbHandler = new DbHandler(); // Fungerer som en sjekk på at databasen fungerer. brukes også i tråden for tempmåling tMålTemp_method()
            bool start = true;
            if (start == true)
            {
                //SensorCom.mesInterval = Settings.Default.mesInterval; // Henter inn config settpunkt på måleintervall og sender til SensorCom
                //SensorCom.alarmLimit = Settings.Default.alarmLimit; // Henter inn config settpunkt på alarmgrense og sender til SensorCom
                //Regulation.setpoint = Settings.Default.setpoint; //Henter in config settpunkt på settpunkt og sender til Regulation
                //Regulation.tolerance = Settings.Default.tolerance; // Henter inn config settpunkt på toleranse og sender til Regulation
                start = false;
            }


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
                    Thread.Sleep(SensorCom.mesInterval);
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
