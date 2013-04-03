using System;
using System.Diagnostics;
using System.IO;

namespace Polakken
{
    public class Logger
    {
        private string dirLogs = "Logs";
        public Logger() 
        {
            if (!Directory.Exists(dirLogs)) 
            {
                Directory.CreateDirectory(dirLogs);
            }
            string filename = string.Format("{0}/Programstart {1}.log", dirLogs, DateTime.Now.ToString("dd-MM-yyy HH.mm.ss"));
            Trace.Listeners.Add(new TextWriterTraceListener(filename, "PolakkenLytter"));
            Trace.WriteLine("Tidspunkt \tType \tKlasse \t\tMelding");
            Trace.WriteLine("-------------------------------------------------------------");
        }

        public static void Error(string message, string module)
        {
            WriteEntry(message, "FEIL", module);
        }

        public static void Error(Exception ex, string module)
        {
            WriteEntry(ex.Message, "FEIL", module);
        }

        public static void Warning(string message, string module)
        {
            WriteEntry(message, "ADVARSEL", module);
        }

        public static void Info(string message, string module)
        {
            WriteEntry(message, "INFO", module);
        }

        private static void WriteEntry(string message, string type, string module)
        {
            Trace.WriteLine(
                    string.Format("{0} \t{1} \t{2}: \t{3}",
                                  DateTime.Now.ToString("HH:mm:ss"),
                                  type,
                                  module,
                                  message));
            Trace.Flush();
        }
    }
}
