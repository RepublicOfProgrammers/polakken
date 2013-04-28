using System;
using System.Threading;

namespace Polakken
{
    internal static class Regulation
    {
        //variabler
        private const string Module = "Regulation";
        private static int _reading = 999;
        private static int _prevReading;
        private static int _difference;
        private static string _loggerInfo;
        public static int Tolerance { get; set; }
        public static int Setpoint { get; set; }
        public static Boolean Status { get; private set; }

        /// <summary>
        ///     Returnerer status for varmekilde. Må programmeres slik at en varmekilde blir slått av og på ved endring av boolean value fra denne metoden.
        /// </summary>
        /// <param name="newread">Temperatur som double</param>
        /// <returns>Boolean varmekilde status</returns>
        public static Boolean Regulator(int newread)
        {
            //Hvis det ikke har blitt hentet inn en verdi for reading vil den lagre den nye målingen i både reading og prevReading
            if (_reading == 999)
            {
                _prevReading = newread;
                _reading = newread;
            }
                //Plasserer den forrige readingen inn i prevReading og den nye i reading. 
            else
            {
                _prevReading = _reading;
                _reading = newread;
            }

            //temperatur under min toleranse, skrur på ovnen. 
            if ((_reading + Tolerance) < Setpoint)
            {
                Status = true;
            }
                //temperatur over max toleranse, skrur av ovnen. 
            else if ((_reading - Tolerance) > Setpoint)
            {
                Status = false;
            }
                //sørger for at ovnen startes opp før temperaturen blir under toleransen. 
            else if ((_prevReading - _reading) > (_reading - (Setpoint - Tolerance)))
            {
                _difference = (_reading - (Setpoint - Tolerance))/(_prevReading - _reading);
                Thread.Sleep(Convert.ToInt32(_difference*SensorCom.MesInterval*60000));
                Status = true;
            }
                //sørger for at ovnen stoppes før temperaturen blir over toleransen. 
            else if ((_reading - _prevReading) > ((Setpoint + Tolerance) - _reading))
            {
                _difference = ((Setpoint + Tolerance) - _reading)/(_reading - _prevReading);
                Thread.Sleep(Convert.ToInt32(_difference*SensorCom.MesInterval*60000));
                Status = false;
            }
            //sender info til loggen om regulering. 
            _loggerInfo = "Gjort regulering og status for varme kilde er satt til " + Convert.ToString(Status);
            Logger.Info(_loggerInfo, Module);
            return Status;
        }
    }
}