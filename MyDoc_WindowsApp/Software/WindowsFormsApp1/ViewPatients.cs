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
using System.Xml.Linq;

namespace MyDoc
{
    public partial class ViewPatients : UserControl
    {
        public ViewPatients()
        {
            InitializeComponent();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            using (var context = new RWA2324_18_DBEntities())
            {
                var query = from patient in context.Patients
                            select new
                            {
                                patient.Username,
                                patient.Name,
                                patient.Surname,
                                patient.PIN,
                                patient.City,
                                patient.Address,
                                patient.Email

                            };
                var patients = query.ToList();
                dgvPatientsView.DataSource = patients;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text.Length == 0)
            {
                using (var context = new RWA2324_18_DBEntities())
                {
                    var query = from patient in context.Patients
                                select new
                                {
                                    patient.Username,
                                    patient.Name,
                                    patient.Surname,
                                    patient.PIN,
                                    patient.City,
                                    patient.Address,
                                    patient.Email

                                };
                    var patients = query.ToList();
                    dgvPatientsView.DataSource = patients;
                }
            }
            else
            {
                using (var context = new RWA2324_18_DBEntities())
                {
                    var query = from patient in context.Patients
                                where patient.Name.Contains(txtSearch.Text) || patient.Surname.Contains(txtSearch.Text)
                                select new
                                {
                                    patient.Username,
                                    patient.Name,
                                    patient.Surname,
                                    patient.PIN,
                                    patient.City,
                                    patient.Address,
                                    patient.Email
                                };
                                
                    var patients = query.ToList();
                    dgvPatientsView.DataSource = patients;
                }
                          
            }
        }
    }
}
