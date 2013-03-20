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
        double SetPoint = 0.0;
        double tolerance = 0.0;
        double mesurInterval = 0.0;
        DataTable u = new DataTable();
        
        

        public GUI()
        {
            InitializeComponent();

        }

        private void GUI_Load(object sender, EventArgs e)
        {
            //
            // Opprett DataTabell og fyll DataGridView
            //
            CreateValues();
            DebugginTestTwo(u);
            dgvDataBase.DataSource = u;
            DataTable LastReading = new DataTable();
            GetLast(LastReading);
            DataTable Equals = new DataTable();
            equals(Equals);
            



            try
            {

                DataView viewStatus = new DataView(u);
                DataTable distinctStatusValues = viewStatus.ToTable(true, "Status");
                cboFilterStatus.DataSource = distinctStatusValues;
                cboFilterStatus.DisplayMember = "Status";
                cboFilterTemp.ValueMember = "Status";

            }
            catch
            {
            }

            try
            {
                DataView viewTemp = new DataView(u);
                DataTable distinctTempValues = viewTemp.ToTable(true, "Temprature");
                cboFilterTemp.DataSource = distinctTempValues;
                cboFilterTemp.DisplayMember = "Temprature";
                cboFilterTemp.ValueMember = "Temprature";
            }
            catch
            {
            }
            try
            {
                DataView viewEquals = new DataView(Equals);
                DataTable distinctTempValues = viewEquals.ToTable(true, "textEquals");
                cboEqualsFilter.DataSource = distinctTempValues;
                cboEqualsFilter.DisplayMember = "textEquals";
                cboEqualsFilter.ValueMember = "valueEquals";
            }
            catch
            {
            }




            //
            // Graf:
            //

            crtView.DataSource = u;
            crtView.ChartAreas.Add("tempOversikt");
            crtView.ChartAreas["tempOversikt"].AxisX.Minimum = 0;
            crtView.ChartAreas["tempOversikt"].AxisX.Maximum = 336;
            crtView.ChartAreas["tempOversikt"].AxisX.Interval = 48;
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
            crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.Angle = 0;


            crtView.Series.Add("temp");
            crtView.Series["temp"].Color = Color.LawnGreen;
            crtView.Series["temp"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtView.Series["temp"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            crtView.Series["temp"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            crtView.Series["temp"].XValueMember = "ReadTime";
            crtView.Series["temp"].YValueMembers = "Temprature";
            crtView.DataBind();

            //
            //Instillger
            //

            Regulation reg = new Regulation(SetPoint, tolerance, mesurInterval);
            SetPoint = reg.setpoint;
            txtSetPoint.Text = SetPoint.ToString();
            tolerance = reg.tolerance;
            txtTol.Text = tolerance.ToString();
            mesurInterval = reg.mesInterval;
            txtInt.Text = mesurInterval.ToString();

            //
            //Filtrering av databasen
            //



        }

        //
        //Fyller Datatabellen for fortegn for filter
        //

        public DataTable equals(DataTable dtbEquals)
        {
            dtbEquals.Columns.Add("textEquals", typeof(string));
            dtbEquals.Rows.Add("Er nøyaktig");
            dtbEquals.Rows.Add("Over");
            dtbEquals.Rows.Add("Under");
            return dtbEquals;
        }

        //
        //Koble Til Databasen og hente ut verdier
        //

        public DataTable DebugginTestTwo(DataTable v)
        {

            DbHandler db = new DbHandler();
            v.Columns.Add("ReadTime", typeof(string));
            v.Columns.Add("Temprature", typeof(string));
            v.Columns.Add("Status", typeof(string));


            db.OpenDb();
            SqlCeDataReader mReader = db.GetReadings();

            while (mReader.Read())
            {
                var row = v.NewRow();
                for (int i = 0; i < 3; i++)
                {

                    string Reading = mReader[i].ToString();
                    if (i == 0)
                    {
                        row["ReadTime"] = Reading;
                    }
                    if (i == 1)
                    {
                        row["Temprature"] = Reading;
                    }
                    if (i == 2)
                    {
                        row["Status"] = Reading;
                    }
                }
                v.Rows.Add(row);

            }

            mReader.Close();
            db.CloseDb();
            return v;
        }
        public DataTable GetLast(DataTable GetLastR)
        {
            DbHandler db = new DbHandler();
            GetLastR.Columns.Add("ReadTime", typeof(DateTime));
            GetLastR.Columns.Add("Temprature", typeof(string));
            GetLastR.Columns.Add("Status", typeof(string));


            db.OpenDb();
            SqlCeDataReader mReader = db.GetReadings();

            while (mReader.Read())
            {
                var row = GetLastR.NewRow();
                for (int i = 0; i < 3; i++)
                {

                    string Reading = mReader[i].ToString();
                    if (i == 0)
                    {
                        row["ReadTime"] = Reading;
                    }
                    if (i == 1)
                    {
                        row["Temprature"] = Reading;
                    }
                    if (i == 2)
                    {
                        row["Status"] = Reading;
                    }
                }
                GetLastR.Rows.Add(row);

            }

            mReader.Close();
            db.CloseDb();
            return GetLastR;
        }
        private void CreateValues()
        {
            Random rnd = new Random();
            DbHandler db = new DbHandler();
            DateTime time = DateTime.Today;
            
            Boolean t = true;
            Boolean f = false;
            for (int i = 0; i < 2; i++)
            {
                if (i % 2 == 0)
                {
                    int C = rnd.Next(-5, 50);
                    DateTime newday = time.AddDays(i);
                    db.SetReading(newday, C, t);

                }
                else
                {
                    int C = rnd.Next(-5, 50);
                    DateTime newday = time.AddDays(i);
                    db.SetReading(newday, C, f);
                }
            }
        }


        //
        //Form Hendelser
        //

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


        //
        //E-Mail
        //

        private void send_Click(object sender, EventArgs e)
        {
            E_mail_handler email = new E_mail_handler();
            try
            {
                if (txtEmail1.Text != "")
                {
                    email.client.Send("republicofprogrammers@gmail.com", txtEmail1.Text, "Hei", "Hei");
                }
                if (txtEmail2.Text != "")
                {
                    email.client.Send("republicofprogrammers@gmail.com", txtEmail2.Text, "Hei", "Hei");
                }
                if (txtEmail3.Text != "")
                {
                    email.client.Send("republicofprogrammers@gmail.com", txtEmail3.Text, "Hei", "Hei");
                }
                if (txtEmail4.Text != "")
                {
                    email.client.Send("republicofprogrammers@gmail.com", txtEmail4.Text, "Hei", "Hei");
                }
                MessageBox.Show("Mailen har blitt sendt");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //
        //Hendelser
        //
        private void btnSaveAll_MouseDown(object sender, MouseEventArgs e)
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
            this.btnSetPointDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDown;
            txtSetPoint.Enabled = true;
            double ChangeSetPointAdd = SetPoint;
            ChangeSetPointAdd = ChangeSetPointAdd + 1;
            SetPoint = ChangeSetPointAdd;
            txtSetPoint.Text = ChangeSetPointAdd.ToString();
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
            double ChangeSetPointSub = SetPoint;
            ChangeSetPointSub = ChangeSetPointSub - 1;
            if (ChangeSetPointSub < 0)
            {
                MessageBox.Show("Nedre Grense Nådd", "FEIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChangeSetPointSub = SetPoint;
                txtSetPoint.Text = ChangeSetPointSub.ToString();
                SetPoint = ChangeSetPointSub;
                txtSetPoint.Enabled = false;
                this.btnSetPointDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDownDown;

            }
            txtSetPoint.Text = ChangeSetPointSub.ToString();
            SetPoint = ChangeSetPointSub;
        }

        private void btnToleranceUp_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnToleranceUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUpDown;
            tolerance = tolerance + 1;
            txtTol.Text = tolerance.ToString();
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

        private void btnShowSelected_Click(object sender, EventArgs e)
        {
            DataView view = new DataView(u);
            string filterString = null;
            string dateSpan = null;


            if (chkFilterDate.Checked)
            {

                string dates = null;
                DateTime startDate;
                DateTime endDate;
                startDate = Convert.ToDateTime(dtpSelectFrom.Text);
                endDate = Convert.ToDateTime(dtpSelectTo.Text);
                dates = "ReadTime >" + "'" + startDate + "'" + "AND ReadTime <" + "'" + endDate + "'";
                view.RowFilter = dates;
                dateSpan = "AND ReadTime >" + "'" + startDate + "'" + "AND ReadTime <" + "'" + endDate + "'"; 


            }
            if (chkFilterStatus.Checked)
            {
                
                int statusIndex;
                statusIndex = cboFilterStatus.SelectedIndex;
                string statusText = null;
                if (statusIndex == 0)
                {
                    statusText = "'True'";
                    filterString = "AND Status =" + statusText + dateSpan;
                    view.RowFilter = "Status =" + statusText + dateSpan;
                }
                if (statusIndex == 1)
                {
                    statusText = "'False'";
                    filterString = "AND Status =" + statusText;
                    view.RowFilter = "Status =" + statusText;
                }
               
                
            } 
             if (chkFilterTemp.Checked)
                {
                    string valueTempString = cboFilterTemp.Text;
                    //int valueTempINT = Convert.ToInt32(valueTempString);
                    
                    int statusIndex;
                    statusIndex = cboEqualsFilter.SelectedIndex;

                    if (statusIndex == 0)
                    {
                        
                        view.RowFilter = "Temprature =" + valueTempString + filterString +  dateSpan;
                    
                    }
                    if (statusIndex == 1)
                    {
                        view.RowFilter = "Temprature >" + valueTempString + filterString + dateSpan;
                        
                    }
                    if (statusIndex == 2)
                    {
                        view.RowFilter = "Temprature <" + valueTempString + filterString + dateSpan;
                        
                    }  
                   
                }

                dgvDataBase.DataSource = view;

            }
                
        

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvDataBase.DataSource = u;
        }

        private void chkFilterStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFilterStatus.Checked)
            {
                cboFilterStatus.Enabled = true;
            }
            else
            {
                cboFilterStatus.Enabled = false;
            }

        }

        private void chkFilterTemp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFilterTemp.Checked)
            {
                cboEqualsFilter.Enabled = true;
                cboFilterTemp.Enabled = true;
            }
            else
            {
                cboEqualsFilter.Enabled = false;
                cboFilterTemp.Enabled = false;
            }
        }

        private void chkFilterDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFilterDate.Checked)
            {
                dtpSelectFrom.Enabled = true;
                dtpSelectTo.Enabled = true;

            }
            else
            {
                dtpSelectFrom.Enabled = false;
                dtpSelectTo.Enabled = false;
            }
        }









    }
}





   