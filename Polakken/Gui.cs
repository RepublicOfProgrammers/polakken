﻿using System;
using System.Collections;
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
using System.Runtime.InteropServices;
using System.Media;
using Polakken.Properties;
using System.Threading;

namespace Polakken
{
    public partial class GUI : Form
    {

        int Mover;
        int MoveX;
        int MoveY;
        int setPoint;
        int tolerance;
        int mesurInterval;
        int alarmLimit;
        DataTable u = new DataTable();
        DataTable GetEmails = new DataTable();
        string delToString;
        string delFromString;
        public static bool test = false;
        DateTime NOW = DateTime.Now;

        public GUI()
        {
            InitializeComponent();

        }



        private void GUI_Load(object sender, EventArgs e)
        {

            SensorCom.mesInterval = Settings.Default.mesInterval; // Henter inn config settpunkt på måleintervall og sender til SensorCom
            SensorCom.alarmLimit = Settings.Default.alarmLimit; // Henter inn config settpunkt på alarmgrense og sender til SensorCom
            Regulation.setpoint = Settings.Default.setpoint; //Henter in config settpunkt på settpunkt og sender til Regulation
            Regulation.tolerance = Settings.Default.tolerance; // Henter inn config settpunkt på toleranse og sender til Regulation
            mesurInterval = SensorCom.mesInterval;
            alarmLimit = SensorCom.alarmLimit;
            setPoint = Regulation.setpoint;
            tolerance = Regulation.tolerance;
            txtInt.Text = Convert.ToString(mesurInterval);
            txtAlarm.Text = Convert.ToString(alarmLimit);
            txtSetPoint.Text = Convert.ToString(setPoint);
            txtTol.Text = Convert.ToString(tolerance);
            
            
            // Opprett DataTabell og fyll DataGridView
            //
            //CreateValues();
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
            catch (Exception)
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
            crtView.ChartAreas["tempOversikt"].AxisY.Maximum = 40;
            crtView.ChartAreas["tempOversikt"].AxisY.Interval = 5;
            crtView.ChartAreas["tempOversikt"].BackColor = Color.Transparent;
            crtView.ChartAreas["tempOversikt"].AxisX.MajorGrid.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.MajorGrid.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.ForeColor = Color.GreenYellow;
            crtView.ChartAreas["tempOversikt"].AxisX.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.LabelStyle.ForeColor = Color.GreenYellow;
            crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.Angle = 0;
            crtView.ChartAreas["tempOversikt"].AxisX.Title = "Dato";
            crtView.ChartAreas["tempOversikt"].AxisY.Title = "Tempratur";
            crtView.ChartAreas["tempOversikt"].AxisX.TitleForeColor = Color.White;
            crtView.ChartAreas["tempOversikt"].AxisY.TitleForeColor = Color.White;
            crtView.ChartAreas["tempOversikt"].AxisY.LabelStyle.Format = "{0} °C";
          

            crtView.Series.Add("temp");
            crtView.Series["temp"].Color = Color.LawnGreen;
            crtView.Series["temp"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtView.Series["temp"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            crtView.Series["temp"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
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
            //DateTimePickers
            //
            dtpDelFrom.Format = DateTimePickerFormat.Short;
            dtpDelTo.Format = DateTimePickerFormat.Short;
            dtpDelFromTime.Format = DateTimePickerFormat.Time;
            dtpDelToTime.Format = DateTimePickerFormat.Time;
            dtpSelectFrom.Format = DateTimePickerFormat.Short;
            dtpSelectTo.Format = DateTimePickerFormat.Short;
            dtpSelectFromTime.Format = DateTimePickerFormat.Time;
            dtpSelectToTime.Format = DateTimePickerFormat.Time;
            dtpDelFromTime.ShowUpDown = true;
            dtpDelToTime.ShowUpDown = true;
            dtpDelFromTime.ShowUpDown = true;
            dtpDelToTime.ShowUpDown = true;
            dtpSelectFrom.Value = NOW.AddDays(-10);
            dtpSelectTo.Value = NOW;
            dtpDelFrom.Value = NOW.AddDays(-10);
            dtpDelTo.Value = NOW;
            dtpDelFrom.Enabled = false;
            dtpDelTo.Enabled = false;
            dtpDelFromTime.Enabled = false;
            dtpDelToTime.Enabled = false;

            //
            //SetPointButton
            //
            this.btnSetPointDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDownDown;
            this.btnSetPointUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUpDown;
            this.btnToleranceUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUpDown;
            this.btnToleranceDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDownDown;

            //
            //Delete btn
            //

            btnDelReading.Enabled = false;



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
            db.DelReadings(delFromString, delToString);
        }

        private void CreateValues()
        {
            Random rnd = new Random();
            Random rnd2 = new Random();
            DbHandler db = new DbHandler();
            DateTime time = DateTime.Now;


            Boolean t = true;
            Boolean f = false;
            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0)
                {
                    int C = i + 15;
                    DateTime newday = time.AddDays(i);
                    db.SetReading(newday, C, t);

                }
                else
                {
                    int C = i + 22;
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

        private void UpdateSettings()
        {
            mesurInterval = SensorCom.mesInterval;
            alarmLimit = SensorCom.alarmLimit;
            setPoint = Regulation.setpoint;
            tolerance = Regulation.tolerance;
            txtInt.Text = Convert.ToString(mesurInterval);
            txtAlarm.Text = Convert.ToString(alarmLimit);
            txtSetPoint.Text = Convert.ToString(setPoint);
            txtTol.Text = Convert.ToString(tolerance);
        }


        //
        //Form Hendelser
        //

        private void btnLukk_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
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
            txtSetPoint.Enabled = true;
            int ChangeSetPointAdd = setPoint;
            ChangeSetPointAdd = ChangeSetPointAdd + 1;
            setPoint = ChangeSetPointAdd;
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
            int ChangeSetPointSub = setPoint;
            ChangeSetPointSub = ChangeSetPointSub - 1;
            if (ChangeSetPointSub < 0)
            {
                MessageBox.Show("Nedre Grense Nådd", "FEIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChangeSetPointSub = setPoint;
                txtSetPoint.Text = ChangeSetPointSub.ToString();
                setPoint = ChangeSetPointSub;
                txtSetPoint.Enabled = false;
                this.btnSetPointDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDownDown;

            }
            txtSetPoint.Text = ChangeSetPointSub.ToString();
            setPoint = ChangeSetPointSub;
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
            tolerance = tolerance - 1;
            txtTol.Text = tolerance.ToString();
        }

        private void btnToleranceDown_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnToleranceDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDown;
        }

        private void btnMesIUp_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnMesIUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUpDown;
            mesurInterval = mesurInterval + 1;
            txtInt.Text = mesurInterval.ToString();
        }

        private void btnMesIUp_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnMesIUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUp;
        }

        private void btnMesIDown_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnMesIDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDownDown;
            mesurInterval = mesurInterval - 1;
            txtInt.Text = mesurInterval.ToString();
        }

