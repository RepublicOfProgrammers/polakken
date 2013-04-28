using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Polakken.Properties;

namespace Polakken
{
    public partial class GuiForm : Form
    {
        private const string MaxError = "Øvre Grense";
        private const string Celcius = "°C";
        private const string MaxValue = "Øvre Grense Nådd";
        private const string MinError = "Nedre Grense";
        private const string MinValue = "Nedre Grense Nådd";
        private const string Minute = " Min.";
        private const MessageBoxButtons MsgButton = MessageBoxButtons.OK;
        private const MessageBoxIcon MsgIcon = MessageBoxIcon.Information;
        public static Log LogForm = null;
        public static DataTable DtEmails = new DataTable();
        public static bool Test = false;
        public static bool Settingsupdate = false;
        public static string LastR;
        public static string LastRt;
        public static DateTime Now;
        public static string StsStatus;

        private readonly DataTable _dataTable = new DataTable();
        private readonly DataTable _getEmails = new DataTable();
        private readonly Image _imgArrowDownDown = Resources.Polakken_btnArrowDownDown;
        private readonly Image _imgArrowDownUp = Resources.Polakken_btnArrowDown;
        private readonly Image _imgArrowUp = Resources.Polakken_btnArrowUp;
        private readonly Image _imgArrowUpDown = Resources.Polakken_btnArrowUpDown;
        private readonly Image _imgDel = Resources.Polakken_btnSlett;
        private int _alarmLimit;
        private int _clickCount;
        private int _countRows;
        private string _delFromString;
        private string _delToString;
        private int _mesurInterval;
        private int _moveX;
        private int _moveY;
        private int _mover;
        private int _setPoint;
        private int _tolerance;
        private int _xMax = 336;
        private int _xMin;

        public GuiForm()
        {
            InitializeComponent();
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            tmrUpdateSettings.Start();
            chkMsgDis.Checked = Settings.Default.hideMsgBox;
            // Henter inn config setting på valg om skjuling av error message boxes. 
            SensorCom.MesInterval = Settings.Default.mesInterval;
            // Henter inn config setting på måleintervall og sender til SensorCom
            SensorCom.AlarmLimit = Settings.Default.alarmLimit;
            // Henter inn config setting på alarmgrense og sender til SensorCom
            Regulation.Setpoint = Settings.Default.setpoint;
            //Henter in config setting på settpunkt og sender til Regulation
            Regulation.Tolerance = Settings.Default.tolerance;
            // Henter inn config setting på toleranse og sender til Regulation
            _mesurInterval = SensorCom.MesInterval;
            _alarmLimit = SensorCom.AlarmLimit;
            _setPoint = Regulation.Setpoint;
            _tolerance = Regulation.Tolerance;
            txtInt.Text = Convert.ToString(_mesurInterval) + Minute; //Fyller intervalltextboxen
            txtAlarm.Text = Convert.ToString(_alarmLimit) + Celcius; //Fyller Alarmgrensetextboxen
            txtSetPoint.Text = Convert.ToString(_setPoint) + Celcius; //Fyller txtSetPoint
            txtTol.Text = Convert.ToString(_tolerance) + Celcius; //Fyller Tollerangsetextboxen
            lblDate1.Visible = false;
            lblDate2.Visible = false;
            LastR = txtCurrent.Text;
            DtEmails = _getEmails;
            btnDelReading.Enabled = false;
            PowerCheck(); //Kjører en metode som sjekker statusen på strømen til maskinen
            SensorCheck(); //Kjører en metode som teser om sensoren er tilkoblet
            //
            // Opprett DataTabell og fyll DataGridView
            //
            FillDataTable(_dataTable);
            //Kjører metoden fillDatatable som fyller datatabellen som sendes med som en parameter
            dgvDataBase.DataSource = _dataTable; //Setter datagridviewens datasource til den utfylte datatabellen
            GetEmail(_getEmails); // gjør akuratt det samme som fillDatatable, men bare for emails
            dgvEmail.DataSource = _getEmails; //Samme som for datagridviewt til databasen

            PopulateTxtbox();
            //Kjører en metode som kjører tester og fyller textboxene med data fra datatabellen dataTable
            _xMin = _countRows - 300; // Setter Variablene xMin og xMax som skal brukes til å sette graf grenseverdier.
            _xMax = _countRows + 36;

            using (var viewTemp = new DataView(_dataTable))
                // Her så fyller man en combobox med distingte tempraturer fra datatabellen.
            {
                DataTable distinctTempValues = viewTemp.ToTable(true, "Temprature");
                cboFilterTemp.DataSource = distinctTempValues;
                cboFilterTemp.DisplayMember = "Temprature";
                cboFilterTemp.ValueMember = "Temprature";
            }


            var viewDeleteEmail = new DataView(_getEmails);
            cboDelEmail.DataSource = viewDeleteEmail;
            cboDelEmail.DisplayMember = "Adresser";
            cboDelEmail.ValueMember = "Index";

            #region Chart

            // Her så endres både det visuelle ved grafen og setter også datasourcen til grafen til den utfylte datatabellen.
            crtView.DataSource = _dataTable;

            crtView.ChartAreas.Add("tempOversikt");
            crtView.ChartAreas["tempOversikt"].AxisX.Minimum = _xMin;
            crtView.ChartAreas["tempOversikt"].AxisX.Maximum = _xMax;
            crtView.ChartAreas["tempOversikt"].AxisX.Interval = 48;
            crtView.ChartAreas["tempOversikt"].AxisY.Minimum = -5;
            crtView.ChartAreas["tempOversikt"].AxisY.Maximum = 40;
            crtView.ChartAreas["tempOversikt"].AxisY.Interval = 5;
            crtView.ChartAreas["tempOversikt"].BackColor = Color.Transparent;
            crtView.ChartAreas["tempOversikt"].AxisX.MajorGrid.LineColor = Color.LightGray;
            crtView.ChartAreas["tempOversikt"].AxisY.MajorGrid.LineColor = Color.LightGray;
            crtView.ChartAreas["tempOversikt"].AxisX.IntervalType = DateTimeIntervalType.Days;
            crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.ForeColor = Color.GreenYellow;
            crtView.ChartAreas["tempOversikt"].AxisX.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.LabelStyle.ForeColor = Color.GreenYellow;
            crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.Angle = 0;
            crtView.ChartAreas["tempOversikt"].AxisX.Title = "Dato";
            crtView.ChartAreas["tempOversikt"].AxisY.Title = "Tempratur";
            crtView.ChartAreas["tempOversikt"].AxisX.TitleFont = new Font("Verdana", 9, FontStyle.Bold);
            crtView.ChartAreas["tempOversikt"].AxisY.TitleFont = new Font("Verdana", 9, FontStyle.Bold);
            crtView.ChartAreas["tempOversikt"].AxisY.TitleAlignment = StringAlignment.Near;
            crtView.ChartAreas["tempOversikt"].AxisX.TitleAlignment = StringAlignment.Near;

            crtView.ChartAreas["tempOversikt"].AxisX.TitleForeColor = Color.White;
            crtView.ChartAreas["tempOversikt"].AxisY.TitleForeColor = Color.White;
            crtView.ChartAreas["tempOversikt"].AxisY.LabelStyle.Format = "{0} °C";
            crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.Interval = 48;

            crtView.Series.Add("temp");
            crtView.Series["temp"].Color = Color.LawnGreen;
            crtView.Series["temp"].ChartType = SeriesChartType.Line;
            crtView.Series["temp"].XValueType = ChartValueType.Date;
            crtView.Series["temp"].YValueType = ChartValueType.Int32;
            crtView.Series["temp"].XValueMember = "ReadTime";
            crtView.Series["temp"].YValueMembers = "Temprature";
            crtView.DataBind();

            #endregion

            //
            //TabellVisning, Endrer det visuelle ved datagridviewet.
            //
            if (!Test)
            {
                chkSetTol.Checked = false;
                dgvDataBase.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvDataBase.Columns[0].Width = 190;
                dgvDataBase.Columns[1].Width = 100;
                dgvDataBase.Columns[2].Visible = false;
            }
            else
            {
                chkSetTol.Checked = true;
                dgvDataBase.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvDataBase.Columns[0].Width = 190;
                dgvDataBase.Columns[1].Width = 50;
                dgvDataBase.Columns[2].Visible = true;
                dgvDataBase.Columns[2].Width = 50;
            }


            //
            //Email TabellVisning, Samme som over , bare for email datagridviewet
            //
            dgvEmail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEmail.Columns[0].Visible = false;
            dgvEmail.Columns[1].Width = dgvEmail.Width;
            dgvEmail.ScrollBars = ScrollBars.Vertical;

            //
            //DateTimePickers, Formaterer de ulike dateTimePickerne slik at de stemmer med det man trenger.
            //
            dtpDelFrom.Format = DateTimePickerFormat.Short;
            dtpDelTo.Format = DateTimePickerFormat.Short;
            dtpDelFromTime.Format = DateTimePickerFormat.Time;
            dtpDelToTime.Format = DateTimePickerFormat.Time; // Velger at disse skal brukes til å velge tidspunkt
            dtpSelectFrom.Format = DateTimePickerFormat.Short;
            dtpSelectTo.Format = DateTimePickerFormat.Short;
            dtpSelectFromTime.Format = DateTimePickerFormat.Time;
            dtpSelectToTime.Format = DateTimePickerFormat.Time;
            dtpDelFromTime.ShowUpDown = true;
            dtpDelToTime.ShowUpDown = true;
            dtpDelFromTime.ShowUpDown = true;
            dtpDelToTime.ShowUpDown = true;
            dtpSelectTo.Value = DateTime.Now;
            dtpSelectFrom.Value = DateTime.Now.AddDays(-10);
            dtpDelFrom.Value = DateTime.Now.AddDays(-10);
            dtpDelTo.Value = DateTime.Now;
            dtpDelFrom.Enabled = false;
            dtpDelTo.Enabled = false;
            dtpDelFromTime.Enabled = false;
            dtpDelToTime.Enabled = false;

            //
            //SetPoint Og Tollerangse checkbox settes om det er aktiv regulering lagret i settings
            //
            chkSetTol.Checked = Settings.Default.RegulationActive;
            //Henter inn config setting på valg om regulering er aktiv eller ikke. 


            //
            //Delete btn, Setter bare at denne er ikke aktiv, denne blir det når man velger slettemetode(Se lenger ned).
            //

            btnDelReading.Enabled = false;
        }

