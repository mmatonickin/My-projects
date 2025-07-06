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
    public partial class FrmAppointmentRequest : Form
    {
        public static Patient_Packages patientPackages;
        int patientID = LoggedPatientID.Instance.GetPatientID();
        int usedConsultations;
        public bool isService;
        public FrmAppointmentRequest(bool _isService = false)
        {
            isService = _isService;
            int patientID = LoggedPatientID.Instance.GetPatientID();
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSymptoms.Text))
            {
                Appointment_Requests appointment_Request = new Appointment_Requests()
                {
                    Symptoms = txtSymptoms.Text,
                    Request_Date = DateTime.Now,
                    ID_Patient = LoggedPatientID.Instance.GetPatientID()
                };

                using (var context = new RWA2324_18_DBEntities())
                {
                    patientPackages = context.Patient_Packages.Where(patient => patient.ID_Patient == patientID).OrderByDescending(patient => patient.ID).FirstOrDefault();
                    if (!isService)
                    {
                        usedConsultations = patientPackages.Used_Consultations + 1 ?? default;
                        context.Patient_Packages.Attach(patientPackages);
                        patientPackages.Used_Consultations = usedConsultations;
                    }
                    context.Appointment_Requests.Add(appointment_Request);
                    context.SaveChanges();
                }
                MessageBox.Show("Vaš zahtjev je uspješno predan","Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Niste unijeli simptome", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmAppointmentRequest_Load(object sender, EventArgs e)
        {
            txtInputDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
