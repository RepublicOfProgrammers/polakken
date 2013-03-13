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
            this.button9 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.tbpTwo = new System.Windows.Forms.TabPage();
            this.dgvDataBase = new System.Windows.Forms.DataGridView();
            this.Readings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Degree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbpThree = new System.Windows.Forms.TabPage();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtEmail1 = new System.Windows.Forms.TextBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.send = new System.Windows.Forms.Button();
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
            this.txtCurrentTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtCurrentTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrentTime.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtCurrentTime.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentTime.ForeColor = System.Drawing.Color.White;
            this.txtCurrentTime.Location = new System.Drawing.Point(36, 122);
            this.txtCurrentTime.Multiline = true;
            this.txtCurrentTime.Name = "txtCurrentTime";
            this.txtCurrentTime.ReadOnly = true;
            this.txtCurrentTime.Size = new System.Drawing.Size(129, 20);
            this.txtCurrentTime.TabIndex = 9;
            this.txtCurrentTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMinTime
            // 
            this.txtMinTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtMinTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
<<<<<<< HEAD
            this.txtMinTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
=======
            this.txtMinTime.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtMinTime.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
>>>>>>> 378e212fc98a4f797200f794103710b468c31ad3
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
<<<<<<< HEAD
            this.txtMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
=======
            this.txtMin.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtMin.Font = new System.Drawing.Font("Lucida Sans", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
>>>>>>> 378e212fc98a4f797200f794103710b468c31ad3
            this.txtMin.ForeColor = System.Drawing.Color.White;
            this.txtMin.Location = new System.Drawing.Point(46, 259);
            this.txtMin.Name = "txtMin";
<<<<<<< HEAD
            this.txtMin.Size = new System.Drawing.Size(107, 42);
=======
            this.txtMin.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(107, 44);
>>>>>>> 378e212fc98a4f797200f794103710b468c31ad3
            this.txtMin.TabIndex = 6;
            this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMaxTime
            // 
            this.txtMaxTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txtMaxTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
<<<<<<< HEAD
            this.txtMaxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
=======
            this.txtMaxTime.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtMaxTime.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
>>>>>>> 378e212fc98a4f797200f794103710b468c31ad3
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
<<<<<<< HEAD
            this.txtMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMax.ForeColor = System.Drawing.Color.White;
            this.txtMax.Location = new System.Drawing.Point(46, 171);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(107, 42);
            this.txtMax.TabIndex = 3;
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCurrentTime
            // 
            this.txtCurrentTime.BackColor = System.Drawing.Color.Black;
            this.txtCurrentTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentTime.ForeColor = System.Drawing.Color.White;
            this.txtCurrentTime.Location = new System.Drawing.Point(36, 119);
            this.txtCurrentTime.Name = "txtCurrentTime";
            this.txtCurrentTime.Size = new System.Drawing.Size(129, 15);
            this.txtCurrentTime.TabIndex = 2;
            this.txtCurrentTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
=======
            this.txtMax.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtMax.Font = new System.Drawing.Font("Lucida Sans", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMax.ForeColor = System.Drawing.Color.White;
            this.txtMax.Location = new System.Drawing.Point(46, 171);
            this.txtMax.Name = "txtMax";
            this.txtMax.ReadOnly = true;
            this.txtMax.Size = new System.Drawing.Size(107, 44);
            this.txtMax.TabIndex = 3;
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
>>>>>>> 378e212fc98a4f797200f794103710b468c31ad3
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
<<<<<<< HEAD
            this.txtCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrent.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtCurrent.Location = new System.Drawing.Point(36, 53);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Size = new System.Drawing.Size(129, 60);
=======
            this.txtCurrent.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtCurrent.Font = new System.Drawing.Font("Lucida Sans", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrent.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtCurrent.Location = new System.Drawing.Point(36, 53);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.ReadOnly = true;
            this.txtCurrent.Size = new System.Drawing.Size(129, 63);
>>>>>>> 378e212fc98a4f797200f794103710b468c31ad3
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
            this.tbpOne.BackgroundImage = global::Polakken.Properties.Resources.tableView;
            this.tbpOne.Controls.Add(this.button9);
            this.tbpOne.Controls.Add(this.label4);
            this.tbpOne.Controls.Add(this.button7);
            this.tbpOne.Controls.Add(this.button8);
            this.tbpOne.Controls.Add(this.textBox8);
            this.tbpOne.Controls.Add(this.label3);
            this.tbpOne.Controls.Add(this.button5);
            this.tbpOne.Controls.Add(this.button6);
            this.tbpOne.Controls.Add(this.textBox7);
            this.tbpOne.Controls.Add(this.label2);
            this.tbpOne.Controls.Add(this.button3);
            this.tbpOne.Controls.Add(this.button4);
            this.tbpOne.Controls.Add(this.textBox6);
            this.tbpOne.Controls.Add(this.label1);
            this.tbpOne.Controls.Add(this.button2);
            this.tbpOne.Controls.Add(this.button1);
            this.tbpOne.Controls.Add(this.textBox5);
            this.tbpOne.Location = new System.Drawing.Point(4, 22);
            this.tbpOne.Name = "tbpOne";
            this.tbpOne.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOne.Size = new System.Drawing.Size(646, 334);
            this.tbpOne.TabIndex = 0;
            this.tbpOne.Text = "Instillinger";
            this.tbpOne.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.BackgroundImage = global::Polakken.Properties.Resources.Lagre1;
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(19, 169);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(80, 32);
            this.button9.TabIndex = 25;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button9_MouseDown);
            this.button9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button9_MouseUp);
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
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(596, 120);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(30, 30);
            this.button7.TabIndex = 23;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(596, 74);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(30, 30);
            this.button8.TabIndex = 22;
            this.button8.UseVisualStyleBackColor = false;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.textBox8.Location = new System.Drawing.Point(514, 77);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(70, 70);
            this.textBox8.TabIndex = 21;
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
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(443, 118);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(30, 30);
            this.button5.TabIndex = 19;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(443, 72);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(30, 30);
            this.button6.TabIndex = 18;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.textBox7.Location = new System.Drawing.Point(361, 75);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(70, 70);
            this.textBox7.TabIndex = 17;
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
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(271, 118);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 30);
            this.button3.TabIndex = 15;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(271, 72);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(30, 30);
            this.button4.TabIndex = 14;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.textBox6.Location = new System.Drawing.Point(189, 75);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(70, 70);
            this.textBox6.TabIndex = 13;
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
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(101, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(101, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.textBox5.Location = new System.Drawing.Point(19, 74);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(70, 70);
            this.textBox5.TabIndex = 0;
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
<<<<<<< HEAD
            this.tbpThree.BackgroundImage = global::Polakken.Properties.Resources.Tab;
            this.tbpThree.Controls.Add(this.send);
=======
            this.tbpThree.BackgroundImage = global::Polakken.Properties.Resources.tableView1;
>>>>>>> 378e212fc98a4f797200f794103710b468c31ad3
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
            this.btnMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMove_MouseDown);
            this.btnMove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMove_MouseMove);
            this.btnMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMove_MouseUp);
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
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtCurrentTime;
        private System.Windows.Forms.TextBox txtMinTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox6;
<<<<<<< HEAD
        private System.Windows.Forms.Button send;
=======
        private System.Windows.Forms.Button button9;
>>>>>>> 378e212fc98a4f797200f794103710b468c31ad3

    }
}

