using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Polakken
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Logger(); // kaller konstruktøren til logger classen kun for å opprette ny logg tekstfil. 

            //TODO: hente inn config settpunkt på måleintervall for å sende inn til SensorCom
            //TODO: kalle SensorCom med måleintervall
            //TODO: Kalle dbhandler.Oppstartsjekk() (denne må også lages, skal sjekke om alt er i orden med harddisk)
            //TODO: Sjekke sist innlogging via databasen. Rapportere til bruker at konfigurasjoner er i orden, polakken starter arbeid.


            //Eventuelt, sletting av eldgammel data som ikke trengs og som tar opp plass/resusser.


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI());
        }
    }
}
