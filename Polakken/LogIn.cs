using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Polakken.Properties;
using System.Text.RegularExpressions;

namespace Polakken
{
    public partial class LogIn : Form
    {

        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            string email;
            email = Settings.Default.Email;
            txtEmail.Text = email.Replace("@gmail.com", "");
            txtPassword.Text = Settings.Default.Password;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
                sendMail.email = txtEmail.Text + "@gmail.com";
                sendMail.password = txtPassword.Text;

                if (chkSave.Checked)
                {
                    Settings.Default.Email = txtEmail.Text + "@gmail.com";
                    Settings.Default.Password = txtPassword.Text;
                }
                else
                {
                    Settings.Default.Email = "";
                    Settings.Default.Password = "";
                }
                Settings.Default.Save();
                DialogResult = DialogResult.OK;
                this.Close();
        }
    }
}