        public DataTable FillDataTable(DataTable dataTableToFill)
            //Datatabell Metode som fyller en vedlagt tom datatabell med data fra databasen, med metode fra DBHandler.
        {
            if (dataTableToFill.Columns.Contains("ReadTime") & dataTableToFill.Columns.Contains("Temprature") &
                dataTableToFill.Columns.Contains("Status")) //Sjekker om tabellen allerede eksisterer.
            {
                Program.MDbHandler.OpenDb(); // Åpner databasen.
                SqlCeDataReader mReader = Program.MDbHandler.GetReadings();
                //Opretter en SQL Datareader som settes lik metoden i DBHandler Getreadings.

                while (mReader.Read()) // Så lenge det er noe å lese i databasne 
                {
                    DataRow row = dataTableToFill.NewRow(); // Oppretter en ny rad i datatabellen
                    for (int i = 0; i < 3; i++)
                        // Kjører test på hvilken kolonne som er gjeldene og fyller inn i den respektive kolonnen i datatabellen.
                    {
                        string reading = mReader[i].ToString();
                        if (i == 0)
                        {
                            row["ReadTime"] = reading;
                        }
                        if (i == 1)
                        {
                            row["Temprature"] = reading;
                        }
                        if (i == 2)
                        {
                            row["Status"] = reading;
                        }
                    }
                    dataTableToFill.Rows.Add(row); // Legger inn radene i tabellen.
                }

                mReader.Close(); // Ikke mer å lese fra databasen, lukker derfor tilkoblingen til leseren.
            }
            else
            {
                dataTableToFill.Columns.Add("ReadTime", typeof (string));
                // Samme som metoden over, men datatabellen har ikke kolonnene og derfor oppretter den de.
                dataTableToFill.Columns.Add("Temprature", typeof (string));
                dataTableToFill.Columns.Add("Status", typeof (string));

                Program.MDbHandler.OpenDb();
                SqlCeDataReader mReader = Program.MDbHandler.GetReadings();

                while (mReader.Read())
                {
                    DataRow row = dataTableToFill.NewRow();
                    for (int i = 0; i < 3; i++)
                    {
                        string reading = mReader[i].ToString();
                        if (i == 0)
                        {
                            row["ReadTime"] = reading;
                        }
                        if (i == 1)
                        {
                            row["Temprature"] = reading;
                        }
                        if (i == 2)
                        {
                            row["Status"] = reading;
                        }
                    }
                    dataTableToFill.Rows.Add(row);
                }

                mReader.Close();
            }

            Program.MDbHandler.CloseDb(); // Lukker så hele databasen
            return dataTableToFill;
            // Her blir datatabellen som metoden har utfylt retunert til der den blir kalt opp i en parameter datatabell.
        }

