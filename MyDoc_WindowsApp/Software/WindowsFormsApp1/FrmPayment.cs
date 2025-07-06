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
using System.Xml.Linq;
using WindowsFormsApp1;

namespace MyDoc
{
    public partial class FrmPayment : Form
    {
        int patientID = LoggedPatientID.Instance.GetPatientID();
        Patient_Packages patientUsedServices = new Patient_Packages();
        public static Nullable<int> packageID;
        public static Nullable<int> serviceID;
        public bool isService;

        public FrmPayment(Nullable<int> package_ID = null, Nullable<int> _serviceID = null, bool _isService = false)
        {
            isService = _isService;
            serviceID = _serviceID;
            packageID = package_ID;
            InitializeComponent();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {

            DateTime dateTime = dtpExpDate.Value.Date;
            if (!string.IsNullOrWhiteSpace(txtIme.Text) && !string.IsNullOrWhiteSpace(txtPrezime.Text) && !string.IsNullOrWhiteSpace(txtCVC.Text) && (txtCVC.Text.Length == 3 || txtCVC.Text.Length == 4) && !string.IsNullOrWhiteSpace(txtCardNum.Text) && txtCardNum.Text.Length == 16 && (txtJMBAG.Text.Length == 10 || string.IsNullOrWhiteSpace(txtJMBAG.Text)))
            {

                Payment newPayment = new Payment()
                {
                    Name = txtIme.Text,
                    Surname = txtPrezime.Text,
                    Card_Number = txtCardNum.Text,
                    CVV = int.Parse(txtCVC.Text),
                    Exp_Date = dateTime,
                    JMBAG = txtJMBAG.Text,
                    ID_Patient = LoggedPatientID.Instance.GetPatientID(),
                    ID_Patient_Package = packageID,
                    ID_Patient_Service = serviceID
                };

                Patient_Packages patient_Packages = new Patient_Packages()
                {
                    Used_Consultations = 0,
                    Used_Blood_Extractions = 0,
                    ID_Patient = LoggedPatientID.Instance.GetPatientID(),
                    ID_Package_Catalog = packageID ?? default
                };

                Patient_Services patientServices = new Patient_Services()
                {
                    ID_Patient = LoggedPatientID.Instance.GetPatientID(),
                    ID_Service_Catalog = serviceID ?? default
                };


                using (var context = new RWA2324_18_DBEntities())
                {
                    patientUsedServices = context.Patient_Packages.Where(patient => patient.ID_Patient == patientID).OrderByDescending(patient => patient.ID).FirstOrDefault();

                    if (patientUsedServices == null && !isService)
                    {
                        context.Payments.Add(newPayment);
                        context.Patient_Packages.Add(patient_Packages);
                        context.SaveChanges();                      
                        DialogResult result = MessageBox.Show("Uspješno plaćanje, vaše usluge su dostupne pod \n\"Moji Paketi\"", "Potvrda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (DialogResult.OK == result)
                        {                       
                            Close();
                        }
                        
                    }
                    else if (!isService && ((patientUsedServices.Used_Consultations == 2 && patientUsedServices.ID_Package_Catalog == 1) || (patientUsedServices.Used_Consultations == 4 && patientUsedServices.ID_Package_Catalog == 2) || (patientUsedServices.Used_Consultations == 7 && patientUsedServices.ID_Package_Catalog == 3 && patientUsedServices.Used_Blood_Extractions == 1)))
                    {
                        context.Payments.Add(newPayment);
                        context.Patient_Packages.Add(patient_Packages);
                        context.SaveChanges();
                        DialogResult result = MessageBox.Show("Uspješno plaćanje, vaše usluge su dostupne pod \n\"Moji Paketi\"", "Potvrda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else if (!isService)
                    {
                        MessageBox.Show("Ne možete kupiti novi paket dok ne iskorisite sve usluge iz trenutnog", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                   

                    if (isService)
                    {
                        context.Patient_Services.Add(patientServices);
                        context.Payments.Add(newPayment);
                        context.SaveChanges();
                        FrmAppointmentRequest frmAppointmentRequest = new FrmAppointmentRequest(isService);
                        frmAppointmentRequest.ShowDialog();
                        isService = false;
                        Close();
                    }

                }
            }
            else if (string.IsNullOrWhiteSpace(txtIme.Text) || string.IsNullOrWhiteSpace(txtPrezime.Text) || string.IsNullOrWhiteSpace(txtCardNum.Text) || string.IsNullOrWhiteSpace(txtCVC.Text) || txtCardNum.Text.Length != 16 || txtCVC.Text.Length != 3 || txtCVC.Text.Length !=4)
            {
                MessageBox.Show("Morate popuniti sva polja", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
