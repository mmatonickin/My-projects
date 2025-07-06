using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace MyDoc
{
    public partial class BuyPackage : UserControl
    {
        public BuyPackage()
        {
            InitializeComponent();
        }

        private void btnBuyBasic_Click(object sender, EventArgs e)
        {
            FrmPayment frmPayment = new FrmPayment(1);
            frmPayment.ShowDialog();
        }

        private void btnBuyAdvanced_Click(object sender, EventArgs e)
        {
            FrmPayment frmPayment = new FrmPayment(2);
            frmPayment.ShowDialog();
        }

        private void btnBuyPremium_Click(object sender, EventArgs e)
        {
            FrmPayment frmPayment = new FrmPayment(3);
            frmPayment.ShowDialog();
        }
    }
}
