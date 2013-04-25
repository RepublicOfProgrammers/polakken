namespace Polakken
{
    partial class LogIn
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.lblGmail = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtEmail.ForeColor = System.Drawing.Color.Silver;
            this.txtEmail.Location = new System.Drawing.Point(33, 252);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(174, 23);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.Text = "Brukernavn";
            this.txtEmail.Click += new System.EventHandler(this.txtEmail_Click);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtPassword.ForeColor = System.Drawing.Color.Silver;
            this.txtPassword.Location = new System.Drawing.Point(33, 288);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(254, 23);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.Text = "Passord";
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.Transparent;
            this.btnEnter.BackgroundImage = global::Polakken.Properties.Resources.btnLoggInn;
            this.btnEnter.FlatAppearance.BorderSize = 0;
            this.btnEnter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEnter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.ForeColor = System.Drawing.Color.Transparent;
            this.btnEnter.Location = new System.Drawing.Point(108, 356);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(99, 27);
            this.btnEnter.TabIndex = 9;
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            this.btnEnter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEnter_MouseDown);
            this.btnEnter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnEnter_MouseUp);
            // 
            // chkSave
            // 
            this.chkSave.AutoSize = true;
            this.chkSave.BackColor = System.Drawing.Color.Transparent;
            this.chkSave.Checked = true;
            this.chkSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSave.Location = new System.Drawing.Point(34, 325);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(15, 14);
            this.chkSave.TabIndex = 3;
            this.chkSave.UseVisualStyleBackColor = false;
            this.chkSave.CheckedChanged += new System.EventHandler(this.chkSave_CheckedChanged);
            // 
            // lblGmail
            // 
            this.lblGmail.AutoSize = true;
            this.lblGmail.BackColor = System.Drawing.Color.Transparent;
            this.lblGmail.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmail.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGmail.Location = new System.Drawing.Point(209, 254);
            this.lblGmail.Name = "lblGmail";
            this.lblGmail.Size = new System.Drawing.Size(81, 18);
            this.lblGmail.TabIndex = 4;
            this.lblGmail.Text = "@gmail.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(48, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Husk Meg";
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Polakken.Properties.Resources.imgLoggInn;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(320, 404);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGmail);
            this.Controls.Add(this.chkSave);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LogIn";
            this.Text = "LogIn";
            this.TransparencyKey = System.Drawing.Color.Honeydew;
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.CheckBox chkSave;
        private System.Windows.Forms.Label lblGmail;
        private System.Windows.Forms.Label label1;
    }
}