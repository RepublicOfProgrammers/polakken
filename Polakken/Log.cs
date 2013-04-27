using System;
using System.Windows.Forms;
using System.IO;

namespace Polakken
{
    public partial class Log : Form
    {

        int Mover;
        int MoveX;
        int MoveY;

        public Log()
        {
            InitializeComponent();            
        }

        private void btnLukk_Click(object sender, EventArgs e)
        {
            if (GUI_FORM.logForm != null)
            {
                GUI_FORM.logForm.Dispose(); // Dispoer Log objektet i GUI klassen for frigjøring av minne. 
                GUI_FORM.logForm = null;
            }
            this.Close();
        }

        /// <summary>
        /// Metoder for flytting av vinduet.
        /// </summary>
        #region Mover
        private void btnMove1_MouseDown(object sender, MouseEventArgs e)
        {
            Mover = 1;
            MoveX = e.X;
            MoveY = e.Y;
        }
        private void btnMove1_MouseUp(object sender, MouseEventArgs e)
        {
            Mover = 0;
        }
        private void btnMove1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mover == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MoveX, MousePosition.Y - MoveY);
            }
        }
        #endregion Mover. 

        /// <summary>
        /// Oppdaterer loggen fortløpende. 
        /// </summary>
        private void tmrUpdateText_Tick(object sender, EventArgs e)
        {            
            FileStream fs = null; // initierer filestream. 
            try
            {
                // Henter dagens logfilnavn fra logger
                // Åpner filen i ReadOnly, men fileshare Readwrite slik at logger fortsatt kan skrive til filen. 
                fs = new FileStream(Logger.currentLog, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (StreamReader sr = new StreamReader(fs)) // bruker using slik at sr automatisk blir disposed. 
                {
                    fs = null;
                    txtRead.Text = sr.ReadToEnd(); // fyller txtRead med tekst fra logfil. 
                    txtRead.SelectionStart = txtRead.Text.Length;
                    txtRead.ScrollToCaret(); // Autoscroller til bunnen av loggen. 
                }
            }
            catch (Exception) { } // gjør ingenting med en eventuell error. 
            finally
            {
                // disposer fs dersom StreamReaderen sr ikke har fått lest filestreamen. 
                if (fs != null)
                    fs.Dispose();
            }
        }
      
        /// <summary>
        /// Fyller tekstområdet med dagens log-fil. 
        /// </summary>
        private void Log_Load(object sender, EventArgs e)
        {
            // Følgende er helt likt innhold i tmrUpdateText_Tick metoden, kommentarer kan leses der.
            tmrUpdateText.Start();
            FileStream fs = null;
            try
            {
                fs = new FileStream(Logger.currentLog, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (StreamReader sr = new StreamReader(fs))
                {
                    fs = null;
                    txtRead.Text = sr.ReadToEnd();

                    // Scroller ikke til bunnen av loggen her.                     
                }
            }
            catch (Exception) { }
            finally
            {
                if(fs != null)
                    fs.Dispose();
            }
            
        }

        
    }
}

