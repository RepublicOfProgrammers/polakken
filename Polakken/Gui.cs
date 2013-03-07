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
            crtView.ChartAreas["tempOversikt"].AxisX.Maximum = 50;
            crtView.ChartAreas["tempOversikt"].AxisX.Interval = 1;
            crtView.ChartAreas["tempOversikt"].AxisY.Minimum = -5;
            crtView.ChartAreas["tempOversikt"].AxisY.Interval = 20;
            crtView.ChartAreas["tempOversikt"].BackColor = Color.Transparent;
            crtView.ChartAreas["tempOversikt"].AxisX.MajorGrid.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.MajorGrid.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.ForeColor = Color.GreenYellow;
            crtView.ChartAreas["tempOversikt"].AxisX.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.LabelStyle.ForeColor = Color.GreenYellow;
            
            
            
            crtView.Series.Add("Temp");
            crtView.Series.Add("MaxSet");
            crtView.Series.Add("MinSet");


            crtView.Series["Temp"].Color = Color.LawnGreen;
            crtView.Series["MaxSet"].Color = Color.Orange;
            crtView.Series["MinSet"].Color = Color.SlateBlue;




            crtView.Series["Temp"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtView.Series["MaxSet"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtView.Series["MinSet"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtView.Series["Temp"].BorderWidth = 2;
            crtView.Series["MaxSet"].BorderWidth = 2;
            crtView.Series["MinSet"].BorderWidth = 2;
                

            crtView.Series["Temp"].Points.AddXY(0, 0);
            crtView.Series["MaxTemp"].Points.AddXY(0, 25);
            crtView.Series["MinTemp"].Points.AddXY(0, 5);

            crtView.Series["Temp"].Points.AddXY(1, 4);
        

            crtView.Series["Temp"].Points.AddXY(12, -10);
         

            crtView.Series["Temp"].Points.AddXY(13, 5);
       

            crtView.Series["Temp"].Points.AddXY(15, -100);
         

            crtView.Series["Temp"].Points.AddXY(16, -50);
            crtView.Series["MaxTemp"].Points.AddXY(30, 25);
            crtView.Series["MinTemp"].Points.AddXY(30, 5);
   


            txtCurrent.AppendText("42" + "°C");
            txtCurrentTime.AppendText("06.03.2013" + " " + "13:37");

            string hello = "666";
            string world = "06.03.2013";
            string c = "°C";
            string t = "13:37";
            txtMax.AppendText(hello + c);
            txtMin.AppendText(hello + c);
            txtMaxTime.AppendText(world + " " + t);
            txtMinTime.AppendText(world + " " + t);
            
            

            
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
