using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polakken
{
    class Regulation
    {
        //variabler
        private Boolean status;
        private int reading;
        private int prevReading;
        private int tolerance;
        public int setpoint { get; set; }
        private double difference;
        //temp variabler
        private int mesInterval;
        
        //regulering
        private Boolean reg()
        {
            if ((reading + tolerance) < setpoint) //temperatur under min toleranse
            {
                status = true;
            }
            else if ((reading - tolerance) > setpoint) //temperatur over max toleranse
            {
                status = false;
            }
            else if ((prevReading - reading) < (setpoint - prevReading))
            {
                difference = (prevReading - reading) / (setpoint - prevReading);
                System.Threading.Thread.Sleep(Convert.ToInt32(difference * mesInterval); //må omgjøres slik at intervallet blir i millisekunder. 
                status = true;
            }
            else if ((prevReading - reading) > (setpoint - prevReading))
            {

            }

            return status;
        }

    }
}
