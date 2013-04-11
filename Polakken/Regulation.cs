using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Polakken.Properties;

namespace Polakken
{
    static class Regulation
    {
        //variabler
        private static string module = "Regulation";
        public static Boolean status;
        private static double reading;
        private static double prevReading;
        private static double difference;
        public static int mesInterval { get; set; }
        private static string loggerInfo;
        public static int tolerance 
        {
            get 
            {
                return tolerance;
            }
            set
            {
                tolerance = value;
                Settings.Default.tolerance = value;
            }
        }
        public static int setpoint
        {
            get 
            {
                return setpoint;
            }
            set
            {
                setpoint = value;
                Settings.Default.setpoint = value;
            }
        }

        public static Boolean regulator(double newread)
        {
            //Hvis det ikke eksisterer en verdi for reading vil den lagre den nye målingen i både reading og prevReading
            if (reading == null)
            {
                prevReading = newread;
                reading = newread;
            }
            //Plasserer den forrige readingen inn i prev Reading og den nye i reading. 
            else
            {
                prevReading = reading;
                reading = newread;
            }

            //temperatur under min toleranse, skrur på ovnen. 
            if ((reading + tolerance) < setpoint)
            {
                status = true;
            }
            //temperatur over max toleranse, skrur av ovnen. 
            else if ((reading - tolerance) > setpoint)
            {
                status = false;
            }
            //sørger for at ovnen startes opp før temperaturen blir under toleransen. 
            else if ((prevReading - reading) < (setpoint - prevReading))
            {
                difference = (prevReading - reading) / (setpoint - prevReading);
                System.Threading.Thread.Sleep(Convert.ToInt32(difference * mesInterval * 60000)); //må omgjøres slik at intervallet blir i millisekunder. 
                status = true;
            }
            //sørger for at ovnen stoppes før temperaturen blir over toleransen. 
            else if ((reading - prevReading) < (prevReading - setpoint))
            {
                difference = (reading - prevReading) / (prevReading - setpoint);
                System.Threading.Thread.Sleep(Convert.ToInt32(difference * mesInterval * 60000)); //må omgjøre slik at intervallet blir i millisekunder. 
                status = false;
            }
            //sender info til loggen om regulering. 
            loggerInfo = "Gjort regulering og status for varme kilde er satt til " + Convert.ToString(status);
            Logger.Info(loggerInfo, module);
            return status;
        }

    }
}
