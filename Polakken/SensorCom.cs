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
        //To do list:
        //Built-in commando for å hente ut CJC-value til termoelementet
        //Feilsøking for å oppdage hvis det skulle bli feil ved måleren (brutt signal)
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

