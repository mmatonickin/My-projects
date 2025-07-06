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

namespace MyDoc
{
    public partial class BasicPaket : UserControl
    {
        public static Patient_Packages patientPackages;
        public static Health_Catalog healthCatalog;
        public int patientID = LoggedPatientID.Instance.GetPatientID();
        int usedBloodExtractions;
        public BasicPaket()
        {
            InitializeComponent();
        }
        private void btnConsultationBasic_Click(object sender, EventArgs e)
        {
            using (var context = new RWA2324_18_DBEntities())
            {
                patientPackages = context.Patient_Packages.Where(patient => patient.ID_Patient == patientID).OrderByDescending(patient => patient.ID).FirstOrDefault();
                if (patientPackages != null)
                    healthCatalog = context.Health_Catalog.Where(catalog => catalog.ID == patientPackages.ID_Package_Catalog).FirstOrDefault();
            }
            if (patientPackages.ID_Package_Catalog == 1 && patientPackages.Used_Consultations < healthCatalog.Max_Consultations)
            { 
                FrmAppointmentRequest frmAppointmentRequest = new FrmAppointmentRequest();
                frmAppointmentRequest.ShowDialog();
            }
            else
            {
                MessageBox.Show("Iskoristili ste sve usluge konzultacije.", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultationAdvanced_Click(object sender, EventArgs e)
        {
            using (var context = new RWA2324_18_DBEntities())
            {
                patientPackages = context.Patient_Packages.Where(patient => patient.ID_Patient == patientID).OrderByDescending(patient => patient.ID).FirstOrDefault();
                if (patientPackages != null)
                    healthCatalog = context.Health_Catalog.Where(catalog => catalog.ID == patientPackages.ID_Package_Catalog).FirstOrDefault();
            }
            if (patientPackages.ID_Package_Catalog == 2 && patientPackages.Used_Consultations < healthCatalog.Max_Consultations)
            {
                FrmAppointmentRequest frmAppointmentRequest = new FrmAppointmentRequest();
                frmAppointmentRequest.ShowDialog();
            }
            else
            {
                MessageBox.Show("Iskoristili ste sve usluge konzultacije.", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultationPremium_Click(object sender, EventArgs e)
        {
            using (var context = new RWA2324_18_DBEntities())
            {
                patientPackages = context.Patient_Packages.Where(patient => patient.ID_Patient == patientID).OrderByDescending(patient => patient.ID).FirstOrDefault();
                if (patientPackages != null)
                    healthCatalog = context.Health_Catalog.Where(catalog => catalog.ID == patientPackages.ID_Package_Catalog).FirstOrDefault();
            }
            if (patientPackages.ID_Package_Catalog == 3 && patientPackages.Used_Consultations < healthCatalog.Max_Consultations)
            {
                FrmAppointmentRequest frmAppointmentRequest = new FrmAppointmentRequest();
                frmAppointmentRequest.ShowDialog();
            }
            else
            {
                MessageBox.Show("Iskoristili ste sve usluge konzultacije.", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBloodExtraction_Click(object sender, EventArgs e)
        {
            using (var context = new RWA2324_18_DBEntities())
            {
                patientPackages = context.Patient_Packages.Where(patient => patient.ID_Patient == patientID).OrderByDescending(patient => patient.ID).FirstOrDefault();
                if (patientPackages != null)
                    healthCatalog = context.Health_Catalog.Where(catalog => catalog.ID == patientPackages.ID_Package_Catalog).FirstOrDefault();
            }
            if (patientPackages.ID_Package_Catalog == 3 && patientPackages.Used_Blood_Extractions < healthCatalog.Max_Blood_Extractions)
            {
                var dialog = MessageBox.Show("Želite li predati zahtjev za vađenje krvi?", "Zahtjev", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Appointment_Requests appointmentRequests = new Appointment_Requests()
                    {
                        ID_Patient = LoggedPatientID.Instance.GetPatientID(),
                        Symptoms = "Zahtjev za vađenje krvi",
                        Request_Date = DateTime.Now.Date
                    };
                    using (var context = new RWA2324_18_DBEntities())
                    {
                        context.Appointment_Requests.Add(appointmentRequests);
                        patientPackages = context.Patient_Packages.Where(patient => patient.ID_Patient == patientID).OrderByDescending(patient => patient.ID).FirstOrDefault();
                        usedBloodExtractions = patientPackages.Used_Blood_Extractions + 1 ?? default;
                        context.Patient_Packages.Attach(patientPackages);
                        patientPackages.Used_Blood_Extractions = usedBloodExtractions;
                        context.SaveChanges();
                    }

                }
            }
            else
            {
                MessageBox.Show("Iskoristili ste sve usluge vađenja krvi.", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
