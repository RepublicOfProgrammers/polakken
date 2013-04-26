using System;
using NationalInstruments.DAQmx;


namespace Polakken
{
    static class SensorCom
    {
        private static string module = "SensorCom";
        public static int alarmLimit { get; set; } //Brukes ikke internt i klassen, men bestemmer hvor lav temperatur som skal til før en alarm sendes. 
        public static int mesInterval { get; set; } //Brukes ikke internt i klassen, men bestemmer hvor ofte det gjøres en måling. 

        /// <summary>
        /// Gjør en temperatur måling. Dersom det oppstår en feil returnerer metoden 999 og skriver til logg.
        /// </summary>
        /// <returns>Returnerer temperaturen i double. </returns>
        public static double temp()
        {
            double analogData;
            Task temperatureTask = new Task();
            try
            {
                temperatureTask.AIChannels.CreateThermocoupleChannel("Dev1/ai0", "Temperature", 0, 100,
                    AIThermocoupleType.J, AITemperatureUnits.DegreesC);

                AnalogSingleChannelReader reader = new AnalogSingleChannelReader(temperatureTask.Stream);                
                analogData = reader.ReadSingleSample(); 
            }
            catch (Exception e)
            {
                Logger.Error(e, module); //Logger feil. 
                analogData = 999;
                //999 vil være en "feilkode"
            }
            finally
            {
                temperatureTask.Dispose();
            }
            return analogData;
        }

        /// <summary>
        /// Tester om Måleenhet er koblet til maskinen.
        /// </summary>
        /// <returns>bool som er true dersom tilkoblet, false i motsatt tilfelle.</returns>
        public static bool connected()
        {
            Task checkConnection = new Task();
            bool connected;

            // Hvis sensor allerede er i bruk tolkes dette som at sensor er koblet til å i øyeblikket i bruk av tempmåling prosessen. 
            // Dermed avsluttes metoden her og sier ifra til GUI at sensor (sansynelighvis er koblet til). 
            // Dette gjøres for å unngå dobbelt sensorbruk som forårsaker feiltolkning i GUI og tempmåling prosessen.
            if (Program.sensorInUse) return true;
            else
            {

                // Tester om programmet klarer å opprette en AIChannel, kun for å se om enhet er koblet til. 
                try
                {
                    // Dette er en u-elegant måte å teste tilkobling til sensor på.
                    // Men det er desverre den måten vi har tid og know-how til å implementere.

                    // Følgende linje er ikke pålitelig nok til dette bruket. Noenganger kaster ikke dette en exception av en eller annen obskur årsak... 
                    checkConnection.AIChannels.CreateThermocoupleChannel("Dev1/ai0", "Temperature", 0, 100,
                        AIThermocoupleType.J, AITemperatureUnits.DegreesC);

                    // ...Derfor må dette gjøres for å garantere en exception dersom ikke sensor er koblet til. 
                    AnalogSingleChannelReader reader = new AnalogSingleChannelReader(checkConnection.Stream);
                    reader.ReadSingleSample(); // Lagrer ikke svar fra sensor, fordi det er denne linjen som kaster exception.  
                    connected = true;

                }
                catch (Exception)
                {
                    // Bruker ikke error.
                    connected = false;
                }
                finally
                {
                    checkConnection.Dispose();
                }
                return connected;
            }
        }
    }
}