        public DataTable GetEmail(DataTable getEmails)
            //Samme type metode som over, men istedenfor målinger så henter denne emails.
        {
            if (getEmails.Columns.Contains("Adresser"))
            {
                Program.MDbHandler.OpenDb();
                SqlCeDataReader emReader = Program.MDbHandler.GetEmails();
                // Oppretter igjen en leser som går igjennom alle oppføringer i databasen.

                while (emReader.Read())
                {
                    DataRow row = getEmails.NewRow();
                    for (int i = 0; i < 2; i++)
                    {
                        string reading = emReader[i].ToString();
                        if (i == 0)
                        {
                            row["Index"] = reading;
                        }
                        if (i == 1)
                        {
                            row["Adresser"] = reading;
                        }
                    }
                    getEmails.Rows.Add(row);
                }

                emReader.Close();
            }
            else
            {
                getEmails.Columns.Add("Index", typeof (int)); // Her oppretter den da kolonnene hvis de ikke eksisterer.
                getEmails.Columns.Add("Adresser", typeof (string));
                Program.MDbHandler.OpenDb();
                SqlCeDataReader emReader = Program.MDbHandler.GetEmails();

                while (emReader.Read())
                {
                    DataRow row = getEmails.NewRow();
                    for (int i = 0; i < 2; i++)
                    {
                        string reading = emReader[i].ToString();
                        if (i == 0)
                        {
                            row["Index"] = reading;
                        }
                        if (i == 1)
                        {
                            row["Adresser"] = reading;
                        }
                    }
                    getEmails.Rows.Add(row);
                }

                emReader.Close();
            }

            Program.MDbHandler.CloseDb(); // lukker databasen.
            return getEmails; //Returnerer datatabellen GetEmails.
        }

        private void DelReadings() // Metode som brukes for å slette måling/er i databasen , igjen via DBHandleren.
        {
            Program.MDbHandler.DelReadings(_delFromString, _delToString);
        }

        private void UpdateSettings()
            //Metode som oppdateerer textboxene , da via sensorkomunikasjonen sine variabler, FKS. ved en motatt email med nye verdier.
        {
            _mesurInterval = SensorCom.MesInterval;
            _alarmLimit = SensorCom.AlarmLimit;
            _setPoint = Regulation.Setpoint;
            _tolerance = Regulation.Tolerance;
            txtInt.Text = Convert.ToString(_mesurInterval) + Minute;
            txtAlarm.Text = Convert.ToString(_alarmLimit) + Celcius;
            txtSetPoint.Text = Convert.ToString(_setPoint) + Celcius;
            txtTol.Text = Convert.ToString(_tolerance) + Celcius;
        }

        /// <summary>
        ///     Metode som fyller textboxer med verdier , kjøer counter på antall elementer i datatabellen
        ///     og henter verdier som skal brukes i mottaMail status.
        /// </summary>
        private void PopulateTxtbox()
        {
            int maxTemp = int.MinValue;
            int maxTempTest;
            int minTemp = int.MaxValue;
            int minTempTest;
            string tempString = "";
            DateTime dt = DateTime.MinValue;
            foreach (DataRow row in _dataTable.Rows)
            {
                tempString = row["Temprature"] + Celcius;
                // string som settes lik den nåværende radens temp i kolonnen Tempratur til string.
                dt = DateTime.Parse(row["ReadTime"].ToString());
                // Samme men bare parser en string med tidspunkt om til DateTime
                txtCurrentTime.Text = dt.ToString(); // textboxen med siste måling datoTid til den parsede datetimen
                _countRows++; //Antall elementertelleren legger til en for hver rad.
                maxTempTest = int.Parse(row["Temprature"].ToString());
                //Kjører test i denne if setingen for å finne høyeste verdi
                if (maxTemp < maxTempTest)
                {
                    maxTemp = maxTempTest;
                    DateTime maxDt = DateTime.Parse(row["ReadTime"].ToString());
                    txtMaxTime.Text = maxDt.ToString();
                    txtMax.Text = maxTemp.ToString() + Celcius;
                }
                minTempTest = int.Parse(row["Temprature"].ToString()); // Og i denne for å finne laveste verdi
                if (minTemp > minTempTest)
                {
                    minTemp = minTempTest;
                    DateTime minDt = DateTime.Parse(row["ReadTime"].ToString());
                    txtMinTime.Text = minDt.ToString();
                    txtMin.Text = minTemp.ToString() + Celcius;
                }
            }
            txtCurrent.Text = tempString; //textboxen til siste avlesingen får den siste tempraturen ifra testen.
            LastR = tempString; // public static string som får siste verdi av tempen  og brukes senere i mottaMail
            LastRt = dt.ToString("dd/MM/yyyy HH:mm:ss"); // samme med denne, men bare da for tiden istedenfor tempen
        }

        /// <summary>
        ///     Metode som tester på datamaskinens strømstatus. Dette ved hjelp av en bool som blir satt i program.
        /// </summary>
        private void PowerCheck()
        {
            if (Program.IsRunningOnBattery == false)
            {
                picPower.Image = Resources.Polakken_imgPowerOn;
                lblPowerInfo.ForeColor = Color.White;
                lblPowerInfo.Text = "Datamaskinen har strøm";
            }
            else if (Program.IsRunningOnBattery)
            {
                picPower.Image = Resources.Polakken_imgPowerOff;
                lblPowerInfo.ForeColor = Color.Red;
                lblPowerInfo.Text = "Datamaskinen går på batteri";
            }
        }

        /// <summary>
        ///     Metode som tester om sensoren er tilkoblet,kjører en public static metode fra sensorcom.
        /// </summary>
        private void SensorCheck()
        {
            if (SensorCom.Connected())
            {
                picSensor.Image = Resources.Polakken_imgSensorIn;
                lblSensorInfo.ForeColor = Color.White;
                lblSensorInfo.Text = "Sensoren er tilkoblet";
            }
            else
            {
                picSensor.Image = Resources.Polakken_imgSensorOut;
                lblSensorInfo.ForeColor = Color.Red;
                lblSensorInfo.Text = "Sensoren er ikke tilkoblet";
            }
        }

