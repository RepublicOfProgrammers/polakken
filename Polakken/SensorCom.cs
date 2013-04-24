using System;
using NationalInstruments.DAQmx;


namespace Polakken
{
    static class SensorCom
    {
        private static string module = "SensorCom";
        public static int alarmLimit { get; set; } //Brukes ikke internt i klassen, men bestemmer hvor lav temperatur som skal til før en alarm sendes. 
        public static int mesInterval { get; set; } //Brukes ikke internt i klassen, men bestemmer hvor ofte det gjøres en måling. 

        public static double temp()
        {
            Task temperatureTask = new Task();
            try
            {
                AIChannel myAIChannel;
                myAIChannel = temperatureTask.AIChannels.CreateThermocoupleChannel("Dev1/ai0", "Temperature", 0, 100,
                    AIThermocoupleType.J, AITemperatureUnits.DegreesC);

                AnalogSingleChannelReader reader = new AnalogSingleChannelReader(temperatureTask.Stream);
                double analogData = reader.ReadSingleSample();
                return analogData;
            }
            catch (Exception e)
            {
                Logger.Error(e, module);
                return 999;
                //999 vil være en "feilkode"
            }
            finally
            {
                temperatureTask.Dispose();
            }
        }
    }
}

