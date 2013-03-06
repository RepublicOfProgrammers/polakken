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

            // Graf:

            crtView.ChartAreas.Add("tempOversikt");
            crtView.ChartAreas["tempOversikt"].AxisX.Minimum = 0;
            crtView.ChartAreas["tempOversikt"].AxisX.Maximum = 20;
            crtView.ChartAreas["tempOversikt"].AxisX.Interval = 1;
            crtView.ChartAreas["tempOversikt"].AxisY.Minimum = -30;
            crtView.ChartAreas["tempOversikt"].AxisY.Interval = 10;
            crtView.ChartAreas["tempOversikt"].BackColor = Color.Transparent;
            crtView.ChartAreas["tempOversikt"].AxisX.MajorGrid.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.MajorGrid.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.ForeColor = Color.GreenYellow;
            crtView.ChartAreas["tempOversikt"].AxisX.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.LabelStyle.ForeColor = Color.GreenYellow;
            
            
            
            crtView.Series.Add("Pakistan");
            crtView.Series.Add("India");

            crtView.Series["Pakistan"].Color = Color.LawnGreen;
            crtView.Series["India"].Color = Color.Red;

            crtView.Series["Pakistan"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtView.Series["India"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtView.Series["Pakistan"].BorderWidth = 2;
            crtView.Series["India"].BorderWidth = 2;
            
                

            crtView.Series["Pakistan"].Points.AddXY(0, 0);
            crtView.Series["India"].Points.AddXY(0, 0);

            crtView.Series["Pakistan"].Points.AddXY(1, 4);
            crtView.Series["India"].Points.AddXY(1, 9);

            crtView.Series["Pakistan"].Points.AddXY(12, -10);
            crtView.Series["India"].Points.AddXY(12, 20);

            crtView.Series["Pakistan"].Points.AddXY(13, 5);
            crtView.Series["India"].Points.AddXY(13, 15);

            crtView.Series["Pakistan"].Points.AddXY(15, -100);
            crtView.Series["India"].Points.AddXY(15, -34);

            crtView.Series["Pakistan"].Points.AddXY(16, -50);
            crtView.Series["India"].Points.AddXY(16, -10);


            txtCurrent.AppendText("42" + "°C");
            txtCurrentTime.AppendText("06.03.2013" + " " + "13:37");


            

            
        }

        private void tabOversikt_Click(object sender, EventArgs e)
        {

        }

       

        private void btnLukk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       
     
    }
}
