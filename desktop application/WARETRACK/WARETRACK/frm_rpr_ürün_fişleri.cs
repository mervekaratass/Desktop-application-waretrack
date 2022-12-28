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
    public partial class frm_rpr_ürün_fişleri : Form
    {
        public frm_rpr_ürün_fişleri()
        {
            InitializeComponent();

            string yol = Veri_tabanı.veritabani_class.baglanti;
            SqlConnection baglan = new SqlConnection(yol);
            baglan.Open();
            SqlCommand komut1 = new SqlCommand("select * from V_ALL_PRFICHE", baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dtg_rpr_ürün_fişleri.DataSource = ds.Tables[0];
            baglan.Close();
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            
            if(txt_ürün_kodu.Text=="")
            {
                MessageBox.Show("degerleri bos bırakmayınız"); 
            }
            else
            {
                string yol = Veri_tabanı.veritabani_class.baglanti;
                SqlConnection baglan = new SqlConnection(yol);
                baglan.Open();
                SqlCommand komut1 = new SqlCommand("select * from PRFICHE where PRCODE=@p1 and FICHETYPE=@p2", baglan);
                komut1.Parameters.AddWithValue("@p1", txt_ürün_kodu.Text.Trim());
                
                int fisturu;
                if (comboBox1.Text == "Üretimden Giriş Fişi (1)")
                {
                    fisturu = Convert.ToInt16(labelbir.Text.Trim());
                    komut1.Parameters.AddWithValue("p2", fisturu);
                }
                else if (comboBox1.Text == "Sayımdan Fazlası Fişi (2)")
                {
                    fisturu = Convert.ToInt16(labeliki.Text.Trim());
                    komut1.Parameters.AddWithValue("p2", fisturu);
                }
                else if (comboBox1.Text == "Sayım Eksiği Fişi (3)")
                {
                    fisturu = Convert.ToInt16(labeluc.Text.Trim());
                    komut1.Parameters.AddWithValue("p2", fisturu);
                }
                else if (comboBox1.Text == "Fire Fişi (4)")
                {
                    fisturu = Convert.ToInt16(labeldort.Text.Trim());
                    komut1.Parameters.AddWithValue("p2", fisturu);
                }

                SqlDataReader dr = komut1.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    SqlCommand komut = new SqlCommand("Select * from V_PRFICHE where [Ürün Kodu] like '%" + txt_ürün_kodu.Text + "%'", baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dtg_rpr_ürün_fişleri.DataSource = ds.Tables[0];
                    baglan.Close();
                    
                }
                else
                {
                    MessageBox.Show("girdiğiniz değerlere ait ürün fişi bulunamamıştır. yeniden deneyin");
                    baglan.Close();
                    dr.Close();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
