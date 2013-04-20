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
        public static Boolean status { get; private set; }
        private static double reading = 999;
        private static double prevReading;
        private static double difference;
        private static string loggerInfo;
        public static int tolerance { get; set; }
        public static int setpoint { get; set; }

        public static Boolean regulator(double newread)
        {
            //Hvis det ikke har blitt hentet inn en verdi for reading vil den lagre den nye målingen i både reading og prevReading
            if (reading == 999)
            {
                prevReading = newread;
                reading = newread;
            }
            //Plasserer den forrige readingen inn i prevReading og den nye i reading. 
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
                System.Threading.Thread.Sleep(Convert.ToInt32(difference * SensorCom.mesInterval * 60000)); 
                status = true;
            }
            //sørger for at ovnen stoppes før temperaturen blir over toleransen. 
            else if ((reading - prevReading) < (prevReading - setpoint))
            {
                difference = (reading - prevReading) / (prevReading - setpoint);
                System.Threading.Thread.Sleep(Convert.ToInt32(difference * SensorCom.mesInterval * 60000)); 
                status = false;
            }
            //sender info til loggen om regulering. 
            loggerInfo = "Gjort regulering og status for varme kilde er satt til " + Convert.ToString(status);
            Logger.Info(loggerInfo, module);
            return status;
        }

    }
}
