using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstrumentDriverInterop.Ivi;

namespace Polakken
{
    class SensorCom
    {        
		niHSDIO my_niHSDIO; //niHSDIO object
        string Sensor_name = "0xxxxx"; //navn til sensoren
        string Sensor_channel = "x"; //kanal sensor benytter

        private void initReader() 
        {
            //variable declaration of local
            uint data;

            my_niHSDIO = InstrumentDriverInterop.Ivi.niHSDIO.InitAcquisitionSession(Sensor_name, true, true, "");
            //initializing niHSDIO object
            my_niHSDIO.AssignStaticChannels(Sensor_channel);
            //configure acquisition with channels listed on form
            my_niHSDIO.ReadStaticU32(out data);	//Leser temp, putter temp i "data" variabel
            my_niHSDIO.Dispose(); //dispose of handle
        }
    }
}

