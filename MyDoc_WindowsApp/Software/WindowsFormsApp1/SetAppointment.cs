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
    public partial class SetAppointment : UserControl
    {
        public SetAppointment()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Appointment_Requests selectedRequest = dgvSetAppointment.CurrentRow.DataBoundItem as Appointment_Requests;  
            int rowIndex = dgvSetAppointment.CurrentRow.Index;
            
            if (selectedRequest != null)
            {
                
                FrmSetAppointment frmSetAppointment = new FrmSetAppointment(selectedRequest, rowIndex, this);
                frmSetAppointment.ShowDialog();
            
            }
            
        }
    }
}
