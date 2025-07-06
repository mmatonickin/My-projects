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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyDoc
{
    public partial class ReportView : UserControl
    {
        int patientID = LoggedPatientID.Instance.GetPatientID();
        public ReportView()
        {
            InitializeComponent();
        }

        private void btnShowReports_Click(object sender, EventArgs e)
        {
            using (var context = new RWA2324_18_DBEntities())
            {
                var query = from report in context.Reports
                            where report.ID_Patient == patientID
                            select new
                            {
                                Diagnose = report.Disgnose,
                                Teraphy = report.Therapy,
                                InputDate = report.Input_Date
                            };

                var reports = query.ToList();
                dgvReport.DataSource = reports;
            }
        }
    }
}
