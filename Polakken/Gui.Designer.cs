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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOversikt = new System.Windows.Forms.TabPage();
            this.txtSiste = new System.Windows.Forms.TextBox();
            this.crtOversikt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabInnstillinger = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabOversikt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crtOversikt)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabOversikt);
            this.tabControl1.Controls.Add(this.tabInnstillinger);
            this.tabControl1.Location = new System.Drawing.Point(12, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(740, 493);
            this.tabControl1.TabIndex = 0;
            // 
            // tabOversikt
            // 
            this.tabOversikt.BackColor = System.Drawing.Color.Black;
            this.tabOversikt.Controls.Add(this.txtSiste);
            this.tabOversikt.Controls.Add(this.crtOversikt);
            this.tabOversikt.Location = new System.Drawing.Point(4, 22);
            this.tabOversikt.Name = "tabOversikt";
            this.tabOversikt.Size = new System.Drawing.Size(732, 467);
            this.tabOversikt.TabIndex = 0;
            this.tabOversikt.Text = "Oversikt";
            this.tabOversikt.Click += new System.EventHandler(this.tabOversikt_Click);
            // 
            // txtSiste
            // 
            this.txtSiste.Font = new System.Drawing.Font("Arial Narrow", 80.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSiste.Location = new System.Drawing.Point(3, 106);
            this.txtSiste.Multiline = true;
            this.txtSiste.Name = "txtSiste";
            this.txtSiste.Size = new System.Drawing.Size(175, 116);
            this.txtSiste.TabIndex = 2;
            this.txtSiste.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSiste.TextChanged += new System.EventHandler(this.txtSiste_TextChanged);
            // 
            // crtOversikt
            // 
            this.crtOversikt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crtOversikt.BackColor = System.Drawing.Color.Black;
            this.crtOversikt.BackSecondaryColor = System.Drawing.Color.White;
            this.crtOversikt.Location = new System.Drawing.Point(-4, 257);
            this.crtOversikt.Name = "crtOversikt";
            this.crtOversikt.Size = new System.Drawing.Size(736, 214);
            this.crtOversikt.TabIndex = 1;
            this.crtOversikt.Text = "5";
            // 
            // tabInnstillinger
            // 
            this.tabInnstillinger.Location = new System.Drawing.Point(4, 22);
            this.tabInnstillinger.Name = "tabInnstillinger";
            this.tabInnstillinger.Size = new System.Drawing.Size(710, 452);
            this.tabInnstillinger.TabIndex = 1;
            this.tabInnstillinger.Text = "Innstillinger";
            this.tabInnstillinger.UseVisualStyleBackColor = true;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 517);
            this.Controls.Add(this.tabControl1);
            this.Name = "GUI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabOversikt.ResumeLayout(false);
            this.tabOversikt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crtOversikt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOversikt;
        private System.Windows.Forms.TabPage tabInnstillinger;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtOversikt;
        private System.Windows.Forms.TextBox txtSiste;

    }
}

