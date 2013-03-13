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
        private double reading;
        private double prevReading;
        public double tolerance { get; set; }
        public double setpoint { get; set; }
        private double difference;
        public double mesInterval { get; set; }

        //constructor
        public Regulation(double setpoint, double tolerance, double mesInterval)
        {
            this.setpoint = setpoint;
            this.tolerance = tolerance;
            this.mesInterval = mesInterval;
            prevReading = reading;
        }

        //ny måling
        public void newread(double newread)
        {
            prevReading = reading;
            reading = newread;  
        }

        //regulering
        public Boolean regulator()
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
                System.Threading.Thread.Sleep(Convert.ToInt32(difference * mesInterval)); //må omgjøres slik at intervallet blir i millisekunder. 
                status = true;
            }
            //sørger for at ovnen stoppes før temperaturen blir over toleransen. 
            else if ((reading - prevReading) < (prevReading - setpoint))
            {
                difference = (reading - prevReading) / (prevReading - setpoint);
                System.Threading.Thread.Sleep(Convert.ToInt32(difference * mesInterval)); //må omgjøre slik at intervallet blir i millisekunder. 
            }

            return status;
        }

    }
}
