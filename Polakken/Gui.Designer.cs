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
            this.txtMinTime = new System.Windows.Forms.TextBox();
            this.lblMin = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtMaxTime = new System.Windows.Forms.TextBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.txtCurrentTime = new System.Windows.Forms.TextBox();
            this.lblSiste = new System.Windows.Forms.Label();
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.btnLukk = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.tbcPage = new System.Windows.Forms.TabControl();
            this.tbpOne = new System.Windows.Forms.TabPage();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnMove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.crtView)).BeginInit();
            this.grpInfo.SuspendLayout();
            this.tbcPage.SuspendLayout();
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
            this.grpInfo.Controls.Add(this.txtMinTime);
            this.grpInfo.Controls.Add(this.lblMin);
            this.grpInfo.Controls.Add(this.txtMin);
            this.grpInfo.Controls.Add(this.txtMaxTime);
            this.grpInfo.Controls.Add(this.lblMax);
            this.grpInfo.Controls.Add(this.txtMax);
            this.grpInfo.Controls.Add(this.txtCurrentTime);
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
            this.txtMinTime.BackColor = System.Drawing.Color.Black;
            this.txtMinTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMinTime.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinTime.ForeColor = System.Drawing.Color.White;
            this.txtMinTime.Location = new System.Drawing.Point(46, 304);
            this.txtMinTime.Name = "txtMinTime";
            this.txtMinTime.Size = new System.Drawing.Size(107, 13);
            this.txtMinTime.TabIndex = 8;
            this.txtMinTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.Location = new System.Drawing.Point(46, 237);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(107, 14);
            this.lblMin.TabIndex = 7;
            this.lblMin.Text = "Max Tempratur";
            // 
            // txtMin
            // 
            this.txtMin.BackColor = System.Drawing.Color.Black;
            this.txtMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMin.Font = new System.Drawing.Font("Lucida Sans", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMin.ForeColor = System.Drawing.Color.White;
            this.txtMin.Location = new System.Drawing.Point(46, 256);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(107, 44);
            this.txtMin.TabIndex = 6;
            this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMaxTime
            // 
            this.txtMaxTime.BackColor = System.Drawing.Color.Black;
            this.txtMaxTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaxTime.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxTime.ForeColor = System.Drawing.Color.White;
            this.txtMaxTime.Location = new System.Drawing.Point(46, 219);
            this.txtMaxTime.Name = "txtMaxTime";
            this.txtMaxTime.Size = new System.Drawing.Size(107, 13);
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
            this.txtMax.BackColor = System.Drawing.Color.Black;
            this.txtMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMax.Font = new System.Drawing.Font("Lucida Sans", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMax.ForeColor = System.Drawing.Color.White;
            this.txtMax.Location = new System.Drawing.Point(46, 171);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(107, 44);
            this.txtMax.TabIndex = 3;
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCurrentTime
            // 
            this.txtCurrentTime.BackColor = System.Drawing.Color.Black;
            this.txtCurrentTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrentTime.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentTime.ForeColor = System.Drawing.Color.White;
            this.txtCurrentTime.Location = new System.Drawing.Point(36, 119);
            this.txtCurrentTime.Name = "txtCurrentTime";
            this.txtCurrentTime.Size = new System.Drawing.Size(129, 16);
            this.txtCurrentTime.TabIndex = 2;
            this.txtCurrentTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.txtCurrent.BackColor = System.Drawing.Color.Black;
            this.txtCurrent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrent.Font = new System.Drawing.Font("Lucida Sans", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrent.ForeColor = System.Drawing.Color.LawnGreen;
            this.txtCurrent.Location = new System.Drawing.Point(36, 53);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Size = new System.Drawing.Size(129, 63);
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
            this.tbpOne.BackgroundImage = global::Polakken.Properties.Resources.Tab;
            this.tbpOne.Location = new System.Drawing.Point(4, 22);
            this.tbpOne.Name = "tbpOne";
            this.tbpOne.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOne.Size = new System.Drawing.Size(646, 334);
            this.tbpOne.TabIndex = 0;
            this.tbpOne.Text = "Instillinger";
            this.tbpOne.UseVisualStyleBackColor = true;
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
            this.dgvDataBase.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataBase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Readings,
            this.Date,
            this.Degree,
            this.Status});
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
            this.tbpThree.BackgroundImage = global::Polakken.Properties.Resources.Tab;
            this.tbpThree.Controls.Add(this.textBox4);
            this.tbpThree.Controls.Add(this.textBox3);
            this.tbpThree.Controls.Add(this.textBox2);
            this.tbpThree.Controls.Add(this.textBox1);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // btnMove
            // 
            this.btnMove.BackColor = System.Drawing.Color.Transparent;
            this.btnMove.FlatAppearance.BorderSize = 0;
            this.btnMove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMove.Location = new System.Drawing.Point(17, 22);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(820, 30);
            this.btnMove.TabIndex = 7;
            this.btnMove.Text = "button1";
            this.btnMove.UseVisualStyleBackColor = false;
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
        private System.Windows.Forms.TextBox txtCurrentTime;
        private System.Windows.Forms.TextBox txtMaxTime;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.TextBox txtMinTime;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TabControl tbcPage;
        private System.Windows.Forms.TabPage tbpOne;
        private System.Windows.Forms.TabPage tbpTwo;
        private System.Windows.Forms.TabPage tbpThree;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.DataGridView dgvDataBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Readings;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Degree;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;

    }
}

