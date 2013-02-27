using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Polakken
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
           
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            crtOversikt.ChartAreas.Add("tempOversikt");
            crtOversikt.ChartAreas["tempOversikt"].AxisX.Minimum = 0;
            crtOversikt.ChartAreas["tempOversikt"].AxisX.Maximum = 20;
            crtOversikt.ChartAreas["tempOversikt"].AxisX.Interval = 1;
            crtOversikt.ChartAreas["tempOversikt"].AxisY.Minimum = -30;
            crtOversikt.ChartAreas["tempOversikt"].AxisY.Interval = 10;
            crtOversikt.ChartAreas["tempOversikt"].BackColor = Color.Black;
            crtOversikt.ChartAreas["tempOversikt"].AxisX.MajorGrid.LineColor = Color.DarkGray;
            crtOversikt.ChartAreas["tempOversikt"].AxisY.MajorGrid.LineColor = Color.DarkGray;
            crtOversikt.ChartAreas["tempOversikt"].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            crtOversikt.ChartAreas["tempOversikt"].AxisX.LabelStyle.ForeColor = Color.Yellow;
            crtOversikt.ChartAreas["tempOversikt"].AxisX.LineColor = Color.DarkGray;
            crtOversikt.ChartAreas["tempOversikt"].AxisY.LineColor = Color.DarkGray;
            crtOversikt.ChartAreas["tempOversikt"].AxisY.LabelStyle.ForeColor = Color.Yellow;
            
            
            
            crtOversikt.Series.Add("Pakistan");
            crtOversikt.Series.Add("India");

            crtOversikt.Series["Pakistan"].Color = Color.Green;
            crtOversikt.Series["India"].Color = Color.Red;

            crtOversikt.Series["Pakistan"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtOversikt.Series["India"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtOversikt.Series["Pakistan"].BorderWidth = 2;
            crtOversikt.Series["India"].BorderWidth = 2;
            
                

            crtOversikt.Series["Pakistan"].Points.AddXY(0, 0);
            crtOversikt.Series["India"].Points.AddXY(0, 0);

            crtOversikt.Series["Pakistan"].Points.AddXY(1, 4);
            crtOversikt.Series["India"].Points.AddXY(1, 9);

            crtOversikt.Series["Pakistan"].Points.AddXY(12, -10);
            crtOversikt.Series["India"].Points.AddXY(12, 20);

            crtOversikt.Series["Pakistan"].Points.AddXY(13, 5);
            crtOversikt.Series["India"].Points.AddXY(13, 15);

            crtOversikt.Series["Pakistan"].Points.AddXY(15, -100);
            crtOversikt.Series["India"].Points.AddXY(15, -34);

            crtOversikt.Series["Pakistan"].Points.AddXY(16, -50);
            crtOversikt.Series["India"].Points.AddXY(16, -10);

           

         


            //Tekstboksen:

            txtSiste.BackColor = Color.Black;
            txtSiste.ForeColor = Color.Green;
            txtSiste.AppendText("50");
            

            
        }

        private void tabOversikt_Click(object sender, EventArgs e)
        {

        }

        private void txtSiste_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
