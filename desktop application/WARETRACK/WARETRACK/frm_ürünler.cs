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
    public partial class frm_ürünler : Form
    {
        public frm_ürünler()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        

        private void btn_degistir_Click(object sender, EventArgs e)
        {
            btn_kaydet.Visible = true;
            btn_degistir.Visible = false;
            txt_urun_kodu.Enabled = false;
        }

        private void frm_ürünler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wARETRACKDataSet14.PRODUCT' table. You can move, or remove it, as needed.
            this.pRODUCTTableAdapter2.Fill(this.wARETRACKDataSet14.PRODUCT);
          

            btn_kaydet.Visible = false;
        }

       

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            txt_urun_kodu.Enabled = true;
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (txt_urun_adi.Text == "" || txt_grup_kodu.Text == "" || txt_aciklama.Text == "" || cmbbox_aktiflik.Text == "")
            {
                MessageBox.Show("Değişikliğin yapılacağı ürünü tablodan tıklayarak seçiniz.");
            }
            else
            {
                btn_kaydet.Visible = false;
                btn_degistir.Visible = true;
                txt_urun_kodu.Enabled = true;
                // kaydetme olayı
                string yol = Veri_tabanı.veritabani_class.baglanti;
                SqlConnection baglan = new SqlConnection(yol);
                baglan.Open();
                SqlCommand komut = new SqlCommand("Update PRODUCT Set PRODUCT_NAME=@p1, EXPO=@p2, ACTIVE=@p3, GROUPCODE=@p4 where CODE=@p5",baglan);
                komut.Parameters.AddWithValue("p1", txt_urun_adi.Text.Trim());
                komut.Parameters.AddWithValue("p2", txt_aciklama.Text.Trim());
                if (cmbbox_aktiflik.Text == "Aktif (0)")
                {
                    int aktif = Convert.ToInt16(labelaktif.Text.Trim());
                    komut.Parameters.AddWithValue("p3", aktif);
                }
                else if (cmbbox_aktiflik.Text == "Kullanım dışı (1)")
                {
                    int kullanimdisi = Convert.ToInt16(labelkullanimdisi.Text.Trim());
                    komut.Parameters.AddWithValue("p3", kullanimdisi);
                }
                komut.Parameters.AddWithValue("p4", txt_grup_kodu.Text.Trim());
                komut.Parameters.AddWithValue("p5", txt_urun_kodu.Text.Trim());
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Değişiklikler kaydedildi.");
                this.pRODUCTTableAdapter2.Fill(this.wARETRACKDataSet14.PRODUCT);

                txt_urun_kodu.Text = "";
                txt_urun_adi.Text = "";
                txt_grup_kodu.Text = "";
                txt_aciklama.Text = "";
                cmbbox_aktiflik.SelectedItem = null;
            }
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            txt_urun_kodu.Enabled = true;

            if(txt_urun_kodu.Text =="" || txt_urun_adi.Text == "" || txt_grup_kodu.Text == "" || txt_aciklama.Text =="" || cmbbox_aktiflik.Text =="")
            {
                MessageBox.Show("Lütfen değerleri boş bırakmayınız.");
            }
            else
            {
                //ekleme olayi
                string yol = Veri_tabanı.veritabani_class.baglanti;
                SqlConnection baglan = new SqlConnection(yol);
                baglan.Open();
                SqlCommand komut1 = new SqlCommand("select * from PRODUCT where CODE=@p6", baglan);
                komut1.Parameters.AddWithValue("@p6", txt_urun_kodu.Text.Trim());
                SqlDataReader dr = komut1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Bu ürün zaten kayıtlı.");
                    baglan.Close();
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    SqlCommand komut = new SqlCommand("insert into PRODUCT (CODE,PRODUCT_NAME,EXPO,ACTIVE,GROUPCODE) values (@p1,@p2,@p3,@p4,@p5)", baglan);
                    komut.Parameters.AddWithValue("@p1", txt_urun_kodu.Text.Trim());
                    komut.Parameters.AddWithValue("@p2", txt_urun_adi.Text.Trim());
                    komut.Parameters.AddWithValue("@p3", txt_aciklama.Text.Trim());
                    if (cmbbox_aktiflik.Text == "Aktif (0)")
                    {
                        int aktif = Convert.ToInt16(labelaktif.Text.Trim());
                        komut.Parameters.AddWithValue("@p4", aktif);
                    }
                    else if (cmbbox_aktiflik.Text == "Kullanım dışı (1)")
                    {
                        int kullanimdisi = Convert.ToInt16(labelkullanimdisi.Text.Trim());
                        komut.Parameters.AddWithValue("@p4", kullanimdisi);
                    }
                    komut.Parameters.AddWithValue("@p5", txt_grup_kodu.Text.Trim());
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Ürün kaydedildi");
                    this.pRODUCTTableAdapter2.Fill(this.wARETRACKDataSet14.PRODUCT);

                    txt_urun_kodu.Text = "";
                    txt_urun_adi.Text = "";
                    txt_grup_kodu.Text = "";
                    txt_aciklama.Text = "";
                    cmbbox_aktiflik.SelectedItem = null;
                }
            }
        }

        private void btn_degistir_Click_1(object sender, EventArgs e)
        {
            if (txt_urun_adi.Text == "" || txt_grup_kodu.Text == "" || txt_aciklama.Text == "" || cmbbox_aktiflik.Text == "")
            {
                MessageBox.Show("Değişikliğin yapılacağı ürünü tablodan tıklayarak seçiniz.");
            }
            else
            {
                btn_kaydet.Visible = true;
                btn_degistir.Visible = false;
                txt_urun_kodu.Enabled = false;
                //benim yazdığım yer

                txt_urun_adi.Enabled = true;
                txt_grup_kodu.Enabled = true;
                txt_aciklama.Enabled = true;
                cmbbox_aktiflik.Enabled = true;
            }
            
        }

        private void cmbbox_aktiflik_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtg_ürünler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_urun_kodu.Enabled = false;
            txt_urun_adi.Enabled = false;
            txt_grup_kodu.Enabled = false;
            txt_aciklama.Enabled = false;
            cmbbox_aktiflik.Enabled = false;
            int secim = dtg_ürünler.SelectedCells[0].RowIndex;
            txt_urun_kodu.Text = dtg_ürünler.Rows[secim].Cells[0].Value.ToString().Trim();
            txt_urun_adi.Text = dtg_ürünler.Rows[secim].Cells[1].Value.ToString().Trim();
            txt_aciklama.Text = dtg_ürünler.Rows[secim].Cells[2].Value.ToString().Trim();
            string aktifolma = dtg_ürünler.Rows[secim].Cells[3].Value.ToString().Trim();
            if (aktifolma == "0")
            {
                cmbbox_aktiflik.SelectedIndex = 0;
            }
            else
            {
                cmbbox_aktiflik.SelectedIndex = 1;
            }
            txt_grup_kodu.Text = dtg_ürünler.Rows[secim].Cells[4].Value.ToString().Trim();
        }

        private void dtg_ürünler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
