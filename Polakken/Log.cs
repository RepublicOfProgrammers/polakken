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
        public string msgbxms;
        public static string ourPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        string file = ourPath + @"\bin\Files\";
        public Log()
        {
            InitializeComponent();
            
        }

        private void btnLukk_Click(object sender, EventArgs e)
        {
            if(GUI_FORM.logForm != null) GUI_FORM.logForm.Dispose();
            this.Close();
        }

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

        private void tmrUpdateText_Tick(object sender, EventArgs e)
        {
            
            FileStream fs = null;
            try
            {
                fs = new FileStream(Logger.currentLog, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (StreamReader sr = new StreamReader(fs))
                {
                    fs = null;
                    txtRead.Text = sr.ReadToEnd();
                    txtRead.SelectionStart = txtRead.Text.Length;
                    txtRead.ScrollToCaret();
                }
            }
            catch (Exception) { }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }
        }
      
        private void Log_Load(object sender, EventArgs e)
        {
            tmrUpdateText.Start();
            FileStream fs = null;
            try
            {
                fs = new FileStream(Logger.currentLog, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (StreamReader sr = new StreamReader(fs))
                {
                    fs = null;
                    txtRead.Text = sr.ReadToEnd();
                    
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

