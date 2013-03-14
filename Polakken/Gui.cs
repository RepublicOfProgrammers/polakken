using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Polakken
{
    public partial class GUI : Form
    {

        int Mover;
        int MoveX;
        int MoveY;
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
            crtView.Series["temp"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            crtView.Series["temp"].Points.AddXY(1, 9);
            crtView.Series["temp"].Points.AddXY(12, 32);
            crtView.Series["temp"].Points.AddXY(30, 8);
            crtView.Series["temp"].Points.AddXY(50, 20);
            


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
            txtSetPoint.Text = "00";




            DbHandler DB = new DbHandler();
            DateTime test = DateTime.Today;
           

            //    while (DB.GetReadings().Read())
            //    {
            //        table.Rows.Add(new object[] { DB.GetReadings()[0], DB.GetReadings()[1], DB.GetReadings()[2] });
            //    }
            //    crtView.DataSource = table;
            //    //add series
            //    for (int i = 0; i < table.Rows.Count; i++)
            //    {
            //        if (crtView.Series.Where(x => x.Name == table.Rows[i][0].ToString()).Count() > 0)
            //        {

            //        }
            //        else
            //        {
            //            crtView.Series.Add(table.Rows[i][0].ToString());

            //        }
            //    }
            //    for (int i = 0; i < crtView.Series.Count; i++)
            //    {

            //        crtView.Series[i].XValueMember = "Date";
            //        crtView.Series[i].YValueMembers = "Value";

            //        crtView.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            //    }
            //    crtView.DataBind();
            //}



        }
        private void btnLukk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void btnMove_MouseDown(object sender, MouseEventArgs e)
        {
            Mover = 1;
            MoveX = e.X;
            MoveY = e.Y;
        }

        private void btnMove_MouseUp(object sender, MouseEventArgs e)
        {
            Mover = 0;
        }

        private void btnMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mover == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MoveX, MousePosition.Y - MoveY);
            }
            

        }


        


        private void send_Click(object sender, EventArgs e)
        {
            E_mail_handler email = new E_mail_handler();
            for (int i = 0; i < 100; i++)
            {
                if (txtEmail1.Text != "")
                {
                    email.client.Send("republicofprogrammers@gmail.com", txtEmail1.Text, "Hei", "Hei");
                }
                //if (txtEmail2.Text != "")
                //{
                //    email.client.Send("republicofprogrammers@gmail.com", txtEmail2.Text, "Hei", "Hei");
                //}
                if (txtEmail3.Text != "")
                {
                    email.client.Send("republicofprogrammers@gmail.com", txtEmail3.Text, "Hei", "Hei");
                }
                if (txtEmail4.Text != "")
                {
                    email.client.Send("republicofprogrammers@gmail.com", txtEmail4.Text, "Hei", "Hei");
                }
                txtEmail2.Text = Convert.ToString(i);
            }
            MessageBox.Show("Mailen har blitt sendt");
        }

            

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnSaveAll.BackgroundImage = global::Polakken.Properties.Resources.LagreDown;
        }

        private void btnSaveAll_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnSaveAll.BackgroundImage = global::Polakken.Properties.Resources.Lagre;
            MessageBox.Show("Du har nå lagret de nye verdiene", "Suksess", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnSetPointUp_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnSetPointUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUpDown;
        }

        private void btnSetPointUp_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnSetPointUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUp;
        }

        private void btnSetPointDown_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnSetPointDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDownDown;
        }

        private void btnSetPointDown_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnSetPointDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDown;
        }

        private void btnToleranceUp_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnToleranceUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUpDown;
        }

        private void btnToleranceUp_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnToleranceUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUp;
        }

        private void btnToleranceDown_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnToleranceDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDownDown;
        }

        private void btnToleranceDown_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnToleranceDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDown;
        }

        private void btnMesIUp_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnMesIUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUpDown;
        }

        private void btnMesIUp_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnMesIUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUp;
        }

        private void btnMesIDown_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnMesIDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDownDown;
        }

        private void btnMesIDown_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnMesIDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDown;
        }

        private void btnAlarmUp_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnAlarmUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUpDown;
        }

        private void btnAlarmUp_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnAlarmUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUp;
        }

        private void btnAlarmDown_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnAlarmDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDownDown;
        }

        private void btnAlarmDown_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnAlarmDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDown;
        }

        private void btnSaveAll_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnSaveAll.BackgroundImage = global::Polakken.Properties.Resources.LagreDown;
        }

        private void btnMove_Click(object sender, EventArgs e)
        {

        }

        private void btnSetPointUp_Click(object sender, EventArgs e)
        {

        }

        private void txtCurrent_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMax_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCurrentTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaxTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMinTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSetPoint_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAlarm_TextChanged(object sender, EventArgs e)
        {

        }
      
     

   

  }
}



   