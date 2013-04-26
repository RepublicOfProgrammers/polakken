using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Text.RegularExpressions;
using Polakken.Properties;


namespace Polakken
{
    public partial class GUI_FORM : Form
    {
        int CountRows = 0;
        int Mover;
        int MoveX;
        int MoveY;
        int setPoint;
        int tolerance;
        int mesurInterval;
        int alarmLimit;
        int xMin = 0;
        int xMax = 336;
        int clickCount = 0;
        DataTable dataTable = new DataTable();
        DataTable GetEmails = new DataTable();
        public static DataTable dtEmails = new DataTable();
        string delToString;
        string delFromString;
        public static bool test = false;
        public static bool settingsupdate = false;
        public static string lastR;
        public static string LastRT;
        public static DateTime now;
        public static string stsStatus;
        string minute = " Min.";
        string celcius = "°C";
        string maxValue = "Øvre Grense Nådd";
        string minValue = "Nedre Grense Nådd";
        string minError = "Nedre Grense";
        string MaxError = "Øvre Grense";
        MessageBoxButtons msgButton = MessageBoxButtons.OK;
        MessageBoxIcon msgIcon = MessageBoxIcon.Information;
        Image imgArrowUp = global::Polakken.Properties.Resources.btnArrowUp;
        Image imgArrowUpDown = global::Polakken.Properties.Resources.btnArrowUpDown;
        Image imgArrowDownUp = global::Polakken.Properties.Resources.btnArrowDown;
        Image imgArrowDownDown = global::Polakken.Properties.Resources.btnArrowDownDown;
        Image imgDel = global::Polakken.Properties.Resources.btnSlett;
        DbHandler db = new DbHandler();
        public static Log logForm = null;



        public GUI_FORM()
        {
            InitializeComponent();

        }

