using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments;
using NationalInstruments.DAQmx;


namespace Polakken
{
    static class SensorCom
    {
        private static string module = "SensorCom";
        public static int alarmLimit { get; set; }
        public static int mesInterval 
        { 
            get; 
            set 
            {
                Regulation.mesInterval = mesInterval;
            } 
        }

        public static double temp()
        {
            try
            {
                //Debug.WriteLine("<<TempDebug>>");
                Task temperatureTask = new Task();
                AIChannel myAIChannel;
                myAIChannel = temperatureTask.AIChannels.CreateThermocoupleChannel("Dev1/ai0", "Temperature", 0, 100,
                    AIThermocoupleType.J, AITemperatureUnits.DegreesC);

                AnalogSingleChannelReader reader = new AnalogSingleChannelReader(temperatureTask.Stream);
                double analogData = reader.ReadSingleSample();
                //Debug.WriteLine(analogData);
                return analogData;
            }
            catch (Exception e)
            {
                Logger.Error(e, module);
                return 999;
                //999 vil være en "feilkode", exceptionen bør også logges. 
            }
        }
    }
}

