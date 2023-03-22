using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciNotSistemi
{
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-EQ95IAG\MSSQLSERVER01;Initial Catalog=DbNotKayit;Integrated Security=True");
        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {

            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values (@p1,@p2,@p3)",baglanti);
            komut.Parameters.AddWithValue("@p1",txtNumara.Text);
            komut.Parameters.AddWithValue("@p2",txtAd.Text);
            komut.Parameters.AddWithValue("@p3",txtSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi!");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtNumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtsnv1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsnv2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtsnv3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            double ortalama,s1,s2,s3;
            string durum;

            s1 = Convert.ToDouble(txtsnv1.Text);
            s2 = Convert.ToDouble(txtsnv2.Text);
            s3 = Convert.ToDouble(txtsnv3.Text);
            ortalama = (s1 + s2 + s3) / 3;
            lblOrtalama.Text = ortalama.ToString();

            if (ortalama > 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBLDERS set OGRS1=@p1,OGRS2=@p2,OGRS3=@p3," +
                "ORTALAMA=@p4,DURUM=@p5 where OGRNUMARA=@p6",baglanti);

            komut.Parameters.AddWithValue("@p1",txtsnv1.Text);
            komut.Parameters.AddWithValue("@p2",txtsnv2.Text);
            komut.Parameters.AddWithValue("@p3",txtsnv3.Text);
            komut.Parameters.AddWithValue("@p4",decimal.Parse(lblOrtalama.Text));
            komut.Parameters.AddWithValue("@p5",durum);
            komut.Parameters.AddWithValue("@p6",txtNumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Successful!");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);

        }
    }
}
