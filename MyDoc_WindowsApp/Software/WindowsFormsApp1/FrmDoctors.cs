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
    public partial class FrmDoctors : Form
    {
        public List<Appointment> appointment;
        public List<Appointment_Requests> Appointment_Requests;

        public FrmDoctors()
        {
            InitializeComponent();
        }
        
        private void btnPatients_Click(object sender, EventArgs e)
        {
            pnlMenuControl2.Height = btnPatients.Height;
            pnlMenuControl2.Top = btnPatients.Top;
            viewPatients1.BringToFront();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            using (var context = new RWA2324_18_DBEntities())
            {
                Appointment_Requests = new List<Appointment_Requests>(context.Appointment_Requests.ToList());
                appointment = new List<Appointment>(context.Appointments.ToList());
            }

            reports1.dgvReports.DataSource = appointment;
            reports1.dgvReports.Columns["ID"].DisplayIndex = 0;
            reports1.dgvReports.Columns["Appointment_Date"].DisplayIndex = 1;
            reports1.dgvReports.Columns["ID_Doctor"].DisplayIndex = 2;
            reports1.dgvReports.Columns["ID_Patient"].DisplayIndex = 3;
            reports1.dgvReports.Columns["Zoom_Link"].DisplayIndex = 4;
            reports1.dgvReports.Columns["Doctor"].Visible = false;
            reports1.dgvReports.Columns["Patient"].Visible = false;

            pnlMenuControl2.Height = btnReports.Height;
            pnlMenuControl2.Top = btnReports.Top;
            reports1.BringToFront();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            using (var context = new RWA2324_18_DBEntities())
            {
                Appointment_Requests = new List<Appointment_Requests>(context.Appointment_Requests.ToList());
                appointment = new List<Appointment>(context.Appointments.ToList());
            }
            setAppointment1.dgvSetAppointment.DataSource = Appointment_Requests;
            setAppointment1.dgvSetAppointment.Columns["ID"].DisplayIndex = 0;
            setAppointment1.dgvSetAppointment.Columns["Symptoms"].DisplayIndex = 1;
            setAppointment1.dgvSetAppointment.Columns["Request_Date"].DisplayIndex = 2;
            setAppointment1.dgvSetAppointment.Columns["ID_Patient"].DisplayIndex = 3;
            setAppointment1.dgvSetAppointment.Columns["Patient"].Visible = false;

            pnlMenuControl2.Height = btnAppointments.Height;
            pnlMenuControl2.Top = btnAppointments.Top;
            setAppointment1.BringToFront();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
