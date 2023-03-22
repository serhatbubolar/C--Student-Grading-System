using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciNotSistemi
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            FrmOgrenciDetay fr = new FrmOgrenciDetay();
            
            fr.numara = txtNumber.Text;

            fr.Show();

           
        }
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtNumber.Text == "1111")
            {
                FrmOgretmenDetay frmOgretmenDetay = new FrmOgretmenDetay();
                frmOgretmenDetay.Show();
            }
        }
    }
}
