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
    public partial class Reports : UserControl
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void btnShowAppointments_Click(object sender, EventArgs e)
        {
            Appointment selectedAppointment = dgvReports.CurrentRow.DataBoundItem as Appointment;
            int rowIndex = dgvReports.CurrentRow.Index;
            if (dgvReports.CurrentRow != null)
            {
                FrmReports frmReports = new FrmReports(selectedAppointment, rowIndex, this);
                frmReports.ShowDialog();
                lblError.Text = "";
            }
            else
            {
                lblError.Text = "Niste odabrali niti jednoga pacijenta";
            }
        }

    }
}
