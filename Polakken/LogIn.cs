using System;
using System.Drawing;
using System.Windows.Forms;
using Polakken.Properties;

namespace Polakken
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e) //Henter inn lagret epost og passord fra settings. 
        {
            string email = Settings.Default.Email;
            txtEmail.Text = email.Replace("@gmail.com", "");
            txtPassword.Text = Settings.Default.Password;
            if (chkSave.Checked)
            {
                txtEmail.ForeColor = Color.FromArgb(122, 184, 0);
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.ForeColor = Color.FromArgb(122, 184, 0);
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            //Tester på at det er skrivd inn et brukernavn og passord. 
            if (txtEmail.TextLength == 0)
            {
                MessageBox.Show("Du må skrive inn ett brukernavn", "Feil");
                chkSave.Checked = false;
            }
            else if (txtPassword.TextLength == 0)
            {
                MessageBox.Show("Du må skrive inn ett passord", "Feil");
                chkSave.Checked = false;
            }
            else if (txtEmail.Text == "Brukernavn" & txtEmail.ForeColor == Color.Silver)
            {
                MessageBox.Show("Du må skrive inn ett brukernavn", "Feil");
            }
            else if (txtPassword.Text == "Passord" & txtPassword.ForeColor == Color.Silver)
            {
                MessageBox.Show("Du må skrive inn ett passord", "Feil");
            }
            else
            {
                SendMail.Email = txtEmail.Text + "@gmail.com";
                SendMail.Password = txtPassword.Text;

                if (chkSave.Checked) //lagrer epost i settings.
                {
                    Settings.Default.Email = txtEmail.Text + "@gmail.com";
                    Settings.Default.Password = txtPassword.Text;
                }
                else
                    //Dersom "Husk meg" checkboksen ikke er checked, setter den email og passord i settings til en tom tekststreng. 
                {
                    Settings.Default.Email = "";
                    Settings.Default.Password = "";
                }
                Settings.Default.Save();
                DialogResult = DialogResult.OK; //Forteller polakken at den kan loade GUIen.
            }
        }

        private void btnEnter_MouseDown(object sender, MouseEventArgs e)
        {
            btnEnter.BackgroundImage = Resources.Polakken_btnLoggInnNed;
        }

        private void btnEnter_MouseUp(object sender, MouseEventArgs e)
        {
            btnEnter.BackgroundImage = Resources.Polakken_btnLoggInn;
        }

        private void chkSave_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkSave.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtEmail.Text = "Brukernavn";
                txtEmail.ForeColor = Color.Silver;
                txtPassword.Text = "Passord";
                txtPassword.ForeColor = Color.Silver;
            }
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Brukernavn" & txtEmail.ForeColor == Color.Silver)
            {
                txtEmail.Clear();
                txtEmail.ForeColor = Color.FromArgb(122, 184, 0);
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Passord" & txtPassword.ForeColor == Color.Silver)
            {
                txtPassword.Clear();
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.ForeColor = Color.FromArgb(122, 184, 0);
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Passord" & txtPassword.ForeColor == Color.Silver)
            {
                txtPassword.Clear();
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.ForeColor = Color.FromArgb(122, 184, 0);
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.TextLength == 0)
            {
                txtEmail.Text = "Brukernavn";
                txtEmail.ForeColor = Color.Silver;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.TextLength == 0)
            {
                txtPassword.Text = "Passord";
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.ForeColor = Color.Silver;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtEmail.TextLength == 0)
                {
                    MessageBox.Show("Du må skrive inn ett brukernavn", "Feil");
                    chkSave.Checked = false;
                }
                else if (txtPassword.TextLength == 0)
                {
                    MessageBox.Show("Du må skrive inn ett passord", "Feil");
                    chkSave.Checked = false;
                }
                else if (txtEmail.Text == "Brukernavn" & txtEmail.ForeColor == Color.Silver)
                {
                    MessageBox.Show("Du må skrive inn ett brukernavn", "Feil");
                }
                else if (txtPassword.Text == "Passord" & txtPassword.ForeColor == Color.Silver)
                {
                    MessageBox.Show("Du må skrive inn ett passord", "Feil");
                }
                else
                {
                    SendMail.Email = txtEmail.Text + "@gmail.com";
                    SendMail.Password = txtPassword.Text;

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
                }
            }
        }
    }
}