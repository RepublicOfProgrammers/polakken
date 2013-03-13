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
            this.crtView = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.txtCurrentTime = new System.Windows.Forms.TextBox();
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
            this.dgvDataBase = new System.Windows.Forms.DataGridView();
            this.Readings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Degree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbpThree = new System.Windows.Forms.TabPage();
            this.send = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtEmail1 = new System.Windows.Forms.TextBox();
            this.btnMove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.crtView)).BeginInit();
            this.grpInfo.SuspendLayout();
            this.tbcPage.SuspendLayout();
            this.tbpOne.SuspendLayout();
            this.tbpTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataBase)).BeginInit();
            this.tbpThree.SuspendLayout();
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
            // txtCurrentTime
            // 
            this.txtCurrentTime.BackColor = System.Drawing.Color.Black;
            this.txtCurrentTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrentTime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentTime.ForeColor = System.Drawing.Color.White;
            this.txtCurrentTime.Location = new System.Drawing.Point(36, 119);
            this.txtCurrentTime.Multiline = true;
            this.txtCurrentTime.Name = "txtCurrentTime";
            this.txtCurrentTime.ReadOnly = true;
            this.txtCurrentTime.Size = new System.Drawing.Size(129, 15);
            this.txtCurrentTime.TabIndex = 2;
            this.txtCurrentTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCurrentTime.TextChanged += new System.EventHandler(this.txtCurrentTime_TextChanged);
            // 
            // txtMinTime
            // 
            this.txtMinTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtMinTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMinTime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtMinTime.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinTime.ForeColor = System.Drawing.Color.White;
            this.txtMinTime.Location = new System.Drawing.Point(36, 309);
            this.txtMinTime.Multiline = true;
            this.txtMinTime.Name = "txtMinTime";
            this.txtMinTime.ReadOnly = true;
            this.txtMinTime.Size = new System.Drawing.Size(129, 20);
            this.txtMinTime.TabIndex = 8;
            this.txtMinTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinTime.TextChanged += new System.EventHandler(this.txtMinTime_TextChanged);
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
            this.txtMin.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtMin.Font = new System.Drawing.Font("Lucida Sans", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMin.ForeColor = System.Drawing.Color.White;
            this.txtMin.Location = new System.Drawing.Point(46, 259);
            this.txtMin.Name = "txtMin";
            this.txtMin.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(107, 44);
            this.txtMin.TabIndex = 6;
            this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMin.TextChanged += new System.EventHandler(this.txtMin_TextChanged);
            // 
            // txtMaxTime
            // 
            this.txtMaxTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtMaxTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaxTime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtMaxTime.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxTime.ForeColor = System.Drawing.Color.White;
            this.txtMaxTime.Location = new System.Drawing.Point(36, 221);
            this.txtMaxTime.Multiline = true;
            this.txtMaxTime.Name = "txtMaxTime";
            this.txtMaxTime.ReadOnly = true;
            this.txtMaxTime.Size = new System.Drawing.Size(129, 20);
            this.txtMaxTime.TabIndex = 5;
            this.txtMaxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMaxTime.TextChanged += new System.EventHandler(this.txtMaxTime_TextChanged);
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
            this.txtMax.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtMax.Font = new System.Drawing.Font("Lucida Sans", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMax.ForeColor = System.Drawing.Color.White;
            this.txtMax.Location = new System.Drawing.Point(46, 171);
            this.txtMax.Name = "txtMax";
            this.txtMax.ReadOnly = true;
            this.txtMax.Size = new System.Drawing.Size(107, 44);
            this.txtMax.TabIndex = 3;
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMax.TextChanged += new System.EventHandler(this.txtMax_TextChanged);
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
            this.txtCurrent.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtCurrent.Font = new System.Drawing.Font("Lucida Sans", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrent.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtCurrent.Location = new System.Drawing.Point(36, 53);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.ReadOnly = true;
            this.txtCurrent.Size = new System.Drawing.Size(129, 63);
            this.txtCurrent.TabIndex = 0;
            this.txtCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCurrent.TextChanged += new System.EventHandler(this.txtCurrent_TextChanged);
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
            this.txtAlarm.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtAlarm.Font = new System.Drawing.Font("Lucida Sans", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlarm.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtAlarm.Location = new System.Drawing.Point(514, 81);
            this.txtAlarm.Name = "txtAlarm";
            this.txtAlarm.ReadOnly = true;
            this.txtAlarm.Size = new System.Drawing.Size(71, 63);
            this.txtAlarm.TabIndex = 28;
            this.txtAlarm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAlarm.TextChanged += new System.EventHandler(this.txtAlarm_TextChanged);
            // 
            // txtInt
            // 
            this.txtInt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtInt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInt.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtInt.Font = new System.Drawing.Font("Lucida Sans", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInt.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtInt.Location = new System.Drawing.Point(361, 81);
            this.txtInt.Name = "txtInt";
            this.txtInt.ReadOnly = true;
            this.txtInt.Size = new System.Drawing.Size(71, 63);
            this.txtInt.TabIndex = 27;
            this.txtInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInt.TextChanged += new System.EventHandler(this.txtInt_TextChanged);
            // 
            // txtTol
            // 
            this.txtTol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtTol.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTol.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtTol.Font = new System.Drawing.Font("Lucida Sans", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTol.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtTol.Location = new System.Drawing.Point(189, 81);
            this.txtTol.Name = "txtTol";
            this.txtTol.ReadOnly = true;
            this.txtTol.Size = new System.Drawing.Size(71, 63);
            this.txtTol.TabIndex = 26;
            this.txtTol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSetPoint
            // 
            this.txtSetPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtSetPoint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSetPoint.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtSetPoint.Font = new System.Drawing.Font("Lucida Sans", 39.75F, System.Drawing.FontStyle.Bold);
            this.txtSetPoint.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtSetPoint.Location = new System.Drawing.Point(19, 81);
            this.txtSetPoint.Name = "txtSetPoint";
            this.txtSetPoint.ReadOnly = true;
            this.txtSetPoint.Size = new System.Drawing.Size(71, 63);
            this.txtSetPoint.TabIndex = 9;
            this.txtSetPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSetPoint.TextChanged += new System.EventHandler(this.txtSetPoint_TextChanged);
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
            this.btnSetPointUp.FlatAppearance.BorderSize = 0;
            this.btnSetPointUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSetPointUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSetPointUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetPointUp.Location = new System.Drawing.Point(101, 71);
            this.btnSetPointUp.Name = "btnSetPointUp";
            this.btnSetPointUp.Size = new System.Drawing.Size(30, 30);
            this.btnSetPointUp.TabIndex = 4;
            this.btnSetPointUp.UseVisualStyleBackColor = false;
            this.btnSetPointUp.Click += new System.EventHandler(this.btnSetPointUp_Click);
            this.btnSetPointUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSetPointUp_MouseDown);
            this.btnSetPointUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSetPointUp_MouseUp);
            // 
            // tbpTwo
            // 
            this.tbpTwo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbpTwo.BackgroundImage")));
            this.tbpTwo.Controls.Add(this.dgvDataBase);
            this.tbpTwo.Location = new System.Drawing.Point(4, 22);
            this.tbpTwo.Name = "tbpTwo";
            this.tbpTwo.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTwo.Size = new System.Drawing.Size(646, 334);
            this.tbpTwo.TabIndex = 1;
            this.tbpTwo.Text = "Databasen";
            this.tbpTwo.UseVisualStyleBackColor = true;
            // 
            // dgvDataBase
            // 
            this.dgvDataBase.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.dgvDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataBase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Readings,
            this.Date,
            this.Degree,
            this.Status});
            this.dgvDataBase.GridColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvDataBase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvDataBase.Location = new System.Drawing.Point(7, 7);
            this.dgvDataBase.Name = "dgvDataBase";
            this.dgvDataBase.Size = new System.Drawing.Size(636, 324);
            this.dgvDataBase.TabIndex = 0;
            // 
            // Readings
            // 
            this.Readings.DataPropertyName = "TB_READINGS";
            this.Readings.HeaderText = "Avlesninger";
            this.Readings.Name = "Readings";
            // 
            // Date
            // 
            this.Date.DataPropertyName = "TB_DATE";
            this.Date.HeaderText = "Dato";
            this.Date.Name = "Date";
            // 
            // Degree
            // 
            this.Degree.DataPropertyName = "TB_DEGREE";
            this.Degree.HeaderText = "Tempratur";
            this.Degree.Name = "Degree";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "TB_STATUS";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // tbpThree
            // 
            this.tbpThree.BackgroundImage = global::Polakken.Properties.Resources.tableView1;
            this.tbpThree.Controls.Add(this.send);
            this.tbpThree.Controls.Add(this.textBox4);
            this.tbpThree.Controls.Add(this.textBox3);
            this.tbpThree.Controls.Add(this.textBox2);
            this.tbpThree.Controls.Add(this.txtEmail1);
            this.tbpThree.Location = new System.Drawing.Point(4, 22);
            this.tbpThree.Name = "tbpThree";
            this.tbpThree.Size = new System.Drawing.Size(646, 334);
            this.tbpThree.TabIndex = 2;
            this.tbpThree.Text = "E-Mail";
            this.tbpThree.UseVisualStyleBackColor = true;
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(164, 53);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 23);
            this.send.TabIndex = 4;
            this.send.Text = "button1";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(16, 90);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(16, 38);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            // 
            // txtEmail1
            // 
            this.txtEmail1.Location = new System.Drawing.Point(16, 12);
            this.txtEmail1.Name = "txtEmail1";
            this.txtEmail1.Size = new System.Drawing.Size(100, 20);
            this.txtEmail1.TabIndex = 0;
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
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            this.btnMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMove_MouseDown);
            this.btnMove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMove_MouseMove);
            this.btnMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMove_MouseUp);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataBase)).EndInit();
            this.tbpThree.ResumeLayout(false);
            this.tbpThree.PerformLayout();
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
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtEmail1;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.DataGridView dgvDataBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Readings;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Degree;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.TextBox txtCurrentTime;
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


        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox txtAlarm;
        private System.Windows.Forms.TextBox txtInt;
        private System.Windows.Forms.TextBox txtTol;
        private System.Windows.Forms.TextBox txtSetPoint;

    


    }
}

