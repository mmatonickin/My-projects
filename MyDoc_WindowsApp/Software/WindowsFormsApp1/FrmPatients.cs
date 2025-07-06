using MyDoc;
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
using System.Windows.Forms.Design;

namespace WindowsFormsApp1
{
    public partial class FrmPatients : Form
    {
        public static Patient_Packages patientPackages;
        public static Health_Catalog healthCatalog;
        int patientID = LoggedPatientID.Instance.GetPatientID();

        public FrmPatients()
        {
            InitializeComponent();
            pnlMenuControl.Height = btnBuyPackage.Height;
            buyPackage1.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBuyPackage_Click(object sender, EventArgs e)
        {
            pnlMenuControl.Height = btnBuyPackage.Height;
            pnlMenuControl.Top = btnBuyPackage.Top;
            buyPackage1.BringToFront();
        }

        private void btnServiceBuy_Click(object sender, EventArgs e)
        {
            pnlMenuControl.Height = btnServiceBuy.Height;
            pnlMenuControl.Top = btnServiceBuy.Top;
            buyService1.BringToFront();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            pnlMenuControl.Height = btnReport.Height;
            pnlMenuControl.Top = btnReport.Top;
            reportView1.BringToFront();
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            pnlMenuControl.Height = btnAppointment.Height;
            pnlMenuControl.Top = btnAppointment.Top;
            appointmentView1.BringToFront();

            using (var context = new RWA2324_18_DBEntities())
            {
                var pastAppointment = context.Appointments.Where(date => date.Appointment_Date < DateTime.Now).ToList();
                if (pastAppointment.Any())
                {
                    context.Appointments.RemoveRange(pastAppointment);
                    context.SaveChanges();
                }

                var query = from appointment in context.Appointments
                            where appointment.ID_Patient == patientID

                            select new
                            {
                                Date = appointment.Appointment_Date,
                                ZoomLink = appointment.Zoom_Link
                            };

                var appointments = query.ToList();
                appointmentView1.dgvAppointment.DataSource = appointments;
             
            }
        }

        private void btnMyPackage_Click(object sender, EventArgs e)
        {
            using (var context = new RWA2324_18_DBEntities())
            {
                patientPackages = context.Patient_Packages.Where(patient => patient.ID_Patient == patientID).OrderByDescending(patient => patient.ID).FirstOrDefault();
                
                if (patientPackages != null)
                    healthCatalog = context.Health_Catalog.Where(catalog => catalog.ID == patientPackages.ID_Package_Catalog).FirstOrDefault();
            }

            if (patientPackages != null && (patientPackages.ID_Package_Catalog == 3 && (patientPackages.Used_Consultations < healthCatalog.Max_Consultations || patientPackages.Used_Blood_Extractions < healthCatalog.Max_Blood_Extractions)))
            {
                pnlMenuControl.Height = btnMyPackage.Height;
                pnlMenuControl.Top = btnMyPackage.Top;
                basicPaket1.BringToFront();
                basicPaket1.txtPremiumAvailableConsl.Text = "Iskorišteno konzultacija:" + patientPackages.Used_Consultations.ToString() + "/7";
                basicPaket1.txtPremiumBloodExAv.Text = "Iskorišteno vađenja krvi:" + patientPackages.Used_Blood_Extractions.ToString() + "/1";
                basicPaket1.btnConsultationBasic.Enabled = false;
                basicPaket1.btnConsultationAdvanced.Enabled = false;
            }
            else if (patientPackages != null && ((patientPackages.ID_Package_Catalog == 2 || patientPackages.ID_Package_Catalog == 1) && (patientPackages.Used_Consultations < healthCatalog.Max_Consultations)))
            {
                pnlMenuControl.Height = btnMyPackage.Height;
                pnlMenuControl.Top = btnMyPackage.Top;
                basicPaket1.BringToFront();
                if (patientPackages.ID_Package_Catalog == 2)
                {
                    basicPaket1.txtAdvancedAvailable.Text = "Iskorišteno konzultacija:" + patientPackages.Used_Consultations.ToString() + "/4";
                    basicPaket1.btnConsultationBasic.Enabled = false;
                    basicPaket1.btnConsultationPremium.Enabled = false;
                    basicPaket1.btnBloodExtraction.Enabled = false;
                }
                if (patientPackages.ID_Package_Catalog == 1)
                {
                    basicPaket1.txtBasicAvailable.Text = "Iskorišteno konzultacija:" + patientPackages.Used_Consultations.ToString() + "/2";
                    basicPaket1.btnConsultationAdvanced.Enabled = false;
                    basicPaket1.btnConsultationPremium.Enabled = false;
                    basicPaket1.btnBloodExtraction.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Nemate kupljenih paketa ili ste iskoristili sve usluge. \nMorate kupiti paket prije provjere preostalih usluga.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
