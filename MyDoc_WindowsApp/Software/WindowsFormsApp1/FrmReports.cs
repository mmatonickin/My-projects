using MyDoc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDoc
{
    public partial class FrmReports : Form
    {
        public Report report;
        public DataGridView dataGridView;
        public int RowIndex;
        public static Patient patient;
        public static Doctor doctor;
        int loggedDoctor = LoggedDoctorID.Instance.GetDoctorID();
        public Appointment selectedAppointment;
        public FrmReports(Appointment appointment, int rowIndex, Reports reports)
        {
            selectedAppointment = appointment;
            InitializeComponent();
            RowIndex = rowIndex;
            dataGridView = reports.dgvReports;
        }

        private void FrmReports_Load(object sender, EventArgs e)
        {
            using (var context = new RWA2324_18_DBEntities())
            {
                patient = context.Patients.Where(pacijent => pacijent.ID == selectedAppointment.ID_Patient).FirstOrDefault();
                doctor = context.Doctors.Where(lijecnik => lijecnik.ID == loggedDoctor).FirstOrDefault();
            }
            txtPatientName.Text = patient.Name;
            txtPatientSurname.Text = patient.Surname;
            txtPatientEmail.Text = patient.Email;
            txtPatientOib.Text = patient.PIN;
            txtDoctor.Text = doctor.Name +" "+ doctor.Surname;
            txtDate.Text = DateTime.Now.ToString();

            txtDoctor.ReadOnly = true;
            txtPatientName.ReadOnly = true;
            txtPatientSurname.ReadOnly = true;
            txtPatientOib.ReadOnly = true;
            txtPatientEmail.ReadOnly = true;
            txtDate.ReadOnly = true;
        }

        private void btnSendReport_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtTherapy.Text) && !string.IsNullOrWhiteSpace(txtSymptoms.Text))
            {
                Report report = new Report()
                {
                    Therapy = txtTherapy.Text,
                    Disgnose = txtSymptoms.Text,
                    Input_Date = DateTime.Now.Date,
                    ID_Doctor = loggedDoctor,
                    ID_Patient = patient.ID
                };

                CurrencyManager currencyManager = (CurrencyManager)dataGridView.BindingContext[dataGridView.DataSource];
                currencyManager.SuspendBinding();
                dataGridView.Rows[RowIndex].Visible = false;
                currencyManager.ResumeBinding();
                using (var context = new RWA2324_18_DBEntities())
                {
                    context.Appointments.Attach(selectedAppointment);
                    context.Appointments.Remove(selectedAppointment);
                    context.Reports.Add(report);
                    context.SaveChanges();
                }
                MessageBox.Show("Uspješno ste poslali nalaz", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Morate popuniti sva polja", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