        /// <summary>
        ///     Metode som endrer min verdien på X-aksen i crtView. den har at du kun kan trykke en gang på hver knapp.
        ///     og den motsatte blir disablet.
        /// </summary>
        public void Zoom()
        {
            crtView.ChartAreas["tempOversikt"].AxisX.Minimum = _xMin;

            if (_clickCount == 0)
            {
                crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.Interval = 48;
                btnZoomOut.Enabled = true;
                btnZoomIn.Enabled = false;
                btnZoomIn.BackgroundImage = Resources.Polakken_btnPlusDisabeld;
                btnZoomOut.BackgroundImage = Resources.Polakken_btnMinus;
                _clickCount = 0;
            }
            if (_clickCount == 1)
            {
                crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.Interval = 96;
                btnZoomOut.Enabled = false;
                btnZoomIn.Enabled = true;
                btnZoomOut.BackgroundImage = Resources.Polakken_btnMinusDisabled;
                btnZoomIn.BackgroundImage = Resources.Polakken_btnPlus;
                _clickCount = 0;
            }
        }

        /// <summary>
        ///     Metode som kjører metoder i GUIEN(Skjer ved tick fra Timer) for å oppdatere de ulike visningene i guien.
        /// </summary>
        public void Update_Form()
        {
            dgvDataBase.DataSource = null; //Fjerner tabelvisningens datakilde.
            crtView.DataSource = null; // Fjerner grafens datakilde
            _dataTable.Clear(); //Tømmer datatabellen. 
            FillDataTable(_dataTable);
                //Fyller tabellen på nytt med metoden filldatatable(for info om den se lenger opp)
            dgvDataBase.DataSource = _dataTable; // setter datakilden til tabellvisningen til datatabellen.
            crtView.DataSource = _dataTable;
            crtView.DataBind(); //databinder grafen så den viser nye punkter.
            PopulateTxtbox(); //Kjører metoden som fyller textboxene med verdier(Siste,Mintemp,Maxtemp).
        }

        #region formEvents

        private void btnLukk_Click(object sender, EventArgs e)
        {
            Program.MålTemp.Abort(); // Stopper måleprossessen slik at programmet lukkes.
            Application.Exit(); // Avslutter hele programmet.
        }

        private void btnMinimize_Click(object sender, EventArgs e)
            //Metode for å minnimere programmet til oppgavelinjen.
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnSaveAll_MouseDown(object sender, MouseEventArgs e)
        {
            btnSaveAll.BackgroundImage = Resources.Polakken_btnLagreDown;
        }

