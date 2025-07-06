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
    public partial class BuyService : UserControl
    {
        int patientID = LoggedPatientID.Instance.GetPatientID();
        public static Patient patient;
        public BuyService()
        {
            InitializeComponent();
        }

        private void btnBuyConsultation_Click_1(object sender, EventArgs e)
        {
            FrmPayment frmPayment = new FrmPayment(null, 1, true);
            frmPayment.ShowDialog();
        }

        private void btnBuyBloodExtraction_Click_1(object sender, EventArgs e)
        {
            FrmPayment frmPayment = new FrmPayment(null, 2, true);
            frmPayment.ShowDialog();
        }

        private void btnBuyVisit_Click_1(object sender, EventArgs e)
        {
            using (var context = new RWA2324_18_DBEntities())
            {
                patient = context.Patients.Where(p => p.ID == patientID).FirstOrDefault();
                if (patient.City == "Varaždin" || patient.City == "Zagreb" || patient.City == "Rijeka" || patient.City == "Osijek" || patient.City == "Zadar" || patient.City == "Split")
                {
                    FrmPayment frmPayment = new FrmPayment(null, 2, true);
                    frmPayment.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Usluga je dostupna isključivo korisnicima koji žive u Varaždinu, Zagrebu, Splitu, Rijeci, Osjeku ili Zadru","Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }   
            
        }   

    }
}
