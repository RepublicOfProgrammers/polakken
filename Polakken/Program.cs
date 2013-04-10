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

            SensorCom.mesInterval = Settings.Default.mesInterval; // henter inn config settpunkt på måleintervall og sender til SensorCom
            SensorCom.alarmLimit = Settings.Default.alarmLimit; // Henter inn config settpunk på alarmgrense og sender til SensorCom

            Thread tMålTemp = new Thread(new ThreadStart(tMålTemp_method));
            tMålTemp.Start(); // Starter måleprosessen. Main() venter ikke på denne tråden før den går videre.

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
            if ((int)SensorCom.temp() == 999)
            {
                Logger.Warning("Får ikke kontakt med måleenhet (se foregående error fra SensorCom), skriver ikke til database, Polakken blunder en times tid.", "Polakken");
                //Sende email?
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
                    mDbHandler.SetReading(DateTime.Now, (int)SensorCom.temp(), Regulation.status);
                }
                Logger.Info("Utført måling, og skrevet til database.", "Polakken");
                Thread.Sleep(SensorCom.mesInterval);
            }
        }
    }
}
