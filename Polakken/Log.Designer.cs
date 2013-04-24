namespace Polakken
{
    partial class Log
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
            this.txtRead = new System.Windows.Forms.TextBox();
            this.ofdRead = new System.Windows.Forms.OpenFileDialog();
            this.btnLukk = new System.Windows.Forms.Button();
            this.btnMove1 = new System.Windows.Forms.Button();
            this.tmrUpdateText = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtRead
            // 
            this.txtRead.BackColor = System.Drawing.Color.White;
            this.txtRead.Location = new System.Drawing.Point(55, 76);
            this.txtRead.Multiline = true;
            this.txtRead.Name = "txtRead";
            this.txtRead.ReadOnly = true;
            this.txtRead.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRead.Size = new System.Drawing.Size(849, 301);
            this.txtRead.TabIndex = 5;
            // 
            // ofdRead
            // 
            this.ofdRead.FileName = "ofdRead";
            // 
            // btnLukk
            // 
            this.btnLukk.BackColor = System.Drawing.Color.Transparent;
            this.btnLukk.BackgroundImage = global::Polakken.Properties.Resources.btnClose;
            this.btnLukk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLukk.FlatAppearance.BorderSize = 0;
            this.btnLukk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLukk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLukk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLukk.Location = new System.Drawing.Point(888, 25);
            this.btnLukk.Name = "btnLukk";
            this.btnLukk.Size = new System.Drawing.Size(30, 30);
            this.btnLukk.TabIndex = 5;
            this.btnLukk.UseVisualStyleBackColor = false;
            this.btnLukk.Click += new System.EventHandler(this.btnLukk_Click);
            // 
            // btnMove1
            // 
            this.btnMove1.BackColor = System.Drawing.Color.Transparent;
            this.btnMove1.FlatAppearance.BorderSize = 0;
            this.btnMove1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMove1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMove1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMove1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMove1.Location = new System.Drawing.Point(40, 12);
            this.btnMove1.Name = "btnMove1";
            this.btnMove1.Size = new System.Drawing.Size(842, 43);
            this.btnMove1.TabIndex = 8;
            this.btnMove1.UseVisualStyleBackColor = false;
            this.btnMove1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMove1_MouseDown);
            this.btnMove1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMove1_MouseMove);
            this.btnMove1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMove1_MouseUp);
            // 
            // tmrUpdateText
            // 
            this.tmrUpdateText.Interval = 6000;
            this.tmrUpdateText.Tick += new System.EventHandler(this.tmrUpdateText_Tick);
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::Polakken.Properties.Resources.LogForn;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(965, 423);
            this.Controls.Add(this.btnMove1);
            this.Controls.Add(this.btnLukk);
            this.Controls.Add(this.txtRead);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Log";
            this.Text = "Log";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Load += new System.EventHandler(this.Log_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdRead;
        private System.Windows.Forms.Button btnLukk;
        private System.Windows.Forms.Button btnMove1;
        public System.Windows.Forms.TextBox txtRead;
        private System.Windows.Forms.Timer tmrUpdateText;
        
    }
}