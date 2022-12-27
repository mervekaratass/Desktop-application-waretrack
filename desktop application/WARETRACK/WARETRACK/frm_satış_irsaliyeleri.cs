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
    public partial class frm_satış_irsaliyeleri : Form
    {
        public frm_satış_irsaliyeleri()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_degistir_Click(object sender, EventArgs e)
        {
            if (txt_irsaliye_no.Text == "" || txt_tarih.Text == "" || txt_belge_no.Text == "" || txt_urun_kodu.Text == "" || txt_adet.Text == "" || txt_fiyat.Text == "")
            {
                MessageBox.Show("Değişikliğin yapılacağı irsaliyeyi tablodan tıklayarak seçiniz.");
            }
            else
            {
                btn_kaydet.Visible = true;
                btn_degistir.Visible = false;
                txt_urun_kodu.Enabled = false;

                //degistir butonu
                txt_irsaliye_no.Enabled = false;
                txt_tarih.Enabled = true;
                txt_belge_no.Enabled = true;
                txt_adet.Enabled = true;
                txt_fiyat.Enabled = true;
            }

        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (txt_irsaliye_no.Text == "" || txt_tarih.Text == "" || txt_belge_no.Text == "" || txt_urun_kodu.Text == "" || txt_adet.Text == "" || txt_fiyat.Text == "")
            {
                MessageBox.Show("Değişikliğin yapılacağı irsaliyeyi tablodan tıklayarak seçiniz.");
            }
            else
            {
                btn_kaydet.Visible = false;
                btn_degistir.Visible = true;
                txt_urun_kodu.Enabled = true;
                txt_irsaliye_no.Enabled = true;
                //ekleme olayı
                string yol = Veri_tabanı.veritabani_class.baglanti;
                SqlConnection baglan = new SqlConnection(yol);
                baglan.Open();
                SqlCommand komut = new SqlCommand("Update TALLYOUT Set DATE_=@p2, DOCNO=@p3, COUNT_=@p4, PRICE=@p5, PRCODE=@p6 where FICHENO=@p1", baglan);
                komut.Parameters.AddWithValue("@p1", txt_irsaliye_no.Text.Trim());
                komut.Parameters.AddWithValue("@p2", Convert.ToDateTime(txt_tarih.Text.Trim()));
                komut.Parameters.AddWithValue("@p3", txt_belge_no.Text.Trim());
                int adet = Convert.ToInt32(txt_adet.Text.Trim());
                komut.Parameters.AddWithValue("@p4", adet);
                komut.Parameters.AddWithValue("@p5", txt_fiyat.Text.Trim());
                komut.Parameters.AddWithValue("@p6", txt_urun_kodu.Text.Trim());
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Degişiklikler kaydedildi");
                this.tALLYOUTTableAdapter4.Fill(this.wARETRACKDataSet15.TALLYOUT);
                txt_urun_kodu.Text = "";
                txt_adet.Text = "";
                txt_irsaliye_no.Text = "";
                txt_tarih.Text = "";
                txt_belge_no.Text = "";
                txt_fiyat.Text = "";
            }

        }

      
        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (txt_irsaliye_no.Text == "" || txt_tarih.Text == "" || txt_belge_no.Text == "" || txt_urun_kodu.Text == "" || txt_adet.Text == "" || txt_fiyat.Text == "")
            {
                MessageBox.Show("Silme işleminin yapılacağı irsaliyeyi tablodan tıklayarak seçiniz.");
            }
            else
            {
                txt_urun_kodu.Enabled = true;
                string yol = Veri_tabanı.veritabani_class.baglanti;
                SqlConnection baglan = new SqlConnection(yol);
                baglan.Open();
                SqlCommand komut = new SqlCommand("Delete From TALLYOUT Where FICHENO=@p1", baglan);
                komut.Parameters.AddWithValue("@p1", txt_irsaliye_no.Text.Trim());
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("İrsaliye silindi.");
                this.tALLYOUTTableAdapter4.Fill(this.wARETRACKDataSet15.TALLYOUT);
                txt_urun_kodu.Text = "";
                txt_adet.Text = "";
                txt_irsaliye_no.Text = "";
                txt_tarih.Text = "";
                txt_belge_no.Text = "";
                txt_fiyat.Text = "";
                
                txt_irsaliye_no.Enabled = true;
                txt_tarih.Enabled = true;
                txt_belge_no.Enabled = true;
                txt_urun_kodu.Enabled = true;
                txt_adet.Enabled = true;
                txt_fiyat.Enabled = true;
            }
        }

        private void btn_ekle_Click_1(object sender, EventArgs e)
        {
            //ekle butonu
            if (txt_irsaliye_no.Text == "" || txt_tarih.Text == "" || txt_belge_no.Text == "" || txt_urun_kodu.Text == "" || txt_adet.Text == "" || txt_fiyat.Text == "")
            {
                MessageBox.Show("Lütfen değerleri boş bırakmayınız.");
            }
            else
            {
                txt_urun_kodu.Enabled = true;
                //ekleme olayi
                string yol = Veri_tabanı.veritabani_class.baglanti;
                SqlConnection baglan = new SqlConnection(yol);
                baglan.Open();
                SqlCommand komut1 = new SqlCommand("select * from PRODUCT where CODE=@p1", baglan);
                komut1.Parameters.AddWithValue("@p1", txt_urun_kodu.Text.Trim());
                SqlDataReader dr = komut1.ExecuteReader();
                if (dr.Read())
                {
                    //alternatif cozum 
                    dr.Close();
                    SqlCommand komut2 = new SqlCommand("select * from TALLYOUT where FICHENO=@p1", baglan);
                    komut2.Parameters.AddWithValue("@p1",txt_irsaliye_no.Text.Trim());
                    SqlDataReader dr1 = komut2.ExecuteReader();
                    if(dr1.Read())
                    {
                        MessageBox.Show("Aynı numaraya sahip başka bir irsaliye daha var. Lütfen farklı bir İrsaliye numarası giriniz");
                        dr1.Close();
                    }
                    else
                    {
                        dr1.Close();
                        dr.Close();
                        //ekleme olayı product tablosunda girilen urun kodu ile uyuşan bir urun varsa gerçekleşir.
                        SqlCommand komut = new SqlCommand("insert into TALLYOUT (FICHENO, DATE_, DOCNO, PRCODE, COUNT_, PRICE) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglan);
                        komut.Parameters.AddWithValue("@p1", txt_irsaliye_no.Text.Trim());
                        komut.Parameters.AddWithValue("@p2", Convert.ToDateTime(txt_tarih.Text.Trim()));
                        komut.Parameters.AddWithValue("@p3", txt_belge_no.Text.Trim());
                        komut.Parameters.AddWithValue("@p4", txt_urun_kodu.Text.Trim());
                        int adet = Convert.ToInt32(txt_adet.Text.Trim());
                        komut.Parameters.AddWithValue("@p5", adet);
                        komut.Parameters.AddWithValue("@p6", txt_fiyat.Text.Trim());
                        komut.ExecuteNonQuery();
                        baglan.Close();
                        MessageBox.Show("Satış irsaliyesi kaydedildi");
                        this.tALLYOUTTableAdapter4.Fill(this.wARETRACKDataSet15.TALLYOUT); 
                        txt_urun_kodu.Text = "";
                        txt_adet.Text = "";
                        txt_irsaliye_no.Text = "";
                        txt_tarih.Text = "";
                        txt_belge_no.Text = "";
                        txt_fiyat.Text = "";
                    }

                    // alternatif cozum bitis
                }
                else
                {
                    MessageBox.Show("Lütfen daha önce sisteme girişi yapılmış bir ürünün irsaliyesini giriniz");
                    baglan.Close();
                }

            }
        }

        private void frm_satış_irsaliyeleri_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wARETRACKDataSet15.TALLYOUT' table. You can move, or remove it, as needed.
            this.tALLYOUTTableAdapter4.Fill(this.wARETRACKDataSet15.TALLYOUT);
            




        }

        private void dtg_satış_irsaliyeleri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_irsaliye_no.Enabled = false;
            txt_tarih.Enabled = false;
            txt_belge_no.Enabled = false;
            txt_urun_kodu.Enabled = false;
            txt_adet.Enabled = false;
            txt_fiyat.Enabled = false;
            int secim = dtg_satış_irsaliyeleri.SelectedCells[0].RowIndex;
            txt_irsaliye_no.Text = dtg_satış_irsaliyeleri.Rows[secim].Cells[0].Value.ToString().Trim();
            txt_tarih.Text = Convert.ToDateTime(dtg_satış_irsaliyeleri.Rows[secim].Cells[1].Value.ToString().Trim()).ToShortDateString();
            txt_belge_no.Text = dtg_satış_irsaliyeleri.Rows[secim].Cells[2].Value.ToString().Trim();
            txt_urun_kodu.Text = dtg_satış_irsaliyeleri.Rows[secim].Cells[3].Value.ToString().Trim();
            txt_adet.Text = dtg_satış_irsaliyeleri.Rows[secim].Cells[4].Value.ToString().Trim();
            txt_fiyat.Text = dtg_satış_irsaliyeleri.Rows[secim].Cells[5].Value.ToString().Trim();
        }
    }
}
