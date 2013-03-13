using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using InstrumentDriverInterop.Ivi;
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
            Task temperatureTask = new Task();
            AIChannel myAIChannel;
            myAIChannel = temperatureTask.AIChannels.CreateThermocoupleChannel("Dev1/ai0", "Temperature", 0, 100,
                AIThermocoupleType.J, AITemperatureUnits.DegreesC, 30);

            AnalogSingleChannelReader reader = new AnalogSingleChannelReader(temperatureTask.Stream);
            double analogData = reader.ReadSingleSample();
            return analogData;
        }
    }
}

