using System;
using NationalInstruments.DAQmx;


namespace Polakken
{
    static class SensorCom
    {
        private static string module = "SensorCom";
        public static int alarmLimit { get; set; } //Brukes ikke internt i klassen, men hører til. 
        public static int mesInterval { get; set; } //Brukes ikke internt i klassen, men hører til. 

        public static double temp()
        {
            try
            {
                Task temperatureTask = new Task();
                AIChannel myAIChannel;
                myAIChannel = temperatureTask.AIChannels.CreateThermocoupleChannel("Dev1/ai0", "Temperature", 0, 100,
                    AIThermocoupleType.J, AITemperatureUnits.DegreesC);

                AnalogSingleChannelReader reader = new AnalogSingleChannelReader(temperatureTask.Stream);
                double analogData = reader.ReadSingleSample();
                temperatureTask.Dispose();
                return analogData;
            }
            catch (Exception e)
            {
                Logger.Error(e, module);
                return 999;
                //999 vil være en "feilkode"
            }
        }
    }
}