        private void GUI_Load(object sender, EventArgs e)
        {

            tmrUpdateSettings.Start();
            chkMsgDis.Checked = Settings.Default.hideMsgBox; // Henter inn config settpunkt på valg om skjuling av error message boxes. 
            SensorCom.mesInterval = Settings.Default.mesInterval; // Henter inn config settpunkt på måleintervall og sender til SensorCom
            SensorCom.alarmLimit = Settings.Default.alarmLimit; // Henter inn config settpunkt på alarmgrense og sender til SensorCom
            Regulation.setpoint = Settings.Default.setpoint; //Henter in config settpunkt på settpunkt og sender til Regulation
            Regulation.tolerance = Settings.Default.tolerance; // Henter inn config settpunkt på toleranse og sender til Regulation
            mesurInterval = SensorCom.mesInterval;
            alarmLimit = SensorCom.alarmLimit;
            setPoint = Regulation.setpoint;
            tolerance = Regulation.tolerance;
            txtInt.Text = Convert.ToString(mesurInterval) + minute;//Fyller intervalltextboxen
            txtAlarm.Text = Convert.ToString(alarmLimit) + celcius;//Fyller Alarmgrensetextboxen
            txtSetPoint.Text = Convert.ToString(setPoint) + celcius;//Fyller txtSetPoint
            txtTol.Text = Convert.ToString(tolerance) + celcius; //Fyller Tollerangsetextboxen
            lblDate1.Visible = false;
            lblDate2.Visible = false;
            lastR = txtCurrent.Text;
            dtEmails = GetEmails;
            btnDelReading.Enabled = false;
            PowerCheck();   //Kjører en metode som sjekker statusen på strømen til maskinen
            SensorCheck();  //Kjører en metode som teser om sensoren er tilkoblet
            //
            // Opprett DataTabell og fyll DataGridView
            //
            fillDataTable(dataTable);//Kjører metoden fillDatatable som fyller datatabellen som sendes med som en parameter
            dgvDataBase.DataSource = dataTable;//Setter datagridviewens datasource til den utfylte datatabellen
            GetEmail(GetEmails);// gjør akuratt det samme som fillDatatable, men bare for emails
            dgvEmail.DataSource = GetEmails;//Samme som for datagridviewt til databasen
           
                populateTxtbox();//Kjører en metode som kjører tester og fyller textboxene med data fra datatabellen dataTable
                xMin = CountRows - 300; // Setter Variablene xMin og xMax som skal brukes til å sette graf grenseverdier.
                xMax = CountRows + 36;

                using (DataView viewTemp = new DataView(dataTable)) // Her så fyller man en combobox med distingte tempraturer fra datatabellen.
                {
                    DataTable distinctTempValues = viewTemp.ToTable(true, "Temprature");
                    cboFilterTemp.DataSource = distinctTempValues;
                    cboFilterTemp.DisplayMember = "Temprature";
                    cboFilterTemp.ValueMember = "Temprature";

                }
            

            DataView viewDeleteEmail = new DataView(GetEmails);
            cboDelEmail.DataSource = viewDeleteEmail;
            cboDelEmail.DisplayMember = "Adresser";
            cboDelEmail.ValueMember = "Index";

            #region Chart
            // Her så endres både det visuelle ved grafen og setter også datasourcen til grafen til den utfylte datatabellen.
            crtView.DataSource = dataTable;

            crtView.ChartAreas.Add("tempOversikt");
            crtView.ChartAreas["tempOversikt"].AxisX.Minimum = xMin;
            crtView.ChartAreas["tempOversikt"].AxisX.Maximum = xMax;
            crtView.ChartAreas["tempOversikt"].AxisX.Interval = 48;
            crtView.ChartAreas["tempOversikt"].AxisY.Minimum = -5;
            crtView.ChartAreas["tempOversikt"].AxisY.Maximum = 40;
            crtView.ChartAreas["tempOversikt"].AxisY.Interval = 5;
            crtView.ChartAreas["tempOversikt"].BackColor = Color.Transparent;
            crtView.ChartAreas["tempOversikt"].AxisX.MajorGrid.LineColor = Color.LightGray;
            crtView.ChartAreas["tempOversikt"].AxisY.MajorGrid.LineColor = Color.LightGray;
            crtView.ChartAreas["tempOversikt"].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.ForeColor = Color.GreenYellow;
            crtView.ChartAreas["tempOversikt"].AxisX.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.LineColor = Color.DarkGray;
            crtView.ChartAreas["tempOversikt"].AxisY.LabelStyle.ForeColor = Color.GreenYellow;
            crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.Angle = 0;
            crtView.ChartAreas["tempOversikt"].AxisX.Title = "Dato";
            crtView.ChartAreas["tempOversikt"].AxisY.Title = "Tempratur";
            crtView.ChartAreas["tempOversikt"].AxisX.TitleFont = new System.Drawing.Font("Verdana", 9, FontStyle.Bold);
            crtView.ChartAreas["tempOversikt"].AxisY.TitleFont = new System.Drawing.Font("Verdana", 9, FontStyle.Bold);
            crtView.ChartAreas["tempOversikt"].AxisY.TitleAlignment = StringAlignment.Near;
            crtView.ChartAreas["tempOversikt"].AxisX.TitleAlignment = StringAlignment.Near;

            crtView.ChartAreas["tempOversikt"].AxisX.TitleForeColor = Color.White;
            crtView.ChartAreas["tempOversikt"].AxisY.TitleForeColor = Color.White;
            crtView.ChartAreas["tempOversikt"].AxisY.LabelStyle.Format = "{0} °C";
            crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.Interval = 48;

            crtView.Series.Add("temp");
            crtView.Series["temp"].Color = Color.LawnGreen;
            crtView.Series["temp"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            crtView.Series["temp"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            crtView.Series["temp"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            crtView.Series["temp"].XValueMember = "ReadTime";
            crtView.Series["temp"].YValueMembers = "Temprature";
            crtView.DataBind();
            #endregion
            //
            //TabellVisning, Endrer det visuelle ved datagridviewet.
            //
            if (!test)
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
            //SetPoint Og Tollerangse knappene, Setter disse til false , fordi det ikke er noe regulering på.
            //
            this.btnSetPointDown.BackgroundImage = global::Polakken.Properties.Resources.btnArrowDownDown;
            this.btnSetPointUp.BackgroundImage = global::Polakken.Properties.Resources.btnArrowUpDown;
            this.btnToleranceUp.BackgroundImage = global::Polakken.Properties.Resources.btnArrowUpDown;
            this.btnToleranceDown.BackgroundImage = global::Polakken.Properties.Resources.btnArrowDownDown;

            //
            //Delete btn, Setter bare at denne er ikke aktiv, denne blir det når man velger slettemetode(Se lenger ned).
            //

            btnDelReading.Enabled = false;



        }
        //
        //Koble Til Databasen og hente ut verdier
        //

        public DataTable fillDataTable(DataTable dataTable_toFill)  //Datatabell Metode som fyller en vedlagt tom datatabell med data fra databasen, med metode fra DBHandler.
        {
            if (dataTable_toFill.Columns.Contains("ReadTime") & dataTable_toFill.Columns.Contains("Temprature") & dataTable_toFill.Columns.Contains("Status")) //Sjekker om tabellen allerede eksisterer.
            {
                db.OpenDb();              //Hvis den gjør det så åpner den databasen vi DBHandler.
                SqlCeDataReader mReader = db.GetReadings();   //Opretter en SQL Datareader som settes lik metoden i DBHandler Getreadings.

                while (mReader.Read()) // Så lenge det er noe å lese i databasne 
                {
                    var row = dataTable_toFill.NewRow(); // Oppretter en ny rad i datatabellen
                    for (int i = 0; i < 3; i++) // Kjører test på hvilken kolonne som er gjeldene og fyller inn i den respektive kolonnen i datatabellen.
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
                    dataTable_toFill.Rows.Add(row); // Legger inn radene i tabellen.

                }

                mReader.Close(); // Ikke mer å lese fra databasen, lukker derfor tilkoblingen til leseren.
            }
            else
            {
                dataTable_toFill.Columns.Add("ReadTime", typeof(string));   // Samme som metoden over, men datatabellen har ikke kolonnene og derfor oppretter den de.
                dataTable_toFill.Columns.Add("Temprature", typeof(string));
                dataTable_toFill.Columns.Add("Status", typeof(string));

                db.OpenDb();
                SqlCeDataReader mReader = db.GetReadings();

                while (mReader.Read())
                {
                    var row = dataTable_toFill.NewRow();
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
                    dataTable_toFill.Rows.Add(row);

                }

                mReader.Close();
            }

            db.CloseDb(); // Lukker så hele databasen
            return dataTable_toFill; // Her blir datatabellen som metoden har utfylt retunert til der den blir kalt opp i en parameter datatabell.
        }


        public DataTable GetEmail(DataTable GetEmails) //Samme type metode som over, men istedenfor målinger så henter denne emails.
        {
            if (GetEmails.Columns.Contains("Adresser"))
            {
                db.OpenDb();
                SqlCeDataReader emReader = db.GetEmails(); // Oppretter igjen en leser som går igjennom alle oppføringer i databasen.

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

                GetEmails.Columns.Add("Index", typeof(int));  // Her oppretter den da kolonnene hvis de ikke eksisterer.
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

            db.CloseDb(); // lukker databasen.
            return GetEmails;   //Returnerer datatabellen GetEmails.
        }

        private void DelEmails(int indexNumber) // Metode som brukes for å slette en email vi DBHandleren, sender men en parameter som blir satt lenger ned i guien.
        {
            db.DelEmail(indexNumber);

        }
        private void DelReadings() // Metode som brukes for å slette måling/er i databasen , igjen via DBHandleren.
        {
            db.DelReadings(delFromString, delToString);
        }

       

        private void UpdateSettings()   //Metode som oppdateerer textboxene , da via sensorkomunikasjonen sine variabler, FKS. ved en motatt email med nye verdier.
        {
            mesurInterval = SensorCom.mesInterval;
            alarmLimit = SensorCom.alarmLimit;
            setPoint = Regulation.setpoint;
            tolerance = Regulation.tolerance;
            txtInt.Text = Convert.ToString(mesurInterval) + minute;
            txtAlarm.Text = Convert.ToString(alarmLimit) + celcius;
            txtSetPoint.Text = Convert.ToString(setPoint) + celcius;
            txtTol.Text = Convert.ToString(tolerance) + celcius;
        }


        //
        //Form Hendelser
        //

        private void btnLukk_Click(object sender, EventArgs e)
        {
            Program.tMålTemp.Abort(); // Stopper måleprossessen slik at programmet lukkes.
            Application.Exit(); // Avslutter hele programmet.
        }

        private void btnMinimize_Click(object sender, EventArgs e) //Metode for å minnimere programmet til oppgavelinjen.
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #region moveForm 
        //Her så brukes mouse eventer til å kunne flytte programmet rundt på skjermen.
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
        #endregion

        //Metode som fyller textboxer med verdier , kjøer counter på antall elementer i datatabellen
        //og henter verdier som skal brukes i mottaMail status.
        private void populateTxtbox()
        {
            int maxTemp = int.MinValue;
            int maxTempTest = int.MinValue;
            int minTemp = int.MaxValue;
            int minTempTest = int.MaxValue;
            string tempString = "";
            DateTime dt = DateTime.MinValue;
            foreach (DataRow row in dataTable.Rows)
            {
                tempString = row["Temprature"].ToString() + celcius;    // string som settes lik den nåværende radens temp i kolonnen Tempratur til string.
                dt = DateTime.Parse(row["ReadTime"].ToString());    // Samme men bare parser en string med tidspunkt om til DateTime
                txtCurrentTime.Text = dt.ToString();                // textboxen med siste måling datoTid til den parsede datetimen
                CountRows++;   //Antall elementertelleren legger til en for hver rad.
                maxTempTest = int.Parse(row["Temprature"].ToString());  //Kjører test i denne if setingen for å finne høyeste verdi
                if (maxTemp < maxTempTest)
                {
                    maxTemp = maxTempTest;
                    DateTime maxDT = DateTime.Parse(row["ReadTime"].ToString());
                    txtMaxTime.Text = maxDT.ToString();
                    txtMax.Text = maxTemp.ToString() + celcius;
                }
                minTempTest = int.Parse(row["Temprature"].ToString());  // Og i denne for å finne laveste verdi
                if (minTemp > minTempTest)
                {
                    minTemp = minTempTest;
                    DateTime minDT = DateTime.Parse(row["ReadTime"].ToString());
                    txtMinTime.Text = minDT.ToString();
                    txtMin.Text = minTemp.ToString() + celcius;
                }

            }
            txtCurrent.Text = tempString; //textboxen til siste avlesingen får den siste tempraturen ifra testen.
            lastR = tempString; // public static string som får siste verdi av tempen  og brukes senere i mottaMail
            LastRT = dt.ToString("dd/MM/yyyy HH:mm:ss"); // samme med denne, men bare da for tiden istedenfor tempen
            
        }
        //
        //Hendelser
        //
        private void btnSaveAll_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnSaveAll.BackgroundImage = global::Polakken.Properties.Resources.btnLagreDown;
        }

        private void btnSaveAll_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnSaveAll.BackgroundImage = global::Polakken.Properties.Resources.btnLagre;
            MessageBox.Show("Du har nå lagret de nye verdiene", "Suksess", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Metode som plusser på setpoint når den er trykket. er også en sjekk i den som sjekker om den er øvre grense.
        private void btnSetPointUp_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnSetPointUp.BackgroundImage = imgArrowUpDown;
            this.btnSetPointDown.BackgroundImage = imgArrowDownUp;
            btnSetPointDown.Enabled = true;
            int ChangeSetPointAdd = setPoint;
            ChangeSetPointAdd = ChangeSetPointAdd + 1;
            setPoint = ChangeSetPointAdd;
            txtSetPoint.Text = ChangeSetPointAdd.ToString() + celcius;
            if (ChangeSetPointAdd > 100)
            {
                ChangeSetPointAdd -= 1 ;
                txtSetPoint.Text = ChangeSetPointAdd.ToString() + celcius;
                setPoint = ChangeSetPointAdd;
                MessageBox.Show(maxValue,MaxError,msgButton,msgIcon);
                btnSetPointUp.Enabled = false;   //Disabler knappen når den har nådd grensen
                this.btnSetPointUp.BackgroundImage = imgArrowUpDown;

            }
        }

        private void btnSetPointUp_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnSetPointUp.BackgroundImage = imgArrowUp;
        }

        private void btnSetPointDown_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnSetPointDown.BackgroundImage = imgArrowDownDown;

        }
        //Samme som sist metode med å endre setpoint ,denne gangen nedover, med en nedre grense
        private void btnSetPointDown_MouseUp(object sender, MouseEventArgs e)
        {
            btnSetPointUp.Enabled = true;
            btnSetPointUp.BackgroundImage = imgArrowUp;
            this.btnSetPointDown.BackgroundImage = imgArrowDownUp;
            int ChangeSetPointSub = setPoint;
            ChangeSetPointSub = ChangeSetPointSub - 1;
            txtSetPoint.Text = ChangeSetPointSub.ToString() + celcius;
            setPoint = ChangeSetPointSub;
            if (ChangeSetPointSub < 0)
            {
                ChangeSetPointSub += 1;
                txtSetPoint.Text = ChangeSetPointSub.ToString() + celcius;
                setPoint = ChangeSetPointSub;
                MessageBox.Show(minValue, minError, msgButton, msgIcon);
                btnSetPointDown.Enabled = false;
                this.btnSetPointDown.BackgroundImage = imgArrowDownDown;

            }
            
        }
        //Samme for tolernagse, med en øvre grense
        private void btnToleranceUp_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnToleranceUp.BackgroundImage = imgArrowUpDown;
            this.btnToleranceDown.BackgroundImage = imgArrowDownUp;
            btnToleranceDown.Enabled = true;
            int ChangeTolAdd = tolerance;
            ChangeTolAdd += 1;
            tolerance = ChangeTolAdd;
            txtTol.Text = ChangeTolAdd.ToString() + celcius;
            if (ChangeTolAdd > 20)
            {
                ChangeTolAdd -= 1;
                txtTol.Text = ChangeTolAdd.ToString() + celcius;
                tolerance = ChangeTolAdd;
                MessageBox.Show(maxValue, MaxError, msgButton, msgIcon);
                btnToleranceUp.Enabled = false;
                this.btnToleranceUp.BackgroundImage = imgArrowUpDown;

            }
        }

