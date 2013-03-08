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
            crtView.ChartAreas["tempOversikt"].AxisX.Interval = 5;
            crtView.ChartAreas["tempOversikt"].AxisY.Minimum = -5;
            crtView.ChartAreas["tempOversikt"].AxisY.Maximum = 50;
            crtView.ChartAreas["tempOversikt"].AxisY.Interval = 10;
            crtView.ChartAreas["tempOversikt"].BackColor = Color.Transparent;
            crtView.ChartAreas["tempOversikt"].AxisX.MajorGrid.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.MajorGrid.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.ForeColor = Color.GreenYellow;
            crtView.ChartAreas["tempOversikt"].AxisX.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.LabelStyle.ForeColor = Color.GreenYellow;

            crtView.Series.Add("temp");
            crtView.Series["temp"].Color = Color.LawnGreen;
            crtView.Series["temp"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtView.Series["temp"].Points.AddXY(0, 10);
            crtView.Series["temp"].Points.AddXY(13, 40);
            crtView.Series["temp"].Points.AddXY(20, 29);
            crtView.Series["temp"].Points.AddXY(50, 5);
            
            
            crtView.Series.Add("MaxSet");
            crtView.Series["MaxSet"].Color = Color.Orange;
            crtView.Series["MaxSet"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtView.Series["MaxSet"].Points.AddXY(0, 30);
            crtView.Series["MaxSet"].Points.AddXY(50, 30);
            

            crtView.Series.Add("MinSet");
            crtView.Series["MinSet"].Color = Color.SlateBlue;
            crtView.Series["MinSet"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtView.Series["MinSet"].Points.AddXY(0, 5);
            crtView.Series["MinSet"].Points.AddXY(50, 5);

            crtView.Series["temp"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;



            double MinY = double.MaxValue;
            double SetMinY = MinY;
            double greatestYValue = double.MinValue;
            double MaxXValue = double.MinValue;
            double MinXValue = double.MaxValue;
            double CurrentSetMaxX = double.MinValue;
            double CurrentSetMaxY = double.MinValue;
            foreach (var ptSetMax in crtView.Series["MaxSet"].Points)
            {
                if (CurrentSetMaxX > ptSetMax.XValue)
                {
                    CurrentSetMaxX = ptSetMax.XValue;
                    CurrentSetMaxY = ptSetMax.YValues[0];
                }
            }
            foreach (var pt in crtView.Series["temp"].Points)
            {
                if (greatestYValue < pt.YValues[0])
                {
                    greatestYValue = pt.YValues[0];
                    MaxXValue = pt.XValue;

                }
                if (pt.YValues[0] < MinY)
                {
                    MinY = pt.YValues[0];
                    MinXValue = pt.XValue;
                }
               
            }
          
            //for (int i = 0; i < 100; i++)
            //{
            //    double d = crtView.Series["temp"].Points[i].YValues[0];

            //    if (d > MaxLim)
            //    {
            //        txtMax.AppendText(d.ToString() + "°C");
            //        txtMax.ForeColor = Color.Red;
                    
            //    }
            //    else
            //    {
                            //    }
            //}
           txtCurrent.AppendText("42" + "°C");
           txtCurrentTime.AppendText("06.03.2013" + " " + "13:37");
           string c = "°C";
           string t = "13:37";
           txtMax.AppendText(greatestYValue + c);
           txtMin.AppendText(MinY + c);
           txtMaxTime.AppendText(MaxXValue + " " + t);
           txtMinTime.AppendText(MinXValue + " " + t);   

                    
            


           
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
