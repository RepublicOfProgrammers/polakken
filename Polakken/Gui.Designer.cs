namespace Polakken
{
    partial class GUI
    {
        
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.crtView = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLukk = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.tbcPage = new System.Windows.Forms.TabControl();
            this.tbpOne = new System.Windows.Forms.TabPage();
            this.chkSetTol = new System.Windows.Forms.CheckBox();
            this.txtAlarm = new System.Windows.Forms.TextBox();
            this.txtInt = new System.Windows.Forms.TextBox();
            this.txtSetPoint = new System.Windows.Forms.TextBox();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAlarmDown = new System.Windows.Forms.Button();
            this.btnAlarmUp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMesIDown = new System.Windows.Forms.Button();
            this.btnMesIUp = new System.Windows.Forms.Button();
            this.txtTol = new System.Windows.Forms.TextBox();
            this.lblTol = new System.Windows.Forms.Label();
            this.btnToleranceDown = new System.Windows.Forms.Button();
            this.btnToleranceUp = new System.Windows.Forms.Button();
            this.lblSet = new System.Windows.Forms.Label();
            this.btnSetPointDown = new System.Windows.Forms.Button();
            this.btnSetPointUp = new System.Windows.Forms.Button();
            this.tbpTwo = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDelType = new System.Windows.Forms.Label();
            this.cboSelectDelete = new System.Windows.Forms.ComboBox();
            this.dtpSelectToTime = new System.Windows.Forms.DateTimePicker();
            this.dtpSelectFromTime = new System.Windows.Forms.DateTimePicker();
            this.dtpDelToTime = new System.Windows.Forms.DateTimePicker();
            this.dtpDelFromTime = new System.Windows.Forms.DateTimePicker();
            this.btnDelReading = new System.Windows.Forms.Button();
            this.dtpDelTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDelFrom = new System.Windows.Forms.DateTimePicker();
            this.chkFilterDate = new System.Windows.Forms.CheckBox();
            this.chkFilterTemp = new System.Windows.Forms.CheckBox();
            this.chkFilterStatus = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.cboEqualsFilter = new System.Windows.Forms.ComboBox();
            this.cboFilterTemp = new System.Windows.Forms.ComboBox();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();
            this.btnShowSelected = new System.Windows.Forms.Button();
            this.dtpSelectTo = new System.Windows.Forms.DateTimePicker();
            this.dtpSelectFrom = new System.Windows.Forms.DateTimePicker();
            this.dgvDataBase = new System.Windows.Forms.DataGridView();
            this.tbpThree = new System.Windows.Forms.TabPage();
            this.btnDelEmail = new System.Windows.Forms.Button();
            this.cboDelEmail = new System.Windows.Forms.ComboBox();
            this.dgvEmail = new System.Windows.Forms.DataGridView();
            this.btnAddEmail = new System.Windows.Forms.Button();
            this.txtAddEmail = new System.Windows.Forms.TextBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.lblSiste = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.txtMaxTime = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.lblMin = new System.Windows.Forms.Label();
            this.txtMinTime = new System.Windows.Forms.TextBox();
            this.txtCurrentTime = new System.Windows.Forms.TextBox();
            this.btnLog = new System.Windows.Forms.Button();
            this.tmrUpdateSettings = new System.Windows.Forms.Timer(this.components);
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.crtView)).BeginInit();
            this.tbcPage.SuspendLayout();
            this.tbpOne.SuspendLayout();
            this.tbpTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataBase)).BeginInit();
            this.tbpThree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // crtView
            // 
            this.crtView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.crtView.BackColor = System.Drawing.Color.Transparent;
            this.crtView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.crtView.BackSecondaryColor = System.Drawing.Color.White;
            this.crtView.Location = new System.Drawing.Point(-16, 435);
            this.crtView.Name = "crtView";
            this.crtView.Size = new System.Drawing.Size(917, 226);
            this.crtView.TabIndex = 1;
            // 
            // btnLukk
            // 
            this.btnLukk.BackColor = System.Drawing.Color.Transparent;
            this.btnLukk.BackgroundImage = global::Polakken.Properties.Resources.Close;
            this.btnLukk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLukk.FlatAppearance.BorderSize = 0;
            this.btnLukk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLukk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLukk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLukk.Location = new System.Drawing.Point(863, 22);
            this.btnLukk.Name = "btnLukk";
            this.btnLukk.Size = new System.Drawing.Size(30, 30);
            this.btnLukk.TabIndex = 4;
            this.btnLukk.UseVisualStyleBackColor = false;
            this.btnLukk.Click += new System.EventHandler(this.btnLukk_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BackgroundImage = global::Polakken.Properties.Resources.Minimize;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.Color.Black;
            this.btnMinimize.Location = new System.Drawing.Point(834, 22);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(33, 30);
            this.btnMinimize.TabIndex = 5;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // tbcPage
            // 
            this.tbcPage.Controls.Add(this.tbpOne);
            this.tbcPage.Controls.Add(this.tbpTwo);
            this.tbcPage.Controls.Add(this.tbpThree);
            this.tbcPage.Location = new System.Drawing.Point(239, 66);
            this.tbcPage.Name = "tbcPage";
            this.tbcPage.Padding = new System.Drawing.Point(0, 0);
            this.tbcPage.SelectedIndex = 0;
            this.tbcPage.Size = new System.Drawing.Size(654, 360);
            this.tbcPage.TabIndex = 6;
            // 
            // tbpOne
            // 
            this.tbpOne.BackColor = System.Drawing.Color.Black;
            this.tbpOne.BackgroundImage = global::Polakken.Properties.Resources.insideTab2;
            this.tbpOne.Controls.Add(this.chkSetTol);
            this.tbpOne.Controls.Add(this.txtAlarm);
            this.tbpOne.Controls.Add(this.txtInt);
            this.tbpOne.Controls.Add(this.txtSetPoint);
            this.tbpOne.Controls.Add(this.btnSaveAll);
            this.tbpOne.Controls.Add(this.label4);
            this.tbpOne.Controls.Add(this.btnAlarmDown);
            this.tbpOne.Controls.Add(this.btnAlarmUp);
            this.tbpOne.Controls.Add(this.label3);
            this.tbpOne.Controls.Add(this.btnMesIDown);
            this.tbpOne.Controls.Add(this.btnMesIUp);
            this.tbpOne.Controls.Add(this.txtTol);
            this.tbpOne.Controls.Add(this.lblTol);
            this.tbpOne.Controls.Add(this.btnToleranceDown);
            this.tbpOne.Controls.Add(this.btnToleranceUp);
            this.tbpOne.Controls.Add(this.lblSet);
            this.tbpOne.Controls.Add(this.btnSetPointDown);
            this.tbpOne.Controls.Add(this.btnSetPointUp);
            this.tbpOne.Location = new System.Drawing.Point(4, 22);
            this.tbpOne.Name = "tbpOne";
            this.tbpOne.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOne.Size = new System.Drawing.Size(646, 334);
            this.tbpOne.TabIndex = 0;
            this.tbpOne.Text = "Instillinger";
            // 
            // chkSetTol
            // 
            this.chkSetTol.AutoSize = true;
            this.chkSetTol.Location = new System.Drawing.Point(12, 63);
            this.chkSetTol.Name = "chkSetTol";
            this.chkSetTol.Size = new System.Drawing.Size(15, 14);
            this.chkSetTol.TabIndex = 29;
            this.chkSetTol.UseVisualStyleBackColor = true;
            this.chkSetTol.CheckedChanged += new System.EventHandler(this.chkSetTol_CheckedChanged);
            // 
            // txtAlarm
            // 
            this.txtAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtAlarm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlarm.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtAlarm.Location = new System.Drawing.Point(523, 143);
            this.txtAlarm.Name = "txtAlarm";
            this.txtAlarm.ReadOnly = true;
            this.txtAlarm.Size = new System.Drawing.Size(71, 22);
            this.txtAlarm.TabIndex = 28;
            this.txtAlarm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInt
            // 
            this.txtInt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtInt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInt.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtInt.Location = new System.Drawing.Point(370, 143);
            this.txtInt.Name = "txtInt";
            this.txtInt.ReadOnly = true;
            this.txtInt.Size = new System.Drawing.Size(71, 22);
            this.txtInt.TabIndex = 27;
            this.txtInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSetPoint
            // 
            this.txtSetPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtSetPoint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSetPoint.Enabled = false;
            this.txtSetPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetPoint.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtSetPoint.Location = new System.Drawing.Point(12, 143);
            this.txtSetPoint.Name = "txtSetPoint";
            this.txtSetPoint.ReadOnly = true;
            this.txtSetPoint.Size = new System.Drawing.Size(71, 22);
            this.txtSetPoint.TabIndex = 9;
            this.txtSetPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaveAll.BackgroundImage")));
            this.btnSaveAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSaveAll.FlatAppearance.BorderSize = 0;
            this.btnSaveAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSaveAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAll.Location = new System.Drawing.Point(276, 245);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(80, 32);
            this.btnSaveAll.TabIndex = 25;
            this.btnSaveAll.UseVisualStyleBackColor = false;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            this.btnSaveAll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSaveAll_MouseDown);
            this.btnSaveAll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSaveAll_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(520, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Alarmgrense";
            // 
            // btnAlarmDown
            // 
            this.btnAlarmDown.BackColor = System.Drawing.Color.Transparent;
            this.btnAlarmDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAlarmDown.BackgroundImage")));
            this.btnAlarmDown.FlatAppearance.BorderSize = 0;
            this.btnAlarmDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAlarmDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAlarmDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlarmDown.Location = new System.Drawing.Point(605, 169);
            this.btnAlarmDown.Name = "btnAlarmDown";
            this.btnAlarmDown.Size = new System.Drawing.Size(30, 30);
            this.btnAlarmDown.TabIndex = 23;
            this.btnAlarmDown.UseVisualStyleBackColor = false;
            this.btnAlarmDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAlarmDown_MouseDown);
            this.btnAlarmDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAlarmDown_MouseUp);
            // 
            // btnAlarmUp
            // 
            this.btnAlarmUp.BackColor = System.Drawing.Color.Transparent;
            this.btnAlarmUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAlarmUp.BackgroundImage")));
            this.btnAlarmUp.FlatAppearance.BorderSize = 0;
            this.btnAlarmUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAlarmUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAlarmUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlarmUp.Location = new System.Drawing.Point(605, 123);
            this.btnAlarmUp.Name = "btnAlarmUp";
            this.btnAlarmUp.Size = new System.Drawing.Size(30, 30);
            this.btnAlarmUp.TabIndex = 22;
            this.btnAlarmUp.UseVisualStyleBackColor = false;
            this.btnAlarmUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAlarmUp_MouseDown);
            this.btnAlarmUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAlarmUp_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(367, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Måleintervall";
            // 
            // btnMesIDown
            // 
            this.btnMesIDown.BackColor = System.Drawing.Color.Transparent;
            this.btnMesIDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMesIDown.BackgroundImage")));
            this.btnMesIDown.FlatAppearance.BorderSize = 0;
            this.btnMesIDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMesIDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMesIDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMesIDown.Location = new System.Drawing.Point(452, 167);
            this.btnMesIDown.Name = "btnMesIDown";
            this.btnMesIDown.Size = new System.Drawing.Size(30, 30);
            this.btnMesIDown.TabIndex = 19;
            this.btnMesIDown.UseVisualStyleBackColor = false;
            this.btnMesIDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMesIDown_MouseDown);
            this.btnMesIDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMesIDown_MouseUp);
            // 
            // btnMesIUp
            // 
            this.btnMesIUp.BackColor = System.Drawing.Color.Transparent;
            this.btnMesIUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMesIUp.BackgroundImage")));
            this.btnMesIUp.FlatAppearance.BorderSize = 0;
            this.btnMesIUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMesIUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMesIUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMesIUp.Location = new System.Drawing.Point(452, 121);
            this.btnMesIUp.Name = "btnMesIUp";
            this.btnMesIUp.Size = new System.Drawing.Size(30, 30);
            this.btnMesIUp.TabIndex = 18;
            this.btnMesIUp.UseVisualStyleBackColor = false;
            this.btnMesIUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMesIUp_MouseDown);
            this.btnMesIUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMesIUp_MouseUp);
            // 
            // txtTol
            // 
            this.txtTol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtTol.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTol.Enabled = false;
            this.txtTol.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTol.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtTol.Location = new System.Drawing.Point(182, 143);
            this.txtTol.Name = "txtTol";
            this.txtTol.ReadOnly = true;
            this.txtTol.Size = new System.Drawing.Size(71, 22);
            this.txtTol.TabIndex = 26;
            this.txtTol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTol
            // 
            this.lblTol.AutoSize = true;
            this.lblTol.BackColor = System.Drawing.Color.Transparent;
            this.lblTol.Enabled = false;
            this.lblTol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTol.ForeColor = System.Drawing.Color.White;
            this.lblTol.Location = new System.Drawing.Point(179, 105);
            this.lblTol.Name = "lblTol";
            this.lblTol.Size = new System.Drawing.Size(70, 16);
            this.lblTol.TabIndex = 16;
            this.lblTol.Text = "Toleranse";
            // 
            // btnToleranceDown
            // 
            this.btnToleranceDown.BackColor = System.Drawing.Color.Transparent;
            this.btnToleranceDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnToleranceDown.BackgroundImage")));
            this.btnToleranceDown.Enabled = false;
            this.btnToleranceDown.FlatAppearance.BorderSize = 0;
            this.btnToleranceDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnToleranceDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnToleranceDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToleranceDown.Location = new System.Drawing.Point(264, 167);
            this.btnToleranceDown.Name = "btnToleranceDown";
            this.btnToleranceDown.Size = new System.Drawing.Size(30, 30);
            this.btnToleranceDown.TabIndex = 15;
            this.btnToleranceDown.UseVisualStyleBackColor = false;
            this.btnToleranceDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnToleranceDown_MouseDown);
            this.btnToleranceDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnToleranceDown_MouseUp);
            // 
            // btnToleranceUp
            // 
            this.btnToleranceUp.BackColor = System.Drawing.Color.Transparent;
            this.btnToleranceUp.BackgroundImage = global::Polakken.Properties.Resources.arrowUp;
            this.btnToleranceUp.Enabled = false;
            this.btnToleranceUp.FlatAppearance.BorderSize = 0;
            this.btnToleranceUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnToleranceUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnToleranceUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToleranceUp.Location = new System.Drawing.Point(264, 121);
            this.btnToleranceUp.Name = "btnToleranceUp";
            this.btnToleranceUp.Size = new System.Drawing.Size(30, 30);
            this.btnToleranceUp.TabIndex = 14;
            this.btnToleranceUp.UseVisualStyleBackColor = false;
            this.btnToleranceUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnToleranceUp_MouseDown);
            this.btnToleranceUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnToleranceUp_MouseUp);
            // 
            // lblSet
            // 
            this.lblSet.AutoSize = true;
            this.lblSet.BackColor = System.Drawing.Color.Transparent;
            this.lblSet.Enabled = false;
            this.lblSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSet.ForeColor = System.Drawing.Color.White;
            this.lblSet.Location = new System.Drawing.Point(9, 104);
            this.lblSet.Name = "lblSet";
            this.lblSet.Size = new System.Drawing.Size(60, 16);
            this.lblSet.TabIndex = 12;
            this.lblSet.Text = "Setpunkt";
            // 
            // btnSetPointDown
            // 
            this.btnSetPointDown.BackColor = System.Drawing.Color.Transparent;
            this.btnSetPointDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetPointDown.BackgroundImage")));
            this.btnSetPointDown.Enabled = false;
            this.btnSetPointDown.FlatAppearance.BorderSize = 0;
            this.btnSetPointDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSetPointDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSetPointDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetPointDown.Location = new System.Drawing.Point(94, 166);
            this.btnSetPointDown.Name = "btnSetPointDown";
            this.btnSetPointDown.Size = new System.Drawing.Size(30, 30);
            this.btnSetPointDown.TabIndex = 5;
            this.btnSetPointDown.UseVisualStyleBackColor = false;
            this.btnSetPointDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSetPointDown_MouseDown);
            this.btnSetPointDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSetPointDown_MouseUp);
            // 
            // btnSetPointUp
            // 
            this.btnSetPointUp.BackColor = System.Drawing.Color.Transparent;
            this.btnSetPointUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetPointUp.BackgroundImage")));
            this.btnSetPointUp.Enabled = false;
            this.btnSetPointUp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSetPointUp.FlatAppearance.BorderSize = 0;
            this.btnSetPointUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSetPointUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSetPointUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetPointUp.Location = new System.Drawing.Point(94, 120);
            this.btnSetPointUp.Name = "btnSetPointUp";
            this.btnSetPointUp.Size = new System.Drawing.Size(30, 30);
            this.btnSetPointUp.TabIndex = 4;
            this.btnSetPointUp.UseVisualStyleBackColor = false;
            this.btnSetPointUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSetPointUp_MouseDown);
            this.btnSetPointUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSetPointUp_MouseUp);
            // 
            // tbpTwo
            // 
            this.tbpTwo.BackgroundImage = global::Polakken.Properties.Resources.insideTab2;
            this.tbpTwo.Controls.Add(this.label5);
            this.tbpTwo.Controls.Add(this.label2);
            this.tbpTwo.Controls.Add(this.lblDelType);
            this.tbpTwo.Controls.Add(this.cboSelectDelete);
            this.tbpTwo.Controls.Add(this.dtpSelectToTime);
            this.tbpTwo.Controls.Add(this.dtpSelectFromTime);
            this.tbpTwo.Controls.Add(this.dtpDelToTime);
            this.tbpTwo.Controls.Add(this.dtpDelFromTime);
            this.tbpTwo.Controls.Add(this.btnDelReading);
            this.tbpTwo.Controls.Add(this.dtpDelTo);
            this.tbpTwo.Controls.Add(this.dtpDelFrom);
            this.tbpTwo.Controls.Add(this.chkFilterDate);
            this.tbpTwo.Controls.Add(this.chkFilterTemp);
            this.tbpTwo.Controls.Add(this.chkFilterStatus);
            this.tbpTwo.Controls.Add(this.btnReset);
            this.tbpTwo.Controls.Add(this.cboEqualsFilter);
            this.tbpTwo.Controls.Add(this.cboFilterTemp);
            this.tbpTwo.Controls.Add(this.cboFilterStatus);
            this.tbpTwo.Controls.Add(this.btnShowSelected);
            this.tbpTwo.Controls.Add(this.dtpSelectTo);
            this.tbpTwo.Controls.Add(this.dtpSelectFrom);
            this.tbpTwo.Controls.Add(this.dgvDataBase);
            this.tbpTwo.Location = new System.Drawing.Point(4, 22);
            this.tbpTwo.Name = "tbpTwo";
            this.tbpTwo.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTwo.Size = new System.Drawing.Size(646, 334);
            this.tbpTwo.TabIndex = 1;
            this.tbpTwo.Text = "Tabelloversikt";
            this.tbpTwo.UseVisualStyleBackColor = true;
            this.tbpTwo.Click += new System.EventHandler(this.tbpTwo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(21, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Filrering";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(36, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 20;
            // 
            // lblDelType
            // 
            this.lblDelType.AutoSize = true;
            this.lblDelType.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDelType.Location = new System.Drawing.Point(66, 33);
            this.lblDelType.Name = "lblDelType";
            this.lblDelType.Size = new System.Drawing.Size(93, 13);
            this.lblDelType.TabIndex = 19;
            this.lblDelType.Text = "Velg Slettemetode";
            // 
            // cboSelectDelete
            // 
            this.cboSelectDelete.AccessibleName = "";
            this.cboSelectDelete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSelectDelete.FormattingEnabled = true;
            this.cboSelectDelete.Items.AddRange(new object[] {
            "Slett alt",
            "Slett siste 30 dager",
            "Slett i egendefinert tidsrom",
            "Slett en egendefinert Oppføring."});
            this.cboSelectDelete.Location = new System.Drawing.Point(165, 30);
            this.cboSelectDelete.Name = "cboSelectDelete";
            this.cboSelectDelete.Size = new System.Drawing.Size(168, 21);
            this.cboSelectDelete.TabIndex = 18;
            this.cboSelectDelete.SelectedIndexChanged += new System.EventHandler(this.cboSelectDelete_SelectedIndexChanged);
            // 
            // dtpSelectToTime
            // 
            this.dtpSelectToTime.Enabled = false;
            this.dtpSelectToTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSelectToTime.Location = new System.Drawing.Point(134, 211);
            this.dtpSelectToTime.MaxDate = new System.DateTime(2113, 3, 14, 0, 0, 0, 0);
            this.dtpSelectToTime.MinDate = new System.DateTime(2013, 3, 11, 0, 0, 0, 0);
            this.dtpSelectToTime.Name = "dtpSelectToTime";
            this.dtpSelectToTime.Size = new System.Drawing.Size(73, 20);
            this.dtpSelectToTime.TabIndex = 17;
            this.dtpSelectToTime.Value = new System.DateTime(2013, 3, 14, 0, 0, 0, 0);
            // 
            // dtpSelectFromTime
            // 
            this.dtpSelectFromTime.Enabled = false;
            this.dtpSelectFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSelectFromTime.Location = new System.Drawing.Point(39, 211);
            this.dtpSelectFromTime.MaxDate = new System.DateTime(2113, 3, 14, 0, 0, 0, 0);
            this.dtpSelectFromTime.MinDate = new System.DateTime(2013, 3, 11, 0, 0, 0, 0);
            this.dtpSelectFromTime.Name = "dtpSelectFromTime";
            this.dtpSelectFromTime.Size = new System.Drawing.Size(73, 20);
            this.dtpSelectFromTime.TabIndex = 16;
            this.dtpSelectFromTime.Value = new System.DateTime(2013, 3, 14, 0, 0, 0, 0);
            // 
            // dtpDelToTime
            // 
            this.dtpDelToTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDelToTime.Location = new System.Drawing.Point(260, 90);
            this.dtpDelToTime.MaxDate = new System.DateTime(2113, 3, 8, 0, 0, 0, 0);
            this.dtpDelToTime.MinDate = new System.DateTime(2013, 3, 11, 0, 0, 0, 0);
            this.dtpDelToTime.Name = "dtpDelToTime";
            this.dtpDelToTime.Size = new System.Drawing.Size(73, 20);
            this.dtpDelToTime.TabIndex = 15;
            this.dtpDelToTime.Value = new System.DateTime(2013, 4, 7, 0, 0, 0, 0);
            // 
            // dtpDelFromTime
            // 
            this.dtpDelFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDelFromTime.Location = new System.Drawing.Point(165, 88);
            this.dtpDelFromTime.MaxDate = new System.DateTime(2113, 3, 8, 0, 0, 0, 0);
            this.dtpDelFromTime.MinDate = new System.DateTime(2013, 3, 11, 0, 0, 0, 0);
            this.dtpDelFromTime.Name = "dtpDelFromTime";
            this.dtpDelFromTime.Size = new System.Drawing.Size(73, 20);
            this.dtpDelFromTime.TabIndex = 14;
            this.dtpDelFromTime.Value = new System.DateTime(2013, 4, 7, 0, 0, 0, 0);
            // 
            // btnDelReading
            // 
            this.btnDelReading.Location = new System.Drawing.Point(163, 112);
            this.btnDelReading.Name = "btnDelReading";
            this.btnDelReading.Size = new System.Drawing.Size(75, 23);
            this.btnDelReading.TabIndex = 13;
            this.btnDelReading.Text = "button1";
            this.btnDelReading.UseVisualStyleBackColor = true;
            this.btnDelReading.Click += new System.EventHandler(this.btnDelReading_Click);
            // 
            // dtpDelTo
            // 
            this.dtpDelTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDelTo.Location = new System.Drawing.Point(260, 62);
            this.dtpDelTo.MaxDate = new System.DateTime(2113, 3, 14, 0, 0, 0, 0);
            this.dtpDelTo.MinDate = new System.DateTime(2013, 3, 11, 0, 0, 0, 0);
            this.dtpDelTo.Name = "dtpDelTo";
            this.dtpDelTo.Size = new System.Drawing.Size(73, 20);
            this.dtpDelTo.TabIndex = 12;
            this.dtpDelTo.Value = new System.DateTime(2013, 4, 9, 0, 0, 0, 0);
            // 
            // dtpDelFrom
            // 
            this.dtpDelFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDelFrom.Location = new System.Drawing.Point(165, 62);
            this.dtpDelFrom.MaxDate = new System.DateTime(2113, 3, 8, 0, 0, 0, 0);
            this.dtpDelFrom.MinDate = new System.DateTime(2013, 3, 11, 0, 0, 0, 0);
            this.dtpDelFrom.Name = "dtpDelFrom";
            this.dtpDelFrom.Size = new System.Drawing.Size(73, 20);
            this.dtpDelFrom.TabIndex = 11;
            this.dtpDelFrom.Value = new System.DateTime(2013, 4, 7, 0, 0, 0, 0);
            // 
            // chkFilterDate
            // 
            this.chkFilterDate.AutoSize = true;
            this.chkFilterDate.Location = new System.Drawing.Point(20, 166);
            this.chkFilterDate.Name = "chkFilterDate";
            this.chkFilterDate.Size = new System.Drawing.Size(15, 14);
            this.chkFilterDate.TabIndex = 10;
            this.chkFilterDate.UseVisualStyleBackColor = true;
            this.chkFilterDate.CheckedChanged += new System.EventHandler(this.chkFilterDate_CheckedChanged);
            // 
            // chkFilterTemp
            // 
            this.chkFilterTemp.AutoSize = true;
            this.chkFilterTemp.Location = new System.Drawing.Point(115, 256);
            this.chkFilterTemp.Name = "chkFilterTemp";
            this.chkFilterTemp.Size = new System.Drawing.Size(15, 14);
            this.chkFilterTemp.TabIndex = 9;
            this.chkFilterTemp.UseVisualStyleBackColor = true;
            this.chkFilterTemp.CheckedChanged += new System.EventHandler(this.chkFilterTemp_CheckedChanged);
            // 
            // chkFilterStatus
            // 
            this.chkFilterStatus.AutoSize = true;
            this.chkFilterStatus.Location = new System.Drawing.Point(20, 257);
            this.chkFilterStatus.Name = "chkFilterStatus";
            this.chkFilterStatus.Size = new System.Drawing.Size(15, 14);
            this.chkFilterStatus.TabIndex = 8;
            this.chkFilterStatus.UseVisualStyleBackColor = true;
            this.chkFilterStatus.CheckedChanged += new System.EventHandler(this.chkFilterStatus_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(101, 303);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Nullstill Filter";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cboEqualsFilter
            // 
            this.cboEqualsFilter.Enabled = false;
            this.cboEqualsFilter.FormattingEnabled = true;
            this.cboEqualsFilter.Location = new System.Drawing.Point(134, 276);
            this.cboEqualsFilter.Name = "cboEqualsFilter";
            this.cboEqualsFilter.Size = new System.Drawing.Size(88, 21);
            this.cboEqualsFilter.TabIndex = 6;
            // 
            // cboFilterTemp
            // 
            this.cboFilterTemp.Enabled = false;
            this.cboFilterTemp.FormattingEnabled = true;
            this.cboFilterTemp.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25"});
            this.cboFilterTemp.Location = new System.Drawing.Point(243, 276);
            this.cboFilterTemp.Name = "cboFilterTemp";
            this.cboFilterTemp.Size = new System.Drawing.Size(56, 21);
            this.cboFilterTemp.TabIndex = 5;
            // 
            // cboFilterStatus
            // 
            this.cboFilterStatus.Enabled = false;
            this.cboFilterStatus.FormattingEnabled = true;
            this.cboFilterStatus.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cboFilterStatus.Location = new System.Drawing.Point(39, 276);
            this.cboFilterStatus.Name = "cboFilterStatus";
            this.cboFilterStatus.Size = new System.Drawing.Size(56, 21);
            this.cboFilterStatus.TabIndex = 4;
            // 
            // btnShowSelected
            // 
            this.btnShowSelected.Location = new System.Drawing.Point(20, 303);
            this.btnShowSelected.Name = "btnShowSelected";
            this.btnShowSelected.Size = new System.Drawing.Size(75, 23);
            this.btnShowSelected.TabIndex = 3;
            this.btnShowSelected.Text = "Vis Filtrert";
            this.btnShowSelected.UseVisualStyleBackColor = true;
            this.btnShowSelected.Click += new System.EventHandler(this.btnShowSelected_Click);
            // 
            // dtpSelectTo
            // 
            this.dtpSelectTo.Enabled = false;
            this.dtpSelectTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSelectTo.Location = new System.Drawing.Point(134, 185);
            this.dtpSelectTo.MaxDate = new System.DateTime(2113, 3, 14, 0, 0, 0, 0);
            this.dtpSelectTo.MinDate = new System.DateTime(2013, 3, 14, 0, 0, 0, 0);
            this.dtpSelectTo.Name = "dtpSelectTo";
            this.dtpSelectTo.Size = new System.Drawing.Size(73, 20);
            this.dtpSelectTo.TabIndex = 2;
            this.dtpSelectTo.Value = new System.DateTime(2013, 3, 14, 0, 0, 0, 0);
            // 
            // dtpSelectFrom
            // 
            this.dtpSelectFrom.Enabled = false;
            this.dtpSelectFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSelectFrom.Location = new System.Drawing.Point(39, 185);
            this.dtpSelectFrom.MaxDate = new System.DateTime(2113, 3, 14, 0, 0, 0, 0);
            this.dtpSelectFrom.MinDate = new System.DateTime(2013, 3, 11, 0, 0, 0, 0);
            this.dtpSelectFrom.Name = "dtpSelectFrom";
            this.dtpSelectFrom.Size = new System.Drawing.Size(73, 20);
            this.dtpSelectFrom.TabIndex = 1;
            this.dtpSelectFrom.Value = new System.DateTime(2013, 3, 14, 0, 0, 0, 0);
            // 
            // dgvDataBase
            // 
            this.dgvDataBase.BackgroundColor = System.Drawing.Color.White;
            this.dgvDataBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LawnGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataBase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDataBase.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDataBase.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDataBase.GridColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvDataBase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvDataBase.Location = new System.Drawing.Point(358, -1);
            this.dgvDataBase.Name = "dgvDataBase";
            this.dgvDataBase.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataBase.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDataBase.RowHeadersWidth = 20;
            this.dgvDataBase.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDataBase.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDataBase.ShowEditingIcon = false;
            this.dgvDataBase.Size = new System.Drawing.Size(290, 339);
            this.dgvDataBase.TabIndex = 0;
            // 
            // tbpThree
            // 
            this.tbpThree.BackgroundImage = global::Polakken.Properties.Resources.insideTab2;
            this.tbpThree.Controls.Add(this.btnDelEmail);
            this.tbpThree.Controls.Add(this.cboDelEmail);
            this.tbpThree.Controls.Add(this.dgvEmail);
            this.tbpThree.Controls.Add(this.btnAddEmail);
            this.tbpThree.Controls.Add(this.txtAddEmail);
            this.tbpThree.Location = new System.Drawing.Point(4, 22);
            this.tbpThree.Name = "tbpThree";
            this.tbpThree.Size = new System.Drawing.Size(646, 334);
            this.tbpThree.TabIndex = 2;
            this.tbpThree.Text = "Mottaker";
            this.tbpThree.UseVisualStyleBackColor = true;
            // 
            // btnDelEmail
            // 
            this.btnDelEmail.Location = new System.Drawing.Point(271, 162);
            this.btnDelEmail.Name = "btnDelEmail";
            this.btnDelEmail.Size = new System.Drawing.Size(75, 23);
            this.btnDelEmail.TabIndex = 4;
            this.btnDelEmail.Text = "button1";
            this.btnDelEmail.UseVisualStyleBackColor = true;
            this.btnDelEmail.Click += new System.EventHandler(this.btnDelEmail_Click);
            // 
            // cboDelEmail
            // 
            this.cboDelEmail.FormattingEnabled = true;
            this.cboDelEmail.Location = new System.Drawing.Point(238, 135);
            this.cboDelEmail.Name = "cboDelEmail";
            this.cboDelEmail.Size = new System.Drawing.Size(143, 21);
            this.cboDelEmail.TabIndex = 3;
            // 
            // dgvEmail
            // 
            this.dgvEmail.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmail.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEmail.Location = new System.Drawing.Point(436, 0);
            this.dgvEmail.Name = "dgvEmail";
            this.dgvEmail.RowHeadersWidth = 20;
            this.dgvEmail.Size = new System.Drawing.Size(214, 334);
            this.dgvEmail.TabIndex = 2;
            // 
            // btnAddEmail
            // 
            this.btnAddEmail.Location = new System.Drawing.Point(89, 162);
            this.btnAddEmail.Name = "btnAddEmail";
            this.btnAddEmail.Size = new System.Drawing.Size(75, 23);
            this.btnAddEmail.TabIndex = 1;
            this.btnAddEmail.Text = "button1";
            this.btnAddEmail.UseVisualStyleBackColor = true;
            this.btnAddEmail.Click += new System.EventHandler(this.btnAddEmail_Click);
            // 
            // txtAddEmail
            // 
            this.txtAddEmail.Location = new System.Drawing.Point(56, 136);
            this.txtAddEmail.Name = "txtAddEmail";
            this.txtAddEmail.Size = new System.Drawing.Size(143, 20);
            this.txtAddEmail.TabIndex = 0;
            // 
            // btnMove
            // 
            this.btnMove.BackColor = System.Drawing.Color.Transparent;
            this.btnMove.FlatAppearance.BorderSize = 0;
            this.btnMove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMove.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMove.Location = new System.Drawing.Point(17, 22);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(820, 30);
            this.btnMove.TabIndex = 7;
            this.btnMove.UseVisualStyleBackColor = false;
            this.btnMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMove_MouseDown);
            this.btnMove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMove_MouseMove);
            this.btnMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMove_MouseUp);
            // 
            // txtCurrent
            // 
            this.txtCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtCurrent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrent.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtCurrent.Location = new System.Drawing.Point(64, 113);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.ReadOnly = true;
            this.txtCurrent.Size = new System.Drawing.Size(129, 60);
            this.txtCurrent.TabIndex = 66;
            this.txtCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSiste
            // 
            this.lblSiste.AutoSize = true;
            this.lblSiste.BackColor = System.Drawing.Color.Transparent;
            this.lblSiste.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiste.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSiste.Location = new System.Drawing.Point(69, 94);
            this.lblSiste.Name = "lblSiste";
            this.lblSiste.Size = new System.Drawing.Size(118, 16);
            this.lblSiste.TabIndex = 1;
            this.lblSiste.Text = "Siste avlesning";
            // 
            // txtMax
            // 
            this.txtMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMax.ForeColor = System.Drawing.Color.White;
            this.txtMax.Location = new System.Drawing.Point(74, 231);
            this.txtMax.Name = "txtMax";
            this.txtMax.ReadOnly = true;
            this.txtMax.Size = new System.Drawing.Size(107, 42);
            this.txtMax.TabIndex = 3;
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.BackColor = System.Drawing.Color.Transparent;
            this.lblMax.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMax.Location = new System.Drawing.Point(74, 212);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(107, 14);
            this.lblMax.TabIndex = 4;
            this.lblMax.Text = "Max Tempratur";
            // 
            // txtMaxTime
            // 
            this.txtMaxTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtMaxTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxTime.ForeColor = System.Drawing.Color.White;
            this.txtMaxTime.Location = new System.Drawing.Point(64, 281);
            this.txtMaxTime.Multiline = true;
            this.txtMaxTime.Name = "txtMaxTime";
            this.txtMaxTime.ReadOnly = true;
            this.txtMaxTime.Size = new System.Drawing.Size(129, 20);
            this.txtMaxTime.TabIndex = 5;
            this.txtMaxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMin
            // 
            this.txtMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMin.ForeColor = System.Drawing.Color.White;
            this.txtMin.Location = new System.Drawing.Point(74, 319);
            this.txtMin.Name = "txtMin";
            this.txtMin.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(107, 42);
            this.txtMin.TabIndex = 6;
            this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.BackColor = System.Drawing.Color.Transparent;
            this.lblMin.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMin.Location = new System.Drawing.Point(74, 300);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(103, 14);
            this.lblMin.TabIndex = 7;
            this.lblMin.Text = "Min Tempratur";
            // 
            // txtMinTime
            // 
            this.txtMinTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtMinTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMinTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinTime.ForeColor = System.Drawing.Color.White;
            this.txtMinTime.Location = new System.Drawing.Point(64, 369);
            this.txtMinTime.Multiline = true;
            this.txtMinTime.Name = "txtMinTime";
            this.txtMinTime.ReadOnly = true;
            this.txtMinTime.Size = new System.Drawing.Size(129, 20);
            this.txtMinTime.TabIndex = 8;
            this.txtMinTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCurrentTime
            // 
            this.txtCurrentTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtCurrentTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentTime.ForeColor = System.Drawing.Color.White;
            this.txtCurrentTime.Location = new System.Drawing.Point(64, 185);
            this.txtCurrentTime.Multiline = true;
            this.txtCurrentTime.Name = "txtCurrentTime";
            this.txtCurrentTime.ReadOnly = true;
            this.txtCurrentTime.Size = new System.Drawing.Size(129, 20);
            this.txtCurrentTime.TabIndex = 9;
            this.txtCurrentTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.Transparent;
            this.btnLog.BackgroundImage = global::Polakken.Properties.Resources.buttonLogg;
            this.btnLog.FlatAppearance.BorderSize = 0;
            this.btnLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Location = new System.Drawing.Point(87, 391);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(75, 23);
            this.btnLog.TabIndex = 10;
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // tmrUpdateSettings
            // 
            this.tmrUpdateSettings.Interval = 10;
            this.tmrUpdateSettings.Tick += new System.EventHandler(this.tmrUpdateSettings_Tick);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.BackColor = System.Drawing.Color.Transparent;
            this.btnZoomIn.BackgroundImage = global::Polakken.Properties.Resources.Minus;
            this.btnZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZoomIn.FlatAppearance.BorderSize = 0;
            this.btnZoomIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnZoomIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomIn.Location = new System.Drawing.Point(807, 629);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(35, 33);
            this.btnZoomIn.TabIndex = 68;
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.BackColor = System.Drawing.Color.Transparent;
            this.btnZoomOut.BackgroundImage = global::Polakken.Properties.Resources.Plus;
            this.btnZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZoomOut.FlatAppearance.BorderSize = 0;
            this.btnZoomOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnZoomOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomOut.Location = new System.Drawing.Point(834, 628);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(33, 32);
            this.btnZoomOut.TabIndex = 69;
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(709, 637);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 16);
            this.label6.TabIndex = 71;
            this.label6.Text = "Zoom Grafen";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImage = global::Polakken.Properties.Resources.BetaV2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(908, 702);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.txtCurrentTime);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.tbcPage);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnLukk);
            this.Controls.Add(this.txtMinTime);
            this.Controls.Add(this.crtView);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblSiste);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.txtMaxTime);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GUI";
            this.Text = "Polakken";
            this.TransparencyKey = System.Drawing.Color.Silver;
            this.Load += new System.EventHandler(this.GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.crtView)).EndInit();
            this.tbcPage.ResumeLayout(false);
            this.tbpOne.ResumeLayout(false);
            this.tbpOne.PerformLayout();
            this.tbpTwo.ResumeLayout(false);
            this.tbpTwo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataBase)).EndInit();
            this.tbpThree.ResumeLayout(false);
            this.tbpThree.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart crtView;
        private System.Windows.Forms.Button btnLukk;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.TabPage tbpOne;
        private System.Windows.Forms.TabPage tbpTwo;
        private System.Windows.Forms.TabPage tbpThree;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.DataGridView dgvDataBase;
        private System.Windows.Forms.Button btnSetPointUp;
        private System.Windows.Forms.Button btnSetPointDown;
        private System.Windows.Forms.Label lblSet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAlarmDown;
        private System.Windows.Forms.Button btnAlarmUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMesIDown;
        private System.Windows.Forms.Button btnMesIUp;
        private System.Windows.Forms.Label lblTol;
        private System.Windows.Forms.Button btnToleranceDown;
        private System.Windows.Forms.Button btnToleranceUp;

        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.TextBox txtAlarm;
        private System.Windows.Forms.TextBox txtInt;
        private System.Windows.Forms.TextBox txtTol;
        private System.Windows.Forms.TextBox txtSetPoint;
        private System.Windows.Forms.Button btnShowSelected;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.ComboBox cboFilterTemp;
        private System.Windows.Forms.ComboBox cboEqualsFilter;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox chkFilterStatus;
        private System.Windows.Forms.CheckBox chkFilterTemp;
        private System.Windows.Forms.CheckBox chkFilterDate;
        private System.Windows.Forms.DateTimePicker dtpSelectTo;
        private System.Windows.Forms.DateTimePicker dtpSelectFrom;
        private System.Windows.Forms.DataGridView dgvEmail;
        private System.Windows.Forms.Button btnAddEmail;
        private System.Windows.Forms.TextBox txtAddEmail;
        private System.Windows.Forms.ComboBox cboDelEmail;
        private System.Windows.Forms.Button btnDelEmail;
        private System.Windows.Forms.DateTimePicker dtpDelTo;
        private System.Windows.Forms.DateTimePicker dtpDelFrom;
        private System.Windows.Forms.Button btnDelReading;
        private System.Windows.Forms.DateTimePicker dtpDelToTime;
        private System.Windows.Forms.DateTimePicker dtpDelFromTime;
        private System.Windows.Forms.DateTimePicker dtpSelectToTime;
        private System.Windows.Forms.DateTimePicker dtpSelectFromTime;
        private System.Windows.Forms.CheckBox chkSetTol;
        private System.Windows.Forms.ComboBox cboSelectDelete;
        private System.Windows.Forms.Label lblSiste;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.TextBox txtMaxTime;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.TextBox txtMinTime;
        private System.Windows.Forms.TextBox txtCurrentTime;
        private System.Windows.Forms.Button btnLog;
        //private GUI.CustomTabControl tbcPage;
        private System.Windows.Forms.TabControl tbcPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDelType;
        private System.Windows.Forms.Timer tmrUpdateSettings;
        public System.Windows.Forms.TextBox txtCurrent;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;

    


    }
}

