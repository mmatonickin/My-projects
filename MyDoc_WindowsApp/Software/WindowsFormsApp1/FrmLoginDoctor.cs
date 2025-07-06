using MyDoc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmLoginDoctor : Form
    {
        public static Doctor LoggedDoctor;
        public FrmLoginDoctor()
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

        private void btnLoginDoctor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtLicenceNumber.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Morate popuniti sva polja.", "Pogreška!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (var context = new RWA2324_18_DBEntities())
                {
                    LoggedDoctor = context.Doctors.Where(doctor => doctor.Username == txtUsername.Text).FirstOrDefault();
                    if (LoggedDoctor != null)
                        LoggedDoctorID.Instance.SetDoctorID(LoggedDoctor.ID);
                }
                if (LoggedDoctor != null && LoggedDoctor.CheckPassword(txtPassword.Text) && LoggedDoctor.CheckLicenceNum(int.Parse(txtLicenceNumber.Text)))
                {
                    FrmDoctors frmDoctors = new FrmDoctors();
                    Hide();
                    frmDoctors.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Krivi podatci", "Problem!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegistrationDoctor frmRegistrationDoctor = new FrmRegistrationDoctor();
            Hide();
            frmRegistrationDoctor.ShowDialog();
            Close();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtLicenceNumber.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Morate popuniti sva polja.", "Pogreška!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    using (var context = new RWA2324_18_DBEntities())
                    {
                        LoggedDoctor = context.Doctors.Where(doctor => doctor.Username == txtUsername.Text).FirstOrDefault();
                        if (LoggedDoctor != null)
                            LoggedDoctorID.Instance.SetDoctorID(LoggedDoctor.ID);
                    }
                    if (LoggedDoctor != null && LoggedDoctor.CheckPassword(txtPassword.Text) && LoggedDoctor.CheckLicenceNum(int.Parse(txtLicenceNumber.Text)))
                    {
                        FrmDoctors frmDoctors = new FrmDoctors();
                        Hide();
                        frmDoctors.ShowDialog();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Krivi podatci", "Problem!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtLicenceNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtLicenceNumber.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Morate popuniti sva polja.", "Pogreška!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    using (var context = new RWA2324_18_DBEntities())
                    {
                        LoggedDoctor = context.Doctors.Where(doctor => doctor.Username == txtUsername.Text).FirstOrDefault();
                        if (LoggedDoctor != null)
                            LoggedDoctorID.Instance.SetDoctorID(LoggedDoctor.ID);
                    }
                    if (LoggedDoctor != null && LoggedDoctor.CheckPassword(txtPassword.Text) && LoggedDoctor.CheckLicenceNum(int.Parse(txtLicenceNumber.Text)))
                    {
                        FrmDoctors frmDoctors = new FrmDoctors();
                        Hide();
                        frmDoctors.ShowDialog();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Krivi podatci", "Problem!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtLicenceNumber.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Morate popuniti sva polja.", "Pogreška!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    using (var context = new RWA2324_18_DBEntities())
                    {
                        LoggedDoctor = context.Doctors.Where(doctor => doctor.Username == txtUsername.Text).FirstOrDefault();
                        if (LoggedDoctor != null)
                            LoggedDoctorID.Instance.SetDoctorID(LoggedDoctor.ID);
                    }
                    if (LoggedDoctor != null && LoggedDoctor.CheckPassword(txtPassword.Text) && LoggedDoctor.CheckLicenceNum(int.Parse(txtLicenceNumber.Text)))
                    {
                        FrmDoctors frmDoctors = new FrmDoctors();
                        Hide();
                        frmDoctors.ShowDialog();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Krivi podatci", "Problem!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
