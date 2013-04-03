using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments;
using NationalInstruments.DAQmx;


namespace Polakken
{
    class SensorCom
    {
        public double mesInterval {get; set;}

        public SensorCom(double mesInterval)
        {
            this.mesInterval = mesInterval;
        }

        public double temp()
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
                return 999;
                //999 vil være en "feilkode", exceptionen bør også logges. 
            }
        }
    }
}

