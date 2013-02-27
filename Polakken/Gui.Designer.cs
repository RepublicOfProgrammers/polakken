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
            this.tabInnstillinger = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabOversikt.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabOversikt);
            this.tabControl1.Controls.Add(this.tabInnstillinger);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(718, 478);
            this.tabControl1.TabIndex = 0;
            // 
            // tabOversikt
            // 
            this.tabOversikt.BackColor = System.Drawing.Color.Transparent;
            this.tabOversikt.Controls.Add(this.checkBox1);
            this.tabOversikt.Location = new System.Drawing.Point(4, 22);
            this.tabOversikt.Name = "tabOversikt";
            this.tabOversikt.Size = new System.Drawing.Size(710, 452);
            this.tabOversikt.TabIndex = 0;
            this.tabOversikt.Text = "Oversikt";
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(106, 85);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 502);
            this.Controls.Add(this.tabControl1);
            this.Name = "GUI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabOversikt.ResumeLayout(false);
            this.tabOversikt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOversikt;
        private System.Windows.Forms.TabPage tabInnstillinger;
        private System.Windows.Forms.CheckBox checkBox1;

    }
}

