using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polakken
{
    static class Regulation
    {
        //variabler
        private static string module = "Regulation";
        private static Boolean status;
        private static double reading;
        private static double prevReading;
        public static int tolerance { get; set; }
        public static int setpoint { get; set; }
        private static double difference;
        public static int mesInterval { get; set; }

        //ny måling
        public static void newRead(double newread)
        {
            prevReading = reading;
            reading = newread;  
        }

        //regulering
        public static  Boolean regulator()
        {
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

            return status;
        }

    }
}
