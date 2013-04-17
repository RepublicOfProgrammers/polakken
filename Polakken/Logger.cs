﻿using System;
using System.Diagnostics;
using System.IO;


namespace Polakken
{
    public class Logger
    {
        //Mappen hvor alle log filene skal ligge
        private string dirLogs = "Logs";
        public static string msgbxms { get; private set;}
        public static bool msgchg = false;
        
        //Konstruktør som kun brukes i oppstart av programmet for å opprette en ny logg fil med dagens dato
        public Logger() 
        {
            if (!Directory.Exists(dirLogs)) 
            {
                //Dersom mappen ikke eksisterer så opprettes den
                Directory.CreateDirectory(dirLogs);
            }
            // Oppretter filen med unikt navn
            string filename = string.Format("{0}/Programstart {1}.log", dirLogs, DateTime.Now.ToString("dd-MM-yyy HH.mm.ss"));
            //Legger filen til i Listeners-listen til programkjøringen. Denne lytter etter trace-events, som behandles i WriteEntry()
            Trace.Listeners.Add(new TextWriterTraceListener(filename, "PolakkenLytter"));
            Trace.WriteLine("Tidspunkt \tType \tKlasse \t\tMelding");
            Trace.WriteLine("-------------------------------------------------------------");
            
        }

  

        //Følgende metoder brukes i de forskjellige trace event'ene vi har definert.
        public static void Error(string message, string module)
        {
            System.Windows.Forms.MessageBox.Show("FEIL: " + message);
            WriteEntry(message, "FEIL", module);
            msgbxms += DateTime.Now.ToString("HH:mm:ss") + " \t FEIL: " + "\t" + message + "\r\n";
            msgchg = true; 
        }

        public static void Error(Exception ex, string module)
        {
            System.Windows.Forms.MessageBox.Show("FEIL: " + ex);
            WriteEntry(ex.Message, "FEIL", module);
            msgbxms += DateTime.Now.ToString("HH:mm:ss") + " \t FEIL: " + "\t" + ex.Message + "\r\n";
            msgchg = true;
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
            //Skriver til trace, som deretter blir skrev til tekstfilen via listeneren. 
            Trace.WriteLine(
                    string.Format("{0} \t{1} \t{2}: \t{3}",
                                  DateTime.Now.ToString("HH:mm:ss"),
                                  type,
                                  module,
                                  message));
            //Flusher til slutt trace, så ikke ting blir ført opp dobbelt.
            Trace.Flush();
        }
    }
}
