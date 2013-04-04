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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.crtView = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.txtMinTime = new System.Windows.Forms.TextBox();
            this.lblMin = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtMaxTime = new System.Windows.Forms.TextBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.lblSiste = new System.Windows.Forms.Label();
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.btnLukk = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.tbcPage = new System.Windows.Forms.TabControl();
            this.tbpOne = new System.Windows.Forms.TabPage();
            this.txtAlarm = new System.Windows.Forms.TextBox();
            this.txtInt = new System.Windows.Forms.TextBox();
            this.txtTol = new System.Windows.Forms.TextBox();
            this.txtSetPoint = new System.Windows.Forms.TextBox();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAlarmDown = new System.Windows.Forms.Button();
            this.btnAlarmUp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMesIDown = new System.Windows.Forms.Button();
            this.btnMesIUp = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnToleranceDown = new System.Windows.Forms.Button();
            this.btnToleranceUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetPointDown = new System.Windows.Forms.Button();
            this.btnSetPointUp = new System.Windows.Forms.Button();
            this.tbpTwo = new System.Windows.Forms.TabPage();
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
            this.txtCurrentTime = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.crtView)).BeginInit();
            this.grpInfo.SuspendLayout();
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
            this.crtView.Location = new System.Drawing.Point(17, 435);
            this.crtView.Name = "crtView";
            this.crtView.Size = new System.Drawing.Size(884, 226);
            this.crtView.TabIndex = 1;
            // 
            // grpInfo
            // 
            this.grpInfo.BackColor = System.Drawing.Color.Transparent;
            this.grpInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.grpInfo.Controls.Add(this.txtCurrentTime);
            this.grpInfo.Controls.Add(this.txtMinTime);
            this.grpInfo.Controls.Add(this.lblMin);
            this.grpInfo.Controls.Add(this.txtMin);
            this.grpInfo.Controls.Add(this.txtMaxTime);
            this.grpInfo.Controls.Add(this.lblMax);
            this.grpInfo.Controls.Add(this.txtMax);
            this.grpInfo.Controls.Add(this.lblSiste);
            this.grpInfo.Controls.Add(this.txtCurrent);
            this.grpInfo.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInfo.ForeColor = System.Drawing.SystemColors.Control;
            this.grpInfo.Location = new System.Drawing.Point(26, 69);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(207, 360);
            this.grpInfo.TabIndex = 3;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "INFO";
            // 
            // txtMinTime
            // 
            this.txtMinTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtMinTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMinTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinTime.ForeColor = System.Drawing.Color.White;
            this.txtMinTime.Location = new System.Drawing.Point(36, 309);
            this.txtMinTime.Multiline = true;
            this.txtMinTime.Name = "txtMinTime";
            this.txtMinTime.ReadOnly = true;
            this.txtMinTime.Size = new System.Drawing.Size(129, 20);
            this.txtMinTime.TabIndex = 8;
            this.txtMinTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.Location = new System.Drawing.Point(46, 240);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(103, 14);
            this.lblMin.TabIndex = 7;
            this.lblMin.Text = "Min Tempratur";
            // 
            // txtMin
            // 
            this.txtMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMin.ForeColor = System.Drawing.Color.White;
            this.txtMin.Location = new System.Drawing.Point(46, 259);
            this.txtMin.Name = "txtMin";
            this.txtMin.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(107, 42);
            this.txtMin.TabIndex = 6;
            this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMaxTime
            // 
            this.txtMaxTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtMaxTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxTime.ForeColor = System.Drawing.Color.White;
            this.txtMaxTime.Location = new System.Drawing.Point(36, 221);
            this.txtMaxTime.Multiline = true;
            this.txtMaxTime.Name = "txtMaxTime";
            this.txtMaxTime.ReadOnly = true;
            this.txtMaxTime.Size = new System.Drawing.Size(129, 20);
            this.txtMaxTime.TabIndex = 5;
            this.txtMaxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.Location = new System.Drawing.Point(46, 152);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(107, 14);
            this.lblMax.TabIndex = 4;
            this.lblMax.Text = "Max Tempratur";
            // 
            // txtMax
            // 
            this.txtMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMax.ForeColor = System.Drawing.Color.White;
            this.txtMax.Location = new System.Drawing.Point(46, 171);
            this.txtMax.Name = "txtMax";
            this.txtMax.ReadOnly = true;
            this.txtMax.Size = new System.Drawing.Size(107, 42);
            this.txtMax.TabIndex = 3;
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSiste
            // 
            this.lblSiste.AutoSize = true;
            this.lblSiste.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiste.Location = new System.Drawing.Point(41, 34);
            this.lblSiste.Name = "lblSiste";
            this.lblSiste.Size = new System.Drawing.Size(118, 16);
            this.lblSiste.TabIndex = 1;
            this.lblSiste.Text = "Siste avlesning";
            // 
            // txtCurrent
            // 
            this.txtCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtCurrent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrent.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtCurrent.Location = new System.Drawing.Point(36, 53);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.ReadOnly = true;
            this.txtCurrent.Size = new System.Drawing.Size(129, 60);
            this.txtCurrent.TabIndex = 0;
            this.txtCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.tbcPage.Location = new System.Drawing.Point(239, 69);
            this.tbcPage.Name = "tbcPage";
            this.tbcPage.SelectedIndex = 0;
            this.tbcPage.Size = new System.Drawing.Size(654, 360);
            this.tbcPage.TabIndex = 6;
            // 
            // tbpOne
            // 
            this.tbpOne.BackgroundImage = global::Polakken.Properties.Resources.tableView1;
            this.tbpOne.Controls.Add(this.txtAlarm);
            this.tbpOne.Controls.Add(this.txtInt);
            this.tbpOne.Controls.Add(this.txtTol);
            this.tbpOne.Controls.Add(this.txtSetPoint);
            this.tbpOne.Controls.Add(this.btnSaveAll);
            this.tbpOne.Controls.Add(this.label4);
            this.tbpOne.Controls.Add(this.btnAlarmDown);
            this.tbpOne.Controls.Add(this.btnAlarmUp);
            this.tbpOne.Controls.Add(this.label3);
            this.tbpOne.Controls.Add(this.btnMesIDown);
            this.tbpOne.Controls.Add(this.btnMesIUp);
            this.tbpOne.Controls.Add(this.label2);
            this.tbpOne.Controls.Add(this.btnToleranceDown);
            this.tbpOne.Controls.Add(this.btnToleranceUp);
            this.tbpOne.Controls.Add(this.label1);
            this.tbpOne.Controls.Add(this.btnSetPointDown);
            this.tbpOne.Controls.Add(this.btnSetPointUp);
            this.tbpOne.Location = new System.Drawing.Point(4, 22);
            this.tbpOne.Name = "tbpOne";
            this.tbpOne.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOne.Size = new System.Drawing.Size(646, 334);
            this.tbpOne.TabIndex = 0;
            this.tbpOne.Text = "Instillinger";
            this.tbpOne.UseVisualStyleBackColor = true;
            // 
            // txtAlarm
            // 
            this.txtAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtAlarm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlarm.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtAlarm.Location = new System.Drawing.Point(514, 94);
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
            this.txtInt.Location = new System.Drawing.Point(361, 94);
            this.txtInt.Name = "txtInt";
            this.txtInt.ReadOnly = true;
            this.txtInt.Size = new System.Drawing.Size(71, 22);
            this.txtInt.TabIndex = 27;
            this.txtInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTol
            // 
            this.txtTol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtTol.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTol.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTol.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtTol.Location = new System.Drawing.Point(189, 94);
            this.txtTol.Name = "txtTol";
            this.txtTol.ReadOnly = true;
            this.txtTol.Size = new System.Drawing.Size(71, 22);
            this.txtTol.TabIndex = 26;
            this.txtTol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSetPoint
            // 
            this.txtSetPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtSetPoint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSetPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetPoint.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtSetPoint.Location = new System.Drawing.Point(19, 94);
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
            this.btnSaveAll.Location = new System.Drawing.Point(19, 169);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(80, 32);
            this.btnSaveAll.TabIndex = 25;
            this.btnSaveAll.UseVisualStyleBackColor = false;
            this.btnSaveAll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSaveAll_MouseDown);
            this.btnSaveAll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSaveAll_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(511, 58);
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
            this.btnAlarmDown.Location = new System.Drawing.Point(596, 120);
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
            this.btnAlarmUp.Location = new System.Drawing.Point(596, 74);
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
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(358, 56);
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
            this.btnMesIDown.Location = new System.Drawing.Point(443, 118);
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
            this.btnMesIUp.Location = new System.Drawing.Point(443, 72);
            this.btnMesIUp.Name = "btnMesIUp";
            this.btnMesIUp.Size = new System.Drawing.Size(30, 30);
            this.btnMesIUp.TabIndex = 18;
            this.btnMesIUp.UseVisualStyleBackColor = false;
            this.btnMesIUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMesIUp_MouseDown);
            this.btnMesIUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMesIUp_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(186, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Toleranse";
            // 
            // btnToleranceDown
            // 
            this.btnToleranceDown.BackColor = System.Drawing.Color.Transparent;
            this.btnToleranceDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnToleranceDown.BackgroundImage")));
            this.btnToleranceDown.FlatAppearance.BorderSize = 0;
            this.btnToleranceDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnToleranceDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnToleranceDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToleranceDown.Location = new System.Drawing.Point(271, 118);
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
            this.btnToleranceUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnToleranceUp.BackgroundImage")));
            this.btnToleranceUp.FlatAppearance.BorderSize = 0;
            this.btnToleranceUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnToleranceUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnToleranceUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToleranceUp.Location = new System.Drawing.Point(271, 72);
            this.btnToleranceUp.Name = "btnToleranceUp";
            this.btnToleranceUp.Size = new System.Drawing.Size(30, 30);
            this.btnToleranceUp.TabIndex = 14;
            this.btnToleranceUp.UseVisualStyleBackColor = false;
            this.btnToleranceUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnToleranceUp_MouseDown);
            this.btnToleranceUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnToleranceUp_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Setpunkt";
            // 
            // btnSetPointDown
            // 
            this.btnSetPointDown.BackColor = System.Drawing.Color.Transparent;
            this.btnSetPointDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetPointDown.BackgroundImage")));
            this.btnSetPointDown.FlatAppearance.BorderSize = 0;
            this.btnSetPointDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSetPointDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSetPointDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetPointDown.Location = new System.Drawing.Point(101, 117);
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
            this.btnSetPointUp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSetPointUp.FlatAppearance.BorderSize = 0;
            this.btnSetPointUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSetPointUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSetPointUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetPointUp.Location = new System.Drawing.Point(101, 71);
            this.btnSetPointUp.Name = "btnSetPointUp";
            this.btnSetPointUp.Size = new System.Drawing.Size(30, 30);
            this.btnSetPointUp.TabIndex = 4;
            this.btnSetPointUp.UseVisualStyleBackColor = false;
            this.btnSetPointUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSetPointUp_MouseDown);
            this.btnSetPointUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSetPointUp_MouseUp);
            // 
            // tbpTwo
            // 
            this.tbpTwo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbpTwo.BackgroundImage")));
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
            // 
            // btnDelReading
            // 
            this.btnDelReading.Location = new System.Drawing.Point(22, 68);
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
            this.dtpDelTo.Location = new System.Drawing.Point(116, 43);
            this.dtpDelTo.MaxDate = new System.DateTime(2113, 3, 14, 0, 0, 0, 0);
            this.dtpDelTo.MinDate = new System.DateTime(2013, 3, 11, 0, 0, 0, 0);
            this.dtpDelTo.Name = "dtpDelTo";
            this.dtpDelTo.Size = new System.Drawing.Size(73, 20);
            this.dtpDelTo.TabIndex = 12;
            this.dtpDelTo.Value = new System.DateTime(2013, 3, 14, 0, 0, 0, 0);
            // 
            // dtpDelFrom
            // 
            this.dtpDelFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDelFrom.Location = new System.Drawing.Point(24, 43);
            this.dtpDelFrom.MaxDate = new System.DateTime(2113, 3, 8, 0, 0, 0, 0);
            this.dtpDelFrom.MinDate = new System.DateTime(2013, 3, 11, 0, 0, 0, 0);
            this.dtpDelFrom.Name = "dtpDelFrom";
            this.dtpDelFrom.Size = new System.Drawing.Size(73, 20);
            this.dtpDelFrom.TabIndex = 11;
            this.dtpDelFrom.Value = new System.DateTime(2013, 3, 14, 0, 0, 0, 0);
            // 
            // chkFilterDate
            // 
            this.chkFilterDate.AutoSize = true;
            this.chkFilterDate.Location = new System.Drawing.Point(5, 192);
            this.chkFilterDate.Name = "chkFilterDate";
            this.chkFilterDate.Size = new System.Drawing.Size(15, 14);
            this.chkFilterDate.TabIndex = 10;
            this.chkFilterDate.UseVisualStyleBackColor = true;
            this.chkFilterDate.CheckedChanged += new System.EventHandler(this.chkFilterDate_CheckedChanged);
            // 
            // chkFilterTemp
            // 
            this.chkFilterTemp.AutoSize = true;
            this.chkFilterTemp.Location = new System.Drawing.Point(97, 238);
            this.chkFilterTemp.Name = "chkFilterTemp";
            this.chkFilterTemp.Size = new System.Drawing.Size(15, 14);
            this.chkFilterTemp.TabIndex = 9;
            this.chkFilterTemp.UseVisualStyleBackColor = true;
            this.chkFilterTemp.CheckedChanged += new System.EventHandler(this.chkFilterTemp_CheckedChanged);
            // 
            // chkFilterStatus
            // 
            this.chkFilterStatus.AutoSize = true;
            this.chkFilterStatus.Location = new System.Drawing.Point(5, 239);
            this.chkFilterStatus.Name = "chkFilterStatus";
            this.chkFilterStatus.Size = new System.Drawing.Size(15, 14);
            this.chkFilterStatus.TabIndex = 8;
            this.chkFilterStatus.UseVisualStyleBackColor = true;
            this.chkFilterStatus.CheckedChanged += new System.EventHandler(this.chkFilterStatus_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(86, 300);
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
            this.cboEqualsFilter.Location = new System.Drawing.Point(116, 258);
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
            this.cboFilterTemp.Location = new System.Drawing.Point(225, 258);
            this.cboFilterTemp.Name = "cboFilterTemp";
            this.cboFilterTemp.Size = new System.Drawing.Size(56, 21);
            this.cboFilterTemp.TabIndex = 5;
            // 
            // cboFilterStatus
            // 
            this.cboFilterStatus.Enabled = false;
            this.cboFilterStatus.FormattingEnabled = true;
            this.cboFilterStatus.Location = new System.Drawing.Point(24, 258);
            this.cboFilterStatus.Name = "cboFilterStatus";
            this.cboFilterStatus.Size = new System.Drawing.Size(56, 21);
            this.cboFilterStatus.TabIndex = 4;
            // 
            // btnShowSelected
            // 
            this.btnShowSelected.Location = new System.Drawing.Point(5, 300);
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
            this.dtpSelectTo.Location = new System.Drawing.Point(116, 211);
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
            this.dtpSelectFrom.Location = new System.Drawing.Point(24, 211);
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
            this.tbpThree.BackgroundImage = global::Polakken.Properties.Resources.tableView1;
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
            this.btnDelEmail.Location = new System.Drawing.Point(34, 218);
            this.btnDelEmail.Name = "btnDelEmail";
            this.btnDelEmail.Size = new System.Drawing.Size(75, 23);
            this.btnDelEmail.TabIndex = 4;
            this.btnDelEmail.Text = "button1";
            this.btnDelEmail.UseVisualStyleBackColor = true;
            // 
            // cboDelEmail
            // 
            this.cboDelEmail.FormattingEnabled = true;
            this.cboDelEmail.Location = new System.Drawing.Point(34, 165);
            this.cboDelEmail.Name = "cboDelEmail";
            this.cboDelEmail.Size = new System.Drawing.Size(121, 21);
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
            this.btnAddEmail.Location = new System.Drawing.Point(34, 89);
            this.btnAddEmail.Name = "btnAddEmail";
            this.btnAddEmail.Size = new System.Drawing.Size(75, 23);
            this.btnAddEmail.TabIndex = 1;
            this.btnAddEmail.Text = "button1";
            this.btnAddEmail.UseVisualStyleBackColor = true;
            this.btnAddEmail.Click += new System.EventHandler(this.btnAddEmail_Click);
            // 
            // txtAddEmail
            // 
            this.txtAddEmail.Location = new System.Drawing.Point(34, 63);
            this.txtAddEmail.Name = "txtAddEmail";
            this.txtAddEmail.Size = new System.Drawing.Size(100, 20);
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
            // txtCurrentTime
            // 
            this.txtCurrentTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtCurrentTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentTime.ForeColor = System.Drawing.Color.White;
            this.txtCurrentTime.Location = new System.Drawing.Point(36, 119);
            this.txtCurrentTime.Multiline = true;
            this.txtCurrentTime.Name = "txtCurrentTime";
            this.txtCurrentTime.ReadOnly = true;
            this.txtCurrentTime.Size = new System.Drawing.Size(129, 20);
            this.txtCurrentTime.TabIndex = 9;
            this.txtCurrentTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImage = global::Polakken.Properties.Resources.Alfa;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(908, 702);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.tbcPage);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnLukk);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.crtView);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GUI";
            this.Text = "Polakken";
            this.TransparencyKey = System.Drawing.Color.Silver;
            this.Load += new System.EventHandler(this.GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.crtView)).EndInit();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
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

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart crtView;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.TextBox txtCurrent;
        private System.Windows.Forms.Label lblSiste;
        private System.Windows.Forms.Button btnLukk;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.TextBox txtMaxTime;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TabControl tbcPage;
        private System.Windows.Forms.TabPage tbpOne;
        private System.Windows.Forms.TabPage tbpTwo;
        private System.Windows.Forms.TabPage tbpThree;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.DataGridView dgvDataBase;
        private System.Windows.Forms.TextBox txtMinTime;
        private System.Windows.Forms.Button btnSetPointUp;
        private System.Windows.Forms.Button btnSetPointDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAlarmDown;
        private System.Windows.Forms.Button btnAlarmUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMesIDown;
        private System.Windows.Forms.Button btnMesIUp;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.TextBox txtCurrentTime;

    


    }
}

