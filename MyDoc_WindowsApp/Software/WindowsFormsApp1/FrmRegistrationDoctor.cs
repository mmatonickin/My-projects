using MyDoc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmRegistrationDoctor : Form
    {
        public FrmRegistrationDoctor()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmChoice frmChoice = new FrmChoice();
            Hide();
            frmChoice.ShowDialog();
            Close();
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLoginDoctor frmLoginDoctor = new FrmLoginDoctor();
            Hide();
            frmLoginDoctor.ShowDialog();
            Close();
        }

        private void btnRegisterPatient_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtLicenceNum.Text) && !string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtSurname.Text) && !string.IsNullOrWhiteSpace(txtEmail.Text) && !string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                int licenceNum = int.Parse(txtLicenceNum.Text);
                string password = HashPassword.Password(txtPassword.Text);
                Doctor newDoctor = new Doctor()
                {
                    License_Num = int.Parse(txtLicenceNum.Text),
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Email = txtEmail.Text,
                    Username = txtUsername.Text,
                    Password = password,

                };
                using (var context = new RWA2324_18_DBEntities())
                {
                    bool usernameExists = context.Doctors.Any(username => username.Username == txtUsername.Text);
                    bool licenceNumExists = context.Doctors.Any(licenceNumber => licenceNumber.License_Num == licenceNum);
                    if (usernameExists)
                    {
                        MessageBox.Show("Korisničko ime već postoji", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else if (txtLicenceNum.Text.Length == 5 && !licenceNumExists)
                    {
                        context.Doctors.Add(newDoctor);
                        context.SaveChanges();
                        DialogResult result = MessageBox.Show("Uspješna registracija", "Potvrda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (DialogResult.OK == result)
                        {
                            FrmDoctors frmDoctors = new FrmDoctors();
                            Hide();
                            frmDoctors.ShowDialog();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Liječnička licenca nije ispravna ili već postoji", "Pogreška!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
