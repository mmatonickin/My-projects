using MyDoc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDoc
{
    public partial class FrmSetAppointment : Form
    {
        public int loggedDoctor = LoggedDoctorID.Instance.GetDoctorID();
        public static Appointment_Requests SelectedRequest;
        public int RowIndex;
        public DataGridView dataGridView;
        public SetAppointment Appointment;

        public FrmSetAppointment(Appointment_Requests appointment_Requests, int rowIndex, SetAppointment setAppointment)   
        {
            InitializeComponent();
            SelectedRequest = appointment_Requests;
            RowIndex = rowIndex;
            dataGridView = setAppointment.dgvSetAppointment;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
        }

        private void FrmSetAppointment_Load(object sender, EventArgs e)
        {           
            Patient selectedPatient;
            Patient patient;
            Appointment_Requests appointment_Requests;
            Doctor doctor;
            
            
            using (var context = new RWA2324_18_DBEntities())
            {
                appointment_Requests = context.Appointment_Requests.Where(request => request.ID == SelectedRequest.ID).FirstOrDefault();
                selectedPatient = context.Patients.Find(appointment_Requests.ID_Patient);
                patient = context.Patients.Where(p => p.Name == selectedPatient.Name).FirstOrDefault();              
                doctor = context.Doctors.Where(doc => doc.ID == loggedDoctor).FirstOrDefault();
            }

            txtDoctor.Text = doctor.Name.ToString() + " " + doctor.Surname.ToString();
            txtDoctor.ReadOnly = true;

            if (selectedPatient != null)
            {
                txtPatientId.Text = selectedPatient.ID.ToString();
                txtPatientName.Text = patient.Name.ToString();
                txtPatientSurname.Text = patient.Surname.ToString();
                txtOIB.Text = patient.PIN.ToString();
                txtEmail.Text = patient.Email.ToString();
                txtSymptoms.Text = appointment_Requests.Symptoms.ToString();

                txtPatientId.ReadOnly = true;
                txtPatientName.ReadOnly = true;
                txtPatientSurname.ReadOnly = true;
                txtOIB.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtSymptoms.ReadOnly = true;
            }

        }          

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            DateTime dateTime = dateTimePicker1.Value;
            
            Appointment appointment = new Appointment()
            {
                Appointment_Date = dateTime,
                Zoom_Link = txtZoomLink.Text,
                ID_Doctor = loggedDoctor,
                ID_Patient = int.Parse(txtPatientId.Text)
            };

            if (!string.IsNullOrWhiteSpace(txtZoomLink.Text))
            {
                CurrencyManager currencyManager = (CurrencyManager)dataGridView.BindingContext[dataGridView.DataSource];
                currencyManager.SuspendBinding();
                dataGridView.Rows[RowIndex].Visible = false;
                currencyManager.ResumeBinding();

                using (var context = new RWA2324_18_DBEntities())
                {
                    context.Appointment_Requests.Attach(SelectedRequest);
                    context.Appointment_Requests.Remove(SelectedRequest);
                    context.Appointments.Add(appointment);
                    context.SaveChanges();
                    Close();
                }

                MessageBox.Show("Uspješno ste dodijelili termin","Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
