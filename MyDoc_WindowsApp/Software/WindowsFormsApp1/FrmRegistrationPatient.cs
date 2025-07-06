using MyDoc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmRegistrationPatient : Form
    {
        public FrmRegistrationPatient()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            FrmChoice frmChoice = new FrmChoice();
            Hide();
            frmChoice.ShowDialog();
            Close();
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLoginPatient frmLoginPatient = new FrmLoginPatient();
            Hide();
            frmLoginPatient.ShowDialog();
            Close();
        }

        private void btnRegisterPatient_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtOIB.Text) && !string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtSurname.Text) && !string.IsNullOrWhiteSpace(txtAddress.Text) && !string.IsNullOrWhiteSpace(txtCity.Text) && !string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text) && txtEmail.Text != "")
            {
                string password = HashPassword.Password(txtPassword.Text);
                Patient newPatient = new Patient()
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Address = txtAddress.Text,
                    City = txtCity.Text,
                    PIN = txtOIB.Text,
                    Username = txtUsername.Text,
                    Password = password,
                    Email = txtEmail.Text
                };
                using (var context = new RWA2324_18_DBEntities())
                {
                    bool usernameExists = context.Patients.Any(username => username.Username == txtUsername.Text);
                    if (usernameExists)
                    {
                        MessageBox.Show("Korisničko ime već postoji", "Pogreška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtOIB.Text.Length == 11)
                    {
                        context.Patients.Add(newPatient);
                        context.SaveChanges();
                        MessageBox.Show("Uspješna registracija", "Potvrda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("OIB nije ispravno unesen.", "Pogreška!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Morate popuniti sva polja.", "Pogreška!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}