        private void btnToleranceUp_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnToleranceUp.BackgroundImage = imgArrowUp;

        }
        //Metode som tester på datamaskinens strømstatus. Dette ved hjelp av en bool som blir satt i program.
        
        private void PowerCheck()
        {
            if (Program.isRunningOnBattery == false)
            {
                picPower.Image = global::Polakken.Properties.Resources.imgPowerOn;
                lblPowerInfo.ForeColor = Color.White;
                lblPowerInfo.Text = "Datamaskinen har strøm";
            }
            else if (Program.isRunningOnBattery == true)
            {
                picPower.Image = global::Polakken.Properties.Resources.imgPowerOff;
                lblPowerInfo.ForeColor = Color.Red;
                lblPowerInfo.Text = "Datamaskinen går på batteri";
            }
        }
        //Metode som tester om sensoren er tilkoblet,kjører en public static metode fra sensorcom.
        private void SensorCheck()
        {
            if (SensorCom.connected())
            {
                picSensor.Image = global::Polakken.Properties.Resources.imgSensorIn;
                lblSensorInfo.ForeColor = Color.White;
                lblSensorInfo.Text = "Sensoren er tilkoblet";
            }else
            {
                picSensor.Image = global::Polakken.Properties.Resources.imgSensorOut;
                lblSensorInfo.ForeColor = Color.Red;
                lblSensorInfo.Text = "Sensoren er ikke tilkoblet";
            }
        }
        //Metode som endrer min verdien på X-aksen i crtView. den har at du kun kan trykke en gang på hver knapp.
        //og den motsatte blir disablet.
        public void Zoom()
        {

            crtView.ChartAreas["tempOversikt"].AxisX.Minimum = xMin;

            if (clickCount == 0)
            {
                
                crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.Interval = 48;
                btnZoomOut.Enabled = true;
                btnZoomIn.Enabled = false;
                btnZoomIn.BackgroundImage = global::Polakken.Properties.Resources.btnPlusDisabeld;
                btnZoomOut.BackgroundImage = global::Polakken.Properties.Resources.btnMinus;
                clickCount = 0;
            }
            if (clickCount == 1)
            {
                crtView.ChartAreas["tempOversikt"].AxisX.LabelStyle.Interval = 96;
                btnZoomOut.Enabled = false;
                btnZoomIn.Enabled = true;
                btnZoomOut.BackgroundImage = global::Polakken.Properties.Resources.btnMinusDisabled;
                btnZoomIn.BackgroundImage = global::Polakken.Properties.Resources.btnPlus;
                clickCount = 0;

            }

        }
        //En metode som endrer tolerangse nedover ved klikk.
        private void btnToleranceDown_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnToleranceUp.BackgroundImage = imgArrowUp;
            this.btnToleranceDown.BackgroundImage = imgArrowDownDown;
            this.btnToleranceUp.Enabled = true;
            int ChangeTolSub = tolerance;
            ChangeTolSub -= 1;
            tolerance = ChangeTolSub;
            txtTol.Text = ChangeTolSub.ToString() + celcius;
            if (ChangeTolSub < 0 )
            {
                ChangeTolSub += 1;
                txtTol.Text = ChangeTolSub.ToString() + celcius;
                tolerance = ChangeTolSub;
                MessageBox.Show(minValue, minError, msgButton, msgIcon);
                btnToleranceDown.Enabled = false;
                this.btnToleranceDown.BackgroundImage = imgArrowDownDown;

            }
        }

        private void btnToleranceDown_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnToleranceDown.BackgroundImage = imgArrowDownUp;
        }
        //metode som plusser på intervallet ved klikk. 
        private void btnMesIUp_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnMesIUp.BackgroundImage = imgArrowUpDown;
            this.btnMesIDown.BackgroundImage = imgArrowDownUp;
            btnMesIDown.Enabled = true;
            int ChangeMesIAdd = mesurInterval;
            ChangeMesIAdd += 1;
            mesurInterval = ChangeMesIAdd;
            txtInt.Text = ChangeMesIAdd.ToString() + minute;
            if (ChangeMesIAdd > 999)
            {
               ChangeMesIAdd -= 1;
               txtInt.Text = ChangeMesIAdd.ToString() + minute;
               mesurInterval = ChangeMesIAdd;
               MessageBox.Show(maxValue, MaxError, msgButton, msgIcon);
               btnMesIUp.Enabled = false;
               this.btnMesIUp.BackgroundImage = imgArrowUpDown;
            }
        }

        private void btnMesIUp_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnMesIUp.BackgroundImage = imgArrowUp;
        }
        //Metode som trekker fra intervallet ved klikk.
        private void btnMesIDown_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnMesIDown.BackgroundImage = imgArrowDownDown;
            this.btnMesIUp.BackgroundImage = imgArrowUp;
            btnMesIUp.Enabled = true;
            int ChangeMesISub = mesurInterval;
            ChangeMesISub -= 1;
            mesurInterval = ChangeMesISub;
            txtInt.Text = ChangeMesISub.ToString() + minute;
            if (ChangeMesISub < 1)
            {
               
                ChangeMesISub += 1;
                txtInt.Text = ChangeMesISub.ToString() + minute;
                mesurInterval = ChangeMesISub;
                MessageBox.Show(minValue, minError, msgButton, msgIcon);
                btnMesIDown.Enabled = false;
                this.btnMesIDown.BackgroundImage = imgArrowDownDown;
            }
        }

        private void btnMesIDown_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnMesIDown.BackgroundImage = imgArrowDownUp;
        }
        //Metode som pluser på den nedre Alarmgrensen ved klikk.
        private void btnAlarmUp_MouseDown(object sender, MouseEventArgs e)
        {


            this.btnAlarmUp.BackgroundImage = imgArrowUpDown;
            this.btnAlarmDown.BackgroundImage = imgArrowDownUp;
            btnAlarmDown.Enabled = true;
            txtAlarm.Enabled = true;
            int ChangeAlarmAdd = alarmLimit;
            ChangeAlarmAdd += 1;
            alarmLimit = ChangeAlarmAdd;
            txtAlarm.Text = ChangeAlarmAdd.ToString() + celcius;
            if (ChangeAlarmAdd > 100)
            {
                ChangeAlarmAdd -= 1;
                txtAlarm.Text = ChangeAlarmAdd.ToString() + celcius;
                alarmLimit = ChangeAlarmAdd;
                MessageBox.Show(maxValue, MaxError, msgButton, msgIcon);
                btnAlarmUp.Enabled = false;
                this.btnAlarmUp.BackgroundImage = imgArrowUpDown;
            }
        }

        private void btnAlarmUp_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnAlarmUp.BackgroundImage = imgArrowUp;
        }
        //Metode som trekker fra den nedre alarmgrensen ved klikk.
        private void btnAlarmDown_MouseDown(object sender, MouseEventArgs e)
        {
           
            this.btnAlarmDown.BackgroundImage = imgArrowDownDown;
            this.btnAlarmUp.BackgroundImage = imgArrowUp;
            btnAlarmUp.Enabled = true;
            int ChangeAlarmISub = alarmLimit;
            ChangeAlarmISub -= 1;
            alarmLimit = ChangeAlarmISub;
            txtAlarm.Text = ChangeAlarmISub.ToString() + celcius;
            if (ChangeAlarmISub < 0)
            {
                ChangeAlarmISub += 1;
                txtAlarm.Text = ChangeAlarmISub.ToString() + celcius;
                alarmLimit = ChangeAlarmISub;
                MessageBox.Show(minValue, minError, msgButton, msgIcon);
                btnAlarmDown.Enabled = false;
                this.btnAlarmDown.BackgroundImage = imgArrowDownDown;
            }
        }

        private void btnAlarmDown_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnAlarmDown.BackgroundImage = imgArrowDownUp;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]//DataView trenger ikke disposing, dette er en bivirking som er arvet. (i følge stackoverflow)
        private void btnShowSelected_Click(object sender, EventArgs e) // Metode som ved klikk opretter ett dataview av datatabellen. denne blir så lagt på ulike row filtere ved å teste på hva som er blitt valgt til å filtrere på med chekboxene.
        {
            if (dtpSelectFrom.Value > dtpSelectTo.Value)
            {
                MessageBox.Show("Startdato kan ikke være større en sluttdato", "Datofeil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataView view = new DataView(dataTable);
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
                    filterString = "AND Status =" + statusText + dateSpan;
                    view.RowFilter = "Status =" + statusText + dateSpan;        //Legger ved de verdiene fra de andre, for hvis de ikke er cheket så er strenge dems tomme.
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
                    view.RowFilter = "Temprature <" + valueTempString + filterString + dateSpan;    //Blir lagt til rowfilteret til viewen.

                }

            }
            dgvDataBase.DataSource = view; // Setter tabellvisningens datakilde til det filtrerte datautsnitte.

        }
        //Metode som kjører metoder i GUIEN(Skjer ved tick fra Timer) for å oppdatere de ulike visningene i guien.
        public void Update_Form()
        {
            dgvDataBase.DataSource = null;  //Fjerner tabelvisningens datakilde.
            dataTable.Clear();  //Tømmer datatabellen.
            fillDataTable(dataTable);   //Fyller tabellen på nytt med metoden filldatatable(for info om den se lenger opp)
            dgvDataBase.DataSource = dataTable; // setter datakilden til tabellvisningen til datatabellen.
            crtView.DataBind(); //databinder grafen så den viser nye punkter.
            populateTxtbox(); //Kjører metoden som fyller textboxene med verdier(Siste,Mintemp,Maxtemp).
        }

        //Metode som nullstiller tabellvisningen når det er tatt ett utsnitt av den og denne er klikket på
        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvDataBase.DataSource = null;//Fjerner tabelvisningens datakilde.
            dataTable.Clear(); //Tømmer datatabellen.
            fillDataTable(dataTable);  //Fyller tabellen på nytt med metoden filldatatable(for info om den se lenger opp)
            dgvDataBase.DataSource = dataTable;// setter datakilden til tabellvisningen til datatabellen.

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
                var foundAdress = GetEmails.Select("Adresser = '" + searchEmail + "'");
                if (foundAdress.Length != 0)
                {
                    MessageBox.Show("Emailen Eksisterer alerede", "FEIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    db.AddEmail(inputText);//Metode som legger til eposten ved at stringen som er eposten sendes med som parameter.Metoden for addemail finner du lenger oppe på siden.
                    dgvEmail.DataSource = null;
                    GetEmails.Clear();
                    GetEmail(GetEmails);                //Oppdaterer så tabellvisningen for email for å vise den nye i tabellvinsingen.
                    dgvEmail.DataSource = GetEmails;
                    txtAddEmail.Clear();
                }

            }


        }

        //Metode som skal ved klikk , se hva som er valgt i slettemetode comboboxen. for så å sette to dato variabler som blir brukt i  delReadings metoden
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
                    MessageBox.Show("Fradato kan ikke være større enn tildato", "Feil", MessageBoxButtons.OK);
                    delToString = delTo.ToString("yyyy.MM.dd HH:mm:ss");
                    delFromString = delFrom.ToString("yyyy.MM.dd HH:mm:ss");
                }
                else
                {
                    delToString = delTo.ToString("yyyy.MM.dd HH:mm:ss");
                    delFromString = delFrom.ToString("yyyy.MM.dd HH:mm:ss");
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
                delToString = delTo.ToString("yyyy.MM.dd HH:mm:ss");
                delFromString = delFrom.ToString("yyyy.MM.dd HH:mm:ss");
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
            int DelIndex = Convert.ToInt32(cboDelEmail.SelectedValue);
            db.DelEmail(DelIndex);
            dgvEmail.DataSource = null;
            GetEmails.Clear();
            GetEmail(GetEmails);
            dgvEmail.DataSource = GetEmails;

        }
        //Checkbox change event som sjekker om regulering skal være av eller på.
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
                this.btnSetPointDown.BackgroundImage = imgArrowDownUp;
                this.btnSetPointUp.BackgroundImage = imgArrowUp;
                this.btnToleranceUp.BackgroundImage = imgArrowUp;
                this.btnToleranceDown.BackgroundImage = imgArrowDownUp;
                dgvDataBase.DataSource = null;
                dgvDataBase.DataSource = dataTable;
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
                lblFilterStatus.Enabled = false;
                cboFilterStatus.Enabled = false;
                chkFilterStatus.Enabled = false;
                lblFilterStatus.Visible = false;
                cboFilterStatus.Visible = false;
                chkFilterStatus.Visible = false;
                this.btnSetPointDown.BackgroundImage = imgArrowDownDown;
                this.btnSetPointUp.BackgroundImage = imgArrowUpDown;
                this.btnToleranceUp.BackgroundImage = imgArrowUpDown;
                this.btnToleranceDown.BackgroundImage = imgArrowDownDown;
                dgvDataBase.DataSource = null;
                dgvDataBase.DataSource = dataTable;
            }

        }
        //Comboxevent som veleger hva som skal være synlig ved valgt element i listen.Den kjører tester.
        private void cboSelectDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSelectDelete.SelectedIndex == 0)
            {
                btnDelReading.BackgroundImage = imgDel;
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
                btnDelReading.BackgroundImage = imgDel;
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
                btnDelReading.BackgroundImage = imgDel;
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
                btnDelReading.BackgroundImage = imgDel;
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
            logForm = new Log();
            logForm.StartPosition = FormStartPosition.Manual; // Velger å sette startposisjonen til dette formet manuelt
            logForm.Location = new Point(700, 40);//Startpossisjonen til formen er i det pointe(x,y)
            logForm.Show();
        }
        //Klikk Metode som lagrer det innenfor tabsiden Istillinger. Disse verdiene lagres til settings slik at de ikke forsvinner når programmet lukkes.
        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            Settings.Default.mesInterval = mesurInterval;
            Settings.Default.tolerance = tolerance;
            Settings.Default.alarmLimit = alarmLimit;
            Settings.Default.setpoint = setPoint;
            Settings.Default.Save();
            Regulation.tolerance = tolerance;
            Regulation.setpoint = setPoint;
            SensorCom.alarmLimit = alarmLimit;
            SensorCom.mesInterval = mesurInterval;
        }
        //Tick eventet som kjører alle de viktige sjekkene som guien har, og update metodene.
        private void tmrUpdateSettings_Tick(object sender, EventArgs e)
        {
            //Sjekker om datamaskinen har strøm
            Program.isRunningOnBattery = (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline);

            PowerCheck();//Sjekker datamaskinens strømstatus
            SensorCheck();//Sjekker om sensoren er tilkoblet.
            now = DateTime.Now;
            stsStatus = "Statusoppdatering den " + now.ToString("dd/MM/yyyy") + " klokken " + now.ToString("HH:mm:ss") + " :"; //Public static string som brukes med datetime now for å få tidpunkt til mottamail status mailen. stringen viser da når mailen ble sendt.
            dtEmails = GetEmails; //Datatabell til mail klassene som inneholder alle motakere. får dette fra den utfylte getEmails. 
            MottaMail.mottaMail(); // Kjører Metode i mottaMail som sjekker inboxen for nye emails.
           
            if (MottaMail.body != null)
            {
                MottaMail.getCommand(); 
            }
            if (Program.needRefresh) //skjer når det har kommet en ny reading. oppdaterer guien
            {
                Update_Form();
                Program.needRefresh = false;
                xMin++;
                xMax++;
                crtView.ChartAreas["tempOversikt"].AxisX.Minimum = xMin;
                crtView.ChartAreas["tempOversikt"].AxisX.Maximum = xMax;
            }
            if (settingsupdate)
            {
                UpdateSettings(); //Oppdaterer instillingsveridenen i tabsiden instillinger.
                settingsupdate = false; 
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            clickCount = 1;
            xMin -= 600;
            Zoom();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            clickCount = 0;
            xMin += 600;
            Zoom();
        }

        private void btnDelReading_MouseDown(object sender, MouseEventArgs e)
        {
            btnDelReading.BackgroundImage = global::Polakken.Properties.Resources.btnSlettDown;
        }

        private void btnDelReading_MouseUp(object sender, MouseEventArgs e)
        {
            btnDelReading.BackgroundImage = global::Polakken.Properties.Resources.btnSlett;
        }

        private void btnShowSelected_MouseDown(object sender, MouseEventArgs e)
        {
            btnShowSelected.BackgroundImage = global::Polakken.Properties.Resources.btnFiltrerDown;
        }

        private void btnShowSelected_MouseUp(object sender, MouseEventArgs e)
        {
            btnShowSelected.BackgroundImage = global::Polakken.Properties.Resources.btnFiltrer;
        }

        private void btnReset_MouseDown(object sender, MouseEventArgs e)
        {
            btnReset.BackgroundImage = global::Polakken.Properties.Resources.btnNullstillFilterDown;
        }

        private void btnReset_MouseUp(object sender, MouseEventArgs e)
        {
            btnReset.BackgroundImage = global::Polakken.Properties.Resources.btnNullstillFilter;
            chkFilterDate.Checked = false;
            chkFilterStatus.Checked = false;
            chkFilterTemp.Checked = false;
        }

        private void btnAddEmail_MouseDown(object sender, MouseEventArgs e)
        {
            btnAddEmail.BackgroundImage = global::Polakken.Properties.Resources.btnLeggTilDown;
        }

        private void btnAddEmail_MouseUp(object sender, MouseEventArgs e)
        {
            btnAddEmail.BackgroundImage = global::Polakken.Properties.Resources.btnLeggTil;
        }

        private void btnDelEmail_MouseDown(object sender, MouseEventArgs e)
        {
            btnDelEmail.BackgroundImage = global::Polakken.Properties.Resources.btnSlettDown;
        }

        private void btnDelEmail_MouseUp(object sender, MouseEventArgs e)
        {
            btnDelEmail.BackgroundImage = imgDel;
        }

        private void chkMsgDis_CheckedChanged(object sender, EventArgs e)
        {
            Logger.showMsgBoxes = chkMsgDis.Checked;
            Settings.Default.hideMsgBox = chkMsgDis.Checked;
            Settings.Default.Save();
        }
        // tester om den email leste variablen er innenfor grensene
        private void txtInt_TextChanged(object sender, EventArgs e)
        {
            if (999 > mesurInterval & mesurInterval > 1)
            {
                btnMesIUp.BackgroundImage = imgArrowUp;
                btnMesIUp.Enabled = true;
                btnMesIDown.BackgroundImage = imgArrowDownUp;
                btnMesIDown.Enabled = true;
            }
        }
        // tester om den email leste variablen er innenfor grensene
        private void txtSetPoint_TextChanged(object sender, EventArgs e)
        {
            if (100 > setPoint & setPoint > 0)
            {
                btnSetPointUp.BackgroundImage = imgArrowUp;
                btnSetPointUp.Enabled = true;
                btnSetPointDown.BackgroundImage = imgArrowDownUp;
                btnSetPointDown.Enabled = true;
            }
        }
        // tester om den email leste variablen er innenfor grensene
        private void txtAlarm_TextChanged(object sender, EventArgs e)
        {
            if (100 > alarmLimit & alarmLimit > 0)
            {
                btnAlarmUp.BackgroundImage = imgArrowUp;
                btnAlarmUp.Enabled = true;
                btnAlarmDown.BackgroundImage = imgArrowDownUp;
                btnAlarmDown.Enabled = true;
            }
        }
        // tester om den email leste variablen er innenfor grensene
        private void txtTol_TextChanged(object sender, EventArgs e)
        {
            if (20 > tolerance & tolerance > 0)
            {
                btnToleranceUp.BackgroundImage = imgArrowUp;
                btnToleranceUp.Enabled = true;
                btnToleranceDown.BackgroundImage = imgArrowDownUp;
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
            if (!test)
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
    }
}