        private void btnSaveAll_MouseUp(object sender, MouseEventArgs e)
        {
            btnSaveAll.BackgroundImage = Resources.Polakken_btnLagre;
            MessageBox.Show("Du har nå lagret de nye verdiene", "Suksess", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        // Metode som plusser på setpoint når den er trykket. er også en sjekk i den som sjekker om den er øvre grense.
        private void btnSetPointUp_MouseDown(object sender, MouseEventArgs e)
        {
            btnSetPointUp.BackgroundImage = _imgArrowUpDown;
            btnSetPointDown.BackgroundImage = _imgArrowDownUp;
            btnSetPointDown.Enabled = true;
            int changeSetPointAdd = _setPoint;
            changeSetPointAdd = changeSetPointAdd + 1;
            _setPoint = changeSetPointAdd;
            txtSetPoint.Text = changeSetPointAdd.ToString() + Celcius;
            if (changeSetPointAdd > 100)
            {
                changeSetPointAdd -= 1;
                txtSetPoint.Text = changeSetPointAdd.ToString() + Celcius;
                _setPoint = changeSetPointAdd;
                MessageBox.Show(MaxValue, MaxError, MsgButton, MsgIcon);
                btnSetPointUp.Enabled = false; //Disabler knappen når den har nådd grensen
                btnSetPointUp.BackgroundImage = _imgArrowUpDown;
            }
        }

        private void btnSetPointUp_MouseUp(object sender, MouseEventArgs e)
        {
            btnSetPointUp.BackgroundImage = _imgArrowUp;
        }

        private void btnSetPointDown_MouseDown(object sender, MouseEventArgs e)
        {
            btnSetPointDown.BackgroundImage = _imgArrowDownDown;
        }

        //Samme som sist metode med å endre setpoint ,denne gangen nedover, med en nedre grense
        private void btnSetPointDown_MouseUp(object sender, MouseEventArgs e)
        {
            btnSetPointUp.Enabled = true;
            btnSetPointUp.BackgroundImage = _imgArrowUp;
            btnSetPointDown.BackgroundImage = _imgArrowDownUp;
            int changeSetPointSub = _setPoint;
            changeSetPointSub = changeSetPointSub - 1;
            txtSetPoint.Text = changeSetPointSub.ToString() + Celcius;
            _setPoint = changeSetPointSub;
            if (changeSetPointSub < 0)
            {
                changeSetPointSub += 1;
                txtSetPoint.Text = changeSetPointSub.ToString() + Celcius;
                _setPoint = changeSetPointSub;
                MessageBox.Show(MinValue, MinError, MsgButton, MsgIcon);
                btnSetPointDown.Enabled = false;
                btnSetPointDown.BackgroundImage = _imgArrowDownDown;
            }
        }

        //Samme for tolernagse, med en øvre grense
        private void btnToleranceUp_MouseDown(object sender, MouseEventArgs e)
        {
            btnToleranceUp.BackgroundImage = _imgArrowUpDown;
            btnToleranceDown.BackgroundImage = _imgArrowDownUp;
            btnToleranceDown.Enabled = true;
            int changeTolAdd = _tolerance;
            changeTolAdd += 1;
            _tolerance = changeTolAdd;
            txtTol.Text = changeTolAdd.ToString() + Celcius;
            if (changeTolAdd > 20)
            {
                changeTolAdd -= 1;
                txtTol.Text = changeTolAdd.ToString() + Celcius;
                _tolerance = changeTolAdd;
                MessageBox.Show(MaxValue, MaxError, MsgButton, MsgIcon);
                btnToleranceUp.Enabled = false;
                btnToleranceUp.BackgroundImage = _imgArrowUpDown;
            }
        }

        private void btnToleranceUp_MouseUp(object sender, MouseEventArgs e)
        {
            btnToleranceUp.BackgroundImage = _imgArrowUp;
        }

        /// <summary>
        ///     En metode som endrer toleranse nedover ved klikk.
        /// </summary>
        private void btnToleranceDown_MouseDown(object sender, MouseEventArgs e)
        {
            btnToleranceUp.BackgroundImage = _imgArrowUp;
            btnToleranceDown.BackgroundImage = _imgArrowDownDown;
            btnToleranceUp.Enabled = true;
            int changeTolSub = _tolerance;
            changeTolSub -= 1;
            _tolerance = changeTolSub;
            txtTol.Text = changeTolSub.ToString() + Celcius;
            if (changeTolSub < 0)
            {
                changeTolSub += 1;
                txtTol.Text = changeTolSub.ToString() + Celcius;
                _tolerance = changeTolSub;
                MessageBox.Show(MinValue, MinError, MsgButton, MsgIcon);
                btnToleranceDown.Enabled = false;
                btnToleranceDown.BackgroundImage = _imgArrowDownDown;
            }
        }

        private void btnToleranceDown_MouseUp(object sender, MouseEventArgs e)
        {
            btnToleranceDown.BackgroundImage = _imgArrowDownUp;
        }

        //metode som plusser på intervallet ved klikk. 
        private void btnMesIUp_MouseDown(object sender, MouseEventArgs e)
        {
            btnMesIUp.BackgroundImage = _imgArrowUpDown;
            btnMesIDown.BackgroundImage = _imgArrowDownUp;
            btnMesIDown.Enabled = true;
            int changeMesIAdd = _mesurInterval;
            changeMesIAdd += 1;
            _mesurInterval = changeMesIAdd;
            txtInt.Text = changeMesIAdd.ToString() + Minute;
            if (changeMesIAdd > 999)
            {
                changeMesIAdd -= 1;
                txtInt.Text = changeMesIAdd.ToString() + Minute;
                _mesurInterval = changeMesIAdd;
                MessageBox.Show(MaxValue, MaxError, MsgButton, MsgIcon);
                btnMesIUp.Enabled = false;
                btnMesIUp.BackgroundImage = _imgArrowUpDown;
            }
        }

        private void btnMesIUp_MouseUp(object sender, MouseEventArgs e)
        {
            btnMesIUp.BackgroundImage = _imgArrowUp;
        }

        //Metode som trekker fra intervallet ved klikk.
        private void btnMesIDown_MouseDown(object sender, MouseEventArgs e)
        {
            btnMesIDown.BackgroundImage = _imgArrowDownDown;
            btnMesIUp.BackgroundImage = _imgArrowUp;
            btnMesIUp.Enabled = true;
            int changeMesISub = _mesurInterval;
            changeMesISub -= 1;
            _mesurInterval = changeMesISub;
            txtInt.Text = changeMesISub.ToString() + Minute;
            if (changeMesISub < 1)
            {
                changeMesISub += 1;
                txtInt.Text = changeMesISub.ToString() + Minute;
                _mesurInterval = changeMesISub;
                MessageBox.Show(MinValue, MinError, MsgButton, MsgIcon);
                btnMesIDown.Enabled = false;
                btnMesIDown.BackgroundImage = _imgArrowDownDown;
            }
        }

        private void btnMesIDown_MouseUp(object sender, MouseEventArgs e)
        {
            btnMesIDown.BackgroundImage = _imgArrowDownUp;
        }

        //Metode som pluser på den nedre Alarmgrensen ved klikk.
        private void btnAlarmUp_MouseDown(object sender, MouseEventArgs e)
        {
            btnAlarmUp.BackgroundImage = _imgArrowUpDown;
            btnAlarmDown.BackgroundImage = _imgArrowDownUp;
            btnAlarmDown.Enabled = true;
            txtAlarm.Enabled = true;
            int changeAlarmAdd = _alarmLimit;
            changeAlarmAdd += 1;
            _alarmLimit = changeAlarmAdd;
            txtAlarm.Text = changeAlarmAdd.ToString() + Celcius;
            if (changeAlarmAdd > 100)
            {
                changeAlarmAdd -= 1;
                txtAlarm.Text = changeAlarmAdd.ToString() + Celcius;
                _alarmLimit = changeAlarmAdd;
                MessageBox.Show(MaxValue, MaxError, MsgButton, MsgIcon);
                btnAlarmUp.Enabled = false;
                btnAlarmUp.BackgroundImage = _imgArrowUpDown;
            }
        }

        private void btnAlarmUp_MouseUp(object sender, MouseEventArgs e)
        {
            btnAlarmUp.BackgroundImage = _imgArrowUp;
        }

        //Metode som trekker fra den nedre alarmgrensen ved klikk.
        private void btnAlarmDown_MouseDown(object sender, MouseEventArgs e)
        {
            btnAlarmDown.BackgroundImage = _imgArrowDownDown;
            btnAlarmUp.BackgroundImage = _imgArrowUp;
            btnAlarmUp.Enabled = true;
            int changeAlarmISub = _alarmLimit;
            changeAlarmISub -= 1;
            _alarmLimit = changeAlarmISub;
            txtAlarm.Text = changeAlarmISub.ToString() + Celcius;
            if (changeAlarmISub < 0)
            {
                changeAlarmISub += 1;
                txtAlarm.Text = changeAlarmISub.ToString() + Celcius;
                _alarmLimit = changeAlarmISub;
                MessageBox.Show(MinValue, MinError, MsgButton, MsgIcon);
                btnAlarmDown.Enabled = false;
                btnAlarmDown.BackgroundImage = _imgArrowDownDown;
            }
        }

        private void btnAlarmDown_MouseUp(object sender, MouseEventArgs e)
        {
            btnAlarmDown.BackgroundImage = _imgArrowDownUp;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        //DataView trenger ikke disposing, dette er en bivirking som er arvet. (i følge stackoverflow)
        private void btnShowSelected_Click(object sender, EventArgs e)
            // Metode som ved klikk opretter ett dataview av datatabellen. denne blir så lagt på ulike row filtere ved å teste på hva som er blitt valgt til å filtrere på med chekboxene.
        {
            if (dtpSelectFrom.Value > dtpSelectTo.Value)
            {
                MessageBox.Show("Startdato kan ikke være større en sluttdato", "Datofeil", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            var view = new DataView(_dataTable);
            string filterString = null;
            string dateSpan = null;

            if (chkFilterDate.Checked)
            {
                DateTime startDate = dtpSelectFrom.Value.Date + dtpSelectFromTime.Value.TimeOfDay;
                DateTime endDate = dtpSelectTo.Value.Date + dtpSelectToTime.Value.TimeOfDay;
                string dates =
                    String.Format(CultureInfo.InvariantCulture.DateTimeFormat, "ReadTime >= #{0}#", startDate) +
                    String.Format(CultureInfo.InvariantCulture.DateTimeFormat, " AND ReadTime <= #{0}#", endDate);
                view.RowFilter = dates;
                dateSpan =
                    String.Format(CultureInfo.InvariantCulture.DateTimeFormat, "AND ReadTime >= #{0}#", startDate) +
                    String.Format(CultureInfo.InvariantCulture.DateTimeFormat, " AND ReadTime <= #{0}#", endDate);
            }
            if (chkFilterStatus.Checked)
            {
                int statusIndex = cboFilterStatus.SelectedIndex;
                string statusText;
                if (statusIndex == 0)
                {
                    statusText = "'True'";
                    filterString = "AND Status =" + statusText + dateSpan;
                    view.RowFilter = "Status =" + statusText + dateSpan;
                }
                if (statusIndex == 1)
                {
                    statusText = "'False'";
                    filterString = "AND Status =" + statusText + dateSpan;
                    view.RowFilter = "Status =" + statusText + dateSpan;
                    //Legger ved de verdiene fra de andre, for hvis de ikke er cheket så er strenge dems tomme.
                }
            }
            if (chkFilterTemp.Checked)
            {
                string valueTempString = cboFilterTemp.Text;
                //int valueTempINT = Convert.ToInt32(valueTempString);

                int statusIndex = cboEqualsFilter.SelectedIndex;

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
                    //Blir lagt til rowfilteret til viewen.
                }
            }
            dgvDataBase.DataSource = view; // Setter tabellvisningens datakilde til det filtrerte datautsnitte.
        }

        //Metode som nullstiller tabellvisningen når det er tatt ett utsnitt av den og denne er klikket på
        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvDataBase.DataSource = null; //Fjerner tabelvisningens datakilde.
            _dataTable.Clear(); //Tømmer datatabellen.
            FillDataTable(_dataTable);
                //Fyller tabellen på nytt med metoden filldatatable(for info om den se lenger opp)
            dgvDataBase.DataSource = _dataTable; // setter datakilden til tabellvisningen til datatabellen.
        }

        //Event som skjer når checkboxen til filterstatus endres og endre comboboxen er enabled eller ikke
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

        //Event som skjer når checkboxen til filtertemp endres og endre comboboxen er enabled eller ikke
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

        //Event som skjer når checkboxen til filterdate endres og endre comboboxen er enabled eller ikke
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

        //Knapp som legger til den innskrevense texten i textboxen txtAddEmail. Kjører en Regular expression test på den for  å se om den er gylid email format.
        //Sjekker også om den eksiskter allerede i databasen.
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
                DataRow[] foundAdress = _getEmails.Select("Adresser = '" + searchEmail + "'");
                if (foundAdress.Length != 0)
                {
                    MessageBox.Show("Emailen Eksisterer alerede", "FEIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Program.MDbHandler.AddEmail(inputText);
                    //Metode som legger til eposten ved at stringen som er eposten sendes med som parameter.Metoden for addemail finner du lenger oppe på siden.
                    dgvEmail.DataSource = null;
                    _getEmails.Clear();
                    GetEmail(_getEmails);
                        //Oppdaterer så tabellvisningen for email for å vise den nye i tabellvinsingen.
                    dgvEmail.DataSource = _getEmails;
                    txtAddEmail.Clear();
                }
            }
        }

        //Metode som skal ved klikk , se hva som er valgt i slettemetode comboboxen. for så å sette to dato variabler som blir brukt i  delReadings metoden
        private void btnDelReading_Click(object sender, EventArgs e)
        {
            DateTime delFrom;
            DateTime delTo;


            if (cboSelectDelete.SelectedIndex == 0)
            {
                dtpDelFrom.Enabled = false;
                dtpDelFromTime.Enabled = false;
                dtpDelTo.Enabled = false;
                dtpDelToTime.Enabled = false;
                const string dateInString = " 2000.01.01 00:00:00";
                DateTime first = DateTime.Parse(dateInString);
                DateTime last = DateTime.Now;
                DateTime added = last.AddDays(50);
                delFrom = first;
                delTo = added;
                _delToString = delTo.ToString("yyyy.MM.dd HH:mm:ss");
                _delFromString = delFrom.ToString("yyyy.MM.dd HH:mm:ss");
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
                _delToString = delTo.ToString("yyyy.MM.dd HH:mm:ss");
                _delFromString = delFrom.ToString("yyyy.MM.dd HH:mm:ss");
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
                    MessageBox.Show("Fradato kan ikke være større enn tildato", "Feil", MessageBoxButtons.OK);
                    _delToString = delTo.ToString("yyyy.MM.dd HH:mm:ss");
                    _delFromString = delFrom.ToString("yyyy.MM.dd HH:mm:ss");
                }
                else
                {
                    _delToString = delTo.ToString("yyyy.MM.dd HH:mm:ss");
                    _delFromString = delFrom.ToString("yyyy.MM.dd HH:mm:ss");
                }
            }
            if (cboSelectDelete.SelectedIndex == 3)
            {
                dtpDelTo.Enabled = false;
                dtpDelToTime.Enabled = false;
                delFrom = dtpDelFrom.Value.Date + dtpDelFromTime.Value.TimeOfDay;
                delTo = dtpDelFrom.Value.Date + dtpDelFromTime.Value.TimeOfDay;
                delTo = delTo.AddMinutes(1.0);
                delFrom = delFrom.AddMinutes(-1.0);
                _delToString = delTo.ToString("yyyy.MM.dd HH:mm:ss");
                _delFromString = delFrom.ToString("yyyy.MM.dd HH:mm:ss");
            }
            if (cboSelectDelete.SelectedIndex == -1)
            {
                btnDelReading.Enabled = false;
            }
            DelReadings();
            Update_Form();
        }

        //Metode som sletter en email. tar å bruker et indexnummer som den får fra comboxen til å velge den som slettes.
        private void btnDelEmail_Click(object sender, EventArgs e)
        {
            int delIndex = Convert.ToInt32(cboDelEmail.SelectedValue);
            Program.MDbHandler.DelEmail(delIndex);
            dgvEmail.DataSource = null;
            _getEmails.Clear();
            GetEmail(_getEmails);
            dgvEmail.DataSource = _getEmails;
        }

        //Checkbox change event som sjekker om regulering skal være av eller på.
        private void chkSetTol_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSetTol.Checked)
            {
                Test = true;
                lblSet.Enabled = true;
                lblTol.Enabled = true;
                btnSetPointUp.Enabled = true;
                btnSetPointDown.Enabled = true;
                btnToleranceDown.Enabled = true;
                btnToleranceUp.Enabled = true;
                txtSetPoint.Enabled = true;
                txtTol.Enabled = true;
                btnSetPointDown.BackgroundImage = _imgArrowDownUp;
                btnSetPointUp.BackgroundImage = _imgArrowUp;
                btnToleranceUp.BackgroundImage = _imgArrowUp;
                btnToleranceDown.BackgroundImage = _imgArrowDownUp;
                dgvDataBase.DataSource = null;
                dgvDataBase.DataSource = _dataTable;
            }
            else
            {
                Test = false;
                lblSet.Enabled = false;
                lblTol.Enabled = false;
                btnSetPointUp.Enabled = false;
                btnSetPointDown.Enabled = false;
                btnToleranceDown.Enabled = false;
                btnToleranceUp.Enabled = false;
                txtSetPoint.Enabled = false;
                txtTol.Enabled = false;
                lblFilterStatus.Enabled = false;
                cboFilterStatus.Enabled = false;
                chkFilterStatus.Enabled = false;
                lblFilterStatus.Visible = false;
                cboFilterStatus.Visible = false;
                chkFilterStatus.Visible = false;
                btnSetPointDown.BackgroundImage = _imgArrowDownDown;
                btnSetPointUp.BackgroundImage = _imgArrowUpDown;
                btnToleranceUp.BackgroundImage = _imgArrowUpDown;
                btnToleranceDown.BackgroundImage = _imgArrowDownDown;
                dgvDataBase.DataSource = null;
                dgvDataBase.DataSource = _dataTable;
            }
            Settings.Default.RegulationActive = chkSetTol.Checked;
        }

