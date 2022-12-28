using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WARETRACK
{
    public partial class frm_rpr_satış_irsaliyeleri : Form
    {
        public frm_rpr_satış_irsaliyeleri()
        {
            InitializeComponent();

            string yol = Veri_tabanı.veritabani_class.baglanti;
            SqlConnection baglan = new SqlConnection(yol);
            baglan.Open();
            SqlCommand komut1 = new SqlCommand("select * from V_ALL_TALLYOUT", baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dtg_rpr_satış_irsaliyeleri.DataSource = ds.Tables[0];
            baglan.Close();
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            if (txt_ürün_kodu.Text == "")
            {
                MessageBox.Show("Ürün kodu değerini boş bırakmayınız");
            }
            else
            {
                string yol = Veri_tabanı.veritabani_class.baglanti;
                SqlConnection baglan = new SqlConnection(yol);
                baglan.Open();
                SqlCommand komut1 = new SqlCommand("select * from TALLYOUT where PRCODE=@p1", baglan);
                komut1.Parameters.AddWithValue("@p1", txt_ürün_kodu.Text.Trim());
                SqlDataReader dr = komut1.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    SqlCommand komut = new SqlCommand("Select * from V_TALLYOUT where [Ürün Kodu] like '%" + txt_ürün_kodu.Text + "%'", baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dtg_rpr_satış_irsaliyeleri.DataSource = ds.Tables[0];
                    baglan.Close();
                }
                else
                {
                    MessageBox.Show("girdiğiniz değerlere ait satış irsaliyesi bulunamamıştır. yeniden deneyiniz");
                    baglan.Close();
                    dr.Close();
                }
                baglan.Close();
            }
        }
    }
}
