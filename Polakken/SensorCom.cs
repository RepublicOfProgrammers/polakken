﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments;
using NationalInstruments.DAQmx;
using Polakken.Properties;


namespace Polakken
{
    static class SensorCom
    {
        private static string module = "SensorCom";
        public static int alarmLimit { get; set; }
        //{
        //    get
        //    {
        //        return alarmLimit;
        //    }
        //    set
        //    {
        //        alarmLimit = value;
        //        Settings.Default.alarmLimit = value;
        //        Settings.Default.Save();
        //    }
        //}
        public static int mesInterval { get; set; }
        //{
        //    get
        //    {
        //        return mesInterval;
        //    }
        //    set
        //    {
        //        mesInterval = value;
        //        Regulation.mesInterval = value;
        //        if (Settings.Default.mesInterval != value)
        //        {
        //            Settings.Default.mesInterval = value;
        //        }
        //        Settings.Default.Save();
        //    }
        //}

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