        //Comboxevent som veleger hva som skal være synlig ved valgt element i listen.Den kjører tester.
        private void cboSelectDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSelectDelete.SelectedIndex == 0)
            {
                btnDelReading.BackgroundImage = _imgDel;
                btnDelReading.Enabled = true;
                dtpDelFrom.Enabled = false;
                dtpDelFromTime.Enabled = false;
                dtpDelTo.Enabled = false;
                dtpDelToTime.Enabled = false;
                lblDate1.Visible = false;
                lblDate2.Visible = false;
            }
            if (cboSelectDelete.SelectedIndex == 1)
            {
                btnDelReading.BackgroundImage = _imgDel;
                btnDelReading.Enabled = true;
                dtpDelFrom.Enabled = false;
                dtpDelFromTime.Enabled = false;
                dtpDelTo.Enabled = false;
                dtpDelToTime.Enabled = false;
                lblDate1.Visible = false;
                lblDate2.Visible = false;
            }
            if (cboSelectDelete.SelectedIndex == 2)
            {
                btnDelReading.BackgroundImage = _imgDel;
                btnDelReading.Enabled = true;
                dtpDelFrom.Enabled = true;
                dtpDelFromTime.Enabled = true;
                dtpDelTo.Enabled = true;
                dtpDelToTime.Enabled = true;
                lblDate1.Visible = true;
                lblDate1.Text = "Fra";
                lblDate2.Visible = true;
                lblDate2.Text = "Til";
            }
            if (cboSelectDelete.SelectedIndex == 3)
            {
                btnDelReading.BackgroundImage = _imgDel;
                btnDelReading.Enabled = true;
                dtpDelTo.Enabled = false;
                dtpDelToTime.Enabled = false;
                lblDate1.Visible = true;
                lblDate1.Text = "Måling";
                lblDate2.Visible = false;
            }
        }

        //Metode som åpner log formen som skal vise log som blir skrevet i Logger klasse.
        private void btnLog_Click(object sender, EventArgs e)
        {
            if (LogForm == null)
            {
                LogForm = new Log {StartPosition = FormStartPosition.Manual, Location = new Point(700, 40)};
                // Velger å sette startposisjonen til dette formet manuelt
                LogForm.Show();
            }
            else
            {
                LogForm.Focus();
            }
        }

        //Klikk Metode som lagrer det innenfor tabsiden Istillinger. Disse verdiene lagres til settings slik at de ikke forsvinner når programmet lukkes.
        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            Settings.Default.mesInterval = _mesurInterval;
            Settings.Default.tolerance = _tolerance;
            Settings.Default.alarmLimit = _alarmLimit;
            Settings.Default.setpoint = _setPoint;
            Settings.Default.Save();
            Regulation.Tolerance = _tolerance;
            Regulation.Setpoint = _setPoint;
            SensorCom.AlarmLimit = _alarmLimit;
            SensorCom.MesInterval = _mesurInterval;
        }

        //Tick eventet som kjører alle de viktige sjekkene som guien har, og update metodene.
        private void tmrUpdateSettings_Tick(object sender, EventArgs e)
        {
            //Sjekker om datamaskinen har strøm
            Program.IsRunningOnBattery = (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline);

            PowerCheck(); //Sjekker datamaskinens strømstatus
            SensorCheck(); //Sjekker om sensoren er tilkoblet.
            Now = DateTime.Now;
            StsStatus = "Statusoppdatering den " + Now.ToString("dd/MM/yyyy") + " klokken " + Now.ToString("HH:mm:ss") +
                        " :";
            //Public static string som brukes med datetime now for å få tidpunkt til mottamail status mailen. stringen viser da når mailen ble sendt.
            DtEmails = _getEmails;
            //Datatabell til mail klassene som inneholder alle motakere. får dette fra den utfylte getEmails. 
            MottaMail.HentMail(); // Kjører Metode i mottaMail som sjekker inboxen for nye emails.

            if (MottaMail.Body != null)
            {
                MottaMail.GetCommand();
            }
            if (Program.NeedRefresh) //skjer når det har kommet en ny reading. oppdaterer guien
            {
                Update_Form();
                Program.NeedRefresh = false;
                _xMin++;
                _xMax++;
                crtView.ChartAreas["tempOversikt"].AxisX.Minimum = _xMin;
                crtView.ChartAreas["tempOversikt"].AxisX.Maximum = _xMax;
            }
            if (Settingsupdate)
            {
                UpdateSettings(); //Oppdaterer instillingsveridenen i tabsiden instillinger.
                Settingsupdate = false;
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            _clickCount = 1;
            _xMin -= 600;
            Zoom();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            _clickCount = 0;
            _xMin += 600;
            Zoom();
        }

        private void btnDelReading_MouseDown(object sender, MouseEventArgs e)
        {
            btnDelReading.BackgroundImage = Resources.Polakken_btnSlettDown;
        }

        private void btnDelReading_MouseUp(object sender, MouseEventArgs e)
        {
            btnDelReading.BackgroundImage = Resources.Polakken_btnSlett;
        }

        private void btnShowSelected_MouseDown(object sender, MouseEventArgs e)
        {
            btnShowSelected.BackgroundImage = Resources.Polakken_btnFiltrerDown;
        }

        private void btnShowSelected_MouseUp(object sender, MouseEventArgs e)
        {
            btnShowSelected.BackgroundImage = Resources.Polakken_btnFiltrer;
        }

        private void btnReset_MouseDown(object sender, MouseEventArgs e)
        {
            btnReset.BackgroundImage = Resources.Polakken_btnNullstillFilterDown;
        }

        private void btnReset_MouseUp(object sender, MouseEventArgs e)
        {
            btnReset.BackgroundImage = Resources.Polakken_btnNullstillFilter;
            chkFilterDate.Checked = false;
            chkFilterStatus.Checked = false;
            chkFilterTemp.Checked = false;
        }

        private void btnAddEmail_MouseDown(object sender, MouseEventArgs e)
        {
            btnAddEmail.BackgroundImage = Resources.Polakken_btnLeggTilDown;
        }

        private void btnAddEmail_MouseUp(object sender, MouseEventArgs e)
        {
            btnAddEmail.BackgroundImage = Resources.Polakken_btnLeggTil;
        }

        private void btnDelEmail_MouseDown(object sender, MouseEventArgs e)
        {
            btnDelEmail.BackgroundImage = Resources.Polakken_btnSlettDown;
        }

        private void btnDelEmail_MouseUp(object sender, MouseEventArgs e)
        {
            btnDelEmail.BackgroundImage = _imgDel;
        }

        private void chkMsgDis_CheckedChanged(object sender, EventArgs e)
        {
            Logger.ShowMsgBoxes = chkMsgDis.Checked;
            Settings.Default.hideMsgBox = chkMsgDis.Checked;
            Settings.Default.Save();
        }

        // tester om den email leste variablen er innenfor grensene
        private void txtInt_TextChanged(object sender, EventArgs e)
        {
            if (999 > _mesurInterval & _mesurInterval > 1)
            {
                btnMesIUp.BackgroundImage = _imgArrowUp;
                btnMesIUp.Enabled = true;
                btnMesIDown.BackgroundImage = _imgArrowDownUp;
                btnMesIDown.Enabled = true;
            }
        }

        // tester om den email leste variablen er innenfor grensene
        private void txtSetPoint_TextChanged(object sender, EventArgs e)
        {
            if (100 > _setPoint & _setPoint > 0)
            {
                btnSetPointUp.BackgroundImage = _imgArrowUp;
                btnSetPointUp.Enabled = true;
                btnSetPointDown.BackgroundImage = _imgArrowDownUp;
                btnSetPointDown.Enabled = true;
            }
        }

        // tester om den email leste variablen er innenfor grensene
        private void txtAlarm_TextChanged(object sender, EventArgs e)
        {
            if (100 > _alarmLimit & _alarmLimit > 0)
            {
                btnAlarmUp.BackgroundImage = _imgArrowUp;
                btnAlarmUp.Enabled = true;
                btnAlarmDown.BackgroundImage = _imgArrowDownUp;
                btnAlarmDown.Enabled = true;
            }
        }

        // tester om den email leste variablen er innenfor grensene
        private void txtTol_TextChanged(object sender, EventArgs e)
        {
            if (20 > _tolerance & _tolerance > 0)
            {
                btnToleranceUp.BackgroundImage = _imgArrowUp;
                btnToleranceUp.Enabled = true;
                btnToleranceDown.BackgroundImage = _imgArrowDownUp;
                btnToleranceDown.Enabled = true;
            }
        }

        // Metode som kjører nå databindingen til datavinsingen til email er feridg , endrer på bredden og utsende til kolonnene
        private void dgvEmail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvEmail.Columns[0].Visible = false;
            dgvEmail.Columns[1].Width = dgvEmail.Width;
            dgvEmail.Columns[1].HeaderText = "Brukere";
            dgvEmail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEmail.ScrollBars = ScrollBars.Vertical;
        }

        // Metode som kjører nå databindingen til datavisningen til datatabellen er feridg , endrer på bredden og utsende til kolonnene
        private void dgvDataBase_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (!Test)
            {
                chkSetTol.Checked = false;
                dgvDataBase.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvDataBase.Columns[0].Width = 178;
                dgvDataBase.Columns[0].HeaderText = "Tidspunkt";
                dgvDataBase.Columns[1].Width = 75;
                dgvDataBase.Columns[1].HeaderText = "Tempratur";
                dgvDataBase.Columns[2].Visible = false;
            }
            else
            {
                chkSetTol.Checked = true;
                dgvDataBase.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvDataBase.Columns[0].Width = 139;
                dgvDataBase.Columns[0].HeaderText = "Tidspunkt";
                dgvDataBase.Columns[1].Width = 57;
                dgvDataBase.Columns[1].HeaderText = "Tempratur";
                dgvDataBase.Columns[2].Visible = true;
                dgvDataBase.Columns[2].HeaderText = "OvnStatus";
                dgvDataBase.Columns[2].Width = 57;
            }
        }

        #endregion

        #region moveForm

        //Her så brukes mouse eventer til å kunne flytte programmet rundt på skjermen.
        private void btnMove_MouseDown(object sender, MouseEventArgs e)
        {
            _mover = 1;
            _moveX = e.X;
            _moveY = e.Y;
        }

        private void btnMove_MouseUp(object sender, MouseEventArgs e)
        {
            _mover = 0;
        }

        private void btnMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mover == 1)
            {
                SetDesktopLocation(MousePosition.X - _moveX, MousePosition.Y - _moveY);
            }
        }

        #endregion
    }
}