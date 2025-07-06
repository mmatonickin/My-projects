using MyDoc;
using MyDoc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmLoginPatient : Form
    {
        public static Patient LoggedPatient;
        public FrmLoginPatient()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmChoice frmChoice = new FrmChoice();
            Hide();
            frmChoice.ShowDialog();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoginPatient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Morate popuniti sva polja.", "Pogreška!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (var context = new RWA2324_18_DBEntities())
                {
                    LoggedPatient = context.Patients.Where(patient => patient.Username == txtUsername.Text).FirstOrDefault();
                    if (LoggedPatient != null)
                    LoggedPatientID.Instance.SetPatientID(LoggedPatient.ID);
                    
                }
                if (LoggedPatient != null && LoggedPatient.CheckPassword(txtPassword.Text))
                {
                    FrmPatients frmPatients = new FrmPatients();
                    Hide();
                    frmPatients.ShowDialog();
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
            FrmRegistrationPatient frmRegistrationPatient = new FrmRegistrationPatient();
            Hide();
            frmRegistrationPatient.ShowDialog();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Morate popuniti sva polja.", "Pogreška!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    using (var context = new RWA2324_18_DBEntities())
                    {
                        LoggedPatient = context.Patients.Where(patient => patient.Username == txtUsername.Text).FirstOrDefault();
                        if (LoggedPatient != null)
                            LoggedPatientID.Instance.SetPatientID(LoggedPatient.ID);

                    }
                    if (LoggedPatient != null && LoggedPatient.CheckPassword(txtPassword.Text))
                    {
                        FrmPatients frmPatients = new FrmPatients();
                        Hide();
                        frmPatients.ShowDialog();
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
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Morate popuniti sva polja.", "Pogreška!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    using (var context = new RWA2324_18_DBEntities())
                    {
                        LoggedPatient = context.Patients.Where(patient => patient.Username == txtUsername.Text).FirstOrDefault();
                        if (LoggedPatient != null)
                            LoggedPatientID.Instance.SetPatientID(LoggedPatient.ID);

                    }
                    if (LoggedPatient != null && LoggedPatient.CheckPassword(txtPassword.Text))
                    {
                        FrmPatients frmPatients = new FrmPatients();
                        Hide();
                        frmPatients.ShowDialog();
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