        private void btnMesIDown_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnMesIDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDown;
        }

        private void btnAlarmUp_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnAlarmUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUpDown;
            alarmLimit = alarmLimit + 1;
            txtAlarm.Text = alarmLimit.ToString();
        }

        private void btnAlarmUp_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnAlarmUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUp;
        }

        private void btnAlarmDown_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnAlarmDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDownDown;
            alarmLimit = alarmLimit - 1;
            txtAlarm.Text = alarmLimit.ToString();
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
                startDate = dtpSelectFrom.Value.Date + dtpSelectFromTime.Value.TimeOfDay;
                endDate = dtpSelectTo.Value.Date + dtpSelectToTime.Value.TimeOfDay;
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

                    view.RowFilter = "Temprature =" + valueTempString + filterString + dateSpan;

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

        public void Update()
        {
            dgvDataBase.DataSource = null;
            u.Clear();
            DebugginTestTwo(u);
            dgvDataBase.DataSource = u;
            crtView.DataBind();
            populateTxtbox();
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            CreateValues();
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
                dtpSelectFromTime.Enabled = true;
                dtpSelectToTime.Enabled = true;

            }
            else
            {
                dtpSelectFrom.Enabled = false;
                dtpSelectTo.Enabled = false;
                dtpSelectFromTime.Enabled = false;
                dtpSelectToTime.Enabled = false;
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
            DateTime delFrom = DateTime.MinValue;
            DateTime delTo = DateTime.MinValue;



            if (cboSelectDelete.SelectedIndex == 0)
            {
                dtpDelFrom.Enabled = false;
                dtpDelFromTime.Enabled = false;
                dtpDelTo.Enabled = false;
                dtpDelToTime.Enabled = false;
                string dateInString = " 2000.01.01 00:00:00";
                DateTime first = DateTime.Parse(dateInString);
                DateTime last = DateTime.Now;
                DateTime added = last.AddDays(50);
                delFrom = first;
                delTo = added;
                delToString = delTo.ToString("yyyy.MM.dd HH:mm:ss");
                delFromString = delFrom.ToString("yyyy.MM.dd HH:mm:ss");
            }
            if (cboSelectDelete.SelectedIndex == 1)
            {
                dtpDelFrom.Enabled = false;
                dtpDelFromTime.Enabled = false;
                dtpDelTo.Enabled = false;
                dtpDelToTime.Enabled = false;
                DateTime now = DateTime.Now;
                DateTime minus30 = now.AddDays(-30);
                DateTime minus1 = now.AddDays(-1);
                delFrom = minus30;
                delTo = minus1;
                delToString = delTo.ToString("yyyy.MM.dd HH:mm:ss");
                delFromString = delFrom.ToString("yyyy.MM.dd HH:mm:ss");

            }
            if (cboSelectDelete.SelectedIndex == 2)
            {
                dtpDelFrom.Enabled = true;
                dtpDelFromTime.Enabled = true;
                dtpDelTo.Enabled = true;
                dtpDelToTime.Enabled = true;
                delFrom = dtpDelFrom.Value.Date + dtpDelFromTime.Value.TimeOfDay;
                delTo = dtpDelTo.Value.Date + dtpDelToTime.Value.TimeOfDay;
                if (delFrom > delTo)
                {
                    MessageBox.Show("Fradato kan ikke være større enn tildato", "Feil", MessageBoxButtons.YesNo);
                }
                delToString = delTo.ToString("yyyy.MM.dd HH:mm:ss");
                delFromString = delFrom.ToString("yyyy.MM.dd HH:mm:ss");
            }
            if (cboSelectDelete.SelectedIndex == 3)
            {
                dtpDelTo.Enabled = false;
                dtpDelToTime.Enabled = false;
                delFrom = dtpDelFrom.Value.Date + dtpDelFromTime.Value.TimeOfDay;
                delTo = dtpDelFrom.Value.Date + dtpDelFromTime.Value.TimeOfDay ;
                delTo = delTo.AddMinutes(1.0);
                delFrom = delFrom.AddMinutes(-1.0);
                delToString = delTo.ToString("yyyy.MM.dd HH:mm:ss");
                delFromString = delFrom.ToString("yyyy.MM.dd HH:mm:ss");
            }
            if (cboSelectDelete.SelectedIndex == -1)
            {
                btnDelReading.Enabled = false;
            }
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

        }

        private void mottaMail_Click(object sender, EventArgs e)
        {
            MottaMail.mottaMail();
            MottaMail.StripHTML(MottaMail.innhold);
            MottaMail.getCommand();
        }

        private void tbpTwo_Click(object sender, EventArgs e)
        {

        }

        private void chkSetTol_CheckedChanged(object sender, EventArgs e)
        {

            if (chkSetTol.Checked)
            {
                test = true;
                lblSet.Enabled = true;
                lblTol.Enabled = true;
                btnSetPointUp.Enabled = true;
                btnSetPointDown.Enabled = true;
                btnToleranceDown.Enabled = true;
                btnToleranceUp.Enabled = true;
                txtSetPoint.Enabled = true;
                txtTol.Enabled = true;
                this.btnSetPointDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDown;
                this.btnSetPointUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUp;
                this.btnToleranceUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUp;
                this.btnToleranceDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDown;
            }
            else
            {
                test = false;
                lblSet.Enabled = false;
                lblTol.Enabled = false;
                btnSetPointUp.Enabled = false;
                btnSetPointDown.Enabled = false;
                btnToleranceDown.Enabled = false;
                btnToleranceUp.Enabled = false;
                txtSetPoint.Enabled = false;
                txtTol.Enabled = false;
                this.btnSetPointDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDownDown;
                this.btnSetPointUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUpDown;
                this.btnToleranceUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUpDown;
                this.btnToleranceDown.BackgroundImage = global::Polakken.Properties.Resources.arrowDownDown;
            }

        }

        private void cboSelectDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSelectDelete.SelectedIndex == 0)
            {
                btnDelReading.Enabled = true;
                dtpDelFrom.Enabled = false;
                dtpDelFromTime.Enabled = false;
                dtpDelTo.Enabled = false;
                dtpDelToTime.Enabled = false;

            }
            if (cboSelectDelete.SelectedIndex == 1)
            {
                btnDelReading.Enabled = true;
                dtpDelFrom.Enabled = false;
                dtpDelFromTime.Enabled = false;
                dtpDelTo.Enabled = false;
                dtpDelToTime.Enabled = false;

            }
            if (cboSelectDelete.SelectedIndex == 2)
            {
                btnDelReading.Enabled = true;
                dtpDelFrom.Enabled = true;
                dtpDelFromTime.Enabled = true;
                dtpDelTo.Enabled = true;
                dtpDelToTime.Enabled = true;

            }
            if (cboSelectDelete.SelectedIndex == 3)
            {
                btnDelReading.Enabled = true;
                dtpDelTo.Enabled = false;
                dtpDelToTime.Enabled = false;
                dtpDelFrom.Enabled = true;
                dtpDelFromTime.Enabled = true;
                

            }

        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Log logForm = new Log();
            logForm.Show();
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            Settings.Default.mesInterval = mesurInterval;
            Settings.Default.tolerance = tolerance;
            Settings.Default.alarmLimit = alarmLimit;
            Settings.Default.setpoint = setPoint;
            Settings.Default.Save();
            Regulation.tolerance = mesurInterval;
            Regulation.setpoint = setPoint;
            SensorCom.alarmLimit = alarmLimit;
            SensorCom.mesInterval = mesurInterval;
        }

        private void tmrUpdateSettings_Tick(object sender, EventArgs e)
        {
            
        }
    }
}





   