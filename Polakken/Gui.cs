using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Diagnostics;

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
        DataTable GetEmails = new DataTable();
        

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
            GetEmail(GetEmails);
            dgvEmail.DataSource = GetEmails;
            DataTable Equals = new DataTable();
            equals(Equals);
            populateTxtbox();



            try
            {

                DataView viewStatus = new DataView(u);
                DataTable distinctStatusValues = viewStatus.ToTable(true, "Status");
                cboFilterStatus.DataSource = distinctStatusValues;
                cboFilterStatus.DisplayMember = "Status";
                cboFilterTemp.ValueMember = "Status";

            }
            catch (Exception)
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
            catch (Exception)
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
            catch(Exception)
            {
            }
            try
            {
                DataView viewDeleteEmail = new DataView(GetEmails);
                cboDelEmail.DataSource = viewDeleteEmail;
                cboDelEmail.DisplayMember = "Adresser";
                cboDelEmail.ValueMember = "Index";
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
            //TabellVisning
            //
            dgvDataBase.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDataBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
         
            
            //
            //Email TabellVisning
            //
            dgvDataBase.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


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
            //DateTimePickers
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
            if (v.Columns.Contains("ReadTime") & v.Columns.Contains("Temprature") & v.Columns.Contains("Status"))
            {
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
            }
            else
            {
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
            }

            db.CloseDb();
            return v;
        }
       
        public DataTable GetEmail(DataTable GetEmails)
        {
            
            DbHandler db = new DbHandler();
            if (GetEmails.Columns.Contains("Adresser"))
            {
                db.OpenDb();
                SqlCeDataReader emReader = db.GetEmails();

                while (emReader.Read())
                {
                    var row = GetEmails.NewRow();
                    for (int i = 0; i < 2; i++)
                    {

                        string Reading = emReader[i].ToString();
                        if (i == 0)
                        {
                            row["Index"] = Reading; 
                        }
                        if (i == 1)
                        {
                            
                            row["Adresser"] = Reading;
                        }
                    }
                    GetEmails.Rows.Add(row);

                }

                emReader.Close();
            }
            else
            {
                
                GetEmails.Columns.Add("Index", typeof(int));
                GetEmails.Columns.Add("Adresser", typeof(string));
                db.OpenDb();
                SqlCeDataReader emReader = db.GetEmails();

                while (emReader.Read())
                {
                    var row = GetEmails.NewRow();
                    for (int i = 0; i < 2; i++)
                    {

                        string Reading = emReader[i].ToString();
                        if (i == 0)
                        {
                            row["Index"] = Reading;
                        }
                        if (i == 1)
                        {
                            row["Adresser"] = Reading;
                           
                        }
                       
                    }
                    GetEmails.Rows.Add(row);

                }

                emReader.Close();
            }
            
            db.CloseDb();
            return GetEmails;
        }

        private void DelEmails(int indexNumber)
        {
            DbHandler db = new DbHandler();
            db.DelEmail(indexNumber);

        }
        private void DelReadings()    
        {
            DbHandler db = new DbHandler();
            DateTime delFrom = DateTime.MinValue;
            DateTime delTo = DateTime.MaxValue;
            delTo = dtpDelTo.Value;
            delFrom = dtpDelFrom.Value;
            if (delFrom > delTo)
            {
                MessageBox.Show("Fradato kan ikke være større enn tildato", "Feil");
            }
            string delToString;
            string delFromString;
            delToString = delTo.ToString("yyyy.MM.dd hh:mm:ss");
            delFromString = delFrom.ToString("yyyy.MM.dd hh:mm:ss");
            db.DelReadings(delFromString, delToString);
            MessageBox.Show(delToString + delFromString);

        }

        private void CreateValues()
        {
            Random rnd = new Random();
            Random rnd2 = new Random();
            DbHandler db = new DbHandler();
            DateTime time = DateTime.Today;
             

            Boolean t = true;
            Boolean f = false;
            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0)
                {
                    int C = i + 5;
                    DateTime newday = time.AddDays(i);
                    db.SetReading(newday, C, t);

                }
                else
                {
                   int C = i - 5;
                    DateTime newday = time.AddDays(i);
                    db.SetReading(newday, C, f);
                }
                
            }
            string emaildummy;
            string emaildummy2;
                
            emaildummy = "alexandergjerseth@gmail.com";
            emaildummy2 = "sglittum@gmail.com";

            db.AddEmail(emaildummy);
            db.AddEmail(emaildummy2);
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

        private void populateTxtbox()
        {
            int maxTemp = int.MinValue;
            int maxTempTest = int.MinValue;
            int minTemp = int.MaxValue;
            int minTempTest = int.MaxValue;
            string Celcius = "°C";
            foreach (DataRow row in u.Rows)
            {
                txtCurrent.Text = row["Temprature"].ToString() + Celcius;
                DateTime dt = DateTime.Parse(row["ReadTime"].ToString());
                txtCurrentTime.Text = dt.ToString();

                maxTempTest = int.Parse(row["Temprature"].ToString());
                if (maxTemp < maxTempTest)
                {
                    maxTemp = maxTempTest;
                    DateTime maxDT = DateTime.Parse(row["ReadTime"].ToString());
                    txtMaxTime.Text = maxDT.ToString();
                    txtMax.Text = maxTemp.ToString() + Celcius;
                }
                minTempTest = int.Parse(row["Temprature"].ToString());
                if (minTemp > minTempTest)
                {
                    minTemp = minTempTest;
                    DateTime minDT = DateTime.Parse(row["ReadTime"].ToString());
                    txtMinTime.Text = minDT.ToString();
                    txtMin.Text = minTemp.ToString() + Celcius;
                }

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
            if (dtpSelectFrom.Value > dtpSelectTo.Value)
            {
                MessageBox.Show("Startdato kan ikke være større en sluttdato", "Datofeil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataView view = new DataView(u);
            string filterString = null;
            string dateSpan = null;


            if (chkFilterDate.Checked)
            {
                string dates = null;
                DateTime startDate;
                DateTime endDate;
                startDate = dtpSelectFrom.Value;
                endDate = dtpSelectTo.Value;
                dates = String.Format(System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat, "ReadTime >= #{0}#", startDate) + String.Format(System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat, " AND ReadTime <= #{0}#", endDate);
                view.RowFilter = dates;
                dateSpan = String.Format(System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat, "AND ReadTime >= #{0}#", startDate) + String.Format(System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat, " AND ReadTime <= #{0}#", endDate);

                


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
            CreateValues();
            dgvDataBase.DataSource = null;
            u.Clear();
            DebugginTestTwo(u);
            dgvDataBase.DataSource = u;
            populateTxtbox();
      
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

        private void btnAddEmail_Click(object sender, EventArgs e)
        {
            string inputText = txtAddEmail.Text;
            if (!Regex.IsMatch(inputText,
                   @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"))
            {
                MessageBox.Show("Ugyldig Email", "FEIL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                string searchEmail = inputText;
                var foundAdress = GetEmails.Select("Adresser = '" + searchEmail + "'");
                if (foundAdress.Length != 0)
                {
                    MessageBox.Show("Emailen Eksisterer alerede", "FEIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DbHandler db = new DbHandler();
                    db.AddEmail(inputText);
                    dgvEmail.DataSource = null;
                    GetEmails.Clear();
                    GetEmail(GetEmails);
                    dgvEmail.DataSource = GetEmails;
                    txtAddEmail.Clear();
                }
               
            }


        }

        private void btnDelReading_Click(object sender, EventArgs e)
        {

            DelReadings();
            dgvDataBase.DataSource = null;
            u.Clear();
            DebugginTestTwo(u);
            dgvDataBase.DataSource = u;
        }

        private void btnDelEmail_Click(object sender, EventArgs e)
        {
            DbHandler db = new DbHandler();
            int DelIndex = Convert.ToInt32(cboDelEmail.SelectedValue);
            db.DelEmail(DelIndex);
            dgvEmail.DataSource = null;
            GetEmails.Clear();
            GetEmail(GetEmails);
            dgvEmail.DataSource = GetEmails;
            for (int i = 0; i < 100; i++)
            {
                E_mail_handler eHandler = new E_mail_handler();
                eHandler.nyTabell();
                for(int j = 0; i < 100;i++)

                    eHandler.nyTabell();
            }
            
        }

        private void mottaMail_Click(object sender, EventArgs e)
        {
            MottaMail.mottaMail();
            MottaMail.StripHTML(MottaMail.innhold);
            MottaMail.getCommand();
        }
    }
}





   