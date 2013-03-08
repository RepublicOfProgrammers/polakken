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
            crtView.ChartAreas["tempOversikt"].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            crtView.ChartAreas["tempOversikt"].AxisX.Interval = 1;
            crtView.ChartAreas["tempOversikt"].AxisY.Minimum = -5;
            crtView.ChartAreas["tempOversikt"].AxisY.Maximum = 50;
            crtView.ChartAreas["tempOversikt"].AxisY.Interval = 10;
            crtView.ChartAreas["tempOversikt"].BackColor = Color.Transparent;
            crtView.ChartAreas["tempOversikt"].AxisX.MajorGrid.LineColor = Color.DarkGray; 
            crtView.ChartAreas["tempOversikt"].AxisY.MajorGrid.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.ForeColor = Color.GreenYellow;
            crtView.ChartAreas["tempOversikt"].AxisX.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.LabelStyle.ForeColor = Color.GreenYellow;


            
            crtView.Series.Add("temp");
            crtView.Series["temp"].Color = Color.LawnGreen;
            crtView.Series["temp"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtView.Series["temp"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            crtView.Series["temp"].Points.AddXY(4131.6084899700, 10);
            crtView.Series["temp"].Points.AddXY(4131.6084899725, 40);
            crtView.Series["temp"].Points.AddXY(4131.6084899750, 43);
            crtView.Series["temp"].Points.AddXY(4131.6084899775, 5);
            

           
            crtView.Series.Add("MaxSet");
            crtView.Series["MaxSet"].Color = Color.Red;
            crtView.Series["MaxSet"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtView.Series["MaxSet"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
          
            

            crtView.Series.Add("MinSet");
            crtView.Series["MinSet"].Color = Color.Blue;
            crtView.Series["MinSet"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtView.Series["MinSet"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
         

            crtView.Series["temp"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            

            //MAX/MIN TEST

            double MinYVlaue = double.MaxValue;
            double SetMinY = MinYVlaue;
            double MaxYVlaue = double.MinValue;
            double MaxXValue = double.MinValue;
            double MinXValue = double.MaxValue;
            double LastX = 0;
            double LastY = 0;
            
            foreach (var pt in crtView.Series["temp"].Points)
            {
                if (MaxYVlaue < pt.YValues[0])
                {
                    MaxYVlaue = pt.YValues[0];
                    MaxXValue = pt.XValue;

                }
                if (pt.YValues[0] < MinYVlaue)
                {
                    MinYVlaue = pt.YValues[0];
                    MinXValue = pt.XValue;
                }
                LastX = pt.XValue;
                LastY = pt.YValues[0];
               
            }


            DateTime MaxDTX = DateTime.FromOADate(MaxXValue);
            
           txtCurrent.AppendText(LastY + "°C");
           txtCurrentTime.AppendText(LastX.ToString());
           string c = "°C";
           txtMax.AppendText(MaxYVlaue + c);
           txtMin.AppendText(MinYVlaue + c);
           txtMaxTime.AppendText(MaxDTX.ToString());
           txtMinTime.AppendText(MinXValue.ToString());   

                    
            


           
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
