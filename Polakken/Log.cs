using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Polakken
{
    public partial class Log : Form
    {
        public static string ourPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        string file = ourPath + @"\bin\Files\";
        public Log()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtRead.Text = "";
            DialogResult result = ofdRead.ShowDialog();
            if (result == DialogResult.OK)
            {
                string data = Read(ofdRead.FileName);
                txtRead.Text = data;
            }
            else
            {

                //do nothing
            }
        }
        private string Read(string file)
        {

            StreamReader reader = new StreamReader(file);
            string data = reader.ReadToEnd();
            reader.Close();

            return data;
        }

        private void txtRead_TextChanged(object sender, EventArgs e)
        {
            txtRead.AppendText("Tidspunkt \tType \tKlasse \t\tMelding");
        }
    }
}
