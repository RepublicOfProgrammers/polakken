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
            this.tbcPage = new Polakken.CTabControl();
            this.lblMaxTemp = new System.Windows.Forms.TabPage();
            this.tbpTwo = new System.Windows.Forms.TabPage();
            this.tbpThree = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.crtView)).BeginInit();
            this.grpInfo.SuspendLayout();
            this.tbcPage.SuspendLayout();
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
            this.crtView.Text = "5";
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
            this.btnLukk.FlatAppearance.BorderSize = 0;
            this.btnLukk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLukk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLukk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLukk.Location = new System.Drawing.Point(872, 22);
            this.btnLukk.Name = "btnLukk";
            this.btnLukk.Size = new System.Drawing.Size(21, 30);
            this.btnLukk.TabIndex = 4;
            this.btnLukk.UseVisualStyleBackColor = false;
            this.btnLukk.Click += new System.EventHandler(this.btnLukk_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.Color.Black;
            this.btnMinimize.Location = new System.Drawing.Point(846, 22);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(21, 30);
            this.btnMinimize.TabIndex = 5;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // tbcPage
            // 
            this.tbcPage.Controls.Add(this.lblMaxTemp);
            this.tbcPage.Controls.Add(this.tbpTwo);
            this.tbcPage.Controls.Add(this.tbpThree);
            this.tbcPage.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tbcPage.ItemSize = new System.Drawing.Size(90, 30);
            this.tbcPage.Location = new System.Drawing.Point(236, 69);
            this.tbcPage.Name = "tbcPage";
            this.tbcPage.SelectedIndex = 0;
            this.tbcPage.Size = new System.Drawing.Size(658, 360);
            this.tbcPage.TabIndex = 2;
            // 
            // lblMaxTemp
            // 
            this.lblMaxTemp.BackColor = System.Drawing.Color.Blue;
            this.lblMaxTemp.BackgroundImage = global::Polakken.Properties.Resources.Chart;
            this.lblMaxTemp.Location = new System.Drawing.Point(4, 34);
            this.lblMaxTemp.Name = "lblMaxTemp";
            this.lblMaxTemp.Padding = new System.Windows.Forms.Padding(3);
            this.lblMaxTemp.Size = new System.Drawing.Size(650, 322);
            this.lblMaxTemp.TabIndex = 0;
            this.lblMaxTemp.Text = "Instillinger";
            // 
            // tbpTwo
            // 
            this.tbpTwo.BackColor = System.Drawing.Color.Blue;
            this.tbpTwo.BackgroundImage = global::Polakken.Properties.Resources.Chart;
            this.tbpTwo.Location = new System.Drawing.Point(4, 34);
            this.tbpTwo.Name = "tbpTwo";
            this.tbpTwo.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTwo.Size = new System.Drawing.Size(650, 322);
            this.tbpTwo.TabIndex = 1;
            this.tbpTwo.Text = "Databasen";
            // 
            // tbpThree
            // 
            this.tbpThree.BackColor = System.Drawing.Color.Blue;
            this.tbpThree.BackgroundImage = global::Polakken.Properties.Resources.Chart;
            this.tbpThree.Location = new System.Drawing.Point(4, 34);
            this.tbpThree.Name = "tbpThree";
            this.tbpThree.Size = new System.Drawing.Size(650, 322);
            this.tbpThree.TabIndex = 2;
            this.tbpThree.Text = "E-mail";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.BackgroundImage = global::Polakken.Properties.Resources.Alfa2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(908, 702);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnLukk);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.tbcPage);
            this.Controls.Add(this.crtView);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GUI";
            this.Text = "Polakken";
            this.TransparencyKey = System.Drawing.Color.LemonChiffon;
            this.Load += new System.EventHandler(this.GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.crtView)).EndInit();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.tbcPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart crtView;
        private CTabControl tbcPage;
        private System.Windows.Forms.TabPage lblMaxTemp;
        private System.Windows.Forms.TabPage tbpTwo;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.TabPage tbpThree;
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

    }
}

