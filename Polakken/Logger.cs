using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Polakken.Properties;

namespace Polakken
{
    public class Logger
    {
        //Mappen hvor alle log filene skal ligge
        private const string DirLogs = "Logs";

        public Logger()
        {
            // Henter inn config settpunkt på valg om skjuling av error message boxes.
            ShowMsgBoxes = Settings.Default.hideMsgBox;

            if (!Directory.Exists(DirLogs))
            {
                //Dersom mappen ikke eksisterer så opprettes den
                Directory.CreateDirectory(DirLogs);
            }
            // Oppretter filen med unikt navn
            string filename = string.Format("{0}/Programstart {1}.log", DirLogs,
                                            DateTime.Now.ToString("dd-MM-yyy HH.mm.ss"));
            CurrentLog = filename;

            //Legger filen til i Listeners-listen til programkjøringen. Denne lytter etter trace-events, som behandles i WriteEntry()
            Trace.Listeners.Add(new TextWriterTraceListener(filename, "PolakkenLytter"));
            Trace.WriteLine("Tidspunkt \tType \tKlasse \t\tMelding");
            Trace.WriteLine("-------------------------------------------------------------");
        }

        // Klasseegenskaper som forteller hva dagens log-fil heter og en variabel som bestemmer dersom alarmer skal vises i msgBox'er.
        public static string CurrentLog { get; set; }
        public static bool ShowMsgBoxes { get; set; }

        //Konstruktør som kun brukes i oppstart av programmet for å opprette en ny logg fil med dagens dato

        //Følgende metoder brukes i de forskjellige trace event'ene vi har definert.
        public static void Error(string message, string module)
        {
            if (!ShowMsgBoxes) MessageBox.Show("FEIL: " + message, "Polakken Error");
            WriteEntry(message, "FEIL", module);
        }

        public static void Error(Exception ex, string module)
        {
            if (!ShowMsgBoxes) MessageBox.Show("FEIL: " + ex, "Polakken Error");
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